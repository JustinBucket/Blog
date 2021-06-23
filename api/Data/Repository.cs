using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Post>> GetBookPosts()
        {
            var bookPosts = await _context.Posts.Where(x => x.Type == MediaType.Book).ToListAsync();

            return bookPosts;
        }

        public async Task<IEnumerable<Post>> GetMoviePosts()
        {
            var moviePosts = await _context.Posts.Where(x => x.Type == MediaType.Movie).ToListAsync();

            return moviePosts;
        }

        public async Task<IEnumerable<Post>> GetMusicPosts()
        {
            var musicPosts = await _context.Posts.Where(x => x.Type == MediaType.Music).ToListAsync();

            return musicPosts;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<IEnumerable<Post>> GetVideoGamePosts()
        {
            var videoGamePosts = await _context.Posts.Where(x => x.Type == MediaType.VideoGame).ToListAsync();

            return videoGamePosts;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}