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
//using System.Text.RegularExpressions.Regex;
using System.Text.RegularExpressions;

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for Sala.xaml
    /// </summary>
    public partial class Sala : Window
    {

        public List<int> sjedista = new List<int>();
        public bool ljub = false;
        public bool vip = false;
        public int pozicija;
        public List<Button> dugmad = new List<Button>();
        public List<Button> kliknut = new List<Button>();
        public static double cijena = 0;
        public Sala()
        {

            InitializeComponent();


            foreach (Projekcija p in BlagajnikPocetna.projekcije)
            {
                Film fl = p.FilmFK;
                if (fl.Naziv == BlagajnikPocetna.naziv && p.VrijemeProjekcije ==BlagajnikPocetna.termin)
                {
                    BlagajnikPocetna.nece_da_moze = p.Zauzeto;
                }
            }

            dodaj();
            for (int i = 0; i < 64; i++) BlagajnikPocetna.nece_da_moze.Add(false);


            for (int i = 0; i < 64; i++)
            {
                if (BlagajnikPocetna.nece_da_moze[i])
                {

                    dugmad[i].IsEnabled = false;
                    dugmad[i].Background = Brushes.Red;
                }

            }


        }

        public void dodaj()
        {
            dugmad.Add(_1);
            dugmad.Add(_2);
            dugmad.Add(_3);
            dugmad.Add(_4);
            dugmad.Add(_5);
            dugmad.Add(_6);
            dugmad.Add(_7);
            dugmad.Add(_8);
            dugmad.Add(_9);
            dugmad.Add(_10);
            dugmad.Add(_11);
            dugmad.Add(_12);
            dugmad.Add(_13);
            dugmad.Add(_14);
            dugmad.Add(_15);
            dugmad.Add(_16);
            dugmad.Add(_17);
            dugmad.Add(_18);
            dugmad.Add(_19);
            dugmad.Add(_20);
            dugmad.Add(_21);
            dugmad.Add(_22);
            dugmad.Add(_23);
            dugmad.Add(_24);
            dugmad.Add(_25);
            dugmad.Add(_26);
            dugmad.Add(_27);
            dugmad.Add(_28);
            dugmad.Add(_29);
            dugmad.Add(_30);
            dugmad.Add(_31);
            dugmad.Add(_32);
            dugmad.Add(_33);
            dugmad.Add(_34);
            dugmad.Add(_35);
            dugmad.Add(_36);
            dugmad.Add(_37);
            dugmad.Add(_38);
            dugmad.Add(_39);
            dugmad.Add(_40);
            dugmad.Add(_41);
            dugmad.Add(_42);
            dugmad.Add(_43);
            dugmad.Add(_44);
            dugmad.Add(_45);
            dugmad.Add(_46);
            dugmad.Add(_47);
            dugmad.Add(_48);
            dugmad.Add(_49);
            dugmad.Add(_50);
            dugmad.Add(_51);
            dugmad.Add(_52);
            dugmad.Add(_53);
            dugmad.Add(_54);
            dugmad.Add(_55);
            dugmad.Add(_56);
            dugmad.Add(_57);
            dugmad.Add(_58);
            dugmad.Add(_59);
            dugmad.Add(_60);
            dugmad.Add(_61);
            dugmad.Add(_62);
            dugmad.Add(_63);
            dugmad.Add(_64);



        }



        private void l1_Click(object sender, RoutedEventArgs e)
        {
            sjedista.Add(7);
            sjedista.Add(8);
            ljub = true;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cijena = BlagajnikPocetna.osnova;

            foreach (Button b in kliknut)
            {

                b.Background = Brushes.Red;
                for (int i = 0; i < 64; i++)
                {

                    if (b.Name == dugmad[i].Name)
                    {
                        if (i % 6 == 0)
                        {
                            cijena += BlagajnikPocetna.cijenaLj;

                        }
                        else if (i > 56)
                        {
                            cijena += BlagajnikPocetna.cijenaVip;
                        }
                        BlagajnikPocetna.nece_da_moze[i] = true;
                        dugmad[i].IsEnabled = true;

                    }
                }

            }

            kliknut.Clear();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            kliknut.Add(_1);

        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_2);
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_3);
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_4);
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_5);
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_6);
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_7);
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_8);
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_9);
        }

        private void _10_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_10);
        }

        private void _11_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_11);
        }

        private void _12_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_12);
        }

        private void _13_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_13);
        }

        private void _14_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_14);
        }

        private void _15_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_15);
        }

        private void _16_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_16);
        }

        private void _17_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_17);
        }

        private void _18_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_18);
        }

        private void _19_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_19);
        }

        private void _20_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_20);
        }

        private void _21_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_21);
        }

        private void _22_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_22);
        }

        private void _23_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_23);
        }

        private void _24_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_24);
        }

        private void _25_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_25);
        }

        private void _26_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_26);
        }

        private void _27_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_27);
        }

        private void _28_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_27);
        }

        private void _29_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_29);
        }

        private void _30_Click(object sender, RoutedEventArgs e)
        {
            kliknut.Add(_30);
        }

        private void _31_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _32_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _33_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _35_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _36_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _37_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _38_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _39_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _40_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _41_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _42_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _43_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _44_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _45_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _46_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _47_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _48_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _49_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _50_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _51_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _52_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _53_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _54_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _55_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _56_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void _57_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _58_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _61_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _62_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _59_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _63_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _60_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _64_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
