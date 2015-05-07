using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kino;

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for KreiranjeSedmicnogRasporeda.xaml
    /// </summary>
    public partial class KreiranjeSedmicnogRasporeda : Window
    {
        public KreiranjeSedmicnogRasporeda()
        {
            InitializeComponent();
            CjenovnikCekiran();
            List<Film> filmovi = new List<Film> {
                new Film{ID = 1, Naziv = "Neki film", GodinaIzdavanja = 1995, Zanr = "komedija", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"ja", "ti"}, Reziser = "On", Sinospis = "gfnerogjer", Slika = "adaw", Username ="dzemal", VrijemeTrajanja = 120},
                new Film{ID = 2, Naziv = "Život je lijep", GodinaIzdavanja = 2012, Zanr = "komedija", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"ja", "ti"}, Reziser = "Nihad", Sinospis = "ydthn", Slika = "drtfn", Username ="Čenga", VrijemeTrajanja = 115}
            };
            tabela.ItemsSource = filmovi;
        }
        #region metodeZaCjenovnikCheckBox
        private void CjenovnikCekiran() //Mijenja ReadOnly property TextBoxova iz cjenovnika
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(cjenovnikGrid); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(cjenovnikGrid, i);
                if (kontrola is TextBox)
                {
                    TextBox t = kontrola as TextBox;
                    t.IsReadOnly = !(t.IsReadOnly);
                }
            }
        }
        private void postojeciCjenovnik_Unchecked(object sender, RoutedEventArgs e)
        {
           CjenovnikCekiran();
        }

        private void postojeciCjenovnik_Checked(object sender, RoutedEventArgs e)
        {
            CjenovnikCekiran();
            //Vratiti pocetne vrijednosti
        }
        #endregion

    }
}
