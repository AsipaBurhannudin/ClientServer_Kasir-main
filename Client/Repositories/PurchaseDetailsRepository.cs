using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class PurchaseDetailsRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public PurchaseDetailsRepository(string request = "PurchaseDetails/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7078/api/")
            };
        }
        public async Task<ResponseDataVM<List<PurchaseDetails>>> Get()
        {
            ResponseDataVM<List<PurchaseDetails>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<PurchaseDetails>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<PurchaseDetails>> Get(string id)
        {
            ResponseDataVM<PurchaseDetails> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<PurchaseDetails>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<PurchaseDetails>> Post(PurchaseDetails purchaseDetails)
        {
            ResponseDataVM<PurchaseDetails> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(purchaseDetails), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<PurchaseDetails>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<PurchaseDetails>> Put(PurchaseDetails purchaseDetails)
        {
            ResponseDataVM<PurchaseDetails> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(purchaseDetails), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<PurchaseDetails>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<PurchaseDetails>> Delete(string id)
        {
            ResponseDataVM<PurchaseDetails> entityVM = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<PurchaseDetails>>(apiResponse);
            }
            return entityVM;
        }
    }
}
