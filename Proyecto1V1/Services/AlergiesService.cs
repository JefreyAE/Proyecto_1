using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Services
{
    public class AlergiesService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public AlergiesService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<IEnumerable<Alergies>> getList()
        {
            var response = await client.GetAsync("api/Alergies");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Alergies>>(json_response);

            return result;
        }

        public async Task<Alergies> get(int? id)
        {
            var response = await client.GetAsync("api/Alergies/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Alergies>(json_response);

            return result;
        }
    }
}
