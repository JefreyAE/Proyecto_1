using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Vaccines
    {
        public int id { get; set; }
        public int? medical_appoiment_id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string application_date { get; set; }
        public string lot_number { get; set; }
        public string expiration_date { get; set; }
        public string application_place { get; set; }
        public string observations { get; set; }

        private VaccinesService _vaccinesService = new VaccinesService();

        public Vaccines() { }
        public Vaccines(int id, int? medical_appoiment_id, string name, string brand, string application_date, string lot_number, string expiration_date, string application_place, string observations)
        {
            this.id = id;
            this.medical_appoiment_id = medical_appoiment_id;
            this.name = name;
            this.brand = brand;
            this.application_date = application_date;
            this.lot_number = lot_number;
            this.expiration_date = expiration_date;
            this.application_place = application_place;
            this.observations = observations;
        }

        public async Task<IEnumerable<Vaccines>> GetVaccines()
        {
            IEnumerable<Vaccines> clinics_list = await this._vaccinesService.getList();
            return clinics_list;
        }

        public async Task<Vaccines> Save()
        {
            var result = await this._vaccinesService.save(this);

            return result;
        }
    }
}
