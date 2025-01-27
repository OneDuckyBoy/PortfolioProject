using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Role : BaseEntity
    {//

        [Required]
        public RoleType RoleType { get; set; }
    }
    public enum RoleType
    {
        Admin,
        User
    }
}
