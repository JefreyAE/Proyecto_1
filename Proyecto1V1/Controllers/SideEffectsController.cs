using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class SideEffectsController : Controller
    {
        // GET: SideEffectsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SideEffectsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SideEffectsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SideEffectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                SideEffects sideEffects = new SideEffects();
                sideEffects.medical_appoiment_id = HttpContext.Session.GetInt32("medical_appoiment_id");
                sideEffects.symptoms_persists = collection["symptoms_persists"];
                sideEffects.alergies_description = collection["alergies_description"];
                sideEffects.other_conditions = collection["other_conditions"];
                sideEffects.dev_cancer = collection["dev_cancer"];

                var mp = await sideEffects.Save();

                var advEventSymptoms = HttpContext.Session.GetString("advEventSymptoms");
                var advEventObjects = JsonConvert.DeserializeObject<List<AdvEventSymptoms>>(advEventSymptoms);
                if (advEventObjects != null)
                {
                    foreach (var item in advEventObjects)
                    {
                        rel_effects_event_symptoms rel = new rel_effects_event_symptoms();
                        rel.side_effects_id = mp.id;
                        rel.adv_event_symptoms_id = item.id;

                        await sideEffects.SaveAdvSymptoms(rel);
                    }
                }
                var alergies = HttpContext.Session.GetString("alergies");
                var alergiesObjects = JsonConvert.DeserializeObject<List<Alergies>>(advEventSymptoms);
                if (alergiesObjects != null)
                {
                    foreach (var item in alergiesObjects)
                    {
                        rel_effects_alergies rel = new rel_effects_alergies();
                        rel.side_effects_id = mp.id;
                        rel.alergies_id = item.id;

                        await sideEffects.SaveAlergies(rel);
                    }
                }

                var newDiseases = HttpContext.Session.GetString("newDiseases");
                var newDiseasesObjects = JsonConvert.DeserializeObject<List<NewDiseases>>(newDiseases);
                if (newDiseasesObjects != null)
                {
                    foreach (var item in newDiseasesObjects)
                    {
                        rel_effects_diseases rel = new rel_effects_diseases();
                        rel.side_effects_id = mp.id;
                        rel.new_diseases_id = item.id;

                        await sideEffects.SaveNewDiseases(rel);
                    }
                }

                var symptoms = HttpContext.Session.GetString("symptoms");
                var symptomsObjects = JsonConvert.DeserializeObject<List<Symptoms>>(symptoms);
                if (symptomsObjects != null)
                {
                    foreach (var item in symptomsObjects)
                    {
                        rel_effects_symptoms rel = new rel_effects_symptoms();
                        rel.side_effects_id = mp.id;
                        rel.symptoms_id = item.id;

                        await sideEffects.SaveSymptoms(rel);
                    }
                }

                return RedirectToAction("/", "Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SideEffectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SideEffectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SideEffectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SideEffectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
