using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class SedmicniRaspored
    {
        public int ID { get; set; }
        public List<Projekcija> Projekcije;
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }

        public SedmicniRaspored()
        {
            Projekcije = new List<Projekcija>();
        }

        public SedmicniRaspored(int id, List<Projekcija> projekcije, DateTime datumPocetka, DateTime datumZavrsetka)
        {
            ID = id;
            Projekcije = projekcije;
            DatumPocetka = datumPocetka;
            DatumZavrsetka = datumZavrsetka;
        }

        public void DodajNovuProjekciju(Projekcija nova)
        {
           //baratanje oko poređenja početka projekcije i sale u kojoj se održava
            //tegobno što su varijable vrijemeOdržavanje tipa string
        }

        public bool IzbrisiProjekciju(int id)
        {
            int brojac=0;
            foreach (Projekcija p in Projekcije)
            { 
                if(p.ID == id)
                {
                    Projekcije.RemoveAt(brojac);
                    return true;
                }
                brojac++;

            }
            return false;
        }


    }
}
