using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class AdvEventSymptoms
    {
        public int id { get; set; }
        public string description { get; set; }

        private AdvEventSymptomsService _advEventSymptomsService = new AdvEventSymptomsService();

        public AdvEventSymptoms() { }
        public AdvEventSymptoms(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public async Task<IEnumerable<AdvEventSymptoms>> GetEventSymptoms()
        {
            IEnumerable<AdvEventSymptoms> advEventSymptoms_list = await this._advEventSymptomsService.getList();
            return advEventSymptoms_list;
        }

        public async Task<AdvEventSymptoms> Save()
        {
            var result = await this._advEventSymptomsService.save(this);

            return result;
        }

        public async Task<AdvEventSymptoms> Get(int id)
        {
            var result = await this._advEventSymptomsService.get(id);

            return result;
        }
    }
}
