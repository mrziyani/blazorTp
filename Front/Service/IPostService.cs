using Front.Models;

namespace Front.Service
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostById(int id);
        Task<PostDto> GetPostWithCommentsAsync(int id);
    }
}
