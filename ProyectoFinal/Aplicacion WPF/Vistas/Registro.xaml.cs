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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Btn_CancelarRegistro_Click(object sender, RoutedEventArgs e) // evento para cerrar la ventana haciendo click en el boton cancelar
        {
            MainWindow X = new MainWindow();
            X.Close();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // evento que me envia a la ventana para crear un nuevo propietario
        {
            RegistroPropietarios nuevoPropietario = new RegistroPropietarios();
            nuevoPropietario.Show();
            this.Close();
        }

        private void Btn_RegistrarCliente_Click(object sender, RoutedEventArgs e) // evento que me envia a la ventana para elegir que tipo de propietario crear
        {
            RegistrioClientes nuevocliente = new RegistrioClientes();
            nuevocliente.Show();
            this.Close();
        }
    }
}
