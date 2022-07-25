using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class PatientsVaccineInformationController : Controller
    {
        // GET: PatientsVaccineInformationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientsVaccineInformationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientsVaccineInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsVaccineInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var medical_appoiment_id = HttpContext.Session.GetInt32("medical_appoiment_id");
                PatientsVaccineInformation patient_information = new PatientsVaccineInformation();
                patient_information.medical_appoiment_id = medical_appoiment_id;
                patient_information.cv_prv_inj = collection["cv_prv_inj"];
                patient_information.sp_cv_prv_inj = collection["sp_cv_prv_inj"];
                patient_information.cv_bfr_inj = collection["cv_bfr_inj"];
                patient_information.reason_inj = collection["reason_inj"];
                patient_information.prg_cv_inj = collection["prg_cv_inj"];
                patient_information.vaccine_reactions = collection["vaccine_reactions"];
                patient_information.enum_reactions = collection["enum_reactions"];
                patient_information.actual_medicines = collection["actual_medicines"];
                patient_information.bfr_cv_medicines = collection["bfr_cv_medicines"];

                var p = await patient_information.Save();

                return RedirectToAction("Create", "AdvEventSymptoms");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsVaccineInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsVaccineInformationController/Edit/5
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

        // GET: PatientsVaccineInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsVaccineInformationController/Delete/5
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
