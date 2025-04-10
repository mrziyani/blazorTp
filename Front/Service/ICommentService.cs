using Front.Models;
namespace Front.Service
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<bool> CreateCommentAsync(CreateComment comment);
        Task<List<CommentWithUser>> GetCommentsWithUserAsync(int postId);
    }
}
