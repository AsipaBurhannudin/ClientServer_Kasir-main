using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class ItemRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public ItemRepository(string request = "Item/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7078/api/")
            };
        }
        public async Task<ResponseDataVM<List<Item>>> Get()
        {
            ResponseDataVM<List<Item>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Item>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Item>> Get(string id)
        {
            ResponseDataVM<Item> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Item>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Item>> Post(Item item)
        {
            ResponseDataVM<Item> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Item>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Item>> Put(Item item)
        {
            ResponseDataVM<Item> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Item>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Item>> Delete(string id)
        {
            ResponseDataVM<Item> entityVM = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Item>>(apiResponse);
            }
            return entityVM;
        }
    }
}
