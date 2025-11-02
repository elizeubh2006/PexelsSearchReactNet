using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PexelApiSearch.Application.SearchHistoryServices.Interfaces
{
    public interface ICreateSearchHistoryHandler
    {
        Task<bool> CreateHandleAsync(string query);
    }
}
