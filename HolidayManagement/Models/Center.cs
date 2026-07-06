using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("centers")]
    public class Center
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("center_name")]
        public string Name { get; set; }
    }
}
