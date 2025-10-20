using DotNetCoreWebStarter.Core.Entities;

namespace DotNetCoreWebStarter.Core.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetMenusForUserAsync(ApplicationUser user);
    }

}
