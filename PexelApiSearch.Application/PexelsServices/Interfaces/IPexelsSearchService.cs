using PexelApiSearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PexelApiSearch.Application.PexelsServices.Interfaces
{
    public interface IPexelsSearchService
    {
        Task<IEnumerable<PexelsSearchResult>> PhotoSearch(string query, int page, int per_page);
    }
}
