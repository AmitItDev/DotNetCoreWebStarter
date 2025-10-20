using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Interfaces;
using DotNetCoreWebStarter.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebStarter.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserRepository(AppDbContext context, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IQueryable<ApplicationUser> Users => _context.Users.AsNoTracking();
        public IQueryable<ApplicationRole> Roles => _context.Roles.AsNoTracking();
        public IQueryable<IdentityUserRole<int>> UserRoles => _context.UserRoles.AsNoTracking();

        public async Task<List<int>> GetUserIdsByRolesAsync(List<string> roleNames)
        {
            return await (from ur in UserRoles
                          join r in Roles on ur.RoleId equals r.Id
                          where roleNames.Contains(r.Name)
                          select ur.UserId) 
                         .Distinct()
                         .ToListAsync();
        }

        public async Task<List<ApplicationRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task ResetPasswordAsync(ApplicationUser user, string password)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserRolesAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Any())
                await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<ApplicationRole?> GetRoleByIdAsync(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

    }
}
