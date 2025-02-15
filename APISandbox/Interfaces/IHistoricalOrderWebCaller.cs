using APISandbox.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISandbox.Interfaces
{
    public interface IHistoricalOrderWebCaller
    {
        Task<List<HistoricalOrder>> GetOrderHistory(HistoricalOrderWebCallerParams parameters);

    }
}
