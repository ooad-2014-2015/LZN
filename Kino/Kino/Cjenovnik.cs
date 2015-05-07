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
        public string Username { get; set; } //ovo da se zna ko je pravio izmjene??
        public int ID { get; set; }


        public Cjenovnik(double osnova, int dodatakZaNocneProjekcije, int dodatakZaLjubavnaMjesta, int dodatakZaVip,
            int dodatakZaPremijere, int dodatakZa3D, int popustZaVipKorisnike, int popustZaRodjendanskePakete,
            DateTime zadnjaIzmjena, string username, int id)
        {
            Osnova = osnova;
            DodatakZaNocneProjekcije = dodatakZaNocneProjekcije;
            DodatakZaLjubavnaMjesta = dodatakZaLjubavnaMjesta;
            DodatakZaVip = DodatakZaVip;
            DodatakZaPremijere = dodatakZaPremijere;
            DodatakZa3D = dodatakZa3D;
            PopustZaVipKorisnike = popustZaVipKorisnike;
            PopustZaRodjendaskePakete = popustZaRodjendanskePakete;
            ZadnjaIzmjena = zadnjaIzmjena;
            Username = username;
            ID = id;
        }


    }
}
