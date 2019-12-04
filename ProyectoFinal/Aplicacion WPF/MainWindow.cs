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


namespace Aplicacion_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : PropiedadVentanas
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Btn_RegistrarsedeLogin_Click(object sender, RoutedEventArgs e) // evento que envia a la ventana para elegir y registrar un nuevo usuaria
        {
            Registro nuevoRegistro = new Registro(); // creo la ventana
            nuevoRegistro.ShowDialog(); // muestro la ventana
            
        }

        private void Btn_IngresardeLogin_Click(object sender, RoutedEventArgs e) // evento que me permite ingresar al sistema si coinsiden los datos con la base de datos
        {
            string salida = "Bienvenido!"; // string que se mostrara cuando ingrese al sistema si todo esta correcto

            if (!string.IsNullOrWhiteSpace(txtb_contraseniadeLogin.Text) && !string.IsNullOrWhiteSpace(txtb_UsuariodeLogin.Text)) // control para saber si se ingresaron todos los campos
            {
                UsuarioABM usuario = new UsuarioABM();
                if (usuario.validar(txtb_UsuariodeLogin.Text, txtb_contraseniadeLogin.Text))
                {
                    if (usuario.tipoUsuario(txtb_UsuariodeLogin.Text))
                    {
                        Cliente cliente = new Cliente();
                        cliente.EmailC = txtb_UsuariodeLogin.Text;
                        PrincipalCliente ppalCliente = new PrincipalCliente(cliente);
                       
                        MessageBox.Show(salida);
                        this.Close();
                        ppalCliente.Show();
                       
                    }
                    else
                    {
                        Principal_Contacto ppalContacto = new Principal_Contacto(txtb_UsuariodeLogin.Text); // creo la ventana Principal_Contacto
                        MessageBox.Show(salida); // muestro msj de bienvenida
                        this.Close();
                        ppalContacto.Show(); // muestro ventana
                        
                        
                    }
                
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrectos");
                }
               
            }
            else
            {
                salida = "Faltan Campos!"; // string que se mostrara en el msj de alerta
                MessageBox.Show(salida); // msj de alerta que se mostrara cuando falten ingresar campos

            }

        }   
        
    }
}
