using AccesoDatos;
using Biblioteca_de_clases;
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

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrioClientes.xaml
    /// </summary>
    public partial class RegistrioClientes : Window
    {
        public RegistrioClientes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // evento para cerrar la ventana mediante un click en el boton cancelar
        {
            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }

        private void Btn_registrarCliente_Click(object sender, RoutedEventArgs e) // evento para enviar los datos del nuevo cliente a la base de datos
        {
            string salida = "Cliente Creado Correctamente."; // string que se mostrara si se el siqguiente control
            if (!string.IsNullOrWhiteSpace(txtbx_ApellidoCliente.Text) && !string.IsNullOrWhiteSpace(txtbx_UsuarioCliente.Text) && !string.IsNullOrWhiteSpace(txtbx_NombreCliente.Text) &&
                !string.IsNullOrWhiteSpace(txtbx_TelefonoCliente.Text) && !string.IsNullOrWhiteSpace(txtbx_ContraseniaCliente.Text) && !string.IsNullOrWhiteSpace(txtbx_UsuarioCliente.Text)) // control para saber si se ingresaron todos los campos
            {
                Cliente cliente = new Cliente();
                ClienteABM clienteAbm = new ClienteABM();
                cliente.ApellidoC = txtbx_ApellidoCliente.Text;
                cliente.NombreC = txtbx_NombreCliente.Text;
                cliente.TelefonoC = Convert.ToInt32(txtbx_TelefonoCliente.Text);
                cliente.EmailC = txtbx_UsuarioCliente.Text;
                cliente.ContraseniaC = txtbx_ContraseniaCliente.Text;
               
                clienteAbm.insertarCliente(cliente);

                UsuarioABM usuarioCLiente = new UsuarioABM();
                //usuarioCLiente.ingresarUsuario(cliente);

                MessageBox.Show(salida);
            }
            else
            {
                salida = "Faltan Campos!"; // string que se mostrara en el msj de alerta
                MessageBox.Show(salida); // msj de alerta que se mostrara si faltan campos por completar
            }
            txtbx_ApellidoCliente.Clear();
            txtbx_ContraseniaCliente.Clear();
            txtbx_NombreCliente.Clear();
            txtbx_TelefonoCliente.Clear();
            txtbx_UsuarioCliente.Clear();
        }
    }
}
