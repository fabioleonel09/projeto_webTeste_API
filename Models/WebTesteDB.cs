using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace webTesteAPI.Models
{
    public class WebTesteDB : DbContext
    {
        public WebTesteDB() : base("name=WebTesteDB")
        { 
        }

        public DbSet<tabelaPaciente> tabelaPacientes { get; set; }
        public DbSet<tabelaAudiometria> tabelaAudiometrias { get; set; }
        public DbSet<tabelaImpedanciometria> tabelaImpedanciometrias { get; set; }
    }
}