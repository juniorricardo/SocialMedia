using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context) => _context = context;

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }
        public async Task<Post> GetPost(int id)
        {
            try
            {
                var post = await _context.Posts.FirstAsync(e => e.PostId == id);
                return post;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var curretPost = await GetPost(post.PostId);

            curretPost.Date = post.Date;
            curretPost.Description = post.Description;
            curretPost.Image = post.Image;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int idPost)
        {
            var currentPost = await GetPost(idPost);

            _context.Posts.Remove(currentPost);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
