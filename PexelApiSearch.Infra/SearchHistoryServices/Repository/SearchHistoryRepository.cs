using Dapper;
using PexelApiSearch.Application.SearchHistoryServices.Interfaces;
using PexelApiSearch.Domain.Entities;
using PexelApiSearch.Infra.Database.Dapper;
using PexelApiSearch.Infra.Database.SearchHistory.Queries;

namespace PexelApiSearch.Infra.SearchHistoryServices.Repository
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly DapperContext _context;

        public SearchHistoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SearchHistory history)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(SearchHistoryQueries.Insert, history);
        }

        public async Task<(IEnumerable<SearchHistory> Items, int Total)> GetPagedAsync(string queryText, int page, int pageSize)
        {
            using var connection = _context.CreateConnection();

            var offset = (page - 1) * pageSize;

            var items = await connection.QueryAsync<SearchHistory>(
                SearchHistoryQueries.SelectPaged,
                new {QueryText  = queryText,  PageSize = pageSize, Offset = offset });

            var total = await connection.ExecuteScalarAsync<int>(SearchHistoryQueries.CountAll);

            return (items, total);
        }
    }
}
