using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Klijent: Osoba
    {
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojLicneKarte { get; set; }

        public Klijent(string ime, string prezime, int id, string adresa, DateTime datumRodjenja, string brojLicneKarte)
            : base(ime, prezime, id)
        {
            Adresa = adresa;
            DatumRodjenja = datumRodjenja;
            BrojLicneKarte = brojLicneKarte;
        }


    }
}
