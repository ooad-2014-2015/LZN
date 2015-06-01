using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        public List<string> filmovi= new List<string>();
        public List<bool> je_li = new List<bool>();
        public List<Ponude> ponude = new List<Ponude>();
        public Page1()
        {
            InitializeComponent();
           // ponude.Add(new Ponude() { ime = "Avengers", put_slike = "avengers.jpg" });
            Ucitaj();
        }

        void Postavi_bool()
        {

            for(int i=0;i<22;i++)
            {
                je_li.Add(false);
            }
        }

        void dodaj()
        {
            filmovi.Add("Umri muški");
            filmovi.Add("Despicable me 2");
            filmovi.Add("Bad boys");
            filmovi.Add("Crni gruja");
            filmovi.Add("Glup, gluplji");
            filmovi.Add("Avengers");
            filmovi.Add("The Pursuit of Happyness");
            filmovi.Add("Mali zmaj kokos");
            filmovi.Add("Frozen");
            filmovi.Add("Zvončica");
            filmovi.Add("Schinders list");
            filmovi.Add("Raging bull");
            filmovi.Add("Casablanca");
            filmovi.Add("Titanik");
            filmovi.Add("Gladiator");
            filmovi.Add("Lord of the Rings: The Return of the King");
            filmovi.Add("Saving private Ryan");
            filmovi.Add("Unforgiven");
            filmovi.Add("Rocky");
            filmovi.Add("Brave heart");
            filmovi.Add("The exorcist");
            filmovi.Add("The Great Gatsby");

        }


        public void Ucitaj()
        {
            Postavi_bool();
            Ucitaj();
      
            int brojac = 0;
            Random rnd = new Random();

           while(true)
            {
                int br = rnd.Next(1, 22);
                if(!je_li[br])
                {
                    je_li[br] = true;
                    brojac++;
                }
                if (brojac == 7) break;
            }

         /*  prvi.Content = filmovi[0];
           drugi.Content = filmovi[1];
           treci.Content = filmovi[2];
           cetvrti.Content = filmovi[3];
           peti.Content = filmovi[4];
           sesti.Content = filmovi[5];
           sedmi.Content = filmovi[6];
            */
        }

        private void prvi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void drugi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void treci_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void cetvrti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void peti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void sesti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void sedmi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

      

      
    }
}