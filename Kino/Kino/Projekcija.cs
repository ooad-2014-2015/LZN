using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Projekcija
    {
        public Sala SalaFK { get; set; }
        public List<bool> Zauzeto;
        public DateTime VrijemeProjekcije { get; set; }
        public string Dimenzionalnost { get; set; }
        public Film FilmFK { get; set; }
        public string TipProjekcije { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public int ID { get; set; }
        public Cjenovnik CjenovnikFK { get; set; }

        public Projekcija()
        {
            Zauzeto= new List<bool>();
        }
        private int DajBrojMijestaSale(int id)
        {
            Baza db = new Baza();
            foreach (var item in db.Sale)  
            {
                if (item.ID == id)
                    return item.UkupanBrojMijesta;
            }
            return -1;
        }
        public Projekcija(Sala salaFK, DateTime vrijemeProjekcije, string dimenzionalnost, Film filmFK, 
            string tipProjekcije, int id, Cjenovnik cjenovnikFK)
        {
            SalaFK = salaFK;
            VrijemeProjekcije = vrijemeProjekcije;
            Dimenzionalnost = dimenzionalnost;
            FilmFK = filmFK;
            TipProjekcije = tipProjekcije;
            BrojSlobodnihMjesta = DajBrojMijestaSale(salaFK.ID);
            ID = id;
            CjenovnikFK = cjenovnikFK;

            Zauzeto = new List<bool>();
            for (int i = 0; i < BrojSlobodnihMjesta; i++)
            {
                Zauzeto.Add(false);
            }
        }

        public void PrikaziNaEkran()
        { 
        }

        public bool Ponisti(int brojSjedista)
        {
            return true;
        }
    }
}
