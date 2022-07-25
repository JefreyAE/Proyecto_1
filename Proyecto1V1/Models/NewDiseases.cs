using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{ 
    public class NewDiseases
    {
        public int id { get; set; }
        public string description { get; set; }

        private NewDiseasesService _newDiseasesService = new NewDiseasesService();

        public NewDiseases() { }
        public NewDiseases(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        public async Task<IEnumerable<NewDiseases>> GetNewDiseases()
        {
            IEnumerable<NewDiseases> newDiseases_list = await this._newDiseasesService.getList();
            return newDiseases_list;
        }
    }
}
