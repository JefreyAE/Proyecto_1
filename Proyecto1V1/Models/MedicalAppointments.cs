namespace Proyecto_1API.Models
{
    public class MedicalAppointments
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public int medic_id { get; set; }
        public string date { get; set; }
}
}
