namespace Proyecto_1API.Models
{
    public class SideEffects
    {
        public int id { get; set; }
        public int medical_appoiment_id { get; set; }
        public string symptoms_persists { get; set; }
        public string alergies_description { get; set; }
        public string other_conditions { get; set; }
        public string dev_cancer { get; set; }

        //public List<rel_effects_event_symptoms>? rel_Effects_Event_Symptoms_list { get; set; }

    }

    public class rel_effects_event_symptoms
    {
        public int id { get; set; }
        public int side_effects_id { get; set; }
        public int adv_event_symptoms_id { get; set; }

        //public Symptoms? Symptoms { get; set; }
        //public SideEffects? SideEffects { get; set; }   
    }

}
