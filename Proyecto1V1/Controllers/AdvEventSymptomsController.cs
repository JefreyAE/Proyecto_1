using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class AdvEventSymptomsController : Controller
    {
        // GET: AdvEventSymptomsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdvEventSymptomsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvEventSymptomsController/Create
        public async Task<ActionResult> Create()
        {
            AdvEventSymptoms advEventSymptoms = new AdvEventSymptoms();
            var advEventSymptomsList = await advEventSymptoms.GetEventSymptoms();

            ViewBag.AdvEventSymptoms = advEventSymptomsList.ToList<AdvEventSymptoms>();

            return View();
        }

        // POST: AdvEventSymptomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                List<AdvEventSymptoms> advEventSymptomsList = new List<AdvEventSymptoms>();

                int size = collection.Count();
                int cont = 1;
                foreach( var d in collection)
                {
                    if (cont < size)
                    {
                        AdvEventSymptoms adv = new AdvEventSymptoms();
                        adv.id = Convert.ToInt32(d.Value);
                        advEventSymptomsList.Add(adv);
                    }
                    cont++;
                }
         
                var result = JsonConvert.SerializeObject(advEventSymptomsList);
                HttpContext.Session.SetString("advEventSymptoms", result);
                return RedirectToAction("Create", "Alergies");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvEventSymptomsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvEventSymptomsController/Edit/5
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

        // GET: AdvEventSymptomsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvEventSymptomsController/Delete/5
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
