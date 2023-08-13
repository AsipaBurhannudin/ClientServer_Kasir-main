using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class CustomerRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public CustomerRepository(string request = "Customer/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7078/api/")
            };
        }
        public async Task<ResponseDataVM<List<Customer>>> Get()
        {
            ResponseDataVM<List<Customer>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Customer>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Customer>> Get(string id)
        {
            ResponseDataVM<Customer> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Customer>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Customer>> Post(Customer customer)
        {
            ResponseDataVM<Customer> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Customer>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Customer>> Put(Customer customer)
        {
            ResponseDataVM<Customer> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Customer>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Customer>> Delete(string id)
        {
            ResponseDataVM<Customer> entityVM = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Customer>>(apiResponse);
            }
            return entityVM;
        }
    }
}
