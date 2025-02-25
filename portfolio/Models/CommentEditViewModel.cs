using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class CommentEditViewModel
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [BindNever]
    public SelectList Projects { get; set; }
}
