using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("holiday_requests")]
    public class HolidayRequest
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_institution_id")]
        public Guid UserInstitutionId { get; set; }
        [Column("requested_day")]
        public DateTime RequestedDay { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("allowed_at")]
        public DateTime AllowedAt { get; set; }
        [Column("declined_at")]
        public DateTime DeclinedAt { get; set; }
        [Column("message")]
        public string Message { get; set; }

    }
}
