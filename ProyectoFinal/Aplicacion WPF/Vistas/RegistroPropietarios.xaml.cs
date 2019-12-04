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
    /// Lógica de interacción para RegistroPropietarios.xaml
    /// </summary>
    public partial class RegistroPropietarios : Window
    {
        public RegistroPropietarios()
        {
            InitializeComponent();
        }

        private void Btn_cancelarRegistroPropietario_Click(object sender, RoutedEventArgs e) // evento para cerrar la ventana mediante un click en el boton cancelar
        {
            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }

        private void Btn_RegistrarDuenio_Click(object sender, RoutedEventArgs e) // evento que envia a la ventana para crear un nuevo duenio
        {
            Registro_Duenio nuevoDuenio = new Registro_Duenio();
            nuevoDuenio.Show();
            this.Close();
        }

        private void Btn_RegistrarInmobiliaria_Click(object sender, RoutedEventArgs e) // evento que envia a la ventana para crear una nueva inmobiliaria
        {
            Registro_Inmobiliaria nuevaInmobiliaria = new Registro_Inmobiliaria();
            nuevaInmobiliaria.Show();
            this.Close();

        }
    }
}
