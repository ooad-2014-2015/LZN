using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Kino
    {
        public List<Film> _filmovi;
        public List<Artikal> _artikli;
        public List<SedmicniRaspored> _sedmicniRasporedi;
        public List<Sala> _sale;
        public string _usernameTrenutnoLogovan { get; set; }

        public Kino()
        { 
            _filmovi=new List<Film>();
            _artikli = new List<Artikal>();
            _sedmicniRasporedi = new List<SedmicniRaspored>();
            _sale = new List<Sala>();

        }

        public Kino(List<Film> filmovi, List<Artikal> artikli, List<SedmicniRaspored> sedmicniRasporedi
            , List<Sala> _sale, string usernameTrenutnoLogovan)
        {
            _filmovi = filmovi;
            _artikli = artikli;
            _sedmicniRasporedi = sedmicniRasporedi;
            _usernameTrenutnoLogovan = usernameTrenutnoLogovan;
        }

        public bool IzbrisiFilm(int id)
        {
            int brojac = 0;
            foreach (Film f in _filmovi)
            {
                if (f._ID == id)
                {
                    _filmovi.RemoveAt(brojac);
                    return true;
                }
                brojac++;
            }
            return false;
        }

        public void DodajNoviFilm(Film f)
        {
            bool postoji=false;
            foreach (Film fl in _filmovi)
            {
                if (f._naziv == fl._naziv && f._reziser == fl._reziser && f._godinaIzdavanja == fl._godinaIzdavanja) postoji = true;
            }

            if (!postoji)
            {
                _filmovi.Add(f);
            }
        }

        public bool IzmijeniFilm(int id)
        { 
            //Ovo moramo kroz formu, da znamo šta hoće da mijenja i kako
            return true;
        }

        public void DodajNovuSalu(Sala s)
        {

            //Može biti više sala sa istim brojem sjedišta
            bool postoji = false;
            foreach (Sala sl in _sale)
            {
                if (s._nazivSale == sl._nazivSale) postoji = true;
            }

            if (!postoji)
            {
                _sale.Add(a);
            }
        }
        //Ima ih još hejbet
    }
}
