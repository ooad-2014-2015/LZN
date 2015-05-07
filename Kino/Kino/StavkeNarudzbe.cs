using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class StavkeNarudzbe
    {
        public string NazivArtikla { get; set; }
        public int IDArtikla { get; set; }
        public int Kolicina { get; set; }
        public double Iznos { get; set; }
        public int ID { get; set; }

        public StavkeNarudzbe(string nazivArtikla, int IdArtikla, int kolicina, double iznos, int id)
        {
            NazivArtikla = nazivArtikla;
            IDArtikla = IdArtikla;
            Kolicina = kolicina;
            Iznos = iznos;
            ID = id;
        }

    }
}
