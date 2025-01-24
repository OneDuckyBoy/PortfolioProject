using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class MoreResource
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>(); // Navigation property
        public ICollection<ResourceLink> Links { get; set; } = new List<ResourceLink>(); // New collection
    }
    public class ResourceLink
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int MoreResourceId { get; set; }
        public MoreResource MoreResource { get; set; } // Navigation property
    }

}
