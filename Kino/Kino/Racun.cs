using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Racun
    {
        public int _serijskiBroj { get; set; }
        public string _vrijemeNarudzbe { get; set; }
        public string _imeRadnika { get; set; }
        public List<StavkeNarudzbe> _stavkeNarudzbe;

        public Racun()
        {
            _stavkeNarudzbe = new List<StavkeNarudzbe>();
        }

        public Racun(int serijskiBroj, string vrijemeNarudzbe, string imeRadnika, List<StavkeNarudzbe> stavkeNarudzbe)
        {
            _serijskiBroj = serijskiBroj;
            _vrijemeNarudzbe = vrijemeNarudzbe;
            _imeRadnika = imeRadnika;
            _stavkeNarudzbe = stavkeNarudzbe;
        }

    }
}
