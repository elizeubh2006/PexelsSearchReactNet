using PexelApiSearch.Application.SearchHistoryServices.Interfaces;
using PexelApiSearch.Domain.Entities;

namespace PexelApiSearch.Application.SearchHistoryServices.Implementations
{
    public class GetSearchHistoryPagedHandler : IGetSearchHistoryPagedHandler
    {
        private readonly ISearchHistoryRepository _repo;

        public GetSearchHistoryPagedHandler(ISearchHistoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<(IEnumerable<SearchHistory> Items, int Total)> HandleAsync(int page, int pageSize)
        {
            return await _repo.GetPagedAsync(page, pageSize);
        }
    }
}
