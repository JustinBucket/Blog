using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data;
using Blog.DTOs;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public PostController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repo.GetPosts();

            var outPosts = _mapper.Map<IEnumerable<OutboundPostDto>>(posts);

            return Ok(outPosts);
        }

        [HttpGet("movie")]
        public async Task<IActionResult> GetMoviePosts()
        {
            var posts = await _repo.GetMoviePosts();

            var outPosts = _mapper.Map<IEnumerable<OutboundPostDto>>(posts);

            return Ok(outPosts);
        }

        [HttpGet("music")]
        public async Task<IActionResult> GetMusicPosts()
        {
            var posts = await _repo.GetMusicPosts();

            var outPosts = _mapper.Map<IEnumerable<OutboundPostDto>>(posts);

            return Ok(outPosts);
        }

        [HttpGet("videogame")]
        public async Task<IActionResult> GetVideoGamePosts()
        {
            var posts = await _repo.GetVideoGamePosts();

            var outPosts = _mapper.Map<IEnumerable<OutboundPostDto>>(posts);

            return Ok(outPosts);
        }

        [HttpGet("book")]
        public async Task<IActionResult> GetBookPosts()
        {
            var posts = await _repo.GetBookPosts();

            var outPosts = _mapper.Map<IEnumerable<OutboundPostDto>>(posts);

            return Ok(outPosts);
        }

        [HttpGet("{postId}", Name="GetPost")]
        public async Task<IActionResult> GetPost(int postId)
        {
            var post = await _repo.GetPost(postId);

            var outPosts = _mapper.Map<OutboundPostDto>(post);

            return Ok(outPosts);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPost([FromForm] InboundPostDto dto)
        {
            var post = new Post()
            {
                Title = dto.Title,
                Paragraphs = dto.Paragraphs,
                CreationDate = DateTime.Now,
                Type = Enum.Parse<MediaType>(dto.MediaTypeString)
            };

            string filePath;

            try
            {
                filePath =  await SaveFile(dto.ImageFile);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);                
            }

            post.ImagePath = filePath;

            _repo.Add(post);

            if (!await _repo.SaveAll())
            {
                // should delete the photo in that case
                System.IO.File.Delete(post.ImagePath);
                return BadRequest("Failed to upload post");
            }

            return CreatedAtRoute("GetPost", new { postId = post.Id }, post);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var folderPath = Path.Combine(Environment.CurrentDirectory, "Photos");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, file.FileName);

            if (System.IO.File.Exists(filePath))
            {
                throw new ArgumentException("file already exists");
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                stream.Position = 0;
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}