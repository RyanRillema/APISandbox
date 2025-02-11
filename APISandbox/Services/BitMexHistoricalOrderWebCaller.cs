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
    public class BitMexHistoricalOrderWebCaller : IHistoricalOrderWebCaller
    {
        HistoricalOrderWebCallerParams _params =  new HistoricalOrderWebCallerParams();
        IHistoricalOrder _order = new BitMexHistoricalOrder();

        public BitMexHistoricalOrderWebCaller()
        {

        }
        public async Task<List<HistoricalOrder>> GetOrderHistory(HistoricalOrderWebCallerParams setParams)
        {
            _params = setParams;
            List<HistoricalOrder> orders;
            string output = await WebCall();            
            orders = _order.PopulateHistoricalOrders(output);
            return orders;
        }
        
        private async Task<string> WebCall()
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
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://testnet.bitmex.com") };
            client.DefaultRequestHeaders.ExpectContinue = false;

            return client;
        }
        private HttpRequestMessage AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body)
        {
            string expires = GetExpires().ToString();
            string message = "GET" + request.RequestUri + expires + body;
            string signatureString = CreateSign(message);

            request.Headers.Add("api-expires", expires);
            request.Headers.Add("api-key", "ZSbLa4SnZk5zh4r08wnPw7RM");
            request.Headers.Add("api-signature", signatureString);

            return request;
        }
        private Dictionary<string, string> CreateParams()
        {
            var param = new Dictionary<string, string>();
            //param["symbol"] = "BTCUSD";
            //param["filter"] = "{\"open\":true}";
            //param["columns"] = "";
            //param["count"] = 100.ToString();
            //param["start"] = 0.ToString();
            //param["reverse"] = false.ToString();
            //param["startTime"] = "";
            //param["endTime"] = "";

            //string category = _params.Category.ToString();

            return param;
        }
        private string CreateSign(string message)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes("rMeqAzEGaGSLJGphWsUjou-_49-uyzK5wmxnoqnzoAAczeCD");
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
            //string url = "/api/v1" + function + ((method == "GET" && paramData != "") ? "?" + paramData : "");
            string url = "/api/v1/order?" + queryString;

            //return new System.Uri($"/v5/order/history?{queryString}", UriKind.Relative);
            return new System.Uri($"{url}", UriKind.Relative);
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
        
        //TODO
        private long GetExpires()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600; // set expires one hour in the future
        }

        public string GetOrders()
        {
            var param = new Dictionary<string, string>();
            //param["symbol"] = "BTCUSD";
            //param["filter"] = "{\"open\":true}";
            //param["columns"] = "";
            //param["count"] = 100.ToString();
            //param["start"] = 0.ToString();
            //param["reverse"] = false.ToString();
            //param["startTime"] = "";
            //param["endTime"] = "";
            //return Query("GET", "/order", param, true);
            return "";
        }

        public string PostOrders()
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = "XBTUSD";
            param["side"] = "Buy";
            param["orderQty"] = "1";
            param["ordType"] = "Market";
            //return Query("POST", "/order", param, true);
            return "";
        }

        public string DeleteOrders()
        {
            var param = new Dictionary<string, string>();
            param["orderID"] = "de709f12-2f24-9a36-b047-ab0ff090f0bb";
            param["text"] = "cancel order by ID";
            //return Query("DELETE", "/order", param, true, true);
            return "";
        }
                
        }

    }
