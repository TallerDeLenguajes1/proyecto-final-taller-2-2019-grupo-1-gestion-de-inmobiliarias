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
using Biblioteca_de_clases;
using AccesoDatos;

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Registro_Inmobiliaria.xaml
    /// </summary>
    public partial class Registro_Inmobiliaria : Window
    {
        public Registro_Inmobiliaria()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // evento para cerrar la ventana mediante un clic en el boton cancelar
        {
            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }

        private void Btn_registrarInmobiliaria_Click(object sender, RoutedEventArgs e)
        {
            
                string salida = "Inmobiliaria Registrada correctamente."; // string que se mostrara si  se registra correctamente
                if (!string.IsNullOrWhiteSpace(txtbx_DireccionInmobiliaria.Text) && !string.IsNullOrWhiteSpace(txtbx_NombreInmobiliaria.Text) && !string.IsNullOrWhiteSpace(txtbx_sitioWebInmobiliaria.Text) &&
                    !string.IsNullOrWhiteSpace(txtbx_TelefonoInmobiliaria.Text) && !string.IsNullOrWhiteSpace(txtbx_ContraseniaInmobiliaria.Text) && !string.IsNullOrWhiteSpace(txtbx_UsuarioInmobiliaria.Text)) // control para saber si se ingresaron todos los campos
                {
                    Inmobiliaria nuevaInmobiliaria = new Inmobiliaria();
                    InmobiliariaABM inmobiliariaAbm = new InmobiliariaABM();

                    nuevaInmobiliaria.Contrasenia = txtbx_ContraseniaInmobiliaria.Text;
                    nuevaInmobiliaria.Direccion = txtbx_DireccionInmobiliaria.Text;
                    nuevaInmobiliaria.Email = txtbx_UsuarioInmobiliaria.Text;
                    nuevaInmobiliaria.SitioWeb = txtbx_sitioWebInmobiliaria.Text;
                    nuevaInmobiliaria.Nombre = txtbx_NombreInmobiliaria.Text;
                    nuevaInmobiliaria.Telefono = Convert.ToInt32(txtbx_TelefonoInmobiliaria.Text);

                    inmobiliariaAbm.InsertInmobiliaria(nuevaInmobiliaria);


                    MessageBox.Show(salida); // msj que muestra si se registro correctamente
                }
                else
                {
                    salida = "Faltan Campos!"; // string que se mostrara en el msj de alerta
                    MessageBox.Show(salida); // msj de alerta que se mostrara cuando no se ingresaron todos los campos
                }
            txtbx_NombreInmobiliaria.Clear();
            txtbx_UsuarioInmobiliaria.Clear();
            txtbx_ContraseniaInmobiliaria.Clear();
            txtbx_DireccionInmobiliaria.Clear();
            txtbx_TelefonoInmobiliaria.Clear();
            txtbx_TelefonoInmobiliaria.Clear();
        }
        
    }
}
