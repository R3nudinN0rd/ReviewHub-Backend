namespace ReviewHub.Models
{
    public class ReviewAttachmentsModel
    {
        public int Id { get; set; }
        public byte[]? Attachement { get; set; }
        public int ReviewId { get; set; }
    }
}
