using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Korisnik: Osoba
    {
        public string _username { get; set; }
        public string  _TipKorisnika { get; set; }
        public string _hashPassword { get; set; }

        public Korisnik(string ime, string prezime, int id, string username, string TipKorisnika, string hashPassword)
            : base(ime, prezime, id)
        {
            _username = username;
            _TipKorisnika = TipKorisnika;
            _hashPassword = hashPassword;
        }

        public void RegistrujNovogKorisnika()
        { 
        }

        public void IzmijeniKorisnika(int id)
        { 
        }

        public void IzbrisiKorisnika(int id)
        { 
        }
    }
}
