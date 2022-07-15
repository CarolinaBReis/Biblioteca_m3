using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;

        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateAsync(string url, T objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (objToCreate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");
            }
            else { return false; }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if(response.StatusCode == HttpStatusCode.OK) { return true; }
            else { return false; }
        }

        public async Task<bool> DeleteAsync(string url, string Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url+Id);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == HttpStatusCode.OK) { return true; }
            else { return false; }
        }

        public async Task<IList<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<T>>(jsonString);
            }

            return null;
            
        }

        public async Task<T> GetAsync(string url, string Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + Id);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }

            return null;
        }

        public async Task<Obras_Nucleos> GetAsyncObra_Nucleos(string url, int Id, string isbn)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + Id + "/" + isbn);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Obras_Nucleos>(jsonString);
            }

            return null;
        }

        public async Task<Requisicoes> GetAsyncRequisicoes(string url, string isbn, int idNucleo, int nif)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + isbn + "/" + idNucleo + "/" + nif);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Requisicoes>(jsonString);
            }

            return null;
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url );
            if (objToUpdate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");
            }
            else { return false; }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent) { return true; }
            else { return false; }
        }

        public async Task<bool> UpdateAsyncObras_Nucleos(string url, Obras_Nucleos objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            if (objToUpdate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");
            }
            else { return false; }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent) { return true; }
            else { return false; }
        }
    }
}
