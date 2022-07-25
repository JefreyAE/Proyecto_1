﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class ClinicsController : Controller
    {
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
                Clinics clinic = new Clinics();
                clinic.name = collection["name"];
                clinic.legal_certificate = collection["legal_certificate"];
                clinic.country = collection["country"];
                clinic.province = collection["province"];
                clinic.canton = collection["canton"];
                clinic.district = collection["district"];
                clinic.phone_number = collection["phone_number"];
                clinic.email = collection["email"];
                clinic.web_site = collection["web_site"];
                var c = await clinic.Save();
                HttpContext.Session.SetInt32("clinic_id", c.id);

                return RedirectToAction("Create","Patients");
            }
            catch
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
