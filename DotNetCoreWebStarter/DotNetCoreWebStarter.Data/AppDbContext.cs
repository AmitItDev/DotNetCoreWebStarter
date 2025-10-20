using DotNetCoreWebStarter.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebStarter.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }

}
