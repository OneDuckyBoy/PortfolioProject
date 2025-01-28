using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{//
    public class Image : BaseEntity
    {


        [Required]
        public string Path { get; set; }
    }
}
