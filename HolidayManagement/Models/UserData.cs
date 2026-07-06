using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("user_data")]
    public class UserData
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("birth")]
        public DateTime Birth { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("children")]
        public int Children { get; set; } = 0;

    }
}
