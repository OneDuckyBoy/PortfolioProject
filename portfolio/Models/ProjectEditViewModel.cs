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
        public string ShortDescription { get; set; } = string.Empty; 

        public string Description { get; set; } = string.Empty; 

        [Required]
        public int CategoryId { get; set; } 

       
        

        public int UserId { get; set; } 

        public string UserEmail { get; set; }

        public int? ImageId { get; set; } 

        public string ImagePath { get; set; } 


        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
