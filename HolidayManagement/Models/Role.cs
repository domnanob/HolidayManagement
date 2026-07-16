using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("role_name")]
        public string Name { get; set; }

        [Column("role_group_id")]
        public Guid GroupId { get; set; }
    }
}
