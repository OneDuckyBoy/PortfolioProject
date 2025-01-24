using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ShortDescription { get; set; } = string.Empty; // Optional summary

        public string Description { get; set; } = string.Empty; // Full description

        public int CategoryId { get; set; } // Foreign key
        public Category Category { get; set; } // Navigation property

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
