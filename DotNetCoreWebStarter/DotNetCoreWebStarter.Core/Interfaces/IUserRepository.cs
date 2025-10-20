using DotNetCoreWebStarter.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace DotNetCoreWebStarter.Core.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> Users { get; }
        IQueryable<ApplicationRole> Roles { get; }
        IQueryable<IdentityUserRole<int>> UserRoles { get; }
        Task<List<int>> GetUserIdsByRolesAsync(List<string> roleNames);
        Task<List<ApplicationRole>> GetAllRolesAsync();
        Task<ApplicationUser?> GetUserByIdAsync(int id);
        Task<List<string>> GetUserRolesAsync(ApplicationUser user);
        Task UpdateUserAsync(ApplicationUser user);
        Task RemoveUserRolesAsync(ApplicationUser user);
        Task<ApplicationRole?> GetRoleByIdAsync(int id);
        Task AddUserToRoleAsync(ApplicationUser user, string roleName);
        Task ResetPasswordAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<bool> DeleteUserAsync(int userId);
    }
}
