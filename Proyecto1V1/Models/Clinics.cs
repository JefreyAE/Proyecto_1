using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class Clinics
    {
        public int id { get; set; }
        public string name { get; set; }
        public string legal_certificate { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string web_site { get; set; }

        private ClinicsService _clinicsServices = new ClinicsService();

        public Clinics() { }
        public Clinics(int id, string name, string legal_certificate, string country, string province, string canton, string district, string phone_number, string email, string web_site)
        {
            this.id = id;
            this.name = name;
            this.legal_certificate = legal_certificate;
            this.country = country;
            this.province = province;
            this.canton = canton;
            this.district = district;
            this.phone_number = phone_number;
            this.email = email;
            this.web_site = web_site;
        }

        public async Task<IEnumerable<Clinics>> GetClinics()
        {
            IEnumerable<Clinics> clinics_list = await this._clinicsServices.getList();
            return clinics_list;
        }

        public async Task<Clinics> Save()
        {
            var result = await this._clinicsServices.save(this);

            return result;
        }
    }
}
