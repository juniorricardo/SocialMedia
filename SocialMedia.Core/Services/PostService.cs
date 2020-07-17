using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository,
                           IUserRepository userRespository)
        {
            _postRepository = postRepository;
            _userRepository = userRespository;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }
        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }

        public async Task InsertPost(Post post)
        {
            var user = await _userRepository.GetUser(post.UserId);
            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }
            if (post.Description.Contains("sexo"))
            {
                throw new Exception("Contenido no permitido.");
            }

            await _postRepository.InsertPost(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }
    }
}
