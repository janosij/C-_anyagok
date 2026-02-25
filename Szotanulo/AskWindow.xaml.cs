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

namespace Szotanulo
{
    /// <summary>
    /// Interaction logic for AskWindow.xaml
    /// </summary>
    public partial class AskWindow : Window
    {
        Szo sz;
        public AskWindow(Szo sz)
        {
            InitializeComponent();
            this.sz = sz;
            hun.Content = sz.Hu;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.ToLower() == sz.Eng.ToLower())
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
