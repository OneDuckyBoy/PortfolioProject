using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Models
{
    public class CommentIndexFilterView 
    {
        public SelectList Projects { get; set; }

        public int? ProjectId { get; set; }
        public SelectList Users { get; set; }
        public int? UserId { get; set; }

        public string? Content { get; set; } = string.Empty;

        public IEnumerable<Comment> Comments{ get; set; }

    }
}
