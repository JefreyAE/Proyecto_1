using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class MedicalAppointmentsController : Controller
    {
        // GET: MedicalAppointmentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicalAppointmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalAppointmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> RedirectedCreate()
        {
            try
            {
                var medic_id = HttpContext.Session.GetInt32("medic_id");
                var patient_id = HttpContext.Session.GetInt32("patient_id");
                var clinic_id = HttpContext.Session.GetInt32("clinic_id");

                MedicalAppointments medicalAppointment = new MedicalAppointments();

                medicalAppointment.patient_id = patient_id;
                medicalAppointment.medic_id = medic_id;
                medicalAppointment.clinic_id = clinic_id;
                medicalAppointment.date = DateTime.Now.ToString();
                var mp = await medicalAppointment.Save();
                HttpContext.Session.SetInt32("medical_appoiment_id", mp.id);

                return RedirectToAction("Create","Vaccines");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalAppointmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalAppointmentsController/Edit/5
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

        // GET: MedicalAppointmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalAppointmentsController/Delete/5
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
