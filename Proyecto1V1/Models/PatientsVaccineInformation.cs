using Proyecto1V1.Services;

namespace Proyecto1V1.Models 
{ 
    public class PatientsVaccineInformation
    {
        public int id { get; set; }
        public int? medical_appoiment_id { get; set; }
        public string cv_prv_inj { get; set; }
        public string sp_cv_prv_inj { get; set; }
        public string cv_bfr_inj { get; set; }
        public string reason_inj { get; set; }
        public string prg_cv_inj { get; set; }
        public string vaccine_reactions { get; set; }
        public string enum_reactions { get; set; }
        public string actual_medicines { get; set; }
        public string bfr_cv_medicines { get; set; }

        private PatientsVaccineInformationService _patientsVaccineInformation = new PatientsVaccineInformationService();

        public PatientsVaccineInformation()
        {
        }
        public PatientsVaccineInformation(int id, int medical_appoiment_id, string cv_prv_inj, string sp_cv_prv_inj, string cv_bfr_inj, string reason_inj, string prg_cv_inj, string vaccine_reactions, string enum_reactions, string actual_medicines, string bfr_cv_medicines)
        {
            this.id = id;
            this.medical_appoiment_id = medical_appoiment_id;
            this.cv_prv_inj = cv_prv_inj;
            this.sp_cv_prv_inj = sp_cv_prv_inj;
            this.cv_bfr_inj = cv_bfr_inj;
            this.reason_inj = reason_inj;
            this.prg_cv_inj = prg_cv_inj;
            this.vaccine_reactions = vaccine_reactions;
            this.enum_reactions = enum_reactions;
            this.actual_medicines = actual_medicines;
            this.bfr_cv_medicines = bfr_cv_medicines;
        }

        public async Task<IEnumerable<PatientsVaccineInformation>> PatientsVaccineInformations()
        {
            IEnumerable<PatientsVaccineInformation> patientsVaccineInformation_list = await this._patientsVaccineInformation.getList();
            return patientsVaccineInformation_list;
        }

        public async Task<PatientsVaccineInformation> Save()
        {
            var result = await this._patientsVaccineInformation.save(this);

            return result;
        }
    }
}
