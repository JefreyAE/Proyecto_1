using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Text;

namespace Proyecto1V1.Services
{
    public class PatientsVaccineInformationService
    {
        private static string _baseUrl;
        HttpClient client = new HttpClient();
        public PatientsVaccineInformationService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<PatientsVaccineInformation> save(PatientsVaccineInformation patient_information)
        {
            var json = JsonConvert.SerializeObject(patient_information);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/PatientsVaccineInformations", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PatientsVaccineInformation>(json_response);

            return result;
        }

        public async Task<IEnumerable<PatientsVaccineInformation>> getList()
        {
            var response = await client.GetAsync("api/PatientsVaccineInformations");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PatientsVaccineInformation>>(json_response);

            return result;
        }

        public async Task<PatientsVaccineInformation> get(int? id)
        {
            var response = await client.GetAsync("api/PatientsVaccineInformations/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PatientsVaccineInformation>(json_response);

            return result;
        }


    }
}
