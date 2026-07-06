using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolidayManagement.Models
{
    [Table("user_institutions")]
    public class UserInstitution
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("institution_id")]
        public Guid InstitutionId { get; set; }

        [Column("role_id")]
        public Guid RoleId { get; set; }
    }
}
