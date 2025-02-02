using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class CreateImageModel
    {
        [Required]
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }
    }
}
