using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szotanulo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szo> szotar = new List<Szo>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var i in File.ReadAllLines("szo.txt"))
            {                
                string[] resz = i.Split(',');
                szotar.Add(new Szo()
                {
                    Hu = resz[0],
                    Eng = resz[1]
                });             
            }
            Random rng = new Random();
            var szotar1 = szotar.OrderBy(x => rng.Next()).ToList();

            foreach (var i in szotar1)
            {
                Label l = new Label();
                l.Content = "?";
                l.FontSize = 60;
                l.Background = Brushes.LightGray;
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                l.VerticalContentAlignment = VerticalAlignment.Center;
                l.Width = 100;
                l.Height = 100;
                l.Tag = i;
                l.Margin = new Thickness(10);
                l.MouseLeftButtonDown += L_MouseLeftButtonDown; ;
                wp.Children.Add(l);

            }

        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label)sender;
            if (l.Background == Brushes.LightPink || l.Background == Brushes.LightGreen)
            {
                return;
            }
            AskWindow aw = new AskWindow((Szo)l.Tag);
            var result = aw.ShowDialog();
            if (result == true)
            {
                l.Background = Brushes.LightGreen;
                l.FontSize = 12;
                l.Content = ((Szo)l.Tag).Hu + "\n" + ((Szo)l.Tag).Eng;
            }
            else
            {
                l.Background= Brushes.LightPink;
            }
        }
    }
}