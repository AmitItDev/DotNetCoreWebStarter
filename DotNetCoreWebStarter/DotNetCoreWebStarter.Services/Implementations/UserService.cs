using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Interfaces;
using DotNetCoreWebStarter.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Dynamic.Core;

namespace DotNetCoreWebStarter.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public async Task<List<ApplicationRole>> GetRolesAsync()
        {
            return await _repo.Roles.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<UserResponse> GetUsersAsync(UserFilterRequest filter)
        {
            var query = _repo.Users;

            // Search filter
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(u => u.UserName.Contains(filter.Search) ||
                                         u.Email.Contains(filter.Search));
            }

            // Role filter
            if (filter.Roles != null && filter.Roles.Any() && !filter.Roles.Contains("All"))
            {
                var roleUserIds = await _repo.GetUserIdsByRolesAsync(filter.Roles);
                query = query.Where(u => roleUserIds.Contains(u.Id));
            }

            // Status filter (multi-select safe)
            if (filter.Status != null && filter.Status.Any() && !filter.Status.Contains("All"))
            {
                var now = DateTimeOffset.Now;
                query = query.Where(u =>
                    (filter.Status.Contains("Active") && (u.LockoutEnd == null || u.LockoutEnd < now)) ||
                    (filter.Status.Contains("Inactive") && u.LockoutEnd != null && u.LockoutEnd >= now)
                );
            }

            if (!string.IsNullOrEmpty(filter.SortField))
            {
                var sort = $"{filter.SortField} {filter.SortDir}";
                query = query.OrderBy(sort);  // Requires System.Linq.Dynamic.Core
            }
            else
            {
                query = query.OrderBy(u => u.UserName); // fallback
            }


            // Total count for pagination
            var totalCount = await query.CountAsync();
            //var sql = query.ToQueryString();
            //Console.WriteLine(sql);
            // Paging + projection
            var users = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(u => new UserDto
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Status = (u.LockoutEnd == null || u.LockoutEnd < DateTimeOffset.Now) ? "Active" : "Inactive"
                })
                .ToListAsync();

            return new UserResponse
            {
                total_count = totalCount,
                data = users,
                last_page = (int)Math.Ceiling((double)totalCount / filter.PageSize)
            };
        }

        public async Task<UserManageViewModel> GetUserForManageAsync(int? id)
        {
            var model = new UserManageViewModel
            {
                AvailableRoles = (await _repo.GetAllRolesAsync())
                    .Select(r => new RoleItem { Id = r.Id, Name = r.Name! })
                    .ToList()
            };

            if (id.HasValue)
            {
                var user = await _repo.GetUserByIdAsync(id.Value);
                if (user != null)
                {
                    model.UserId = user.Id;
                    model.UserName = user.UserName;
                    model.Name = user.DisplayName;
                    model.Email = user.Email!;
                    var roles = await _repo.GetUserRolesAsync(user);
                    var currentRole = (await _repo.GetAllRolesAsync())
                        .FirstOrDefault(r => roles.Contains(r.Name!));
                    model.RoleId = currentRole?.Id;
                }
            }

            return model;
        }

        public async Task<Tuple<bool, string>> ManageUserAsync(UserManageViewModel model)
        {
            ApplicationUser? user;

            bool savePlainPassword = _configuration.GetValue<bool>("AppSettings:SavePlainPassword");
            if (model.UserId.HasValue)
            {
                user = await _repo.GetUserByIdAsync(model.UserId.Value);
                if (user == null)
                    return Tuple.Create(false, "User not found");

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.DisplayName = model.Name;
                if (savePlainPassword)
                {
                    user.PasswordPlainText = model.Password;
                }
                await _repo.UpdateUserAsync(user);

                await _repo.RemoveUserRolesAsync(user);
                if (model.RoleId.HasValue)
                {
                    var role = await _repo.GetRoleByIdAsync(model.RoleId.Value);
                    if (role != null)
                        await _repo.AddUserToRoleAsync(user, role.Name!);
                }

                if (!string.IsNullOrEmpty(model.Password))
                    await _repo.ResetPasswordAsync(user, model.Password);

                return Tuple.Create(true, "");
            }
            else
            {
                user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    DisplayName = model.Name,
                    PasswordPlainText = savePlainPassword ? model.Password : ""
                };

                IdentityResult result = await _repo.CreateUserAsync(user, model.Password!);
                if (!result.Succeeded)
                    return Tuple.Create(false, string.Join(", ", result.Errors.Select(e => e.Description)));

                if (model.RoleId.HasValue)
                {
                    var role = await _repo.GetRoleByIdAsync(model.RoleId.Value);
                    if (role != null)
                        await _repo.AddUserToRoleAsync(user, role.Name!);
                }

                return Tuple.Create(true, "");
            }
        }

        public async Task<Tuple<bool, string>> DeleteUserAsync(int userId)
        {
            var user = await _repo.GetUserByIdAsync(userId);
            if (user == null)
                return Tuple.Create(false, "User not found");

            return Tuple.Create(await _repo.DeleteUserAsync(userId), "");
        }

    }
}
