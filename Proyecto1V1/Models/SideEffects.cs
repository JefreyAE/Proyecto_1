using Proyecto1V1.Services;

namespace Proyecto1V1.Models
{ 
    public class SideEffects
    {
        public int id { get; set; }
        public int? medical_appoiment_id { get; set; }
        public string symptoms_persists { get; set; }
        public string alergies_description { get; set; }
        public string other_conditions { get; set; }
        public string dev_cancer { get; set; }

        private SideEffectsService _sideEffectsService = new SideEffectsService();

        public SideEffects() { }
        public SideEffects(int id, int medical_appoiment_id, string symptoms_persists, string alergies_description, string other_conditions, string dev_cancer)
        {
            this.id = id;
            this.medical_appoiment_id = medical_appoiment_id;
            this.symptoms_persists = symptoms_persists;
            this.alergies_description = alergies_description;
            this.other_conditions = other_conditions;
            this.dev_cancer = dev_cancer;
        }

        public async Task<IEnumerable<SideEffects>> GetSideEffects()
        {
            IEnumerable<SideEffects> sideEffects_list = await this._sideEffectsService.getList();
            return sideEffects_list;
        }

        public async Task<SideEffects> Save()
        {
            var result = await this._sideEffectsService.save(this);

            return result;
        }

        public async Task<rel_effects_event_symptoms> SaveAdvSymptoms(rel_effects_event_symptoms rel)
        {
            var result = await this._sideEffectsService.saveAdvSymptomsSideEffects(rel);

            return result;
        }

        public async Task<rel_effects_alergies> SaveAlergies(rel_effects_alergies rel)
        {
            var result = await this._sideEffectsService.saveAlergiesSideEffects(rel);

            return result;
        }

        public async Task<rel_effects_diseases> SaveNewDiseases(rel_effects_diseases rel)
        {
            var result = await this._sideEffectsService.saveNewDiseasesSideEffects(rel);

            return result;
        }

        public async Task<rel_effects_symptoms> SaveSymptoms(rel_effects_symptoms rel)
        {
            var result = await this._sideEffectsService.saveSymptomsSideEffects(rel);

            return result;
        }
    }

    public class rel_effects_event_symptoms
    {
        public int id { get; set; }
        public int side_effects_id { get; set; }
        public int adv_event_symptoms_id { get; set; }
    }

    public class rel_effects_alergies
    {
        public int id { get; set; }
        public int side_effects_id { get; set; }
        public int alergies_id { get; set; }
    }

    public class rel_effects_diseases
    {
        public int id { get; set; }
        public int side_effects_id { get; set; }
        public int new_diseases_id { get; set; }
    }

    public class rel_effects_symptoms
    {
        public int id { get; set; }
        public int side_effects_id { get; set; }
        public int symptoms_id { get; set; }
    }
}
