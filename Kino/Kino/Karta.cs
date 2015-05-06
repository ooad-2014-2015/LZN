using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Karta
    {
        public int _serijskiBroj { get; set; }
        public string _nazivFilma { get; set; }
        public DateTime _datumProjekcije { get; set; }
        public string _nazivSale { get; set; }
        public int _redniBrojSjedista { get; set; }

        public Karta(int serijskiBroj, string nazivFilma, DateTime datumProjekcije, string nazivSale, int redniBrojSjedista)
        {
            _serijskiBroj = serijskiBroj;
            _nazivFilma = nazivFilma;
            _datumProjekcije = datumProjekcije;
            _nazivFilma = nazivFilma;
            _redniBrojSjedista = redniBrojSjedista;
        }

    }
}
