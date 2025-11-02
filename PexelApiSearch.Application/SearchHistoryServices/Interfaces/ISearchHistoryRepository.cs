using PexelApiSearch.Domain.Entities;

namespace PexelApiSearch.Application.SearchHistoryServices.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task AddAsync(SearchHistory history);
        Task<(IEnumerable<SearchHistory> Items, int Total)> GetPagedAsync(int page, int pageSize);
    }
}
