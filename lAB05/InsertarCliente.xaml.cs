using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace lAB05
{
    public partial class InsertarCliente : Window
    {
        public InsertarCliente()
        {
            InitializeComponent();
        }

        private int checkBoxValue = 0;

        public int CheckBoxValue
        {
            get { return checkBoxValue; }
            set { checkBoxValue = value; }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxValue = 1;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxValue = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS; Initial Catalog=neptuno; User Id=UserHuallpa; Password=1234567";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("InsertarCliente", connection);


                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@idCliente", txtidCliente.Text);
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

                    if (checkBox.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@Activo", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Activo", 0);
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show("Cliente insertado correctamente.");

                    ListarClientes lista = new ListarClientes();
                    lista.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar cliente: " + ex.Message);
                }
            }
        }
    }
}
