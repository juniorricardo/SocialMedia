using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities {
    public sealed class Post : BaseEntity {
        public Post () => Comments = new HashSet<Comment> ();

        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}