using DotNetCoreWebStarter.Core.Entities;
using DotNetCoreWebStarter.Data;
using DotNetCoreWebStarter.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DotNetCoreWebStarter.Web.Tests
{
    public class MenuServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);

            // Seed data
            var adminRole = new ApplicationRole { Id = 1, Name = "Admin" };
            var userRole = new ApplicationRole { Id = 2, Name = "User" };
            context.Roles.AddRange(adminRole, userRole);

            var jobMenu = new MenuItem { MenuId = 1, Title = "Jobs", IsActive = true, Order = 1 };
            var userMenu = new MenuItem { MenuId = 2, Title = "Users", IsActive = true, Order = 2 };
            context.MenuItems.AddRange(jobMenu, userMenu);

            context.RoleMenus.AddRange(
                new RoleMenu { RoleId = 1, MenuId = 1 },
                new RoleMenu { RoleId = 1, MenuId = 2 },
                new RoleMenu { RoleId = 2, MenuId = 1 }
            );

            context.SaveChanges();
            return context;
        }
        private UserManager<ApplicationUser> GetMockUserManager()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            var mgr = new UserManager<ApplicationUser>(
                store.Object,
                null, // IOptions<IdentityOptions>
                new PasswordHasher<ApplicationUser>(),
                new IUserValidator<ApplicationUser>[0],
                new IPasswordValidator<ApplicationUser>[0],
                null, // ILookupNormalizer
                null, // IdentityErrorDescriber
                null, // IServiceProvider
                null  // ILogger<UserManager<ApplicationUser>>
            );
            return mgr;
        }


        [Fact]
        public async Task GetMenusForUser_AdminUser_ReturnsAllMenus()
        {
            var context = GetDbContext();
            var menuService = new MenuService(context, GetMockUserManager());

            var user = new ApplicationUser { Id = 1, UserName = "admin" };
            var roles = new List<string> { "Admin" };

            var menus = await menuService.GetMenusForUserAsync(user);

            Assert.Equal(2, menus.Count); // Jobs + Users
        }

        [Fact]
        public async Task GetMenusForUser_NormalUser_ReturnsJobsOnly()
        {
            var context = GetDbContext();
            var menuService = new MenuService(context, GetMockUserManager());

            var user = new ApplicationUser { Id = 2, UserName = "user" };
            var roles = new List<string> { "User" };

            var menus = await menuService.GetMenusForUserAsync(user);

            Assert.Single(menus);
            Assert.Equal("Jobs", menus.First().Title);
        }
    }
}