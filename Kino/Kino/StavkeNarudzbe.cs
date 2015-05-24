using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class StavkeNarudzbe
    {
        public Artikal Artikal { get; set; }
        public int Kolicina { get; set; }
        public double Iznos { get; set; }
        public int ID { get; set; }

        public StavkeNarudzbe(Artikal nazivArtikla, int kolicina, double iznos, int id)
        {
            Artikal = nazivArtikla;
            Kolicina = kolicina;
            Iznos = iznos;
            ID = id;
        }

    }
}
