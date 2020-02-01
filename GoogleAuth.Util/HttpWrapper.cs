using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAuth.Util
{
    public class HttpWrapper : IHttpWrapper
    {
        public async Task<string> Delete(string Url, List<KeyValuePair<string, string>> Headers = null)
        {
            return await SendRequest(Url, HttpMethod.Delete, Headers);
        }

        public async Task<string> Get(string Url, List<KeyValuePair<string, string>> Headers = null)
        {
            return await SendRequest(Url, HttpMethod.Get, Headers);
        }

        public async Task<string> Post(string Url, object body, List<KeyValuePair<string, string>> Headers = null)
        {
            return await SendRequest(Url, HttpMethod.Post, Headers, body);
        }

        public async Task<string> Put(string Url, object body, List<KeyValuePair<string, string>> Headers = null)
        {
            return await SendRequest(Url, HttpMethod.Put, Headers, body);
        }

        private void AddHttpHeaders(HttpRequestMessage request, List<KeyValuePair<string, string>> Headers)
        {
            if (Headers == null)
                return;

            foreach (var header in Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
        private async Task<string> SendRequest(string Url, HttpMethod method, List<KeyValuePair<string, string>> Headers = null, object body = null)
        {
            using (var http = new HttpClient())
            {
                var request = new HttpRequestMessage(method, Url);

                if (body != null)
                    //request.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body)));
                    request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                AddHttpHeaders(request, Headers);

                var response = await http.SendAsync(request);
                var responseText = await response.Content.ReadAsStringAsync();
                return responseText;
            }
        }
    }
}
