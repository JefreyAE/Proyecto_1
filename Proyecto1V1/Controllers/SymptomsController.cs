using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class SymptomsController : Controller
    {
        // GET: SymptomsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SymptomsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SymptomsController/Create
        public async Task<ActionResult> Create()
        {
            Symptoms symptoms = new Symptoms();
            var symptomsList = await symptoms.GetSymptoms();

            ViewBag.Symptoms = symptomsList.ToList<Symptoms>();

            return View();
        }

        // POST: SymptomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                List<Symptoms> symptomsList = new List<Symptoms>();

                int size = collection.Count();
                int cont = 1;
                foreach (var d in collection)
                {
                    if (cont < size)
                    {
                        Symptoms simptoms = new Symptoms();
                        simptoms.id = Convert.ToInt32(d.Value);
                        symptomsList.Add(simptoms);
                    }
                    cont++;
                }

                var result = JsonConvert.SerializeObject(symptomsList);
                HttpContext.Session.SetString("symptoms", result);
                return RedirectToAction("Create", "SideEffects");
            }
            catch
            {
                return View();
            }
        }

        // GET: SymptomsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SymptomsController/Edit/5
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

        // GET: SymptomsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SymptomsController/Delete/5
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
