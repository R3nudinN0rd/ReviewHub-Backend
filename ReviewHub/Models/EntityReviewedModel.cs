namespace ReviewHub.Models
{
    public class EntityReviewedModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public byte[]? Image { get; set; }
        public int EntityTypeId { get; set; }
    }
}
