using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRespository.GetAll();
        }
        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRespository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRespository.GetById(post.UserId);
            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }
            if (post.Description.Contains("sexo"))
            {
                throw new Exception("Contenido no permitido.");
            }

            await _unitOfWork.PostRespository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRespository.Update(post);
            return true;
        }
        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRespository.Delete(id);
            return true;
        }
    }
}
