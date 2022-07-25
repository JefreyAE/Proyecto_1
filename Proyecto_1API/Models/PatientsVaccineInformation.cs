namespace Proyecto_1API.Models
{
    public class PatientsVaccineInformation
    {
        public int id { get; set; }
        public int medical_appoiment_id { get; set; }
        public string cv_prv_inj { get; set; }
        public string sp_cv_prv_inj { get; set; }
        public string cv_bfr_inj { get; set; }
        public string reason_inj { get; set; }
        public string prg_cv_inj { get; set; }
        public string vaccine_reactions { get; set; }
        public string enum_reactions { get; set; }
        public string actual_medicines { get; set; }
        public string bfr_cv_medicines { get; set; }
    }
}
