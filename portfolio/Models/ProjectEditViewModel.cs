using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Portfolio.Models
{
    public class ProjectEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ShortDescription { get; set; } = string.Empty; // Optional summary

        public string Description { get; set; } = string.Empty; // Full description

        [Required]
        public int CategoryId { get; set; } // Foreign key

       
        //public string CategoryName { get; set; } // To display the category name

        public int UserId { get; set; } // Foreign key

        public string UserEmail { get; set; } // To display the user email

        public int? ImageId { get; set; } // Foreign key (optional)

        public string ImagePath { get; set; } // To display the image path


        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
