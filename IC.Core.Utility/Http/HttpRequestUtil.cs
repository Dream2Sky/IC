using IC.Core.Entity.Http;
using IC.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IC.Core.Utility.Extensions;

namespace IC.Core.Utility.Http
{
    public class HttpRequestUtil
    {
        public static HttpContent GetHttpContent(Dictionary<string, string> paramDict)
        {
            if (paramDict == null || paramDict.Count <= 0)
            {
                return null;
            }
            HttpContent content = new FormUrlEncodedContent(paramDict);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            content.Headers.ContentType.CharSet = "UTF-8";

            return content;
        }

        public static string GetUrl(string url, Dictionary<string, string> paramDict)
        {
            if (paramDict == null || paramDict.Count <= 0)
            {
                return url;
            }
            url += "?";
            foreach (var item in paramDict)
            {
                url += string.Format("{0}={1}&", item.Key, item.Value);
            }

            return url;
        }

        public static T Get<T>(HttpClient httpClient, HttpRequestMessage requestMessage)
        {
            var res = httpClient.SendAsync(requestMessage);
            res.Wait();
            var resp = res.Result;
            Task<string> temp = resp.Content.ReadAsStringAsync();
            temp.Wait();

            return JsonConvert.DeserializeObject<T>(temp.Result);
        }

        public static T Get<T>(HttpClient httpClient, string url, Dictionary<string, string> paramDict)
        {
            var httpContent = GetHttpContent(paramDict);
            url = GetUrl(url, paramDict);

            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
                Content = httpContent
            };

            return Get<T>(httpClient, httpRequestMessage);
        }

        public static T Get<T>(string url, Dictionary<string, string> paramDict)
        {
            return Get<T>(new HttpClient(), url, paramDict);
        }

        public static HttpResult<T> GetHttpResponse<T>
            (Entity.Enum.HTTP_SUCCESS status, int statusCode, string msg, T data)
        {
            HttpResult<T> httpResult = new HttpResult<T>
            {
                Success = status.GetDescription(),
                Code = statusCode,
                Msg = msg,
                Data = data
            };
            return httpResult;
        }


        public static HttpResult<T> GetHttpResponse<T>(int statusCode, string msg, T data)
        {
            return GetHttpResponse<T>(Entity.Enum.HTTP_SUCCESS.SUCCESS, statusCode, msg, data);
        }
    }
}
