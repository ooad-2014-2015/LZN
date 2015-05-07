using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Film
    {
        public string _naziv { get; set; }
        public string _zanr { get; set; }
        public string _reziser { get; set; }
        public List<string> _glumci;
        public string _sinospis { get; set; }
        public DateTime _godinaIzdavanja { get; set; }
        public string _vrijemeIzdavanja { get; set; }
        public string _slika { get; set; }
        public DateTime _datumUnosa { get; set; }
        public DateTime _datumPosljednjeIzmjene { get; set; }
        public string _username { get; set; }
        public int _ID { get; set; }

        public Film()
        {
            _glumci = new List<string>();
        }

        public Film(string naziv, string zanr, string reziser, List<string> glumci, string sinospis, DateTime godinaIzdavanja, string vrijemeIzdavanja
            , string slika, DateTime datumUnosa, DateTime datumPosljednjeIzmjene, string username, int ID)
        {
            _naziv = naziv;
            _zanr = zanr;
            _reziser = reziser;
            _glumci = glumci;
            _sinospis = sinospis;
            _godinaIzdavanja = godinaIzdavanja;
            _vrijemeIzdavanja = vrijemeIzdavanja;
            _slika = slika;
            _datumUnosa = datumUnosa;
            _datumPosljednjeIzmjene = datumPosljednjeIzmjene;
            _username = username;
            _ID = ID;

        }

        
    }

}
