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

namespace lAB05
{
    /// <summary>
    /// Lógica de interacción para BuscarID.xaml
    /// </summary>
    public partial class BuscarID : Window
    {
        public BuscarID()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idCliente = txtIdCliente.Text;

            if (!string.IsNullOrEmpty(idCliente))
            {
                ActualizarCliente actualizarClienteWindow = new ActualizarCliente(idCliente);
                actualizarClienteWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el ID del cliente que desea actualizar.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
