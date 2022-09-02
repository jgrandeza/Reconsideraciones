using System;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class DataContextApp : DbContext
    {
        public DataContextApp(DbContextOptions<DataContextApp> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<A_COMPONENTES> A_COMPONENTES { get; set; }
        public DbSet<A_TIPODOCIDENTIDAD> A_TIPODOCIDENTIDAD  { get; set; }
        public DbSet<A_SEXO> A_SEXO { get; set; }
        public DbSet<A_TIPOATENCION> A_TIPOATENCION { get; set; }

        public DbSet<M_SERVICIOS> M_SERVICIOS { get; set; }
        public DbSet<A_LUGARATENCION> A_LUGARATENCION { get; set; }
        public DbSet<A_CONDICIONMATERNA> A_CONDICIONMATERNA { get; set; }
    }
}

