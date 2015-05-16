using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Artikal
    {
        public int ID { get; set; }
        public double Cijena { get; set; }
        public string Naziv { get; set; }
        public int NaStanju { get; set; }
        public double Kolicina { get; set; }
        public byte[] Slika { get; set; }

        public Artikal(int id, double cijena, string naziv, byte[] slika, double kolicina, int naStanju)
        {
            ID = id;
            Cijena = cijena;
            Naziv = naziv;
            Slika = slika;
            Kolicina = kolicina;
            NaStanju = naStanju;
        }

        public Artikal()
        {
            // TODO: Complete member initialization
        }
    }
}
