using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class VaccinesController : Controller
    {
        // GET: VaccinesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VaccinesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VaccinesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Vaccines vaccine = new Vaccines();
                vaccine.medical_appoiment_id = HttpContext.Session.GetInt32("medical_appoiment_id");
                vaccine.name = collection["name"];
                vaccine.brand = collection["brand"];
                vaccine.application_date = collection["application_date"];
                vaccine.lot_number = collection["lot_number"];
                vaccine.expiration_date = collection["expiration_date"];
                vaccine.application_place = collection["application_place"];
                vaccine.observations = collection["observations"];
                var v = await vaccine.Save();
                HttpContext.Session.SetInt32("vaccine_id", v.id);


                var vaccines = HttpContext.Session.GetString("vaccines");
                List<Vaccines> vaccinesList = new List<Vaccines>();
                if(vaccines != null)
                {
                    vaccinesList = JsonConvert.DeserializeObject<List<Vaccines>>(vaccines);
                }             
                
                vaccinesList.Add(v);
               
                var result = JsonConvert.SerializeObject(vaccinesList);
                HttpContext.Session.SetString("vaccines", result);


                string submit_type = collection["submit1"];
                if(submit_type != null)
                {
                    return RedirectToAction("Create", "PatientsVaccineInformation");
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: VaccinesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VaccinesController/Edit/5
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

        // GET: VaccinesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VaccinesController/Delete/5
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
