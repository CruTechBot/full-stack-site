using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly DatabaseContext _context;

        public CommentService(DatabaseContext context)
        {
            _context = context;
        }

        public bool AddComment(int userId, string commentText)
        {
            var comment = new Comment
            {
                UserId = userId,
                Text = commentText,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Comments.Add(comment);
                
            _context.SaveChanges();

            return true;
        }

        public bool DeleteComment(int userId, int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                return false;
            }

            if (comment.UserId != userId)
            {
                return false;
            }

            _context.Comments.Remove(comment);

            _context.SaveChanges();

            return true;

        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.Include(c => c.User).OrderByDescending(c => c.CreatedAt);
        }
    }
}
