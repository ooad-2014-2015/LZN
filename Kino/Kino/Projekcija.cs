using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Projekcija
    {
        public int _salaFK { get; set; }
        public List<bool> _zauzeto;
        public string _vrijemeProjekcije { get; set; }
        public string _dimenzionalnost { get; set; }
        public int _filmFK { get; set; }
        public string _tipProjekcije { get; set; }
        public int _brojSlobodnihMjesta { get; set; }
        public int _ID { get; set; }
        public int _cjenovnikFK { get; set; }

        public Projekcija()
        {
            _zauzeto= new List<bool>();
        }

        public Projekcija(int salaFK, List<bool> zauzeto, string vrijemeProjekcije, string dimenzionalnost, int filmFK, 
            string tipProjekcije, int brojSlobodnihMjesta, int ID, int cjenovnikFK)
        {
            _salaFK = salaFK;
            _zauzeto = zauzeto;
            _vrijemeProjekcije = vrijemeProjekcije;
            _dimenzionalnost = dimenzionalnost;
            _filmFK = filmFK;
            _tipProjekcije = tipProjekcije;
            _brojSlobodnihMjesta = brojSlobodnihMjesta;
            _ID = ID;
            _cjenovnikFK = cjenovnikFK;
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
