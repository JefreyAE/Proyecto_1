using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Helpers;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class PatientsController : Controller
    {
        public IMailService _mailService;

        public PatientsController(IMailService mailService)
        {
            this._mailService = mailService;
        }

        // GET: PatientsControllercs
        public async Task<ActionResult> Index()
        {
            Patients patient = new Patients();

            var x = await patient.GetPatients();

            return View(x);
        }

        // GET: PatientsControllercs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientsControllercs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Patients patient = new Patients();
                patient.id_number = collection["id_number"];
                patient.name = collection["name"];
                patient.surname_1 = collection["surname_1"];
                patient.surname_2 = collection["surname_2"];
                patient.birth_date = collection["birth_date"];
                patient.gender = collection["gender"];
                patient.contact_number = collection["contact_number"];
                patient.country = collection["country"];
                patient.province = collection["province"];
                patient.canton = collection["canton"];
                patient.district = collection["district"];
                patient.marital_status = collection["marital_status"];
                patient.phone_number = collection["phone_number"];
                patient.email = collection["email"];
                patient.register_date = collection["register_date"];
                patient.occupation = collection["occupation"];

                if (collection["id"] == "")
                {
                    var p = await patient.Save();
                    HttpContext.Session.SetInt32("patient_id", p.id);
                }
                else
                {
                    patient.id = Convert.ToInt32(collection["id"]);
                    var m = await patient.Update(Convert.ToInt32(collection["id"]));
                    HttpContext.Session.SetInt32("patient_id", patient.id);
                }

                _mailService.SendEmail(collection["email"], "Paciente - Registrado en el sistema de control de vacunación COVID", "Como resultado de una consulta ha sido registrado en el sistema");

                return RedirectToAction("RedirectedCreate", "MedicalAppointments");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsControllercs/Edit/5
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

        // GET: PatientsControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsControllercs/Delete/5
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
