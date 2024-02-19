using AgremiacionOdontologica.Controllers.Models;
using AgremiacionOdontologica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Data
{
    public class ApiDb : DbContext
    {
        public ApiDb(DbContextOptions<ApiDb> options) : base(options)
        {

        }

        public DbSet<Domicilio> Domicilio => Set<Domicilio>();
        public DbSet<Localidad> Localidad => Set<Localidad>();
        public DbSet<Provincia> Provincia => Set<Provincia>();
        public DbSet<Odontologo> Odontologo => Set<Odontologo>();
        public DbSet<OdontologoEstado> OdontologoEstado => Set<OdontologoEstado>();
        public DbSet<Entrega> Entrega => Set<Entrega>();
        public DbSet<ObraSocial> ObraSocial => Set<ObraSocial>();
        public DbSet<BonoEstado> BonoEstado => Set<BonoEstado>();
        public DbSet<Paciente> Paciente => Set<Paciente>();
        public DbSet<Practica> Practica => Set<Practica>();
        public DbSet<Bono> Bono => Set<Bono>();



    }
}
/* 
 comando para migraciones: 
 dotnet ef migrations add NameMigration
 dotnet ef database update  
 
*/
