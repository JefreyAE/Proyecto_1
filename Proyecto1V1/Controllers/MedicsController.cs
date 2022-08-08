using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Helpers;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class MedicsController : Controller
    {
        public IMailService _mailService;

        public MedicsController(IMailService mailService)
        {
            this._mailService = mailService;
        }

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

                if (collection["id"] == "")
                {
                    var existMedicId = await medic.GetByIdNumber(Convert.ToInt32(collection["id_number"]));
                    var existMedicProff = await medic.GetProfessionalCode(collection["professional_code"]);

                    if(existMedicId.id == 0 && existMedicProff.id != 0)
                    {
                        medic.id = existMedicProff.id;
                        var m1 = await medic.Update(existMedicProff.id);
                        HttpContext.Session.SetInt32("medic_id", medic.id);
                    }else if (existMedicId.id != 0 && existMedicProff.id == 0)
                    {
                        medic.id = existMedicId.id;
                        var m2 = await medic.Update(existMedicId.id);
                        HttpContext.Session.SetInt32("medic_id", medic.id);
                    }else{
                        var m = await medic.Save();
                        HttpContext.Session.SetInt32("medic_id", m.id);
                    }
                }
                else
                {
                    medic.id = Convert.ToInt32(collection["id"]);
                    var m = await medic.Update(Convert.ToInt32(collection["id"]));
                    HttpContext.Session.SetInt32("medic_id", medic.id);
                }

                _mailService.SendEmail(collection["email"], "Médico - Registrado en el sistema de control de vacunación COVID", "Como resultado de una consulta ha sido registrado en el sistema");
                return RedirectToAction("Create", "Clinics");

            }
            catch(Exception ex)
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
