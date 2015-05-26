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
        public string Sinopsis { get; set; }
        public int GodinaIzdavanja { get; set; }
        public int VrijemeTrajanja { get; set; } 
        public byte[] Slika { get; set; } 
        public DateTime DatumUnosa { get; set; }
        public DateTime DatumPosljednjeIzmjene { get; set; }
        public virtual Korisnik KorisnikKojiJeKreiraoFIlm { get; set; }
        public virtual Korisnik KorisnikKojiJeNapravioPosljednjeIzmjene { get; set; }
        public int KorisnikId { get; set; }

        public Film()
        {
            Glumci = new List<string>();
        }

        public Film(string naziv, string zanr, string reziser, List<string> glumci, string sinospis, int godinaIzdavanja, int vrijeme_Trajanja
            , byte[] slika, DateTime datumUnosa, DateTime datumPosljednjeIzmjene, Korisnik kor, Korisnik zadnjaIzmjena, int id)
        {
            Naziv = naziv;
            Zanr = zanr;
            Reziser = reziser;
            Glumci = glumci;
            Sinopsis = sinospis;
            GodinaIzdavanja = godinaIzdavanja;
            VrijemeTrajanja = vrijeme_Trajanja;
            Slika = slika;
            DatumUnosa = datumUnosa;
            DatumPosljednjeIzmjene = datumPosljednjeIzmjene;
            KorisnikKojiJeKreiraoFIlm = kor;
            KorisnikKojiJeNapravioPosljednjeIzmjene = zadnjaIzmjena;
            ID = id;
            KorisnikId = kor.ID;
        }

        
    }

}
