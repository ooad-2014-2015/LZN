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
        public Film Film { get; set; }
        public DateTime DatumProjekcije { get; set; }
        public Sala Sala { get; set; }
        public int RedniBrojSjedista { get; set; }

        public Karta(int serijskiBroj, Film nazivFilma, DateTime datumProjekcije, Sala nazivSale, int redniBrojSjedista)
        {
            SerijskiBroj = serijskiBroj;
            Film = nazivFilma;
            DatumProjekcije = datumProjekcije;
            Sala = nazivSale;
            RedniBrojSjedista = redniBrojSjedista;
        }

    }
}
