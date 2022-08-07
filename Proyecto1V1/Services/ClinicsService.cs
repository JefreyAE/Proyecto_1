using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Net.Http.Headers;
using System.Text;


namespace Proyecto1V1.Services
{
    public class ClinicsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public ClinicsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Clinics> save(Clinics clinic)
        {
            var json = JsonConvert.SerializeObject(clinic);
            var content = new StringContent(json, Encoding.UTF8,"application/json");

            var response = await client.PostAsync("api/Clinics", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Clinics>(json_response);

            return result;
        }

        public async Task<Clinics> update(int id,  Clinics clinic)
        {
            var json = JsonConvert.SerializeObject(clinic);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/Clinics/"+id, content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Clinics>(json_response);

            return result;
        }

        public async Task<IEnumerable<Clinics>> getList()
        {
            var response = await client.GetAsync("api/Clinics");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Clinics>>(json_response);

            return result;
        }

        public async Task<Clinics> get(int? id)
        {
            var response = await client.GetAsync("api/Clinics/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Clinics>(json_response);

            return result;
        }

        public async Task<Clinics> getByName(string? name)
        {
            var response = await client.GetAsync("api/Clinics/clinic_name/" + name);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Clinics>(json_response);

            return result;
        }

        public async Task<Clinics> getByLegal_certificate(string? id)
        {
            var response = await client.GetAsync("api/Clinics/legal_certificate/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Clinics>(json_response);

            return result;
        }

    }
}
