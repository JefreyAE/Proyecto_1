using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class AlergiesController : Controller
    {
        // GET: AlergiesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AlergiesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlergiesController/Create
        public async Task<ActionResult> Create()
        {
            Alergies alergies = new Alergies();
            var alergiesList = await alergies.GetAlergies();

            ViewBag.Alergies = alergiesList.ToList<Alergies>();
            return View();
        }

        // POST: AlergiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                List<Alergies> alergiesList = new List<Alergies>();

                int size = collection.Count();
                int cont = 1;
                foreach (var d in collection)
                {
                    if (cont < size)
                    {
                        Alergies ale = new Alergies();
                        ale.id = Convert.ToInt32(d.Value);
                        alergiesList.Add(ale);
                    }
                    cont++;
                }

                var result = JsonConvert.SerializeObject(alergiesList);
                HttpContext.Session.SetString("alergies", result);
                return RedirectToAction("Create", "NewDiseases");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlergiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlergiesController/Edit/5
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

        // GET: AlergiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlergiesController/Delete/5
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
