using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class Sale
    {
        public string NazivSale { get; set; }
        public int BrojObicnihSjedista { get; set; }
        public int BrojLjubavnihSjedista { get; set; }
        public int BrojVipSjedista { get; set; }
        public int ID { get; set; }
        public int UkupanBrojMijesta { get; set; }

        public Sale(string nazivSale, int brojObicnihSjedista, int brojLjubavnihSjedista, int brojVipSjedista, int id)
        {
            NazivSale = nazivSale;
            BrojObicnihSjedista = brojObicnihSjedista;
            BrojLjubavnihSjedista = brojLjubavnihSjedista;
            BrojVipSjedista = brojVipSjedista;
            ID = id;
            UkupanBrojMijesta = brojLjubavnihSjedista + BrojObicnihSjedista + BrojVipSjedista;
        }

        public Sale()
        {
            // TODO: Complete member initialization
        }

    }
}
