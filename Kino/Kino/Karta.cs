using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Karta
    {
        public int SerijskiBroj { get; set; }
        public string NazivFilma { get; set; }
        public DateTime DatumProjekcije { get; set; }
        public string NazivSale { get; set; }
        public int RedniBrojSjedista { get; set; }

        public Karta(int serijskiBroj, string nazivFilma, DateTime datumProjekcije, string nazivSale, int redniBrojSjedista)
        {
            SerijskiBroj = serijskiBroj;
            NazivFilma = nazivFilma;
            DatumProjekcije = datumProjekcije;
            NazivFilma = nazivFilma;
            RedniBrojSjedista = redniBrojSjedista;
        }

    }
}
