using Microsoft.AspNetCore.Mvc;
using ReviewHub.Models;
using ReviewHub.Repositories.CommentRepository;

namespace ReviewHub.Controllers
{
    [ApiController]
    [Route("review-hub-api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository)); 
        }

        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<CommentModel>> GetAllComments()
        {
            return Ok(_commentRepository.GetAllCommentsAsync().Result);
        }

        [HttpGet("{commentId}", Name = "GetCommentById")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"commentId"})]
        public ActionResult<CommentModel> GetCommentById(int commentId) 
        {
            return _commentRepository.CommentExists(commentId) == false ?
                                NotFound("Comment not found!") :
                                Ok(_commentRepository.GetCommentByIdAsync(commentId).Result);
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            _commentRepository.AddComment(comment);
            return CreatedAtRoute("GetCommentById",
                                  new { commentId = comment.Id },
                                  comment);    
        }

        [HttpPut]
        public ActionResult UpdateComment(CommentModel comment)
        {
            if(_commentRepository.CommentExists(comment.Id) == false)
            {
                return NotFound("Comment not found!");
            }

            _commentRepository.UpdateComment(comment);
            return Ok("Comment updated!");
        }

        [HttpDelete]
        public ActionResult DeleteComment(int commentId)
        {
            if(_commentRepository.CommentExists(commentId) == false)
            {
                return NotFound("Comment not found!");
            }

            _commentRepository.DeleteComment(commentId);
            return Ok("Comment deleted!");
        }
    }
}
