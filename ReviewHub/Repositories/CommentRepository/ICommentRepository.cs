using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        public Task<CommentModel> GetCommentByIdAsync(int commentId);
        public Task<IEnumerable<CommentModel>> GetAllCommentsAsync();
        public CommentModel AddComment(CommentModel comment);
        public void UpdateComment(CommentModel comment);
        public void DeleteComment(int commentId);
        public bool CommentExists(int commentId);
    }
}
