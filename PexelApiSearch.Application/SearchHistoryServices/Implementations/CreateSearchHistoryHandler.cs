using PexelApiSearch.Application.SearchHistoryServices.Interfaces;
using PexelApiSearch.Domain.Entities;

namespace PexelApiSearch.Application.SearchHistoryServices.Implementations
{
    public class CreateSearchHistoryHandler : ICreateSearchHistoryHandler
    {
        private readonly ISearchHistoryRepository _repo;

        public CreateSearchHistoryHandler(ISearchHistoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> CreateHandleAsync(string searchQuery)
        {
            
            var entity = new SearchHistory
            {
                Id = Guid.NewGuid(),
                Query = searchQuery,
                SearchDate = DateTime.UtcNow
            };

            try
            {
                await _repo.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
