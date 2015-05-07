using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Projekcija
    {
        public int SalaFK { get; set; }
        public List<bool> Zauzeto;
        public string VrijemeProjekcije { get; set; }
        public string Dimenzionalnost { get; set; }
        public int FilmFK { get; set; }
        public string TipProjekcije { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public int ID { get; set; }
        public int CjenovnikFK { get; set; }

        public Projekcija()
        {
            Zauzeto= new List<bool>();
        }

        public Projekcija(int salaFK, List<bool> zauzeto, string vrijemeProjekcije, string dimenzionalnost, int filmFK, 
            string tipProjekcije, int brojSlobodnihMjesta, int id, int cjenovnikFK)
        {
            SalaFK = salaFK;
            Zauzeto = zauzeto;
            VrijemeProjekcije = vrijemeProjekcije;
            Dimenzionalnost = dimenzionalnost;
            FilmFK = filmFK;
            TipProjekcije = tipProjekcije;
            BrojSlobodnihMjesta = brojSlobodnihMjesta;
            ID = id;
            CjenovnikFK = cjenovnikFK;
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
