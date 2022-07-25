using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Net.Http.Headers;
using System.Text;


namespace Proyecto1V1.Services
{
    public class MedicsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();
        public MedicsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Medics> save(Medics medic)
        { 
            var json = JsonConvert.SerializeObject(medic);
            var content = new StringContent(json, Encoding.UTF8,"application/json");

            var response = await client.PostAsync("api/Medics", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Medics>(json_response);

            return result;
        }

        public async Task<IEnumerable<Medics>> getList()
        { 
            var response = await client.GetAsync("api/Medics");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Medics>>(json_response);

            return result;
        }

    }
}
