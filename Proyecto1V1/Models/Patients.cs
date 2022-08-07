using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Patients
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string name { get; set; }
        public string surname_1 { get; set; }
        public string surname_2 { get; set; }
        public string birth_date { get; set; }
        public string gender { get; set; }
        public string contact_number { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string marital_status { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string register_date { get; set; }
        public string occupation { get; set; }

        private PatientsService _patientsServices = new PatientsService();
        public Patients()
        {
            
        }

        public async Task<IEnumerable<Patients>> GetPatients()
        {
            IEnumerable<Patients> patients_list = await this._patientsServices.getList();
            return patients_list;
        }

        public async Task<Patients> Save()
        {
            var result = await this._patientsServices.save(this);
            return result;
        }

        public async Task<Patients> Update(int id)
        {
            var result = await this._patientsServices.update(id, this);
            return result;
        }

        public async Task<Patients> Get(int? id)
        {
            var result = await this._patientsServices.get(id);

            return result;
        }

    }
}
