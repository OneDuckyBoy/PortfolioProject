﻿using Models.Models;

namespace Portfolio.Models
{
    public class Comment : BaseEntity
    {//
		
		private string text;

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

        public int ProjectId { get; set; } // Foreign key
        public Project Project { get; set; } // Navigation property
        public int UserId { get; set; } // Foreign key
        public User User { get; set; } // Navigation property
        public int? ImageId { get; set; } // Foreign key (optional)
        public Image Image { get; set; } // Navigation property

        public DateTime DateAdded { get; set; }


        public ICollection<LikedComments> LikedComments { get; set; } = new List<LikedComments>();
    }
}
