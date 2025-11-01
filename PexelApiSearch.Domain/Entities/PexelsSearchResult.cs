namespace PexelApiSearch.Domain.Entities
{
    public class PexelsSearchResult
    {
        public DateTime SearchDate { get; set; }
        public double ElapsedSeconds { get; set; }
        public string OriginalUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Author { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
