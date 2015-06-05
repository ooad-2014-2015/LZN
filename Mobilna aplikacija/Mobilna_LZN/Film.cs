using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1
{
    public class Film
    {
        public int _id { get; set; }
        public string _ime { get; set; }
        public DateTime _datum { get; set; }
        public List<string> _termini;

        Film()
        {
            _termini = new List<string>();
        }


    }
}
