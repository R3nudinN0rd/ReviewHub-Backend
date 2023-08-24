using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Entities;
using ReviewHub.Models;

namespace ReviewHub.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ReviewHubContext _reviewHubContext;
        private readonly IMapper _mapper;
        public CommentRepository(ReviewHubContext reviewHubContext, IMapper mapper)
        {
            _reviewHubContext = reviewHubContext ?? throw new ArgumentNullException(nameof(reviewHubContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public CommentModel AddComment(CommentModel comment)
        {
            try
            {
                _reviewHubContext.Comments.Add(
                    _mapper.Map<Comment>(comment)
                    );
                return comment;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public bool CommentExists(int commentId)
        {
            var comment = _reviewHubContext.Comments.FirstOrDefault(c => c.Id == commentId);
            return comment != null;
        }

        public void DeleteComment(int commentId)
        {
            var commentToDelete = _reviewHubContext.Comments.FirstOrDefault(comment => comment.Id == commentId);
            try
            {
                _reviewHubContext.Comments.Remove(commentToDelete);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                _reviewHubContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<CommentModel>> GetAllCommentsAsync()
        {
            return _mapper.Map<IEnumerable<CommentModel>>(
                        await _reviewHubContext.Comments.ToListAsync()
                    );
        }

        public async Task<CommentModel> GetCommentByIdAsync(int commentId)
        {
            return _mapper.Map<CommentModel>(
                        await _reviewHubContext.Comments.FirstOrDefaultAsync(comment => comment.Id == commentId)
                    );
        }

        public void UpdateComment(CommentModel comment)
        {
            try
            {
                var existingComment = _reviewHubContext.Comments.FirstOrDefault(c => c.Id == comment.Id);
                    _reviewHubContext.Comments.Update(
                            _mapper.Map(comment,existingComment)
                        );
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
