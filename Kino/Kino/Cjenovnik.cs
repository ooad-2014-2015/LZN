using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Cjenovnik
    {
        public double Osnova { get; set; }
        public int DodatakZaNocneProjekcije { get; set; }
        public int DodatakZaLjubavnaMjesta { get; set; }
        public int DodatakZaVip { get; set; }
        public int DodatakZaPremijere { get; set; }
        public int DodatakZa3D { get; set; }
        public int PopustZaVipKorisnike { get; set; }
        public int PopustZaRodjendaskePakete { get; set; }
        public DateTime ZadnjaIzmjena { get; set; }
        public Korisnik KorisnikKreirao { get; set; } 
        public int ID { get; set; }
        public int DodatakZaFilmoveDuzeOd120Min { get; set; }
        public int DodatakZaPretpremijere { get; set; }

        public Cjenovnik(double osnova, int dodatakZaNocneProjekcije, int dodatakZaLjubavnaMjesta, int dodatakZaVip,
            int dodatakZaPremijere, int dodatakZa3D, int popustZaVipKorisnike, int popustZaRodjendanskePakete, int dodatakaZaDugeFilmove, int dodatakPretpremijere,
            DateTime zadnjaIzmjena, Korisnik username, int id)
        {
            Osnova = osnova;
            DodatakZaNocneProjekcije = dodatakZaNocneProjekcije;
            DodatakZaLjubavnaMjesta = dodatakZaLjubavnaMjesta;
            DodatakZaVip = dodatakZaVip;
            DodatakZaPremijere = dodatakZaPremijere;
            DodatakZa3D = dodatakZa3D;
            PopustZaVipKorisnike = popustZaVipKorisnike;
            PopustZaRodjendaskePakete = popustZaRodjendanskePakete;
            ZadnjaIzmjena = zadnjaIzmjena;
            KorisnikKreirao = username;
            ID = id;
            DodatakZaFilmoveDuzeOd120Min = dodatakaZaDugeFilmove;
            DodatakZaPretpremijere = dodatakPretpremijere;
        }

        public Cjenovnik()
        {
            // TODO: Complete member initialization
        }


    }
}
