using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1V1.Helpers;
using Proyecto1V1.Models;

namespace Proyecto1V1.Controllers
{
    public class ReportController : Controller
    {
        public IMailService _mailService;

        public ReportController(IMailService mailService)
        {
            this._mailService = mailService;
        }
        // GET: ReportController
        public async Task<ActionResult> Index()
        {
            var medic_id = HttpContext.Session.GetInt32("medic_id");
            var patient_id = HttpContext.Session.GetInt32("patient_id");
            var clinic_id = HttpContext.Session.GetInt32("clinic_id");
            var medical_appoiment_id = HttpContext.Session.GetInt32("medical_appoiment_id");
            var patient_information_id = HttpContext.Session.GetInt32("patient_information_id");
            var sideEffects_id = HttpContext.Session.GetInt32("sideEffects_id");

            var md = await new Medics().Get(medic_id);
            var pd = await new Patients().Get(patient_id);
            var cd = await new Clinics().Get(clinic_id);
            var mad = await new MedicalAppointments().Get(medical_appoiment_id);
            var pvid = await new PatientsVaccineInformation().Get(patient_information_id);
            var sed = await new SideEffects().Get(sideEffects_id);

            ViewBag.medic = md;
            ViewBag.patient = pd;
            ViewBag.clinic = cd;
            ViewBag.medicalAppointment = mad;
            ViewBag.patientVaccioneInformation = pvid;
            ViewBag.sideEffects = sed;
  
            List<Vaccines> vaccinesList = LoadVaccinesList();
            ViewBag.vaccionesList = vaccinesList;
  
            List<AdvEventSymptoms> advEvetntSymptomsList = await LoadAdvEventSymptomsList();
            ViewBag.advEventsSymptomsList = advEvetntSymptomsList;

            List<Alergies> alergiesList = await LoadAlergiesList();
            ViewBag.alergiesList = alergiesList;

            List<NewDiseases> newDiseaseList = await LoadNewDiseasesList();
            ViewBag.newDiseasesList = newDiseaseList;
      
            List<Symptoms> symptomsList = await LoadSymptomsList();
            ViewBag.symptomsList = symptomsList;

            var report_email = createReport(md, pd, cd,  mad, vaccinesList, alergiesList, advEvetntSymptomsList, newDiseaseList, symptomsList, sed, pvid);
            _mailService.SendEmail(pd.email, "Reporte de la consulta al paciente", report_email);
            _mailService.SendEmail(md.email, "Reporte de la consulta al médico", report_email);

            return View();
        }

        public List<Vaccines> LoadVaccinesList()
        {
            var vaccines = HttpContext.Session.GetString("vaccines");
            List<Vaccines> vaccinesList = new List<Vaccines>();
            if (vaccines != null)
            {
                vaccinesList = JsonConvert.DeserializeObject<List<Vaccines>>(vaccines);
            }

            return vaccinesList;
        }
        public async Task< List<AdvEventSymptoms>> LoadAdvEventSymptomsList()
        {
            var advEventSymptoms = HttpContext.Session.GetString("advEventSymptoms");
            var advEventObjects = JsonConvert.DeserializeObject<List<AdvEventSymptoms>>(advEventSymptoms);
            List<AdvEventSymptoms> advEventtSymptomsList = new List<AdvEventSymptoms>();
            if (advEventObjects != null)
            {
                foreach (var item in advEventObjects)
                {
                    AdvEventSymptoms advEventSymptom = new AdvEventSymptoms();
                    var r = await advEventSymptom.Get(item.id);
                    advEventtSymptomsList.Add(r);
                }
            }

            return advEventtSymptomsList;
        }
        public async Task<List<Alergies>> LoadAlergiesList()
        {
            var alergies = HttpContext.Session.GetString("alergies");
            var alergiesObjects = JsonConvert.DeserializeObject<List<Alergies>>(alergies);
            List<Alergies> alergiesList = new List<Alergies>();
            if (alergiesObjects != null)
            {
                foreach (var item in alergiesObjects)
                {
                    Alergies Alergie = new Alergies();
                    var r = await Alergie.Get(item.id);
                    alergiesList.Add(r);
                }
            }

            return alergiesList;
        }

        public async Task<List<Symptoms>> LoadSymptomsList()
        {
            var symptoms = HttpContext.Session.GetString("symptoms");
            var symptomsObjects = JsonConvert.DeserializeObject<List<Symptoms>>(symptoms);
            List<Symptoms> symptomsList = new List<Symptoms>();
            if (symptomsObjects != null)
            {
                foreach (var item in symptomsObjects)
                {
                    Symptoms Symptom = new Symptoms();
                    var r = await Symptom.Get(item.id);
                    symptomsList.Add(r);
                }
            }

            return symptomsList;
        }

        public async Task<List<NewDiseases>> LoadNewDiseasesList()
        {
            var newDiseases = HttpContext.Session.GetString("newDiseases");
            var newDiseasesObjects = JsonConvert.DeserializeObject<List<NewDiseases>>(newDiseases);
            List<NewDiseases> newDiseaseList = new List<NewDiseases>();
            if (newDiseasesObjects != null)
            {
                foreach (var item in newDiseasesObjects)
                {
                    NewDiseases NewDisease = new NewDiseases();
                    var r = await NewDisease.Get(item.id);
                    newDiseaseList.Add(r);
                }
            }

            return newDiseaseList;
        }

        public string createReport(Medics md, Patients pd, Clinics cd, MedicalAppointments mad, List<Vaccines> vaccinesList, List<Alergies> alergiesList, List<AdvEventSymptoms> advEvetntSymptomsList, List<NewDiseases> newDiseaseList, List<Symptoms> symptomsList, SideEffects sed,
            PatientsVaccineInformation pvid)
        {
            string report_email = "";

            var medic_html = "<h1>Reporte de la consulta</h1>" +
               "<br><h2>Médico que realiza la consulta</h2>" +
               "<table class='table'><thead>" +
               "<tr>" +
                   "<th>Identificación</th>" +
                   "<th>Código profesional</th>" +
                   "<th>Nombre completo</th>" +
                   "<th>Correo electrónico</th>" +
                   "<th>País</th>" +
                   "<th>Provincia</th>" +
                   "<th>Cantón</th>" +
               "</tr>" +
               "</thead>" +
               "<tbody>" +
                   "<tr>" +
                       "<td>" + md.id_number + "</td>" +
                       "<td>" + md.professional_code + "</td>" +
                       "<td>" + md.full_name + "</td>" +
                       "<td>" + md.email + "</td>" +
                       "<td>" + md.country + "</td>" +
                       "<td>" + md.province + "</td>" +
                       "<td>" + md.canton + "</td>" +
                   "</tr>" +
               "</tbody>" +
               "</table>" +
               "<br>";

            var clinic_html = "<br><h2>Clínica donde se realiza la consulta</h2>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>Nombre de la clínica</th>" +
                    "<th>Cédula jurídica</th>" +
                    "<th>País</th>" +
                    "<th>Provincia</th>" +
                    "<th>Cantón</th>" +
                    "<th>Distrito</th>" +
                    "<th>Teléfono administrativo</th>" +
                    "<th>Correo electrónico</th>" +
                    "<th>Sitio Web</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                    "<tr>" +
                        "<td>" + cd.name + "</td>" +
                        "<td>" + cd.legal_certificate + "</td>" +
                        "<td>" + cd.country + "</td>" +
                        "<td>" + cd.province + "</td>" +
                        "<td>" + cd.canton + "</td>" +
                        "<td>" + cd.district + "</td>" +
                        "<td>" + cd.phone_number + "</td>" +
                        "<td>" + cd.email + "</td>" +
                        "<td>" + cd.web_site + "</td>" +
                    "</tr>" +
                "</tbody>" +
                "</table>" +
                "<br>";

            var patient_html = "<br><h2>Datos del paciente</h2>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>Nombre del paciente</th>" +
                    "<th>Número de identificación</th>" +
                    "<th>Fecha de nacimiento</th>" +
                    "<th>Sexo</th>" +
                    "<th>Número de contacto</th>" +
                    "<th>País</th>" +
                    "<th>Provincia/estado</th>" +
                    "<th>Cantón</th>" +
                    "<th>Distrito</th>" +
                    "<th>Estado civil</th>" +
                    "<th>Teléfono</th>" +
                    "<th>Correo electrónico</th>" +
                    "<th>Fecha de registro</th>" +
                    "<th>Ocupación u oficio</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                    "<tr>" +
                        "<td>" + pd.name + "</td>" +
                        "<td>" + pd.id_number + "</td>" +
                        "<td>" + pd.birth_date + "</td>" +
                        "<td>" + pd.gender + "</td>" +
                        "<td>" + pd.contact_number + "</td>" +
                        "<td>" + pd.country + "</td>" +
                        "<td>" + pd.province + "</td>" +
                        "<td>" + pd.canton + "</td>" +
                        "<td>" + pd.district + "</td>" +
                        "<td>" + pd.marital_status + "</td>" +
                        "<td>" + pd.phone_number + "</td>" +
                        "<td>" + pd.email + "</td>" +
                        "<td>" + pd.register_date + "</td>" +
                        "<td>" + pd.occupation + "</td>" +
                    "</tr>" +
                "</tbody>" +
                "</table>" +
                "<br>";

            var date_html = "<br/><h2>Datos de la cita </h2><h3> Fecha: " + mad.date + "</h2>";

            var vaccine_html1 = "<br/><h2>Vacunas COVID que se aplicó el paciente</h2>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>Nombre</th>" +
                    "<th>Marca</th>" +
                    "<th>Fecha de aplicación</th>" +
                    "<th>Lugar de aplicación</th>" +
                    "<th>Número de lote</th>" +
                    "<th>Observaciones</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            var vaccine_html2 = "";
            foreach (var vaccine in vaccinesList)
            {
                vaccine_html2 += "<tr>" +
                            "<td>" + vaccine.name + "</td>" +
                            "<td>" + vaccine.brand + "</td>" +
                            "<td>" + vaccine.application_date + "</td>" +
                            "<td>" + vaccine.application_place + "</td>" +
                            "<td>" + vaccine.lot_number + "</td>" +
                            "<td>" + vaccine.observations + "</td>" +
                     "</tr>";
            }
            var vaccine_html3 = "</tbody>" +
               "</table>" +
               "<br>";

            var vaccine_html = vaccine_html1 + vaccine_html2 + vaccine_html3;

            var patientsVaccineInformation_html = "<br><h2>Información previa del paciente</h2>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>¿Ha tenido COVID previo a inyectarse?</th>" +
                    "<th>¿Ha tenido sospecha de haber tenido COVID antes de ponerte lainyección ?</th>" +
                    "<th>¿Ha tenido COVID después de tomar la inyección?</th>" +
                    "<th>¿Razón de inyectarse contra COVID?</th>" +
                    "<th>¿Estaba embarazada al inyectarse contra COVID? Si aplica</th>" +
                    "<th>¿Ha tenido reacciones a vacunas en el pasado?</th>" +
                    "<th>Medicamentos actuales con receta: enumere todos los medicamentos y las dosis.</th>" +
                    "<th>Nuevos medicamentos recetados que tuvieron que ser iniciados después de la(s) inyección(es) de COVID</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                    "<tr>" +
                        "<td>" + pvid.cv_prv_inj + "</td>" +
                        "<td>" + pvid.sp_cv_prv_inj + "</td>" +
                        "<td>" + pvid.cv_bfr_inj + "</td>" +
                        "<td>" + pvid.reason_inj + "</td>" +
                        "<td>" + pvid.prg_cv_inj + "</td>" +
                        "<td>" + pvid.vaccine_reactions + "</td>" +
                        "<td>" + pvid.enum_reactions + "</td>" +
                        "<td>" + pvid.actual_medicines + "</td>" +
                        "<td>" + pvid.bfr_cv_medicines + "</td>" +
                    "</tr>" +
                "</tbody>" +
                "</table>" +
                "<br>";

            var sideEffect_html = "<br><h3>Como resultado de la aplicación de la vacuna o vacunas se experimentaron los siguientes efectos secundarios</h3>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>Descripción detallada de las alergias</th>" +
                    "<th>¿Si ha desarrollado un nuevo cáncer o la reaparición de un cáncer existente después de la inyección de COVID, especifique el tipo de cáncer?</th>" +
                    "<th>Otras condiciones</th>" +
                    "<th>¿Persisten los sintomas?</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                    "<tr>" +
                        "<td>" + sed.alergies_description + "</td>" +
                        "<td>" + sed.dev_cancer + "</td>" +
                        "<td>" + sed.other_conditions + "</td>" +
                        "<td>" + sed.symptoms_persists + "</td>" +
                    "</tr>" +
                "</tbody>" +
                "</table>" +
                "<br>";

            var advEventSymptoms_html1 = "<br><h3>Como resultado de la aplicación de la vacuna o vacunas se experimentaron los siguientes efectos adversos</h3>" +
                "<table class='table'><thead>" +
                "<tr>" +
                    "<th>Descripción</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            var advEventSymptoms_html2 = "";
            foreach (var adv in advEvetntSymptomsList)
            {
                advEventSymptoms_html2 += "<tr>" +
                            "<td>" + adv.description + "</td>" +
                     "</tr>";
            }
            var advEventSymptoms_html3 = "</tbody>" +
               "</table>";
            var advEventSymptoms_html = advEventSymptoms_html1 + advEventSymptoms_html2 + advEventSymptoms_html3;

            var alergiesList_html1 = "<br><h3>Como resultado de la aplicación de la vacuna o vacunas se experimentaron las siguientes alergias</h3>" +
                "<table class='table'><thead>" +
                " <tr>" +
                    "<th>Descripción</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            var alergiesList_html2 = "";
            foreach (var aler in alergiesList)
            {
                alergiesList_html2 += "<tr>" +
                            "<td>" + aler.description + "</td>" +
                     "</tr>";
            }
            var alergiesList_html3 = "</tbody>" +
               "</table>";
            var alergiesList_html = alergiesList_html1 + alergiesList_html2 + alergiesList_html3;

            var newDiseaseList_html1 = "<br><h3>Como resultado de la aplicación de la vacuna o vacunas se experimentaron las siguientes nuevas enfermedades</h3>" +
                "<table class='table'><thead>" +
                " <tr>" +
                    "<th>Descripción</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            var newDiseaseList_html2 = "";
            foreach (var newDe in newDiseaseList)
            {
                newDiseaseList_html2 += "<tr>" +
                            "<td>" + newDe.description + "</td>" +
                     "</tr>";
            }
            var newDiseaseList_html3 = "</tbody>" +
               "</table>";
            var newDiseaseList_html = newDiseaseList_html1 + newDiseaseList_html2 + newDiseaseList_html3;

            var symptomsList_html1 = "<br><h3>Como resultado de la aplicación de la vacuna o vacunas se experimentaron siguientes sintomas</h3>" +
                "<table class='table'><thead>" +
                " <tr>" +
                    "<th>Descripción</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            var symptomsList_html2 = "";
            foreach (var syL in symptomsList)
            {
                symptomsList_html2 += "<tr>" +
                            "<td>" + syL.description + "</td>" +
                     "</tr>";
            }
            var symptomsList_html3 = "</tbody>" +
               "</table>";
            var symptomsList_html = symptomsList_html1 + symptomsList_html2 + symptomsList_html3;

            report_email = medic_html + clinic_html + patient_html + date_html + vaccine_html + patientsVaccineInformation_html + sideEffect_html + advEventSymptoms_html + alergiesList_html + newDiseaseList_html + symptomsList_html;

            HttpContext.Session.Clear();

            return report_email;
        }

        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController/Create
        public async Task<ActionResult> Create()
        {
            
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController/Edit/5
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

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
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
