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

namespace Lottohuzas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SortedSet<int> adatok = new SortedSet<int>();
        List<SortedSet<int>>? eddigi;

        private List<SortedSet<int>> Szamok()
        {
            List<SortedSet<int>> eddigi = new List<SortedSet<int>>();
            foreach (var i in File.ReadAllLines("otos.csv"))
            {
                string[] z = i.Split(';');
                SortedSet<int> c = new SortedSet<int>();
                c.Add(int.Parse(z[11]));
                c.Add(int.Parse(z[12]));
                c.Add(int.Parse(z[13]));
                c.Add(int.Parse(z[14]));
                c.Add(int.Parse(z[15]));
                eddigi.Add(c);
            }
            return eddigi;

        }

        private void Kirajzol(Grid grid)
        {
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.Margin = new Thickness(0, 70, 0, 0);
            grid.Width = 450;
            grid.Height = 200;
            //grid.ShowGridLines = true;
            for (int i = 0; i < 15; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                grid.ColumnDefinitions.Add(col);
            }
            for (int i = 0; i < 6; i++)
            {
                RowDefinition row = new RowDefinition();
                grid.RowDefinitions.Add(row);
            }

            gr.Children.Add(grid);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Button button = new Button();
                    button.Content = ((j + 1) + i * 15).ToString();
                    button.Name = "b" + ((j + 1) + i * 15).ToString();
                    button.Click += btn_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    grid.Children.Add(button);

                }
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            Grid grid = new Grid();
            Kirajzol(grid);

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (adatok.Count < 5)
            {
                Button clicked = (Button)sender;
                clicked.Background = Brushes.White;
                clicked.Foreground = Brushes.Red;
                clicked.FontWeight = FontWeights.Bold;
                int szam = int.Parse(clicked.Name.Substring(1, clicked.Name.Length - 1));

                adatok.Add(szam);
                if (adatok.Count == 5)
                {
                    eddigi = Szamok();
                    string sz = "";
                    foreach (var i in adatok)
                    {
                        sz += i.ToString() + ", ";
                    }

                    lsb.Items.Add(sz);
                    int otos = 0;
                    int negyes = 0;
                    int harmas = 0;
                    int kettes = 0;
                    int egyes = 0;
                    int nullas = 0;
                    foreach (var i in eddigi)
                    {
                        i.IntersectWith(adatok);
                        if (i.Count == 5)
                        {
                            otos++;
                        }
                        else if (i.Count == 4)
                        {
                            negyes++;
                        }
                        else if (i.Count == 3)
                        {
                            harmas++;
                        }
                        else if (i.Count == 2)
                        {
                            kettes++;
                        }
                        else if (i.Count == 1)
                        {
                            egyes++;
                        }
                        else if (i.Count == 0)
                        {
                            nullas++;
                        }
                    }
                    tbotos.Text = otos.ToString();
                    tbnegyes.Text = negyes.ToString();
                    tbharmas.Text = harmas.ToString();
                    tbkettes.Text = kettes.ToString();
                    tbegyes.Text = egyes.ToString();
                    tbnullas.Text = nullas.ToString();
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gr.Children.RemoveRange(5, 1);
            adatok.Clear();
            eddigi.Clear();
            lsb.Items.Clear();
            Grid grid = new Grid();
            Kirajzol(grid);
            tbotos.Text = "";
            tbnegyes.Text = "";
            tbharmas.Text = "";
            tbkettes.Text = "";
            tbegyes.Text = "";
            tbnullas.Text = "";

        }
    }


}