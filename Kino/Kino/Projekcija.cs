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
        public DateTime VrijemeProjekcije { get; set; }
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
        private int DajBrojMijestaSale(int id)
        {
            var sale = new List<Sala>{ //Ovo izbrisati kada se poveze sa bazom i ne dodavati nove sale!!!
                new Sala{ID = 1, NazivSale = "Kino sala", BrojLjubavnihSjedista = 8, BrojObicnihSjedista = 80, BrojVipSjedista = 4, UkupanBrojMijesta = 92},
                new Sala{ID = 2, NazivSale = "B", BrojLjubavnihSjedista = 10, BrojObicnihSjedista = 60, BrojVipSjedista = 0, UkupanBrojMijesta = 70},
                new Sala{ID = 3, NazivSale = "C", BrojLjubavnihSjedista = 0, BrojObicnihSjedista = 85, BrojVipSjedista = 15, UkupanBrojMijesta = 100},
                new Sala{ID = 2, NazivSale = "D", BrojLjubavnihSjedista = 14, BrojObicnihSjedista = 55, BrojVipSjedista = 0, UkupanBrojMijesta = 69}
            };
            foreach (var item in sale)  
            {
                if (item.ID == id)
                    return item.UkupanBrojMijesta;
            }
            return -1;
        }
        public Projekcija(int salaFK, DateTime vrijemeProjekcije, string dimenzionalnost, int filmFK, 
            string tipProjekcije, int id, int cjenovnikFK)
        {
            SalaFK = salaFK;
            VrijemeProjekcije = vrijemeProjekcije;
            Dimenzionalnost = dimenzionalnost;
            FilmFK = filmFK;
            TipProjekcije = tipProjekcije;
            BrojSlobodnihMjesta = DajBrojMijestaSale(salaFK);
            ID = id;
            CjenovnikFK = cjenovnikFK;

            Zauzeto = new List<bool>();
            int mijesta = DajBrojMijestaSale(salaFK);
            for (int i = 0; i < mijesta; i++)
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
