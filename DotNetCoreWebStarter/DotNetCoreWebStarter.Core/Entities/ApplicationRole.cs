using Microsoft.AspNetCore.Identity;

namespace DotNetCoreWebStarter.Core.Entities
{
    public class ApplicationRole : IdentityRole<int>  
    {
        public string? Description { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int RoleId => Id;
    }
}
