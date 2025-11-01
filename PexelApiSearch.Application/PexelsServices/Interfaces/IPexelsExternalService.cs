using PexelApiSearch.Application.PexelsServices.DTOs;

namespace PexelApiSearch.Application.PexelsServices.Interfaces
{
    public interface IPexelsExternalService
    {
        Task<PexelsResponseDto?> SearchPhotosAsync(string query, int per_page, int page);
    }
}
