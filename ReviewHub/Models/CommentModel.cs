namespace ReviewHub.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ReviewId { get; set; }
    }
}
