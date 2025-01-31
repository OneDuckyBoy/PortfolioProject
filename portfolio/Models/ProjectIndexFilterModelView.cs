using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Models
{
    public class ProjectIndexFilterModelView
    {
        public string? Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; } = string.Empty;
        public int? CategoryId { get; set; }


        public SelectList Categories { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
