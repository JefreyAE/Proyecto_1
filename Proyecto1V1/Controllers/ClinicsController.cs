using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Helpers;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class ClinicsController : Controller
    {

        public IMailService _mailService;

        public ClinicsController(IMailService mailService)
        {
            this._mailService = mailService;
        }

        // GET: ClinicsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClinicsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                string submit_type = collection["submit1"];
                Clinics clinic = new Clinics();
                if (submit_type != null)
                {
                    clinic.name = collection["name"];
                    clinic.legal_certificate = collection["legal_certificate"];
                    clinic.country = collection["country"];
                    clinic.province = collection["province"];
                    clinic.canton = collection["canton"];
                    clinic.district = collection["district"];
                    clinic.phone_number = collection["phone_number"];
                    clinic.email = collection["email"];
                    clinic.web_site = collection["web_site"];

                    if (collection["id"] == "")
                    {                    
                        var existClinicName = await clinic.GetByName(collection["name"]);
                        var existClinicLegalCert = await clinic.GetByLegal_certificate(collection["legal_certificate"]);

                        if (existClinicName.id == 0 && existClinicLegalCert.id != 0)
                        {
                            clinic.id = existClinicLegalCert.id;
                            var m1 = await clinic.Update(existClinicLegalCert.id);
                            HttpContext.Session.SetInt32("clinic_id", clinic.id);
                        }
                        else if (existClinicName.id != 0 && existClinicLegalCert.id == 0)
                        {
                            clinic.id = existClinicName.id;
                            var m2 = await clinic.Update(existClinicName.id);
                            HttpContext.Session.SetInt32("clinic_id", clinic.id);
                        }
                        else
                        {
                            var m = await clinic.Save();
                            HttpContext.Session.SetInt32("clinic_id", m.id);
                        }
                    }
                    else
                    {
                        clinic.id = Convert.ToInt32(collection["id"]);
                        var m = await clinic.Update(Convert.ToInt32(collection["id"]));
                        HttpContext.Session.SetInt32("clinic_id", clinic.id);
                    }
                    _mailService.SendEmail(collection["email"], "Se ha registrado la clínica", "Como resultado de una consulta se ha registrado la clínica en el sistema, debido a una consulta.");
                }
                else
                {
                    clinic.name = "no-data";
                    clinic.legal_certificate = "no-data";
                    clinic.country = "no-data";
                    clinic.province = "no-data";
                    clinic.canton = "no-data";
                    clinic.district = "no-data";
                    clinic.phone_number = "no-data";
                    clinic.email = "no-data";
                    clinic.web_site = "no-data";
                }

                return RedirectToAction("Create", "Patients");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ClinicsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicsController/Edit/5
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

        // GET: ClinicsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicsController/Delete/5
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
