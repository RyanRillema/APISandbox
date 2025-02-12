using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.Services
{
    public class BybitHistoricalOrderWebCaller : IHistoricalOrderWebCaller
    {
        //RC: This class is very similar to the BitMexHistoricalOrderWebCaller class.
        //I don't see anything sepcific to this class that I want to comment on but many of the comments from 
        //BitMexHistoricalOrderWebCaller apply here too
        HistoricalOrderWebCallerParams _params =  new HistoricalOrderWebCallerParams();
        IHistoricalOrder _order = new BybitHistoricalOrder();
        
        public BybitHistoricalOrderWebCaller() 
        {
            
        }
        public async Task<List<HistoricalOrder>> GetOrderHistory(HistoricalOrderWebCallerParams setParams) 
        {
            _params = setParams;
            List<HistoricalOrder> orders;
            string webCallResult = await WebCall();
            orders = _order.PopulateHistoricalOrders(webCallResult);

            return orders;
        }
        private async Task<String> WebCall()
        {
            string output;

            try
            {
                HttpClient client = getClient();

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
        private HttpRequestMessage SetupRequest(HttpRequestMessage setRequest)
        {
            var payload = CreateParams();
            var queryString = MakeString(payload);
            setRequest.Method = HttpMethod.Get;
            setRequest.RequestUri = CreateUri(queryString);
            AddGetRequestHeadersForAuthentication(setRequest, queryString);

            return setRequest;
        }
        private HttpClient getClient()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://api-testnet.bybit.com") };
            client.DefaultRequestHeaders.ExpectContinue = false;

            return client;
        }
        private HttpRequestMessage AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body)
        {
            string timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();
            string message = $"{timestamp}BqvWkuqyIrWRosPqO6{20000}{body}";
            request.Headers.Add("X-BAPI-API-KEY", "BqvWkuqyIrWRosPqO6");
            request.Headers.Add("X-BAPI-RECV-WINDOW", "20000");
            request.Headers.Add("X-BAPI-SIGN", CreateSign(message));
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            return request;
        }
        private Dictionary<string, string> CreateParams()
        {
            //return new() { { "api_key", "BqvWkuqyIrWRosPqO6" }, { "category", "spot" }, {"recv_window","20000"},{ "timestamp", DateTime.UtcNow.ToString() } };
            // , { "timestamp", DateTime.UtcNow.AddMonths(-2).ToString() }
            string category = _params.Category.ToString();
            return new() { { "category", _params.Category.ToString() } };
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
