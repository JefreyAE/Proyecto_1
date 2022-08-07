using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Services
{
    public class NewDiseasesService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public NewDiseasesService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<IEnumerable<NewDiseases>> getList()
        {
            var response = await client.GetAsync("api/NewDiseases");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<NewDiseases>>(json_response);

            return result;
        }

        public async Task<NewDiseases> get(int? id)
        {
            var response = await client.GetAsync("api/NewDiseases/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<NewDiseases>(json_response);

            return result;
        }

    }
}
