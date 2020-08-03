using System;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IRepository<Post> PostRespository => _postRepository ?? new BaseRespository<Post>(_context);

        public IRepository<User> UserRespository => _userRepository ?? new BaseRespository<User>(_context);

        public IRepository<Comment> CommentRespository => _commentRepository ?? new BaseRespository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
