using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Symptoms
    {
        public int id { get; set; }
        public string description { get; set; }

        private SymptomsService _symptomsService = new SymptomsService();

        public Symptoms() { }
        public Symptoms(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public async Task<IEnumerable<Symptoms>> GetSymptoms()
        {
            IEnumerable<Symptoms> symptoms_list = await this._symptomsService.getList();
            return symptoms_list;
        }

        public async Task<Symptoms> Get(int id)
        {
            var result = await this._symptomsService.get(id);

            return result;
        }
    }
}
