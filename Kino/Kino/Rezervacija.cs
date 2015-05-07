using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Rezervacija
    {
        public int _ID { get; set; }
        public DateTime _datumRezervacije { get; set; }
        public List<StavkeNarudzbe> _hrana;

        public Rezervacija()
        {
            _hrana = new List<StavkeNarudzbe>();
        }

        public Rezervacija(int ID, DateTime datumRezervacije, List<StavkeNarudzbe> hrana)
        {
            _ID = ID;
            _datumRezervacije = datumRezervacije;
            _hrana = hrana;
        }

        public bool IzbrisiPostojecuStavku(int id)
        {
            int brojac = 0;
            foreach(StavkeNarudzbe s in _hrana)
            {
                if (s._ID == id)
                {
                    _hrana.RemoveAt(brojac);
                    return true;
                }
                brojac++;
            }

            return false;
        }

        public void DodajNovuStavku(StavkeNarudzbe s)
        {
            _hrana.Add(s);
        }



    }
}
