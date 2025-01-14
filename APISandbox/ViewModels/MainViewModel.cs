﻿using APISandbox.ViewModels.Orders;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.ViewModels;

public partial class MainViewModel : ViewModelBase
{    
    [ObservableProperty]
    private string _output;

    [RelayCommand]
    private async Task Go()
    {
        try
        {
            JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields=true,AllowTrailingCommas=true,ReadCommentHandling=JsonCommentHandling.Skip};
            HttpClient client = new HttpClient() { BaseAddress = new Uri("https://api.bybit.com") };
            client.DefaultRequestHeaders.ExpectContinue = false;

            using (HttpRequestMessage request = new())
            {
                request.Method = HttpMethod.Get;
                var payload = CreateParams();
                var queryString = MakeString(payload);
                request.RequestUri = new System.Uri($"/v5/order/history?{queryString}", UriKind.Relative);
                //var body = JsonSerializer.Serialize(payload, jsonSerializerOptions);
                //request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                AddGetRequestHeadersForAuthentication(request, queryString);

                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Output = await response.Content.ReadAsStringAsync();

                        BybitViewModel Test = JsonSerializer.Deserialize<BybitViewModel>(Output);

                    } else
                    {
                        Output = response.StatusCode.ToString();
                    }

                }

            }
        }
        catch (Exception ex)
        {
            Output = ex.Message;            
        }

    }

    public ObservableCollection<OrderViewModel> Orders { get; } = new();

    private Dictionary<string, string> CreateParams()
    {
        //return new() { { "api_key", "dYJedZtxQtASVNSCBW" }, { "category", "spot" }, {"recv_window","20000"},{ "timestamp", DateTime.UtcNow.ToString() } };
        return new() { { "category", "spot" } };
    }
    
    protected HttpRequestMessage AddGetRequestHeadersForAuthentication(HttpRequestMessage request, string body)
    {
        string timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 01, 01)).TotalMilliseconds).ToString();
        string message = $"{timestamp}dYJedZtxQtASVNSCBW{20000}{body}";
        request.Headers.Add("X-BAPI-API-KEY", "dYJedZtxQtASVNSCBW");
        request.Headers.Add("X-BAPI-RECV-WINDOW", "20000");
        request.Headers.Add("X-BAPI-SIGN", CreateSign(message));
        request.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
        return request;
    }

    protected string CreateSign(string message)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes("XBOoyJQV0EfvfKMLfa2AkNzkev1A3DFWbtDS");
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        byte[] signatureBytes = null;
        using (var hash = new HMACSHA256(keyByte))
            signatureBytes = hash.ComputeHash(messageBytes);

        var hex = new StringBuilder(signatureBytes.Length * 2);

        foreach (var b in signatureBytes)
            hex.AppendFormat("{0:x2}", b);

        return hex.ToString();
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
