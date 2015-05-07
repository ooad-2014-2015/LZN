using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Klijent: Osoba
    {
        public string _adresa { get; set; }
        public DateTime _datumRodjenja { get; set; }
        public string _brojLicneKarte { get; set; }

        public Klijent(string ime, string prezime, int id, string adresa, DateTime datumRodjenja, string brojLicneKarte)
            : base(ime, prezime, id)
        {
            _adresa = adresa;
            _datumRodjenja = datumRodjenja;
            _brojLicneKarte = brojLicneKarte;
        }


    }
}
