using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; } // Foreign key
        public Role UserRole { get; set; } // Navigation property

        public int? ProfilePictureId { get; set; } // Foreign key
        public Image ProfilePicture { get; set; } // Navigation property

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;


    }
}
