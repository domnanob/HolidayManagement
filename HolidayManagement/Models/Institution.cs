using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("institutions")]
    public class Institution
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("institution_name")]
        public string Name { get; set; }

        [Column("center_id")]
        public Guid CenterID { get; set; }
    }
}
