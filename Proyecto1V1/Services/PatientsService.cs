using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Net.Http.Headers;
using System.Text;


namespace Proyecto1V1.Services
{
    public class PatientsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public PatientsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Patients> save(Patients patient)
        {
            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, Encoding.UTF8,"application/json");

            var response = await client.PostAsync("api/Patients",content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Patients>(json_response);

            return result;
        }

        public async Task<IEnumerable<Patients>> getList()
        {
            var response = await client.GetAsync("api/Patients");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Patients>>(json_response);

            return result;
        }

    }
}
