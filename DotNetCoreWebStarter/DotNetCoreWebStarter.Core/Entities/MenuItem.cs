
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebStarter.Core.Entities
{
    public class MenuItem
    {
        [Key]
        public int MenuId { get; set; }     

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Url { get; set; }
        public string? Icon { get; set; }

        public int? ParentMenuId { get; set; }
        [ForeignKey("ParentMenuId")]
        public MenuItem? Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();

        public int Order { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
    }
}
