namespace PexelApiSearch.Domain.Entities
{
    public class SearchHistory
    {
        public Guid Id { get; set; }
        public string Query { get; set; }
        public DateTime SearchDate { get; set; }

    }
}
