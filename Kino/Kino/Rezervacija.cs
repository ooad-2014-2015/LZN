using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Rezervacija
    {
        public int ID { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public List<StavkeNarudzbe> Hrana;

        public Rezervacija()
        {
            Hrana = new List<StavkeNarudzbe>();
        }

        public Rezervacija(int id, DateTime datumRezervacije, List<StavkeNarudzbe> hrana)
        {
            ID = id;
            DatumRezervacije = datumRezervacije;
            Hrana = hrana;
        }

        public bool IzbrisiPostojecuStavku(int id)
        {
            int brojac = 0;
            foreach(StavkeNarudzbe s in Hrana)
            {
                if (s.ID == id)
                {
                    Hrana.RemoveAt(brojac);
                    return true;
                }
                brojac++;
            }

            return false;
        }

        public void DodajNovuStavku(StavkeNarudzbe s)
        {
            Hrana.Add(s);
        }



    }
}
