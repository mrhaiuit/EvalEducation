using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace EVE.WebApi.Shared.Response
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static StringContent ToStringContent(this object obj)
        {
            return new StringContent(obj.ToJson(), Encoding.UTF8, "application/json");
        }
    }
}
