using Kino;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PrikazEditovanjeFilma.xaml
    /// </summary>
    public partial class PrikazEditovanjeFilma : Window
    {
        Film film;
        bool pregled;
        public PrikazEditovanjeFilma(Film parametarFilm, bool pregled)
        {
            InitializeComponent();
            film = parametarFilm;
            this.pregled = pregled;
            if (pregled)
            {
                Pregled();
            }
            PopuniKontrole();
            window.Title = film.Naziv;
         
        }
        private void PopuniKontrole()
        {
            naziv.Text = film.Naziv;
            godina.Text = Convert.ToString(film.GodinaIzdavanja);
            id.Text = Convert.ToString(film.ID);
            zanr.Text = film.Zanr;
            reziser.Text = film.Reziser;
            trajanjeFilma.Text = Convert.ToString(film.VrijemeTrajanja);
            datumUnosa.Text = film.DatumUnosa.ToShortDateString();
            DatumIzmjene.Text = DateTime.Now.ToShortDateString();
            korisnikUnio.Text = film.KorisnikKojiJeKreiraoFIlm;
            korisnikIzmjenio.Text = "Trenutno logovani korisnik"; //Ovo izmjeniti

            foreach(string item in film.Glumci)
            {
                glumci.Items.Add(item);
            }
            sinopsis.Text = film.Sinopsis;
            if(film.Slika == null)
                return;

            ImageSource image = LoadImage(film.Slika) as ImageSource; 
            slika.Source = image;           
        }
        private void Pregled()
        {
            naziv.IsReadOnly = true;
            godina.IsReadOnly = true;
            zanr.IsReadOnly = true;
            reziser.IsReadOnly = true;
            trajanjeFilma.IsReadOnly = true;
            sinopsis.IsReadOnly = true;
            glumci.IsEnabled = false;
            dodajGlumca.IsReadOnly = true;
            brisanje.IsEnabled = false;
            odabirSlike.IsEnabled = false;
            potvrdiBrisanje.IsEnabled = false;
        }
        private bool Validiraj()
        {
            int broj = 1;
            if(naziv.Text.Length == 0 || zanr.Text.Length == 0 || godina.Text.Length == 0 || reziser.Text.Length == 0 || sinopsis.Text.Length == 0 || glumci.Items.Count == 0
                || trajanjeFilma.Text.Length == 0)
            {
                status.ItemsSource = ("Morate popuniti sva polja").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }
       
            Int32.TryParse(godina.Text, out broj);
            if(broj == 0)
            {
                status.ItemsSource = ("Neispravan unos godine izdavanja filma. Godina mora biti cijeli broj!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }

            Int32.TryParse(trajanjeFilma.Text , out broj);
            if (broj == 0)
            {
                status.ItemsSource = ("Neispravan unos vremena trajanja filma. Vrijeme trajanja mora biti cijeli broj!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBara());
                nit.Start();
                return false;
            }
            return true;
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
        #region Eventi za button_click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog prozor = new OpenFileDialog();
            var rezultat = prozor.ShowDialog();

            if(rezultat == true)
            {
                prozor.Filter = "JPEG FIles(*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg"; //Ne radi?
                try
                {
                    slika.Source = new BitmapImage(new Uri(prozor.FileName));
                }
                catch(Exception)
                {
                    status.ItemsSource = ("Pogrešan format!").ToList();
                }
                return;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dodajGlumca.Text.Length > 0)
            {
                glumci.Items.Add(dodajGlumca.Text);
                dodajGlumca.Clear();
                return;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(glumci.SelectedIndex != -1)
            {
                glumci.Items.RemoveAt(glumci.SelectedIndex);
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (pregled)
                return;

            if (Validiraj() == false)
                return;

            if (MessageBox.Show("Da li ste sigurni da želite spasiti izmjene?", "Spašavanje izmjena", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.No)
                return;

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
            //film.KorisnikKojiJeNapravioPosljednjeIzmjene = logovani korisnik
            film.VrijemeTrajanja = Int32.Parse(trajanjeFilma.Text);
            film.Zanr = zanr.Text;
            film.Glumci.Clear();
            foreach(string item in glumci.Items)
            {
                film.Glumci.Add(item);
            }
            //spasi u bazu
            MessageBox.Show("Izmjene su spašene", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        private void potvrdiBrisanje_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite izbrisati film iz baze podataka?", "Brisanje", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.No)
                return;

            //provjeriti da li se film koristi u projekcijama i zabraniti brisanje ako da
            //izbrisati iz baze
        }
        #endregion
        private byte[] getJPGFromImageControl(BitmapImage imageC)
        {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageC));
                encoder.Save(memStream);
                return memStream.GetBuffer();

        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) 
                return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
