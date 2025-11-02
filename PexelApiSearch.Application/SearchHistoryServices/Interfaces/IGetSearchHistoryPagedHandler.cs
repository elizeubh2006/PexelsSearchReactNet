using PexelApiSearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PexelApiSearch.Application.SearchHistoryServices.Interfaces
{
    public interface IGetSearchHistoryPagedHandler
    {
        Task<(IEnumerable<SearchHistory> Items, int Total)> HandleAsync(int page, int pageSize);
    }
}
