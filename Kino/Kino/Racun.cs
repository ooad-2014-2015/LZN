using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Racun
    {
        public int ID { get; set; }
        public DateTime VrijemeNarudzbe { get; set; }
        public Korisnik Radnik { get; set; }
        public List<StavkeNarudzbe> _stavkeNarudzbe;

        public Racun()
        {
            _stavkeNarudzbe = new List<StavkeNarudzbe>();
        }

        public Racun(int serijskiBroj, DateTime vrijemeNarudzbe, Korisnik imeRadnika, List<StavkeNarudzbe> stavkeNarudzbe)
        {
            ID = serijskiBroj;
            VrijemeNarudzbe = vrijemeNarudzbe;
            Radnik = imeRadnika;
            _stavkeNarudzbe = stavkeNarudzbe;
        }

    }
}
