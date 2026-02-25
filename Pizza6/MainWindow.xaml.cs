using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;
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

namespace Pizza6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("pizza.json"))
            {
                var be = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText("pizza.json"));
                if (be != null)
                {
                    foreach(var i in be)
                    {
                        lb.Items.Add(i);
                    }
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pizza x = new Pizza();
            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Írj megrendelőt!");
                txt.Focus();
            }
            x.Megrendelo = txt.Text;
            x.Nev = ((ComboBoxItem)cb.SelectedItem).Content.ToString() ?? "";
            x.Alap = rb1.IsChecked==true ? "Paradicsom" : "tejföl";
            if (cb1.IsChecked==true)
            {
                x.Extrak.Add("Chili");
            }
            if (cb2.IsChecked == true)
            {
                x.Extrak.Add("Sajt");
            }
            if (cb1.IsChecked == true)
            {
                x.Extrak.Add("Avokádó");
            }
            
            lb.Items.Add(x);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lb.Items.Remove(lb.SelectedItem);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            File.WriteAllText("pizza.json", JsonConvert.SerializeObject(lb.Items));
        }
    }
}