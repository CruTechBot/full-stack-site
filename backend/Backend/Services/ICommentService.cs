using Database.Models;

namespace Backend.Services
{
    public interface ICommentService
    {
        bool AddComment(int userId, string commentText);

        IEnumerable<Comment> GetComments();

        bool DeleteComment(int userId, int commentId);
    }
}
