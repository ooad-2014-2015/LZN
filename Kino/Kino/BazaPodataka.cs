using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Baza : DbContext
    {
        public Baza()
            : base("KinoBaza")
        {

        }

        public DbSet<Artikal> Artiki { get; set; }
        public DbSet<Cjenovnik> Cjenovnici { get; set; }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<SedmicniRaspored> SedmicniRasporedi { get; set; }
        public DbSet<Projekcija> Projekcije { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
