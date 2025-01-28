using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{//
    public class LikedComments : BaseEntity
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
