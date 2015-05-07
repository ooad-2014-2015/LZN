using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Cjenovnik
    {
        public double _osnova { get; set; }
        public int _dodatakZaNocneProjekcije { get; set; }
        public int _dodatakZaLjubavnaMjesta { get; set; }
        public int _dodatakZaVip { get; set; }
        public int _dodatakZaPremijere { get; set; }
        public int _dodatakZa3D { get; set; }
        public int _popustZaVipKorisnike { get; set; }
        public int _popustZaRodjendaskePakete { get; set; }
        public DateTime _zadnjaIzmjena { get; set; }
        public string _username { get; set; } //ovo da se zna ko je pravio izmjene??
        public int _ID { get; set; }


        public Cjenovnik(double osnova, int dodatakZaNocneProjekcije, int dodatakZaLjubavnaMjesta, int dodatakZaVip,
            int dodatakZaPremijere, int dodatakZa3D, int popustZaVipKorisnike, int popustZaRodjendanskePakete,
            DateTime zadnjaIzmjena, string username, int id)
        {
            _osnova = osnova;
            _dodatakZaNocneProjekcije = dodatakZaNocneProjekcije;
            _dodatakZaLjubavnaMjesta = dodatakZaLjubavnaMjesta;
            _dodatakZaVip = _dodatakZaVip;
            _dodatakZaPremijere = dodatakZaPremijere;
            _dodatakZa3D = dodatakZa3D;
            _popustZaVipKorisnike = popustZaVipKorisnike;
            _popustZaRodjendaskePakete = popustZaRodjendanskePakete;
            _zadnjaIzmjena = zadnjaIzmjena;
            _username = username;
            _ID = id;
        }


    }
}
