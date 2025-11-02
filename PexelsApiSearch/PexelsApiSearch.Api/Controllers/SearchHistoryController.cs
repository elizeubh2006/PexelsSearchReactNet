using Microsoft.AspNetCore.Mvc;
using PexelApiSearch.Application.SearchHistoryServices.Implementations;
using PexelApiSearch.Application.SearchHistoryServices.Interfaces;

namespace PexelsApiSearch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IGetSearchHistoryPagedHandler _getHistory;

        public SearchHistoryController(IGetSearchHistoryPagedHandler getHistory)
        {
            _getHistory = getHistory;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchHistory(string queryText, int page = 1, int pageSize = 10)
        {
            var result = await _getHistory.HandleAsync(queryText, page, pageSize);

            return Ok(new
            {
                Total = result.Total,
                Page = page,
                PageSize = pageSize,
                Items = result.Items
            });
        }
    }
}
