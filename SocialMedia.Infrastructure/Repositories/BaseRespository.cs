using System;
using System.Collections.Generic;
using System.Text;
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
        private DbSet<T> _entities;
        public BaseRespository(SocialMediaContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
