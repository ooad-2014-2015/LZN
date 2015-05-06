using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class StavkeNarudzbe
    {
        public string _nazivArtikla { get; set; }
        public int _IDArtikla { get; set; }
        public int _kolicina { get; set; }
        public double _iznos { get; set; }
        public int _ID { get; set; }

        public StavkeNarudzbe(string nazivArtikla, int IDArtikla, int kolicina, double iznos, int ID)
        {
            _nazivArtikla = nazivArtikla;
            _IDArtikla = IDArtikla;
            _kolicina = kolicina;
            _iznos = iznos;
            _ID = ID;
        }

    }
}
