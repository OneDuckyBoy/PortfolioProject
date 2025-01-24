using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public RoleType RoleType { get; set; }
    }
    public enum RoleType
    {
        Admin,
        User
    }
}
