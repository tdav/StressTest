using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TestApp.Utils
{
    public class RestClient : IDisposable
    {
        private string contentType = "application/json";
        private HttpClient client;

        public RestClient(string ServerUrl)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(150);
            client.MaxResponseContentBufferSize = 2147483647;
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
        }
         
        public async Task<TRES> FormDataAsync<TRES>(string url, Dictionary<string, string> values)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TRES>(res);
            }
            else
            {
                throw new Exception($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }

        public byte[] GetImage(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            var response = client.GetAsync(  url).Result;

            if (response.IsSuccessStatusCode)
            {
                var photo = response.Content.ReadAsByteArrayAsync();
                return photo.Result;
            }
            else
            {
                throw new Exception($"({url}) -> {response.StatusCode}, \n {response.ReasonPhrase}");
            }
        }

        public async Task<T> GetApi<T>(string url)
        {
            var res = await client.GetAsync(url);

            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            else
            {
                throw new Exception($"{res.StatusCode} {res.ReasonPhrase}");
            }
        }

        public async Task<TRES> PutApi<T, TRES>(T param, string url) where T : class
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"))
            using (HttpResponseMessage response = await client.PutAsync(url, httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    var searchResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TRES>(searchResult);
                }
                else
                {
                    throw new Exception($"{response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }

        public async Task<TRES> PostApi<T, TRES>(T param, string url) where T : class
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"))
            using (HttpResponseMessage response = await client.PostAsync(url, httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    var searchResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TRES>(searchResult);
                }
                else
                {
                    throw new Exception($"{response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}