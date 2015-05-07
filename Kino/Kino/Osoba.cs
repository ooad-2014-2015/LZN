using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public abstract class Osoba
    {
        public string _ime { get; set; }
        public string _prezime { get; set; }
        public int _ID { get; set; }

        public Osoba(string ime, string prezime, int ID)
        {
            _ime = ime;
            _prezime = prezime;
            _ID = ID;
        }

    }
}
