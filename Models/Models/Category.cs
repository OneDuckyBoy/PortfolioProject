using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Category : BaseEntity
    {//

        [Required]
        [MaxLength(100), MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500), MinLength(3)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>(); // Navigation property
    }
}
