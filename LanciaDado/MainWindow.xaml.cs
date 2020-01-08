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

namespace LanciaDado
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

        private void btnRicomincia_Click(object sender, RoutedEventArgs e)
        {
            txtValore.Text = "";
            lblResult.Content = "";
            lblPunti.Content = "100";
            dado.Source = null;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string v = txtValore.Text;
                if (v != "1" && v != "2" && v != "3" && v != "4" && v != "5" && v != "6")
                    throw new Exception("I numeri inseribili sono da 1 a 6.");
                int numero = int.Parse(txtValore.Text);
                int punti = int.Parse((lblPunti.Content).ToString());
                if (punti <= 0)
                    throw new Exception("Hai 0 punti. GAME OVER!");
                Random random = new Random();
                int numeroCasuale = random.Next(1, 7);
                dado.Source = new BitmapImage(new Uri($@"Immagini\dado{numeroCasuale}.png", UriKind.Relative));
                if (numeroCasuale == numero)
                {
                    lblResult.Content = $"Complimenti! Hai vinto!";
                    punti = punti + 15;
                    lblPunti.Content = punti.ToString();
                }
                else
                {
                    lblResult.Content = $"Ritenta!";
                    punti = punti - 5;
                    lblPunti.Content = punti.ToString();
                }
                txtValore.Clear();
                txtValore.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtValore.Text = "";
                lblResult.Content = "";
                lblPunti.Content = "100";
                dado.Source = null;
            }
        }
    }
}
