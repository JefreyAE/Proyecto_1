using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Medics
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string professional_code { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string canton { get; set; }

        private MedicsService _medicsServices = new MedicsService();

        public Medics()
        {

        }
        public Medics(int id, string id_number, string professional_code, string full_name, string email, string country, string province, string canton)
        {
            this.id = id;
            this.id_number = id_number;
            this.professional_code = professional_code;
            this.full_name = full_name;
            this.email = email;
            this.country = country;
            this.province = province;
            this.canton = canton;
        }

        public async Task<IEnumerable<Medics>> GetMedics()
        {
            IEnumerable<Medics> medics_list = await this._medicsServices.getList();
            return medics_list;
        }

        public async Task<Medics> Save()
        {
            var result = await this._medicsServices.save(this);

            return result;
        }


    }

    
}
