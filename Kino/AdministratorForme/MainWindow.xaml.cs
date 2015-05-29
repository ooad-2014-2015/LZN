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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (Baza db = new Baza())
            {
                //Ovo odkomentarisati nakon testiranja
                /*Korisnik korisnik = new Korisnik();
                bool ima = false;
                foreach(var item in db.Korisnici.ToList())
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
                }
                this.Hide();

                if(korisnik.TipKorisnika == "Blagajnik")
                {
                    //var prozor = new BlagajnikPočetna();
                    //prozor.ShowDialog();
                }
                else if (korisnik.TipKorisnika == "Finansijski menadžer")
                {
                    // var prozor = new FinansijskiMenadžerPočetna(); 
                    //prozor.ShowDialog();
                }
                else
                {
                    var prozor = new AdministratorPočetna(korisnik);
                    prozor.ShowDialog();
                }*/


                this.Hide(); //ovo izbrisati nakon testiranja
                if (username.Text == "blagajnik")
                {
                    //var prozor = new BlagajnikPočetna();
                    //prozor.ShowDialog();
                }
                else if (username.Text == "finansije")
                {
                   // var prozor = new FinansijskiMenadžerPočetna(); 
                   //prozor.ShowDialog();
                }
                else if(username.Text == "admin")
                {
                    var prozor = new AdministratorPočetna(new Korisnik());
                    prozor.ShowDialog();
                }

                this.ShowDialog();
                password.Clear();
                username.Clear();
            }
        }
    }
}
