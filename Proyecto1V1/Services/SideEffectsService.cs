using Newtonsoft.Json;
using Proyecto1V1.Models;
using System.Text;

namespace Proyecto1V1.Services
{
    public class SideEffectsService
    {

        private static string _baseUrl;
        HttpClient client = new HttpClient();

        public  SideEffectsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

            this.client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<SideEffects> save(SideEffects sideEffects)
        {
            var json = JsonConvert.SerializeObject(sideEffects);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/SideEffects", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SideEffects>(json_response);

            return result;
        }

        public async Task<rel_effects_event_symptoms> saveAdvSymptomsSideEffects(rel_effects_event_symptoms rel)
        {
            var json = JsonConvert.SerializeObject(rel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Rel_effects_event_symptoms", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<rel_effects_event_symptoms>(json_response);

            return result;
        }

        public async Task<rel_effects_alergies> saveAlergiesSideEffects(rel_effects_alergies rel)
        {
            var json = JsonConvert.SerializeObject(rel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Rel_effects_alergies", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<rel_effects_alergies>(json_response);

            return result;
        }

        public async Task<rel_effects_diseases> saveNewDiseasesSideEffects(rel_effects_diseases rel)
        {
            var json = JsonConvert.SerializeObject(rel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Rel_effects_diseases", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<rel_effects_diseases>(json_response);

            return result;
        }

        public async Task<rel_effects_symptoms> saveSymptomsSideEffects(rel_effects_symptoms rel)
        {
            var json = JsonConvert.SerializeObject(rel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Rel_effects_symptoms", content);
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<rel_effects_symptoms>(json_response);

            return result;
        }

        public async Task<IEnumerable<SideEffects>> getList()
        {
            var response = await client.GetAsync("api/SideEffects");
            var json_response = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<SideEffects>>(json_response);

            return result;

        }

        public async Task<SideEffects> get(int? id)
        {
            var response = await client.GetAsync("api/SideEffects/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<SideEffects>(json_response);

            return result;
        }
    }
}
