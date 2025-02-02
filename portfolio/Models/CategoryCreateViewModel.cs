using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class CategoryCreateViewModel
    {
        [Required]
        [MaxLength(100), MinLength(3)]
        public string Name { get; set; }
        [MaxLength(500), MinLength(3)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }
    }
}
