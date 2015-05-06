using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Artikal
    {
        public int _ID { get; set; }
        public double _cijena { get; set; }
        public string _naziv { get; set; }
        public string _slika { get; set; }
        public double _kolicina { get; set; }
        public int _naStanju { get; set; }

        public Artikal(int ID, double cijena, string naziv, string slika, double kolicina, int naStanju)
        {
            _ID = ID;
            _cijena = cijena;
            _naziv = naziv;
            _slika = slika;
            _kolicina = kolicina;
            _naStanju = naStanju;
        }
    }
}
