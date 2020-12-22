using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lider.DPVAT.MODELO.Help.ClientHTTP
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient httpClient;

        public HttpClient()
        {
            this.httpClient = new System.Net.Http.HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await this.httpClient.SendAsync(httpRequestMessage);

            return response;
        }

        public async Task<HttpResponseMessage> GetAsyncBasicAuthentication(string uri, string user, string password)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + password));
            System.Net.Http.HttpClient httpClientBasic = new System.Net.Http.HttpClient();
            httpClientBasic.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);

            var response = await httpClientBasic.SendAsync(httpRequestMessage);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            return await DoRequestAsync(HttpMethod.Post, uri, item);
        }

        public async Task<HttpResponseMessage> PostAsyncBasicAuthentication<T>(string uri, T item, string user, string password)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json")
            };

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + password));
            System.Net.Http.HttpClient httpClientBasic = new System.Net.Http.HttpClient();
            httpClientBasic.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);

            var response = await httpClientBasic.SendAsync(httpRequestMessage);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item)
        {
            return await DoRequestAsync(HttpMethod.Put, uri, item);
        }

        private async Task<HttpResponseMessage> DoRequestAsync<T>(HttpMethod httpMethod, string uri, T item)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json")
            };

            var response = await this.httpClient.SendAsync(httpRequestMessage);

            return response;
        }

        private async Task<HttpResponseMessage> DoRequestAsync<T>(HttpMethod httpMethod, string uri, T item, string type)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), null, type)
            };

            var response = await this.httpClient.SendAsync(httpRequestMessage);

            return response;
        }


        public async Task<HttpResponseMessage> PatchAsync<T>(string uri, T item)
        {
            return await DoRequestAsync(new HttpMethod("PATCH"), uri, item);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            var response = await this.httpClient.SendAsync(httpRequestMessage);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsyncTokenBearer<T>(string uri, T item)
        {
            System.Net.Http.HttpClient httpClientBasic = new System.Net.Http.HttpClient();
            
            var response = await httpClientBasic.PostAsJsonAsync(uri, item);
            return response;
        }


        public async Task<HttpResponseMessage> PostAsyncRequisicao<T>(string uri, T item, string token)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json")
            };

            //  string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(token));
            System.Net.Http.HttpClient httpClientBasic = new System.Net.Http.HttpClient();
            var tokenApi = "bearer " + token;
            tokenApi = tokenApi.Replace(@"""", "").ToString();
            httpClientBasic.DefaultRequestHeaders.Add("Authorization", tokenApi);

            var response = await httpClientBasic.SendAsync(httpRequestMessage);

            return response;

        }
    }
}
