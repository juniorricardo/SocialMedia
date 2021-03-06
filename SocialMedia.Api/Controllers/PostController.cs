﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialMedia.Api.Response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService,
            ILogger<PostController> logger,
            IMapper mapper)
        {
            _postService = postService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET  api/post
        [HttpGet]
        public IActionResult GetPosts(int? userId,
            DateTime? date,
            string description)
        {
            _logger.LogInformation("Obteniendo los Posts.");
            var posts = _postService.GetPosts();
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            var response = new ApiResponse<IEnumerable<PostDto>>(postDtos);
            return Ok(response);
        }

        // GET  api/post/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            if (post == null)
            {
                _logger.LogWarning($"El Post con el Id {id}, no ha sido encontrado.");
                return NotFound();
            }

            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            await _postService.InsertPost(post);
            _logger.LogInformation($"Insertando una publicacion. {post}");

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,
            PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = _postService.UpdatePost(post);

            var response = new ApiResponse<bool>(result);

            _logger.LogInformation($"Actualizando una publicacion. {post}");

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}