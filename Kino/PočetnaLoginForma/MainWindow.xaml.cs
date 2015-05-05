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
            if(username.Text == "blagajnik")
            {
                var prozor = new BlagajnikPočetna();
                this.Close();
                prozor.ShowDialog();
                //exit();
            }
            else if (username.Text == "finansije")
            {
                var prozor = new FinansijskiMenadžerPočetna(); //Proslijedit logovanog korisnika
                this.Close();
                prozor.ShowDialog();

            }
            else
            {
                var prozor = new AdministratorPočetna();
                this.Close();
                prozor.ShowDialog();
                //exit();
            }
           
        }
    }
}
