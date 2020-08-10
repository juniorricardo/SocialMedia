using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : BaseRespository<Post>, IPostRepository
    {
        public PostRepository(SocialMediaContext context)
            : base(context) { }

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entities.Where(post => 
                                    post.UserId.Equals(userId))
                                  .ToListAsync();
        }
    }
}
