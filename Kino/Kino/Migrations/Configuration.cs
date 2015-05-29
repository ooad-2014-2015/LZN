namespace Kino.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Baza>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Baza db)
        {
            db.Korisnici.AddOrUpdate(new Korisnik("Administrator", "administrator", 1, "admin", "Administrator sistema", Convert.ToString(("admin").GetHashCode()), "Muško"));
            db.SaveChanges();
            db.Cjenovnici.AddOrUpdate(new Cjenovnik(5, 1, 1, 3, 2, 1, 5, 5, 1, 1, DateTime.Now, db.Korisnici.ToList()[0], 1));
            db.Sale.AddOrUpdate(new Sala("A", 80, 15, 5, 1));
        }
    }
}
