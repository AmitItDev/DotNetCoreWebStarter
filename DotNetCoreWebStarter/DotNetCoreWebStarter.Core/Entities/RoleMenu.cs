using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNetCoreWebStarter.Core.Entities
{
    public class RoleMenu
    {
        [Key]
        public int RoleMenuId { get; set; } 

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public ApplicationRole? Role { get; set; }

        public int MenuId { get; set; }  
        [ForeignKey("MenuId")]
        public MenuItem? MenuItem { get; set; }
    }
}
