using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
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

namespace Nyilvantartas_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppDbContext ctx = new AppDbContext();
        ObservableCollection<Dolgozo> dolgozok = new ObservableCollection<Dolgozo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        // az esetlegesen lassú adatbázis kapcsolat miatt töltjük be itt és nem a konstruktorban
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // a WPF Bindingnál mindig egy memóriában lévő gyűjteményt vár!!!
            // ezért itt betöltjük a memóriába:            
            ctx.Szervezetiegysegek.Load();

            // majd átadjuk a vezérlőnek: 
            cboSzervez.ItemsSource = ctx.Szervezetiegysegek.Local.ToObservableCollection();

            // Vagy listává konvertáljuk a lekérdezés eredményét és ezzel már be is kerül a memóriába
            // majd átadjuk a combobox forrásának
            // (itt nem kell a DisplayMemberPath mert csak a név van a listában NEM az objektum!):
            /*
            var ad = ctx.Szervezetiegysegek.Select(x => x.Nev).ToList();
            cboSzervez.ItemsSource = ad;
            */

            // Hogy betöltődéskor már látszódjanak az adatbázisban lévő adatok
            var adat = ctx.Dolgozok.ToList();
            dolgozok = new ObservableCollection<Dolgozo>(adat);
            dg.ItemsSource = dolgozok;
        }


        private void btnKereses_Click(object sender, RoutedEventArgs e)
        {
            // itt ki kell választani, hogy a 2 lehetőség közül választott-e
            // legalább egyet vagy mindkettőt
            var adat = ctx.Dolgozok
            .Where(x =>
                (x.Adoazonositojel == txtAdoaz.Text || string.IsNullOrEmpty(txtAdoaz.Text)) &&
                (x.Szervezetiegyseg == cboSzervez.SelectedItem || cboSzervez.SelectedItem == null)
            )
            .ToList();
            dolgozok = new ObservableCollection<Dolgozo>(adat);
            dg.ItemsSource = dolgozok;

        }

        private void btnFelttor_Click(object sender, RoutedEventArgs e)
        {
            txtAdoaz.Text = "";
            cboSzervez.SelectedIndex = -1;
            // végszükségben így is lehet frissíteni a datagrid frissítését!!! Jegyezzük meg!!!
            btnKereses_Click(null, null);
        }

        private void btnUj_Click(object sender, RoutedEventArgs e)
        {
            Dolgozo x = new Dolgozo()
            {
                Felveteldatuma = DateTime.Now
            };

            // FONTOS a két paraméter, mert a Rogzites ablaknak szüksége van
            // az adatbázis contextre, hogy ismerje pl. a szervezeti egységeket!
            // a Dolgozo példány átadása is kell, hogy a másik ablak tudja,
            // új dolgozó vagy módosítás, ugyanazt az objektumpéldányt használja mindkét ablak!!!
            Rogzites rogzites = new Rogzites(ctx, x);

            if (rogzites.ShowDialog() == true)
            {
                // Ha minden rendben volt a módosítással,
                // akkor a státuszát módosítottra változtatjuk, majd mentjük
                ctx.Dolgozok.Add(x);
                ctx.SaveChanges();
                dolgozok.Add(x);

            }

        }

        private void btnModositas_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Dolgozo x = (Dolgozo)dg.SelectedItem;
                Rogzites rogzites = new Rogzites(ctx, x);


                if (rogzites.ShowDialog() == true)
                {
                    // Ha minden rendben volt a módosítással,
                    // akkor a státuszát módosítottra változtatjuk, ezzel jelezzük az EF-nek,
                    // hogy mentse a változásokat (UPDATE SQL parancs)                    
                    ctx.Entry(x).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                else
                {
                    // akarta módosítani, talán át is írt ezt-azt, de a Mégsem gombra kattintott
                    // ilyenkor NEM akarom látni a módosítást a Datagridben
                    ctx.Entry(x).State = EntityState.Unchanged;
                    dg.Items.Refresh();
                }
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                if (MessageBox.Show("Biztosan törölni szeretnéd?", "Hé", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Dolgozo x = (Dolgozo)dg.SelectedItem;
                    ctx.Remove(x);
                    ctx.SaveChanges();
                    dolgozok.Remove(x);
                }

            }

        }

    }
}