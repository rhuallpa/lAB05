﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lAB05
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertarCliente insertar = new InsertarCliente();
            insertar.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListarClientes lista = new ListarClientes();
            lista.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BuscarID buscar = new BuscarID();
            buscar.ShowDialog();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EliminarCliente eliminarCliente = new EliminarCliente();
            eliminarCliente.ShowDialog();
        }
    }
}