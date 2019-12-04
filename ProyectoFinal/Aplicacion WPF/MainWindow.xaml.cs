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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aplicacion_WPF.Vistas;
using AccesoDatos;
using Biblioteca_de_clases;
using NLog;

namespace Aplicacion_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            txtb_UsuariodeLogin.Focus();//el foco empiece en este textbox
           
            InitializeComponent();

           
        }

        private void Btn_RegistrarsedeLogin_Click(object sender, RoutedEventArgs e) // evento que envia a la ventana para elegir y registrar un nuevo usuaria
        {
            Registro nuevoRegistro = new Registro(); // creo la ventana
            nuevoRegistro.Show(); // muestro la ventana
            this.Close();
        }

        private void Btn_IngresardeLogin_Click(object sender, RoutedEventArgs e) // evento que me permite ingresar al sistema si coinsiden los datos con la base de datos
        {
            string salida = "Bienvenido!"; // string que se mostrara cuando ingrese al sistema si todo esta correcto

            if (!string.IsNullOrWhiteSpace(txtb_contraseniadeLogin.Password) && !string.IsNullOrWhiteSpace(txtb_UsuariodeLogin.Text)) // control para saber si se ingresaron todos los campos
            {
                UsuarioABM usuario = new UsuarioABM();
                if (usuario.validar(txtb_UsuariodeLogin.Text, txtb_contraseniadeLogin.Password))
                {
                    if (usuario.tipoUsuario(txtb_UsuariodeLogin.Text))
                    {

                        logger.Info("se logueo el cliente->"+txtb_UsuariodeLogin.Text);
                        PrincipalCliente ppalCliente = new PrincipalCliente(txtb_UsuariodeLogin.Text);
                        this.Close();
                        ppalCliente.Show();

                    }
                    else
                    {
                        logger.Info("se logueo el contacto->" + txtb_UsuariodeLogin.Text);
                        Principal_Contacto ppalContacto = new Principal_Contacto(txtb_UsuariodeLogin.Text); // creo la ventana Principal_Contacto
                        MessageBox.Show(salida); // muestro msj de bienvenida
                        this.Close();
                        ppalContacto.Show(); // muestro ventana


                    }

                }
                else
                {
                    logger.Warn("se logueo incorrectamente email->" + txtb_UsuariodeLogin.Text + "-pass->"+txtb_contraseniadeLogin.Password);
                    MessageBox.Show("Usuario y/o Contraseña incorrectos");
                }
               
            }
            else
            {
                salida = "Faltan Campos!"; // string que se mostrara en el msj de alerta
                MessageBox.Show(salida); // msj de alerta que se mostrara cuando falten ingresar campos

            }

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)//detecta cuando se presiona ENTER para actibar el boton de logueo
        {
            if (e.Key == Key.Enter)
            {
                Btn_IngresardeLogin_Click((object)sender, e);
            }
        }
    }
}
