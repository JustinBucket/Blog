using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data
{
    public interface IRepository
    {
        void Add<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Post>> GetMusicPosts();
        Task<IEnumerable<Post>> GetVideoGamePosts();
        Task<IEnumerable<Post>> GetMoviePosts();
        Task<IEnumerable<Post>> GetBookPosts();
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int postId);
    }
}