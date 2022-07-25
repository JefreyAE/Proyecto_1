using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{
    public class MedicalAppointments
    {
        public int id { get; set; }
        public int? patient_id { get; set; }
        public int? medic_id { get; set; }
        public int? clinic_id { get; set; }
        public string date { get; set; }

        private MedicalAppointmentsService _medicalServices = new MedicalAppointmentsService();
        public MedicalAppointments() { }

        public MedicalAppointments(int id, int patient_id, int medic_id, string date)
        {
            this.id = id;
            this.patient_id = patient_id;
            this.medic_id = medic_id;
            this.date = date;
        }

        public async Task<IEnumerable<MedicalAppointments>> GetMedicalAppointments()
        {
            IEnumerable<MedicalAppointments> medical_list = await this._medicalServices.getList();
            return medical_list;
        }

        public async Task<MedicalAppointments> Save()
        {
            var result = await this._medicalServices.save(this);

            return result;
        }
    }
}
