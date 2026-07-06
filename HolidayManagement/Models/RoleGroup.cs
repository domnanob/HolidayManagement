using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("role_groups")]
    public class RoleGroup
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        
        [Column("permission_level")]
        public int PermissionLevel { get; set; }
        
        [Column("group_name")]
        public string Name { get; set; }
    }
}
