using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Kino
    {
        public List<Film> Filmovi;
        public List<Artikal> Artikli;
        public List<SedmicniRaspored> SedmicniRasporedi;
        public List<Sala> Sale;
        public Korisnik TrenutnoLogovan { get; set; }

        public Kino(Korisnik k)
        {
            Baza db = new Baza();

            Filmovi=new List<Film>();
            Artikli = new List<Artikal>();
            SedmicniRasporedi = new List<SedmicniRaspored>();
            Sale = new List<Sala>();

            Filmovi = db.Filmovi.ToList();
            Artikli = db.Artiki.ToList();
            SedmicniRasporedi = db.SedmicniRasporedi.ToList();
            Sale = db.Sale.ToList();
            TrenutnoLogovan = k;
        }

        public Kino(List<Film> filmovi, List<Artikal> artikli, List<SedmicniRaspored> sedmicniRasporedi
            , List<Sala> _sale, Korisnik usernameTrenutnoLogovan)
        {
            Filmovi = filmovi;
            Artikli = artikli;
            SedmicniRasporedi = sedmicniRasporedi;
            TrenutnoLogovan = usernameTrenutnoLogovan;
        }

        public bool IzbrisiFilm(int id)
        {
            int brojac = 0;
            foreach (Film f in Filmovi)
            {
                if (f.ID == id)
                {
                    Filmovi.RemoveAt(brojac);
                    return true;
                }
                brojac++;
            }
            return false;
        }

        public void DodajNoviFilm(Film f)
        {
            bool postoji=false;
            foreach (Film fl in Filmovi)
            {
                if (f.Naziv == fl.Naziv && f.Reziser == fl.Reziser && f.GodinaIzdavanja == fl.GodinaIzdavanja) postoji = true;
            }

            if (!postoji)
            {
                Filmovi.Add(f);
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
            foreach (Sala sl in Sale)
            {
                if (s.NazivSale == sl.NazivSale) postoji = true;
            }

            if (!postoji)
            {
              //?  _sale.Add(s1);
            }
        }
        //Ima ih još hejbet
    }
}
