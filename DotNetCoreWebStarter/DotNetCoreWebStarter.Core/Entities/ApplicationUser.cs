using Microsoft.AspNetCore.Identity;

namespace DotNetCoreWebStarter.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? DisplayName { get; set; }
        public bool IsActive { get; set; } = true;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int UserId => Id;

        public string? PasswordPlainText { get; set; }
    }
}
