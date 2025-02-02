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
        HttpRequestMessage SetupRequest(HttpRequestMessage setRequest);
        HttpClient getClient();
        JsonSerializerOptions getJsonSerializerOptions();
        Dictionary<string, string> CreateParams();
        HttpRequestMessage AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body);
        string CreateSign(string message);
        Uri CreateUri(string queryString);

    }
}
