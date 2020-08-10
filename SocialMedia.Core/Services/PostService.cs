using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
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

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.PostRespository.GetAll();
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
                throw new BusinessException("El usuario no existe.");
            }

            var userPosts = await _unitOfWork.PostRespository.GetPostsByUser(user.Id);
            if (userPosts.Count() < 10)
            {
                var lastPost = userPosts.OrderBy(u => u.Date).LastOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("Usted no esta habilitado para publicar.");
                }
            }
            if (post.Description.Contains("sexo"))
            {
                throw new BusinessException("Contenido no permitido.");
            }

            await _unitOfWork.PostRespository.Add(post);
            await _unitOfWork.SaveChangesAsync();

        }

        public bool UpdatePost(Post post)
        {
            _unitOfWork.PostRespository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRespository.Delete(id);
            return true;
        }
    }
}
