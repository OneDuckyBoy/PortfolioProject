using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ProjectCreateViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string ShortDescription { get; set; } = string.Empty; 

        public string Description { get; set; } = string.Empty; 

        [Required]
        public IFormFile Image { get; set; } 

        [Required]
        public int CategoryId { get; set; } 

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    }
}
