using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lider.DPVAT.MODELO.Help.ClientHTTP
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item);

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item);

        Task<HttpResponseMessage> PatchAsync<T>(string uri, T item);

        Task<HttpResponseMessage> DeleteAsync(string uri);

        Task<HttpResponseMessage> GetAsyncBasicAuthentication(string uri, string user, string password);

        Task<HttpResponseMessage> PostAsyncBasicAuthentication<T>(string uri, T item, string user, string password);
    }
}
