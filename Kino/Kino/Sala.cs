using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Sala
    {
        public string _nazivSale { get; set; }
        public int _brojObicnihSjedista { get; set; }
        public int _brojLjubavnihSjedista { get; set; }
        public int _brojVipSjedista { get; set; }
        public int _ID { get; set; }

        public Sala(string nazivSale, int brojObicnihSjedista, int brojLjubavnihSjedista, int brojVipSjedista, int ID)
        {
            _nazivSale = nazivSale;
            _brojObicnihSjedista = brojObicnihSjedista;
            _brojLjubavnihSjedista = brojLjubavnihSjedista;
            _brojVipSjedista = brojVipSjedista;
            _ID = ID;
        }

    }
}
