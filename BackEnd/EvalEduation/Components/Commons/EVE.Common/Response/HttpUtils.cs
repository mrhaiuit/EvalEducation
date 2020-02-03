using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EVE.Commons.Response
{
    public static class HttpUtils<T>
            where T : class
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<T> Post(string url,
                                         object content)
        {
            HttpResponseMessage response;
            if(content == null)
            {
                response = await Client.PostAsync(url, null);
            }
            else
            {
                response = await Client.PostAsync(url, new StringContent(JsonUtils<object>.ToJson(content), Encoding.UTF8, "application/json"));
            }

            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();var obj = JsonUtils<T>.JsonToObj(res);
                return obj;
            }

            return null;
        }

        public static async Task<T> Put(string url,
                                        object content)
        {
            HttpResponseMessage response;
            if(content == null)
            {
                response = await Client.PostAsync(url, null);
            }
            else
            {
                response = await Client.PutAsync(url, new StringContent(JsonUtils<object>.ToJson(content), Encoding.UTF8, "application/json"));
            }

            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var obj = JsonUtils<T>.JsonToObj(res);
                return obj;
            }

            return null;
        }

        public static async Task<T> Delete(string url,
                                           object content)
        {
            HttpResponseMessage response;
            if(content == null)
            {
                response = await Client.DeleteAsync(url);
            }
            else
            {
                var request = new HttpRequestMessage
                              {
                                      Method = HttpMethod.Delete,
                                      RequestUri = new Uri(url),
                                      Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
                              };
                response = await Client.SendAsync(request);
            }

            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var obj = JsonUtils<T>.JsonToObj(res);
                return obj;
            }

            return null;
        }

        public static async Task<T> Get(string url,
                                        object content)
        {
            var response = await Client.GetAsync(BuildQueryPath(url, content));
            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var obj = JsonUtils<T>.JsonToObj(res);
                return obj;
            }

            return null;
        }

        private static string BuildQueryPath(string url,
                                             object obj)
        {
            if(obj == null)
            {
                return url;
            }

            StringBuilder builder = new StringBuilder();
            string condition = "?";
            builder.Append(url);
            Type type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var name = prop.Name;
                var value = prop.GetValue(obj, null)
                                .ToString();

                builder.Append($"{condition}{name}={value}");
                condition = "&";
            }

            return builder.ToString();
        }
    }
}
