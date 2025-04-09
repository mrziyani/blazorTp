using Front.Models;
namespace Front.Service
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
