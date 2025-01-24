using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>(); // Navigation property
    }
}
