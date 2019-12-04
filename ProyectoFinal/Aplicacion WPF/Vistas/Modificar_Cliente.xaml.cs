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
using Biblioteca_de_clases;
using NLog;

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Modificar_Cliente.xaml
    /// </summary>
    
    public partial class Modificar_Cliente : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ClienteABM CABM;
        
        public Modificar_Cliente( Cliente C)
        {
            InitializeComponent();
            
            CABM = new ClienteABM();
            CABM.SelectCliente(ref C);
            txtbx_ModNombreCliente.Text = C.NombreC;
            txtbx_ModApellidoCliente.Text = C.ApellidoC;
            txtbx_ModEmailCliente.Text = C.EmailC;
            txtbx_ModTelefonoCliente.Text = C.TelefonoC.ToString();
            txtbx_ModContraseniaCliente.Text = C.ContraseniaC;

        }


        private void Btn_cancelarModificarCliente_Click(object sender, RoutedEventArgs e) // Evento para cerrar la ventana modificar cliente
        {
            this.Close();
        }
              
       

        private void Btn_modificarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClienteABM clienteAmb = new ClienteABM();
                Cliente C = new Cliente();
                C.NombreC = txtbx_ModNombreCliente.Text;
                C.ApellidoC = txtbx_ModApellidoCliente.Text;
                C.EmailC = txtbx_ModEmailCliente.Text;
                C.ContraseniaC = txtbx_ModContraseniaCliente.Text;
                clienteAmb.updateCliente(C);
                MessageBox.Show("Modificacion Exitosa");
            }
            catch(Exception ex)
            {
                logger.Error("ERROR al modificar cliente-> {0}", ex.ToString());
                MessageBox.Show("Error al modificar");
            }
            
        }
    }
}
