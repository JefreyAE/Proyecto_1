using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Alergies
    {
        public int id { get; set; }
        public string description { get; set; }

        private AlergiesService _alergiesService = new AlergiesService();

        public Alergies() { }
        public Alergies(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public async Task<IEnumerable<Alergies>> GetAlergies()
        {
            IEnumerable<Alergies> alergies_list = await this._alergiesService.getList();
            return alergies_list;
        }
    }
}
