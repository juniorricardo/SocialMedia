using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(i => new Post
            {
                PostId = i,
                UserId = i * 2,
                Description = $"Description {i}",
                Date = DateTime.Now,
                Image = $"https://migaleria.com/selectImage/id/{i}"
            });
            return posts;
        }
    }
}
