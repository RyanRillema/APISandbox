using APISandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.Interfaces
{
    public interface IHistoricalOrderWebCaller
    {
        Task<List<HistoricalOrder>> GetOrderHistory(HistoricalOrderWebCallerParams _params);

    }
}
