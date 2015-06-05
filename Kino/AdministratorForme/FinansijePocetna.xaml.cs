using Kino;
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

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for FinansijePocetna.xaml
    /// </summary>
    public partial class FinansijePocetna : Window
    {
        public FinansijePocetna()
        {
            InitializeComponent();
            using(Baza db = new Baza())
            {
                db.Racuni.Add(new Racun(1, DateTime.Now, db.Korisnici.ToList()[0], new List<StavkeNarudzbe>()));
                db.Racuni.Add(new Racun(1, DateTime.Now, db.Korisnici.ToList()[0], new List<StavkeNarudzbe>()));
                db.SaveChanges();
            }
            datum.SelectedDate = DateTime.Today;
            Pretraga();
        }

        private void PrintanjeIzvjestaja(object sender, RoutedEventArgs e)
        {
            PrintDialog printer = new PrintDialog();
            if(printer.ShowDialog().GetValueOrDefault(false))
            {
                printer.PrintVisual(this, this.Title);
            }
        }
        private void Pretraga()
        {
            DateTime vrijeme = datum.SelectedDate.Value;
            Baza db = new Baza();
            var lista = db.Racuni.ToList();
            var racuni = (from r in lista

                          where r.VrijemeNarudzbe.Year == vrijeme.Year && r.VrijemeNarudzbe.Month == vrijeme.Month && r.VrijemeNarudzbe.Day == vrijeme.Day

                          select r).ToList();

            tabela.ItemsSource = racuni;
        }
        private void PretragaClick(object sender, RoutedEventArgs e)
        {
            Pretraga();
        }
    }
}
