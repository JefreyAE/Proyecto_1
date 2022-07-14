namespace Proyecto_1API.Models
{
    public class SideEffects
    {
        public int id { get; set; }
        public int medical_appointments_id { get; set; }
        public string symptoms_persists { get; set; }
        public string alergies_description { get; set; }
        public string other_conditions { get; set; }
        public string dev_cancer { get; set; }
    }
}
