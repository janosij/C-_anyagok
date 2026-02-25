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

namespace Szokereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int id = 0;      
        List<Szo> szavak = new List<Szo>();
        List<Kartya> kartyak = new List<Kartya>();
        public MainWindow()
        {
            InitializeComponent();
            // beolvassuk a szavakat, az Id lesz, ami alapján összekapcsoljuk őket
            foreach (var sor in File.ReadAllLines("szo.txt"))
            {
                var resz = sor.Split(',');
                szavak.Add(new Szo
                {
                    Id = id++,
                    Hu = resz[0],
                    Eng = resz[1]
                });
            }
            // minden szót külön objektumba teszünk, de az összetartozóknál egyforma az Id!
            foreach (var szo in szavak)
            {
                kartyak.Add(new Kartya
                {
                    SzoId = szo.Id,
                    Felirat = szo.Hu
                });

                kartyak.Add(new Kartya
                {
                    SzoId = szo.Id,
                    Felirat = szo.Eng
                });
            }
            // összekutyuljuk a szavakat
            var kevert = kartyak.OrderBy(x => Guid.NewGuid()).ToList();
            
            //gr.ShowGridLines = true;
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                gr.ColumnDefinitions.Add(col);
            }
            for (int i = 0; i < 5; i++)
            {
                RowDefinition row = new RowDefinition();
                gr.RowDefinitions.Add(row);
            }
            for (int i = 0; i < gr.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < gr.RowDefinitions.Count; j++)
                {
                    int index = j * gr.ColumnDefinitions.Count + i;
                    Label l = new Label();
                    l.Margin = new Thickness(5);
                    l.Background = Brushes.LightGray;
                    l.Content = "?";
                    l.FontSize = 40;
                    l.HorizontalContentAlignment = HorizontalAlignment.Center;
                    l.VerticalContentAlignment = VerticalAlignment.Center;
                    // itt a tárolt objektumban benne an a szó és az Id is
                    l.Tag = new Kartya
                    {
                        SzoId = kevert[index].SzoId,
                        Felirat = kevert[index].Felirat
                    };
                    l.MouseLeftButtonDown += L_MouseLeftButtonDown;
                    Grid.SetColumn(l, i);
                    Grid.SetRow(l, j);
                    gr.Children.Add(l);
                }
            }


        }
        Label elso = null;
        Label masodik = null;
        bool varakozas = false;

        private async void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (varakozas) return;

            Label lbl = (Label)sender;
            Kartya kartya = (Kartya)lbl.Tag;

            // itt nem csinálunk semmit, ha már megtaláltuk a párját vagy fel van fordítva
            if (kartya.Paros || kartya.Felforditva) return;

            // felfordítás
            lbl.Content = kartya.Felirat;
            lbl.FontSize = 20;
            lbl.Background = Brushes.LightBlue;
            kartya.Felforditva = true;

            // ha ez az első felfordított, akkor megkapja az értéket, majd vár a következő fordításra:
            if (elso == null)
            {
                elso = lbl;
                return;
            }

            // ha nem ő volt az első, mert az elso != null, akkor ő a második
            // a varakozás = true akadályozza meg a következő felfordítását az if (varakozas) return; a metódus elején
            masodik = lbl;
            varakozas = true;

            // várunk kicsit
            await Task.Delay(1500);

            Kartya k1 = (Kartya)elso.Tag;
            Kartya k2 = (Kartya)masodik.Tag;

            if (k1.SzoId == k2.SzoId) // párt találtunk
            {
                k1.Paros = true;
                k2.Paros = true;

                elso.Background = Brushes.LightGreen;
                masodik.Background = Brushes.LightGreen;
            }
            else // nem találtunk párt
            {
                elso.Content = "?";
                masodik.Content = "?";

                elso.FontSize = 40;
                masodik.FontSize = 40;

                elso.Background = Brushes.LightGray;
                masodik.Background = Brushes.LightGray;

                k1.Felforditva = false;
                k2.Felforditva = false;
            }

            elso = null;
            masodik = null;
            varakozas = false;
        }

               
            
        
    }
}