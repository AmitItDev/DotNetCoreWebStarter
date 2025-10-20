using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebStarter.Core.Models.Users
{
    public class UserManageViewModel
    {
        public int? UserId { get; set; }  // null → new user
        public string Name { get; set; }

        [Required, Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Role")]
        public int? RoleId { get; set; }

        public List<RoleItem> AvailableRoles { get; set; } = new();
    }

    public class RoleItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
