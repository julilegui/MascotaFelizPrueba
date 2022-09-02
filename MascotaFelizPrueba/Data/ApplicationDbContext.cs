using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MascotaFelizPrueba.Models;

namespace MascotaFelizPrueba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MascotaFelizPrueba.Models.Dueno> Dueno { get; set; }
        public DbSet<MascotaFelizPrueba.Models.Historia> Historia { get; set; }
        public DbSet<MascotaFelizPrueba.Models.Mascota> Mascota { get; set; }
        public DbSet<MascotaFelizPrueba.Models.Persona> Persona { get; set; }
        public DbSet<MascotaFelizPrueba.Models.Veterinario> Veterinario { get; set; }
        public DbSet<MascotaFelizPrueba.Models.VisitaPyP> VisitaPyP { get; set; }
    }
}
