using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Core.Interfaces;
using DotNetCoreWebStarter.Core.Services;
using DotNetCoreWebStarter.Data;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace DotNetCoreWebStarter.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MenuService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<MenuItem>> GetMenusForUserAsync(ApplicationUser user)
        {
            try
            {
                var roles = await _userManager.GetRolesAsync(user);
                var menus = _context.MenuItems
                    .Include(m => m.Children) // Include children before filtering
                    .Where(m => m.IsActive && m.RoleMenus.Any(rm => roles.Contains(rm.Role!.Name)))
                    .OrderBy(m => m.Order)
                    .ToList();

                return menus;
            }
            catch (Exception ex)
            {
                ErrorLogService.Log(ex);
                throw;
            }
        }
    }

}
