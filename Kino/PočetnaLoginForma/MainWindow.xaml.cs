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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlagajnikForme;
using FinansijskiMenadžerForme;
using AdministratorForme;
using Kino;
using System.Data.Entity;

namespace PočetnaLoginForma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (Baza db = new Baza())
            {
                Korisnik korisnik = new Korisnik();
                bool ima = false;
                /*foreach(var item in db.Korisnici.ToList())
                {
                    if (item.Username == username.Text && password.Password.GetHashCode() == Int32.Parse(item.Password))
                    {
                        korisnik = item;
                        ima = true;
                        break;                     
                    }
                }

                if(ima == false)
                {
                    status.ItemsSource = ("Pogrešan username ili password").ToList();
                    status.Foreground = Brushes.Red;
                    return;
                }*/
                this.Hide();
                if (username.Text == "blagajnik")
                {
                    var prozor = new BlagajnikPočetna();
                    prozor.ShowDialog();
                    //exit();
                }
                else if (username.Text == "finansije")
                {
                    var prozor = new FinansijskiMenadžerPočetna(); //Proslijedit logovanog korisnika
                    prozor.ShowDialog();

                }
                else
                {
                    var prozor = new AdministratorPočetna(korisnik);
                    prozor.ShowDialog();
                }
                this.ShowDialog();
                password.Clear();
                username.Clear();
            }
        }
    }
}
