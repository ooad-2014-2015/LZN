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
    public partial class Page3 : PhoneApplicationPage
    {
        public List<string> vrijeme = new List<string>();
        public Page3()
        {
            InitializeComponent();
            Napuni();
            Dodijeli();
        }

        public void Napuni()
        {
            vrijeme.Add("12:30");
            vrijeme.Add("13:00");
            vrijeme.Add("13:15");
            vrijeme.Add("15:30");
            vrijeme.Add("16:00");
            vrijeme.Add("16:15");
            vrijeme.Add("16:30");
            vrijeme.Add("17:30");
            vrijeme.Add("18:20");
            vrijeme.Add("18:30");
            vrijeme.Add("19:15");
            vrijeme.Add("19:30");
            vrijeme.Add("20:30");

        }

        public void Dodijeli()
        {
            Random rand = new Random();
            int br = rand.Next(1, 10);
            p1.Content = vrijeme[br];
            p2.Content = vrijeme[br + 1];
            p3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            u1.Content = vrijeme[br];
            u2.Content = vrijeme[br + 1];
            u3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            s1.Content = vrijeme[br];
            s2.Content = vrijeme[br + 1];
            s3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            c1.Content = vrijeme[br];
            c2.Content = vrijeme[br + 1];
            c3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            pe1.Content = vrijeme[br];
            pe2.Content = vrijeme[br + 1];
            pe3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            su1.Content = vrijeme[br];
            su2.Content = vrijeme[br + 1];
            su3.Content = vrijeme[br + 2];

            br = rand.Next(1, 10);
            n1.Content = vrijeme[br];
            n2.Content = vrijeme[br + 1];
            n3.Content = vrijeme[br + 2];
        }
    }
}