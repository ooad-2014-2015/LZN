using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Racun
    {
        public int SerijskiBroj { get; set; }
        public string VrijemeNarudzbe { get; set; }
        public string ImeRadnika { get; set; }
        public List<StavkeNarudzbe> _stavkeNarudzbe;

        public Racun()
        {
            _stavkeNarudzbe = new List<StavkeNarudzbe>();
        }

        public Racun(int serijskiBroj, string vrijemeNarudzbe, string imeRadnika, List<StavkeNarudzbe> stavkeNarudzbe)
        {
            SerijskiBroj = serijskiBroj;
            VrijemeNarudzbe = vrijemeNarudzbe;
            ImeRadnika = imeRadnika;
            _stavkeNarudzbe = stavkeNarudzbe;
        }

    }
}
