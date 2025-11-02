using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PexelApiSearch.Infra.Database.SearchHistory.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
