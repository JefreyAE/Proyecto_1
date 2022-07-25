using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_1API.Models;

namespace Proyecto_1API.Data
{
    public class Proyecto_1APIContext : DbContext
    {
        public Proyecto_1APIContext (DbContextOptions<Proyecto_1APIContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_1API.Models.AdvEventSymptoms>? AdvEventSymptoms { get; set; }

        public DbSet<Proyecto_1API.Models.Alergies>? Alergies { get; set; }

        public DbSet<Proyecto_1API.Models.Clinics>? Clinics { get; set; }

        public DbSet<Proyecto_1API.Models.MedicalAppointments>? MedicalAppointments { get; set; }

        public DbSet<Proyecto_1API.Models.Medics>? Medics { get; set; }

        public DbSet<Proyecto_1API.Models.NewDiseases>? NewDiseases { get; set; }

        public DbSet<Proyecto_1API.Models.PatientsVaccineInformation>? PatientsVaccineInformation { get; set; }

        public DbSet<Proyecto_1API.Models.SideEffects>? SideEffects { get; set; }

        public DbSet<Proyecto_1API.Models.Symptoms>? Symptoms { get; set; }

        public DbSet<Proyecto_1API.Models.Vaccines>? Vaccines { get; set; }

        public DbSet<Proyecto_1API.Models.Patients>? Patients { get; set; }

        //Tables de relaciones de muchos a muchos
        public DbSet<Proyecto_1API.Models.rel_effects_event_symptoms>? rel_effects_event_symptoms  { get; set; }

}
}
