using System;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> PostRespository { get; }
        IRepository<User> UserRespository { get; }
        IRepository<Comment> CommentRespository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
