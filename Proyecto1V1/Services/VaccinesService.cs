using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Proyecto1V1.Services
{
    public class VaccinesService
    {
        public static string _baseUrl;
        HttpClient client = new HttpClient();

        public VaccinesService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Vaccines> save(Vaccines vaccine)
        {
            var json = JsonConvert.SerializeObject(vaccine);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Vaccines", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Vaccines>(json_response);

            return result;
        } 

        public async Task<IEnumerable<Vaccines>> getList()
        {
            var response = await client.GetAsync("api/Vaccines");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Vaccines>>(json_response);

            return result;
        }

        public async Task<Vaccines> get(int? id)
        {
            var response = await client.GetAsync("api/Vaccines/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Vaccines>(json_response);

            return result;
        }

    }
}
