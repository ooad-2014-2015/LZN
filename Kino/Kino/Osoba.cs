using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public abstract class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int ID { get; set; }

        public Osoba(string ime, string prezime, int id)
        {
            Ime = ime;
            Prezime = prezime;
            ID = id;
        }

    }
}
