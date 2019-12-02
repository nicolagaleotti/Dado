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
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            int numero = int.Parse(txtValore.Text);
            try
            {
                if (numero > 6)
                    throw new Exception("I numeri inseribili sono da 1 a 6.");
                int da = 1;
                int a = 7;
                Random random = new Random();
                int numeroCasuale = random.Next(da, a);
                if (numeroCasuale == numero)
                    lblResult.Content = $"Il numero uscito è {numeroCasuale}. Complimenti! Hai vinto!";
                else
                    lblResult.Content = $"Il numero uscito è {numeroCasuale}. Ritenta!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtValore.Text = "";
                lblResult.Content = "";
            }
        }
    }
}
