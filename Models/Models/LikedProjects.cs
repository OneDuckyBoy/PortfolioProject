using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{//
    public class LikedProjects : BaseEntity
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
