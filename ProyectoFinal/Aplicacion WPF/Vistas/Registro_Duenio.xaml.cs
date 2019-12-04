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
    /// Lógica de interacción para Registro_Duenio.xaml
    /// </summary>
    public partial class Registro_Duenio : Window
    {
        public Registro_Duenio()
        {
            InitializeComponent();
        }

  

        private void Button_Click(object sender, RoutedEventArgs e) // evento para cerrar la ventana de registro del cliente
        {
            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }

        private void Btn_registrarDuenio_Click(object sender, RoutedEventArgs e) // evento que permite enviar los datos del nuevo duenio a la base de datos
        {
            string salida = "Dueño Registrado Correctamente."; // string que se mostrara en el msj si se registro correctamente
            if (!string.IsNullOrWhiteSpace(txtbx_DireccionDuenio.Text) && !string.IsNullOrWhiteSpace(txtbx_NombreDuenio.Text) && !string.IsNullOrWhiteSpace(txtbx_horarioDispDuenio.Text) &&
                !string.IsNullOrWhiteSpace(txtbx_TelefonoDuenio.Text) && !string.IsNullOrWhiteSpace(txtbx_ContraseniaDuenio.Text) && !string.IsNullOrWhiteSpace(txtbx_UsuarioDuenio.Text)) // control de si se ingresaron todos los datos
            {
                Duenio nuevoDuenio = new Duenio();
                DuenioABM duenioAbm = new DuenioABM();

                nuevoDuenio.Nombre = txtbx_NombreDuenio.Text;
                nuevoDuenio.HorarioDeDisponibilidad = txtbx_horarioDispDuenio.Text;
                nuevoDuenio.Telefono = Convert.ToInt32(txtbx_TelefonoDuenio.Text);
                nuevoDuenio.Direccion = txtbx_DireccionDuenio.Text;
                nuevoDuenio.Email = txtbx_UsuarioDuenio.Text;
                nuevoDuenio.Contrasenia = txtbx_ContraseniaDuenio.Text;

                duenioAbm.insertarDuenio(nuevoDuenio);
                MessageBox.Show(salida); // ventana de msj cuando se realiza correctamente el registrodue
                
            }
            else
            {
                salida = "Faltan Campos!"; // string que se mossrara en el msj de alerta
                MessageBox.Show(salida); // msj de alerta que se mostrara si faltan campos por completar
            }
            txtbx_NombreDuenio.Clear();
            txtbx_horarioDispDuenio.Clear();
            txtbx_TelefonoDuenio.Clear();
            txtbx_DireccionDuenio.Clear();
            txtbx_UsuarioDuenio.Clear();
            txtbx_ContraseniaDuenio.Clear();
        }
    }
}
