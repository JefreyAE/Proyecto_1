using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class NewDiseasesController : Controller
    {
        // GET: NewDiseasesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewDiseasesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewDiseasesController/Create
        public async Task<ActionResult> Create()
        {
            NewDiseases newDiseases = new NewDiseases();
            var newDiseasesList = await newDiseases.GetNewDiseases();

            ViewBag.NewDiseases = newDiseasesList.ToList<NewDiseases>();
            return View();
        }

        // POST: NewDiseasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                List<NewDiseases> newDiseasesList = new List<NewDiseases>();

                int size = collection.Count();
                int cont = 1;
                foreach (var d in collection)
                {
                    if (cont < size)
                    {
                        NewDiseases nd = new NewDiseases();
                        nd.id = Convert.ToInt32(d.Value);
                        newDiseasesList.Add(nd);
                    }
                    cont++;
                }

                var result = JsonConvert.SerializeObject(newDiseasesList);
                HttpContext.Session.SetString("newDiseases", result);
                return RedirectToAction("Create", "Symptoms");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewDiseasesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewDiseasesController/Edit/5
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

        // GET: NewDiseasesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewDiseasesController/Delete/5
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
