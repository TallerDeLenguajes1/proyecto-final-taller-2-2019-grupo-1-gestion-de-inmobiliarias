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
    /// Lógica de interacción para CrearTerreno.xaml
    /// </summary>
    public partial class CrearTerreno : Window
    {
        Contacto contacto;
        string mail;
        bool modificar=false;
        bool mostrar = false;
        public CrearTerreno(Terreno C,string email, int X)//inicio de mostrar cliente
        {
            InitializeComponent();
            mostrar = true;
            mail = email;
            btn_AñadirTerreno.Visibility=Visibility.Hidden;
            //cmbx_EstadoTerreno.Items.Add("En Venta");
            //cmbx_EstadoTerreno.Items.Add("No Disponible");
            titulo_ventanaNuevoTerreno.Content = "MOSTRAR";
            txtb_DireccionTerreno.Text = C.DireccionI;
            txtb_nombreTerreno.Text = C.NombreI;
            txtb_PrecioTerreno.Text = C.PrecioI.ToString();
            txtb_SuperficieTerreno.Text = C.SuperficieI.ToString();
            switch (C.EstadoI)
            {
             
                case estado.NoDisponible:
                    cmbx_EstadoTerreno.Items.Add("No Disponible");
                    cmbx_EstadoTerreno.SelectedIndex = 0;
                    break;
                case estado.Venta:
                    cmbx_EstadoTerreno.Items.Add("En Venta");
                    cmbx_EstadoTerreno.SelectedIndex = 0    ;
                    break;
            }
            cmbx_EstadoTerreno.IsReadOnly = true;
            txtb_DireccionTerreno.IsReadOnly = true;
            txtb_nombreTerreno.IsReadOnly = true;
            txtb_PrecioTerreno.IsReadOnly = true;
            txtb_SuperficieTerreno.IsReadOnly = true;
            cmbx_EstadoTerreno.IsReadOnly = true;
        }
        public CrearTerreno(Terreno C, string email)//inicio de mostrar
        {
            InitializeComponent();
            mail = email;
            btn_AñadirTerreno.Visibility = Visibility.Hidden;
            //cmbx_EstadoTerreno.Items.Add("En Venta");
            //cmbx_EstadoTerreno.Items.Add("No Disponible");
            titulo_ventanaNuevoTerreno.Content = "MOSTRAR";
            txtb_DireccionTerreno.Text = C.DireccionI;
            txtb_nombreTerreno.Text = C.NombreI;
            txtb_PrecioTerreno.Text = C.PrecioI.ToString();
            txtb_SuperficieTerreno.Text = C.SuperficieI.ToString();
            switch (C.EstadoI)
            {

                case estado.NoDisponible:
                    cmbx_EstadoTerreno.Items.Add("No Disponible");
                    cmbx_EstadoTerreno.SelectedIndex = 0;
                    break;
                case estado.Venta:
                    cmbx_EstadoTerreno.Items.Add("En Venta");
                    cmbx_EstadoTerreno.SelectedIndex = 0;
                    break;
            }
            cmbx_EstadoTerreno.IsReadOnly = true;
            txtb_DireccionTerreno.IsReadOnly = true;
            txtb_nombreTerreno.IsReadOnly = true;
            txtb_PrecioTerreno.IsReadOnly = true;
            txtb_SuperficieTerreno.IsReadOnly = true;
            cmbx_EstadoTerreno.IsReadOnly = true;
        }
        public CrearTerreno(Contacto C,string email)//inicio de crear
        {
            InitializeComponent();
            contacto = C;
            cmbx_EstadoTerreno.Items.Add("En Venta");
            cmbx_EstadoTerreno.Items.Add("No Disponible");
            mail = email;
        }
        public CrearTerreno(Terreno C, string email,bool activar)//inicion de modificar
        {
            InitializeComponent();
            btn_AñadirTerreno.Content = "modificar";
            cmbx_EstadoTerreno.Items.Add("En Venta");
            cmbx_EstadoTerreno.Items.Add("No Disponible");
            mail = email;
            modificar = activar;
            titulo_ventanaNuevoTerreno.Content = "Modificar Terreno";
            txtb_DireccionTerreno.Text=C.DireccionI;
            txtb_nombreTerreno.Text=C.NombreI;
            txtb_PrecioTerreno.Text=C.PrecioI.ToString();
            txtb_SuperficieTerreno.Text=C.SuperficieI.ToString();
            switch (C.EstadoI)
            {
                case estado.Alquiler:
                    cmbx_EstadoTerreno.SelectedIndex = 0;
                    break;
                case estado.NoDisponible:
                    cmbx_EstadoTerreno.SelectedIndex = 1;
                    break;
                case estado.Venta:
                    cmbx_EstadoTerreno.SelectedIndex = 2;
                    break;
            }
        }

        private void Btn_CancelarCrearTerreno_Click(object sender, RoutedEventArgs e) // evento para cerrrar la ventana mediante un click en el boton cancelar
        {

            if (mostrar)
            {
                //PrincipalCliente C = new PrincipalCliente(mail);
                //C.Show();
                this.Close();
            }
            else
            {
                Principal_Contacto C = new Principal_Contacto(mail);
                C.Show();
                this.Close();
            }
        }

        private void Btn_AñadirTerreno_Click(object sender, RoutedEventArgs e) // evento que envia los datos del nuevo terreno a la base de datos
        {
            string salida = "Terreno Creado Correctamente.";
            if (!string.IsNullOrWhiteSpace(txtb_DireccionTerreno.Text) && !string.IsNullOrWhiteSpace(txtb_nombreTerreno.Text) &&
                !string.IsNullOrWhiteSpace(txtb_PrecioTerreno.Text) && !string.IsNullOrWhiteSpace(txtb_SuperficieTerreno.Text)) // control que sirve para saber si se ingresaron todos los campos
            {
                Terreno nuevoTerreno = new Terreno();
                TerrenoABM terrenoAbm = new TerrenoABM();

                nuevoTerreno.DireccionI = txtb_DireccionTerreno.Text;
                nuevoTerreno.NombreI = txtb_nombreTerreno.Text;
                nuevoTerreno.PrecioI = Convert.ToDouble(txtb_PrecioTerreno.Text);
                nuevoTerreno.SuperficieI = Convert.ToInt32(txtb_SuperficieTerreno.Text);
                switch (cmbx_EstadoTerreno.SelectedIndex)
                {
                    case 1:
                        nuevoTerreno.EstadoI = estado.NoDisponible;
                        break;
                    case 0:
                        nuevoTerreno.EstadoI = estado.Venta;
                        break;                 
                }
                if (modificar)//selecciona si modifica o crea
                {
                    terrenoAbm.UpdateTerreno(nuevoTerreno);
                    MessageBox.Show("modificado exitosamente"); // 
                }
                else
                {
                    terrenoAbm.InsertTerreno(nuevoTerreno, contacto);

                    MessageBox.Show(salida); // 
                }
                
            }
            else
            {
                salida = "Faltan Campos!";
                MessageBox.Show(salida);
            }
            
        }
    }
}
