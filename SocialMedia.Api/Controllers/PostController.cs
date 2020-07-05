using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostRepository postRepository,
                              ILogger<PostController> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        // GET  api/post
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            _logger.LogInformation("Obteniendo los Posts.");
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }

        // GET  api/post/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            if (post == null)
            {
                _logger.LogWarning($"El Post con el Id {id}, no ha sido encontrado.");
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _postRepository.InsertPost(post);
            _logger.LogInformation($"Insertando una publicacion. {post}");
            return Ok(post);
        }
    }
}