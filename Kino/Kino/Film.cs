using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Film
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public string Reziser { get; set; }
        public List<string> Glumci;
        public string Sinospis { get; set; }
        public int GodinaIzdavanja { get; set; }
        public int VrijemeTrajanja { get; set; } 
        public string Slika { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime DatumPosljednjeIzmjene { get; set; }
        public string Username { get; set; }

        public Film()
        {
            Glumci = new List<string>();
        }

        public Film(string naziv, string zanr, string reziser, List<string> glumci, string sinospis, int godinaIzdavanja, int vrijeme_Trajanja
            , string slika, DateTime datumUnosa, DateTime datumPosljednjeIzmjene, string username, int id)
        {
            Naziv = naziv;
            Zanr = zanr;
            Reziser = reziser;
            Glumci = glumci;
            Sinospis = sinospis;
            GodinaIzdavanja = godinaIzdavanja;
            VrijemeTrajanja = vrijeme_Trajanja;
            Slika = slika;
            DatumUnosa = datumUnosa;
            DatumPosljednjeIzmjene = datumPosljednjeIzmjene;
            Username = username;
            ID = id;

        }

        
    }

}
