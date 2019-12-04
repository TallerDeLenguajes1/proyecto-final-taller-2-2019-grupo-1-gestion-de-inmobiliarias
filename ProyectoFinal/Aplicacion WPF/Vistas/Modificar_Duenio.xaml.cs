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
using AccesoDatos;
using NLog;

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Modificar_Duenio.xaml
    /// </summary>
    public partial class Modificar_Duenio : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        DuenioABM duenioABM;
        public Modificar_Duenio(Duenio D)
        {
            InitializeComponent();
            duenioABM = new DuenioABM();
            duenioABM.SelectDuenio(ref D);
            txtbx_NombreDuenio.Text = D.Nombre;
            txtbx_TelefonoDuenio.Text = D.Telefono.ToString();
            txtbx_EmailDuenio.Text = D.Email;
            txtbx_horarioDispDuenio.Text = D.HorarioDeDisponibilidad;
            txtbx_ContraseniaDuenio.Text = D.Contrasenia;
        }

        private void Btn_cancelarModificarDuenio_Click(object sender, RoutedEventArgs e)
        {
            Principal_Contacto X = new Principal_Contacto(txtbx_EmailDuenio.Text);
            X.Show();
            this.Close();
        }

        private void Btn_modificarDuenio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Duenio duenio = new Duenio();
                duenio.Nombre = txtbx_NombreDuenio.Text;
                duenio.Telefono = Convert.ToInt32(txtbx_TelefonoDuenio.Text);
                duenio.Email = txtbx_EmailDuenio.Text;
                duenio.HorarioDeDisponibilidad = txtbx_horarioDispDuenio.Text;
                duenio.Contrasenia = txtbx_ContraseniaDuenio.Text;
                duenioABM.updateDuenio(duenio);
                MessageBox.Show("Modificado correctamente");
            }
            catch (Exception ex)
            {
                logger.Error("ERROR al modificar duenio-> {0}", ex.ToString());
                MessageBox.Show("error al modificar");             
            }
           
        }

        private void Txtbx_TelefonoDuenio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
