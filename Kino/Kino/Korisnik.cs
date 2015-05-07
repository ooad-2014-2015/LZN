using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Korisnik: Osoba
    {
        public string  Username { get; set; }
        public string  TipKorisnika { get; set; }
        public string  Password { get; set; }

        public Korisnik(string ime, string prezime, int id, string username, string tipKorisnika, string hashPassword)
            : base(ime, prezime, id)
        {
            Username = username;
            TipKorisnika = tipKorisnika;
            Password = hashPassword;
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
