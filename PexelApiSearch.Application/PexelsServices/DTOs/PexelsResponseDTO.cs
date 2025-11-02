using System.Text.Json.Serialization;

namespace PexelApiSearch.Application.PexelsServices.DTOs
{
    public class PexelsResponseDto
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("photos")]
        public List<PexelsPhoto> Photos { get; set; } = new();

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("next_page")]
        public string? NextPage { get; set; }
    }

    public class PexelsPhoto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("photographer")]
        public string Photographer { get; set; }

        [JsonPropertyName("photographer_url")]
        public string PhotographerUrl { get; set; }

        [JsonPropertyName("photographer_id")]
        public decimal PhotographerId { get; set; }

        [JsonPropertyName("avg_color")]
        public string AvgColor { get; set; }

        [JsonPropertyName("src")]
        public PexelsPhotoSrc Src { get; set; }

        [JsonPropertyName("liked")]
        public bool Liked { get; set; }

        [JsonPropertyName("alt")]
        public string Alt { get; set; }
    }

    public class PexelsPhotoSrc
    {
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("large2x")]
        public string Large2x { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("portrait")]
        public string Portrait { get; set; }

        [JsonPropertyName("landscape")]
        public string Landscape { get; set; }

        [JsonPropertyName("tiny")]
        public string Tiny { get; set; }
    }
}
