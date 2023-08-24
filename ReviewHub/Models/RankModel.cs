namespace ReviewHub.Models
{
    public class RankModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinAmountOfPoints { get; set; }
        public int MaxAmountOfPoints { get; set; }
    }
}
