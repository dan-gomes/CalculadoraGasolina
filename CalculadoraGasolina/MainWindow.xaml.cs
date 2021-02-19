using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalculadoraGasolina
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {           

            if (full.Text != null 
                && km_lt.Text != null 
                && km_ida.Text != null
                && km_volta.Text != null)
            {
                if (Regex.IsMatch(full.Text,"\\d") 
                    && Regex.IsMatch(km_lt.Text, "\\d") 
                    && Regex.IsMatch(km_ida.Text, "\\d")
                    && Regex.IsMatch(km_volta.Text, "\\d"))
                {
                    decimal precoLitro = Convert.ToDecimal(full.Text);
                    int kmPorLitro = Convert.ToInt32(km_lt.Text);
                    decimal distancia = Convert.ToDecimal(km_ida.Text) + Convert.ToDecimal(km_volta.Text);
                    var quantidadeLitro = distancia / kmPorLitro;
                    var valorPago = precoLitro * quantidadeLitro;
                    resultado.Text = $"{valorPago:C2}";
                    return;
                }              
            }

            resultado.Text = "Error";
        }
    }
}
