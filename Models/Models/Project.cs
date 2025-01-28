using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project : BaseEntity
    {//

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ShortDescription { get; set; } = string.Empty; // Optional summary

        public string Description { get; set; } = string.Empty; // Full description

        public int CategoryId { get; set; } // Foreign key
        public Category Category { get; set; } // Navigation property

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


        public ICollection<LikedProjects> LikedProjects { get; set; } = new List<LikedProjects>();


        public int UserId { get; set; }
        public User User { get; set; }


        public int? ImageId { get; set; } // Foreign key (optional)
        public Image Image { get; set; } // Navigation property
    }
}
