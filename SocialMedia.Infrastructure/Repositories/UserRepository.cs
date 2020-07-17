using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;

        public UserRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId.Equals(id));
        }
    }
}
