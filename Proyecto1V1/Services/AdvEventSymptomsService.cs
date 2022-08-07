using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Text;

namespace Proyecto1V1.Services
{
    public class AdvEventSymptomsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public AdvEventSymptomsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);

        } 

        public async Task<IEnumerable<AdvEventSymptoms>> getList()
        {
            var response = await client.GetAsync("api/AdvEventSymptoms");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<AdvEventSymptoms>>(json_response);

            return result;
        }

        public async Task<AdvEventSymptoms> save(AdvEventSymptoms patient)
        {
            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/AdvEventSymptoms", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AdvEventSymptoms>(json_response);

            return result;
        }

        public async Task<AdvEventSymptoms> get(int? id)
        {
            var response = await client.GetAsync("api/AdvEventSymptoms/"+id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AdvEventSymptoms>(json_response);

            return result;
        }
    }
}
