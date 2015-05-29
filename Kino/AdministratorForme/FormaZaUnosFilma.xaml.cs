using Kino;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for FormaZaUnosFilma.xaml
    /// </summary>
    public partial class FormaZaUnosFilma : Window
    {
        Korisnik k;
        public FormaZaUnosFilma(Korisnik korisnik)
        {
            InitializeComponent();
            k = korisnik;
            Baza db = new Baza();
            var filmovi = db.Filmovi.ToList();
            try
            {
                id.Text = Convert.ToString(filmovi.Last().ID + 1);
            }
            catch(Exception)
            {
                id.Text = Convert.ToString(1);
            }
            datumUnosa.Text = DatumIzmjene.Text = DateTime.Now.ToShortDateString();
            korisnikIzmjenio.Text = korisnikUnio.Text = korisnik.Ime + " " + korisnik.Prezime;
        }

        private void IzbaciGlumcaButtonClick(object sender, RoutedEventArgs e)
        {
            if (glumci.SelectedIndex != -1)
            {
                glumci.Items.RemoveAt(glumci.SelectedIndex);
            }
        }
        private void DodajGlumcaButtonClick(object sender, RoutedEventArgs e)
        {
            if (dodajGlumca.Text.Length > 0)
            {
                glumci.Items.Add(dodajGlumca.Text);
                dodajGlumca.Clear();
                return;
            }
        }
        private void FileDialogButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog prozor = new OpenFileDialog();
            var rezultat = prozor.ShowDialog();

            if (rezultat == true)
            {
                prozor.Filter = "JPEG FIles(*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg"; //Ne radi?
                try
                {
                    slika.Source = new BitmapImage(new Uri(prozor.FileName));
                }
                catch (Exception)
                {
                    status.ItemsSource = ("Pogrešan format!").ToList();
                }
                return;
            }
        }
        private void IzmjeniBojuStatusBara()
        {
            Brush boja = Brushes.Red;
            Dispatcher.BeginInvoke((Action)(() => boja = status.Background));

            for (int i = 1; i <= 3; i++)
            {
                Dispatcher.BeginInvoke((Action)(() => status.Background = Brushes.Red));
                Thread.Sleep(800);

                Dispatcher.BeginInvoke((Action)(() => status.Background = boja));
                Thread.Sleep(800);
            }
        }
        private bool Validiraj()
        {
            int broj = 1;
            if (naziv.Text.Length == 0 || zanr.Text.Length == 0 || godina.Text.Length == 0 || reziser.Text.Length == 0 || sinopsis.Text.Length == 0 || glumci.Items.Count == 0
                || trajanjeFilma.Text.Length == 0)
            {
                status.ItemsSource = ("Morate popuniti sva polja").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }

            Int32.TryParse(godina.Text, out broj);
            if (broj == 0)
            {
                status.ItemsSource = ("Neispravan unos godine izdavanja filma. Godina mora biti cijeli broj!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }

            Int32.TryParse(trajanjeFilma.Text, out broj);
            if (broj == 0)
            {
                status.ItemsSource = ("Neispravan unos vremena trajanja filma. Vrijeme trajanja mora biti cijeli broj!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }
            return true;
        }
        private void PotvrdiUnosButtonClick(object sender, RoutedEventArgs e)
        {
            if (Validiraj() == false)
                return;

            if (MessageBox.Show("Da li ste sigurni da želite unijeti film?", "Novi film", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.No)
                return;

            Film film = new Film();

            film.ID = Int32.Parse(id.Text);
            film.DatumUnosa = DateTime.Now;
            film.KorisnikKojiJeKreiraoFIlm = k;
            film.KorisnikKojiJeNapravioPosljednjeIzmjene = k;
            film.DatumPosljednjeIzmjene = DateTime.Now;
            film.GodinaIzdavanja = Int32.Parse(godina.Text);
            film.Naziv = naziv.Text;
            film.Reziser = reziser.Text;
            film.Sinopsis = sinopsis.Text;
            try
            {
                film.Slika = getJPGFromImageControl(slika.Source as BitmapImage);
            }
            catch (Exception) { }
            film.VrijemeTrajanja = Int32.Parse(trajanjeFilma.Text);
            film.Zanr = zanr.Text;
            film.Glumci = "";
            foreach (string item in glumci.Items)
            {
                film.Glumci += item + ", ";
            }
            using(Baza db = new Baza())
            {
                db.Filmovi.Add(film);
                db.SaveChanges();
            }
            MessageBox.Show("Uspješno ste unijeli novi film u bazu podataka", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        private byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }
    }
}
