using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public sealed class User : BaseEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirthday { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
