namespace ReviewHub.Models
{
    public class SuggestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public int UserId { get; set; }
    }
}
