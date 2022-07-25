using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class MedicsController : Controller
    {
        // GET: MedicsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Medics medic = new Medics();
                medic.id_number = collection["id_number"];
                medic.professional_code = collection["professional_code"];
                medic.email = collection["email"];
                medic.full_name = collection["full_name"];
                medic.country = collection["country"];
                medic.province = collection["province"];
                medic.canton = collection["canton"];
                var m = await medic.Save();
                HttpContext.Session.SetInt32("medic_id", m.id);

                return RedirectToAction("Create", "Clinics");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicsController/Edit/5
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

        // GET: MedicsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicsController/Delete/5
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
