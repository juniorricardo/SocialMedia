using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRespository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        protected readonly DbSet<T> Entities;

        public BaseRespository(SocialMediaContext context)
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await Entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            Entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _context.Remove(entity);
        }
    }
}

