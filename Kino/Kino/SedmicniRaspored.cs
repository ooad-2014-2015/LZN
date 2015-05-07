using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class SedmicniRaspored
    {
        public int _ID { get; set; }
        public List<Projekcija> _projekcije;
        public DateTime _datumPocetka { get; set; }
        public DateTime _datumZavrsetka { get; set; }

        public SedmicniRaspored()
        {
            _projekcije = new List<Projekcija>();
        }

        public SedmicniRaspored(int ID, List<Projekcija> projekcije, DateTime datumPocetka, DateTime datumZavrsetka)
        {
            _ID = ID;
            _projekcije = projekcije;
            _datumPocetka = datumPocetka;
            _datumZavrsetka = datumZavrsetka;
        }

        public void DodajNovuProjekciju(Projekcija nova)
        {
           //baratanje oko poređenja početka projekcije i sale u kojoj se održava
            //tegobno što su varijable vrijemeOdržavanje tipa string
        }

        public bool IzbrisiProjekciju(int id)
        {
            int brojac=0;
            foreach (Projekcija p in _projekcije)
            { 
                if(p._ID == id)
                {
                    _projekcije.RemoveAt(brojac);
                    return true;
                }
                brojac++;

            }
            return false;
        }


    }
}
