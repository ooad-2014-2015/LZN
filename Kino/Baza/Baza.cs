using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    class BazaPodataka : DbContext
    {
        public BazaPodataka() : base("BazaPodataka")
        {

        }

        public DbSet<FilmB> Filmovi { get; set; }
        public DbSet<ArtikalB> Artikli { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
