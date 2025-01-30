using Microsoft.AspNetCore.Identity;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User : IdentityUser<int>
    {//


        //public int RoleId { get; set; } // Foreign key
        //public Role UserRole { get; set; } // Navigation property




        public int? ProfilePictureId { get; set; } // Foreign key
        public Image ProfilePicture { get; set; } // Navigation property

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<LikedComments> LikedComments { get; set; } = new List<LikedComments>();
        public ICollection<LikedProjects> LikedProjects { get; set; } = new List<LikedProjects>();

    }
}
