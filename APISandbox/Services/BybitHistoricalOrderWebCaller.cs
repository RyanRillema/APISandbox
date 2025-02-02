using APISandbox.Interfaces;
using APISandbox.Models;
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
        HistoricalOrderWebCallerParams thisParams;
        public BybitHistoricalOrderWebCaller(HistoricalOrderWebCallerParams setParams)
        {
            thisParams = setParams;
        }
        public HttpRequestMessage SetupRequest(HttpRequestMessage setRequest)
        {
            var payload = CreateParams();
            var queryString = MakeString(payload);
            setRequest.Method = HttpMethod.Get;
            setRequest.RequestUri = CreateUri(queryString);
            AddGetRequestHeadersForAuthentication(setRequest, queryString);

            return setRequest;
        }
        public HttpRequestMessage AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body)
        {
            string timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();
            string message = $"{timestamp}BqvWkuqyIrWRosPqO6{20000}{body}";
            request.Headers.Add("X-BAPI-API-KEY", "BqvWkuqyIrWRosPqO6");
            request.Headers.Add("X-BAPI-RECV-WINDOW", "20000");
            request.Headers.Add("X-BAPI-SIGN", CreateSign(message));
            request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
            return request;
        }

        public Dictionary<string, string> CreateParams()
        {
            //return new() { { "api_key", "BqvWkuqyIrWRosPqO6" }, { "category", "spot" }, {"recv_window","20000"},{ "timestamp", DateTime.UtcNow.ToString() } };
            // , { "timestamp", DateTime.UtcNow.AddMonths(-2).ToString() }
            string test = thisParams.Category.ToString();
            return new() { { "category", test } };
        }

        public string CreateSign(string message)
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

        public Uri CreateUri(string queryString)
        {
            return new System.Uri($"/v5/order/history?{queryString}", UriKind.Relative);
        }

        public HttpClient getClient()
        {            
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://api-testnet.bybit.com") };
            client.DefaultRequestHeaders.ExpectContinue = false;

            return client;
        }

        public JsonSerializerOptions getJsonSerializerOptions()
        {
            JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields = true, AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip };

            return jsonSerializerOptions;
        }

        protected string MakeString(Dictionary<string, string> parms, bool escapeStrings = false)
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
