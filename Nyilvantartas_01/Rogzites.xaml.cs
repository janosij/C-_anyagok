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

namespace Nyilvantartas_01
{
    /// <summary>
    /// Interaction logic for Rogzites.xaml
    /// </summary>
    public partial class Rogzites : Window
    {
        AppDbContext ctx;
        public Rogzites(AppDbContext context, Dolgozo dolgozo)
        {
            InitializeComponent();
            ctx = context;
            this.DataContext = dolgozo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // a WPF Bindingnál mindig egy memóriában lévő gyűjteményt vár!!!
            // itt már NEM betöltjük a memóriába, mert ezt már megtettük a főprogramban:            
            //ctx.Szervezetiegysegek.Load();

            // de át kell adnunk a vezérlőnek: 
            cboSzerve.ItemsSource = ctx.Szervezetiegysegek.Local.ToObservableCollection();
            cboSzerve.DisplayMemberPath = "Nev";

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            // vissza kell olvasnom először, hogy melyik dolgozó van a datacontextben
            Dolgozo x = (Dolgozo)this.DataContext;
            // majd ellenőrizzük, hogy minden kötelezőt megadott-e a felhasználó
            // csak lightosan ellenőrzök
            if (x.Adoazonositojel.Length != 10)
            {
                txtAdojel.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNev.Text))
            {
                txtNev.Focus();
                return;
            }

            // Ez itt ravasz!  Ellenőrzi, hogy a TextBox-ban lévő adat
            // valid-e a beállított szabályok szerint? Miközben NEM állítottunk be szabályt!
            // De a binding automatikusan típuskonverziót és validációt végez az adattípus alapján
            // és itt az adattípus INT (XAML-ben megadtuk a kötésben az int típusú propertyt!!!)
            if (Validation.GetHasError(txtEvessz))
            {
                txtEvessz.Focus();
                return;
            }
            if (x.Szervezetiegyseg == null)
            {
                cboSzerve.IsDropDownOpen = true;
                return;
            }
            this.DialogResult = true;
            this.Close();


        }

        private void btnMegsem_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


    }

}
