using System;
using System.Data.SqlClient;
using System.Windows;

namespace lAB05
{
    public partial class ActualizarCliente : Window
    {
        private string idCliente;

        public ActualizarCliente(string idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            txtidCliente.Text = idCliente;
            CargarDatosCliente(idCliente);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActualizarClienteEnBaseDeDatos();
        }

        private void CargarDatosCliente(string idCliente)
        {
            string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS; Initial Catalog=Neptuno; User Id=UserHuallpa; Password=1234567";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Clientes WHERE idCliente = @IdCliente", connection);
                    command.Parameters.AddWithValue("@IdCliente", idCliente);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombreCompañia.Text = reader["NombreCompañia"].ToString();
                        txtNombreContacto.Text = reader["NombreContacto"].ToString();
                        txtCargoContacto.Text = reader["CargoContacto"].ToString();
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtCiudad.Text = reader["Ciudad"].ToString();
                        txtRegion.Text = reader["Region"].ToString();
                        txtCodPostal.Text = reader["CodPostal"].ToString();
                        txtPais.Text = reader["Pais"].ToString();
                        txtTelefono.Text = reader["Telefono"].ToString();
                        txtFax.Text = reader["Fax"].ToString();
                        checkBox.IsChecked = (bool)reader["Activo"];
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos del cliente: " + ex.Message);
                }
            }
        }

        private void ActualizarClienteEnBaseDeDatos()
        {
            string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS; Initial Catalog=Neptuno; User Id=Fendo; Password=123456";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ActualizarCliente", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdCliente", idCliente);
                    command.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                    command.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                    command.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    command.Parameters.AddWithValue("@Pais", txtPais.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Fax", txtFax.Text);
                    command.Parameters.AddWithValue("@Activo", checkBox.IsChecked == true ? 1 : 0);

                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show("Cliente actualizado correctamente.");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }
    }
}