using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostRepository postRepository,
                              ILogger<PostController> logger,
                              IMapper mapper)
        {
            _postRepository = postRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET  api/postDto
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            _logger.LogInformation("Obteniendo los Posts.");
            var posts = await _postRepository.GetPosts();

            var postDtos = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return Ok(postDtos);
        }

        // GET  api/postDto/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            if (post == null)
            {
                _logger.LogWarning($"El Post con el Id {id}, no ha sido encontrado.");
                return NotFound();
            }
            var postDto = _mapper.Map<PostDTO>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            await _postRepository.InsertPost(post);
            _logger.LogInformation($"Insertando una publicacion. {post}");
            return Ok(postDto);
        }
    }
}