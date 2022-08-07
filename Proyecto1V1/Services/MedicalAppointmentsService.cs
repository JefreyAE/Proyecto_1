using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Net.Http.Headers;
using System.Text;


namespace Proyecto1V1.Services
{
    public class MedicalAppointmentsService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public MedicalAppointmentsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<MedicalAppointments> save(MedicalAppointments medical)
        {
            var json = JsonConvert.SerializeObject(medical);
            var content = new StringContent(json, Encoding.UTF8,"application/json");

            var response = await client.PostAsync("api/MedicalAppointments", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MedicalAppointments>(json_response);

            return result;
        }

        public async Task<IEnumerable<MedicalAppointments>> getList()
        {
            var response = await client.GetAsync("api/MedicalAppointments");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<MedicalAppointments>>(json_response);

            return result;

        }

        public async Task<MedicalAppointments> get(int? id)
        {
            var response = await client.GetAsync("api/MedicalAppointments/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<MedicalAppointments>(json_response);

            return result;
        }

    }
}
