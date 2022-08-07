using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Services
{
    public class SymptomsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public SymptomsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<IEnumerable<Symptoms>> getList()
        {
            var response = await client.GetAsync("api/Symptoms");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Symptoms>>(json_response);

            return result;
        }

        public async Task<Symptoms> get(int? id)
        {
            var response = await client.GetAsync("api/Symptoms/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Symptoms>(json_response);

            return result;
        }
    }
}
