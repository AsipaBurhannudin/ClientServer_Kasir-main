using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text;

namespace Client.Repositories
{
    public class UsersRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public UsersRepository(string request = "Users/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7078/api/")
            };
        }

        public async Task<ResponseDataVM<string>> Login(LoginVM login)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "login", content).Result) //localhost/api/university {method:post} -> content
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<List<Users>>> Get()
        {
            ResponseDataVM<List<Users>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Users>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<string>> Post(Users users)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result) //localhost/api/university {method:post} -> content
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Users>> Get(string id)
        {
            ResponseDataVM<Users> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Users>>(apiResponse);
            }
            return entity;
        }


    }
}