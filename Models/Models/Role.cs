using Microsoft.AspNetCore.Identity;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Role : IdentityRole<int>
    {//



        //[Required]
        //public RoleType RoleType { get; set; }
    }
    public enum RoleType
    {
        Admin,
        User
    }
}
