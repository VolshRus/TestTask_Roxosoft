using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientApp.Utils
{
    internal class RequestService : IRequestService, IRequestServiceQuery
    {
        IRequestServiceQuery IRequestService.FromUrl(string url)
        {
            _requestUrl = url;
            return this;
        }

        IRequestServiceQuery IRequestServiceQuery.With(object key, object value)
        {
            _requestParams.Add(key.ToString(), value.ToString());
            return this;
        }

        async Task<T> IRequestServiceQuery.GetAsync<T>()
        {
            using (var client = new HttpClient())
            {
                var requestUrl = BuildUrl(_requestUrl, _requestParams);
                ClearCache();

                var response = await client.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request on url {requestUrl} error text: {error}");
                }

                var okResult = await response.Content.ReadAsStringAsync();

                var result = DeserializeResult<T>(okResult);

                return result;
            }
        }

        private T DeserializeResult<T>(string result)
        {
            T value;
            try
            {
                value = JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                throw new JsonException($"Cannot deserialize json: {result} in [{typeof(T)}]", e);
            }
            return value;
        }

        private void ClearCache()
        {
            _requestParams.Clear();
            _requestUrl = string.Empty;
        }

        private string BuildUrl(string url, IDictionary<string, string> arguments)
        {
            var result = $"{url}?{string.Join("&", arguments.Select(s => $"{s.Key}={s.Value}"))}";
            var isOk = Uri.IsWellFormedUriString(result, UriKind.Absolute);
            if (!isOk)
                throw new UriFormatException($"Url {result} is not a valid URL.");
            return result;
        }

        private string _requestUrl;
        private readonly Dictionary<string, string> _requestParams = new Dictionary<string, string>();
    }
}
