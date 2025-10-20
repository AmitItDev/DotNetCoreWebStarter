using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Models.Users;

namespace DotNetCoreWebStarter.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationRole>> GetRolesAsync();
        Task<UserResponse> GetUsersAsync(UserFilterRequest filter);
        Task<UserManageViewModel> GetUserForManageAsync(int? id);
        Task<Tuple<bool, string>> ManageUserAsync(UserManageViewModel model);
        Task<Tuple<bool, string>> DeleteUserAsync(int userId);
    }
}
