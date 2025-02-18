using APISandbox.Interfaces;
using APISandbox.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Services
{
    public class BybitHistoricalOrderWebCaller : IHistoricalOrderWebCaller
    {
        private const string _testnetBaseUrl = "https://api-testnet.bybit.com";

        HistoricalOrderWebCallerParams _params =  new HistoricalOrderWebCallerParams();
        IOrderFactory _order = new BybitOrderFactory();
                
        public async Task<List<HistoricalOrder>> GetOrderHistory(HistoricalOrderWebCallerParams parameters) 
        {
            _params = parameters;
            var output = await WebCall();
            return _order.PopulateHistoricalOrders(output);
        }
        private async Task<String> WebCall()
        {
            string output;

            try
            {
                HttpClient client = GetClient();

                using (HttpRequestMessage request = new())
                {
                    SetupRequest(request);

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            output = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            output = response.StatusCode.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }
        private void SetupRequest(HttpRequestMessage request)
        {
            var payload = CreateParams();
            var queryString = MakeString(payload);
            request.Method = HttpMethod.Get;
            request.RequestUri = CreateUri(queryString);
            AddGetRequestHeadersForAuthentication(request, queryString);
        }
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(_testnetBaseUrl) };
            client.DefaultRequestHeaders.ExpectContinue = false;

            return client;
        }
        private void AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body)
        {
            string timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();
            string message = $"{timestamp}BqvWkuqyIrWRosPqO6{20000}{body}";
            request.Headers.Add("X-BAPI-API-KEY", "BqvWkuqyIrWRosPqO6");
            request.Headers.Add("X-BAPI-RECV-WINDOW", "20000");
            request.Headers.Add("X-BAPI-SIGN", CreateSign(message));
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
        }
        private Dictionary<string, string> CreateParams()
        {
            var param = new Dictionary<string, string>();

            string startTime = Convert.ToInt64((_params.StartTime - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();
            string endTime = Convert.ToInt64((_params.EndTime - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();

            param["category"] = _params.Category.ToString();
            param["startTime"] = startTime;
            param["endTime"] = endTime;

            return param;
        }
        private string CreateSign(string message)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes("sqsi3jSERbvMifgZ6ViB28Suyt3Qj7A9dLiv");
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] signatureBytes = null;
            using (var hash = new HMACSHA256(keyByte))
                signatureBytes = hash.ComputeHash(messageBytes);

            var hex = new StringBuilder(signatureBytes.Length * 2);

            foreach (var b in signatureBytes)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
        private Uri CreateUri(string queryString)
        {
            return new System.Uri($"/v5/order/history?{queryString}", UriKind.Relative);
        }       
        private string MakeString(Dictionary<string, string> parms, bool escapeStrings = false)
        {
            if (parms == null)
                return "";

            Func<object, string> getString = delegate (object value)
            {
                if (value is bool)
                    return value.ToString().ToLower();

                if (value is Enum myEnum)
                    value = myEnum.ToString();

                if (escapeStrings && value is string)
                    return $"\"{value}\"";

                return value.ToString();
            };

            var list = new List<string>();
            foreach (var parm in parms)
                list.Add($"{getString(parm.Key)}={getString(parm.Value)}");

            return string.Join("&", list);
        }

    }
}
