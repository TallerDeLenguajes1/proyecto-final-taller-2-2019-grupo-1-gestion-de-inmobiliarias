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
using NLog;
namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Modifica_Inmobiliaria.xaml
    /// </summary>
    public partial class Modifica_Inmobiliaria : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        InmobiliariaABM InmobiliariaABM=new InmobiliariaABM();
        public Modifica_Inmobiliaria(Inmobiliaria inmobiliaria)
        {
            InitializeComponent();
            InmobiliariaABM.SelectInmobiliaria(ref inmobiliaria);
            txtbx_NombreInmobiliaria.Text = inmobiliaria.Nombre;
            txtbx_DireccionInmobiliaria.Text = inmobiliaria.Direccion;
            txtbx_ContraseniaInmobiliaria.Text = inmobiliaria.Contrasenia;
            txtbx_sitioWebInmobiliaria.Text = inmobiliaria.SitioWeb;
            txtbx_TelefonoInmobiliaria.Text = inmobiliaria.Telefono.ToString();
            txtbx_UsuarioInmobiliaria.Text = inmobiliaria.Email;
        }

        private void Btn_registrarInmobiliaria_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Inmobiliaria I = new Inmobiliaria();
                I.Nombre = txtbx_NombreInmobiliaria.Text;
                I.Telefono = Convert.ToInt32(txtbx_TelefonoInmobiliaria.Text);
                I.Email = txtbx_UsuarioInmobiliaria.Text;
                I.SitioWeb= txtbx_sitioWebInmobiliaria.Text;
                I.Contrasenia = txtbx_ContraseniaInmobiliaria.Text;
                I.Direccion = txtbx_DireccionInmobiliaria.Text;
                InmobiliariaABM.Updateinmobiliaria(I);
                MessageBox.Show("Modificado correctamente");
            }
            catch (Exception ex)
            {
                logger.Error("ERROR al modificar inmobiliaria-> {0}", ex.ToString());
                MessageBox.Show("error al modificar");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Principal_Contacto X = new Principal_Contacto(txtbx_UsuarioInmobiliaria.Text);
            X.Show();
            this.Close();
        }
    }
}
