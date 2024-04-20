using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Lógica de interacción para EliminarCliente.xaml
    /// </summary>
    public partial class EliminarCliente : Window
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idCliente = txtIdCliente.Text.Trim();

            if (!string.IsNullOrEmpty(idCliente))
            {
                try
                {
                    EliminarClienteLogico(idCliente);
                    MessageBox.Show("Cliente eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el ID del cliente que desea eliminar.");
            }
        }

        private void EliminarClienteLogico(string idCliente)
        {
           
            string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS; Initial Catalog=neptuno; User Id=UserHuallpa; Password=1234567";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("EliminarClienteLogico", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdCliente", idCliente);

                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
