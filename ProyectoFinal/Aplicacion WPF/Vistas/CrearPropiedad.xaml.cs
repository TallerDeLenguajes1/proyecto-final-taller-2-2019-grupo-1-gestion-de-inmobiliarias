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

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para CrearPropiedad.xaml
    /// </summary>
    public partial class CrearPropiedad : Window
    {
        Contacto contacto;
        bool mostrar=false;
        string mail;
        bool modificar = false;
        public CrearPropiedad(Propiedad C,string email)//inicio de ventana mostrar detalles inmueble seleccionado
        {
            InitializeComponent();
            mail=email;
            btn_AñadirPropiedad.Visibility = Visibility.Hidden;
            label_TituloCrearProp.Content = "MOSTRAR";
            //cmbx_CondicionPropiedad.Items.Add("En construccion");
            //cmbx_CondicionPropiedad.Items.Add("Habitable");
            //cmbx_CondicionPropiedad.IsReadOnly = true;
            //cmbx_EstadoPropiedad.Items.Add("No Disponible");
            //cmbx_EstadoPropiedad.Items.Add("En venta");
            //cmbx_EstadoPropiedad.IsReadOnly = true;
            txtb_nombrePropiedad.Text = C.NombreI;
            txtb_nombrePropiedad.IsReadOnly = true;
            txtb_DireccionPropiedad.Text = C.DireccionI;
            txtb_DireccionPropiedad.IsReadOnly = true;
            txtb_SuperficiePropiedad.Text = C.SuperficieI.ToString();
            txtb_SuperficiePropiedad.IsReadOnly = true;
            txtb_PrecioPropiedad.Text = C.PrecioI.ToString();
            txtb_PrecioPropiedad.IsReadOnly = true;
            txtb_CantBaños.Text = C.CantidadBanios.ToString();
            txtb_CantBaños.IsReadOnly = true;
            txtb_CantCocheras.Text = C.CantidadCocheras.ToString();
            txtb_CantCocheras.IsReadOnly = true;
            txtb_Canthabitaciones.Text = C.CantidadHabitaciones.ToString();
            txtb_Canthabitaciones.IsReadOnly = true;
            txtb_CantSuites.Text = C.CantidadSuites.ToString();
            txtb_CantSuites.IsReadOnly = true;
            txtb_FechaHabitablePropiedad.Text = C.FechaHabitable;
            txtb_FechaHabitablePropiedad.IsReadOnly = true;
            if (C.Condicion)
            {
                cmbx_CondicionPropiedad.Items.Add("Habitable");
                cmbx_CondicionPropiedad.SelectedIndex = 0;
            }
            else
            {
                cmbx_CondicionPropiedad.Items.Add("En Construcción");
                cmbx_CondicionPropiedad.SelectedIndex = 0;
            }
            
            switch (C.EstadoI)
            {
                case estado.NoDisponible:
                    cmbx_EstadoPropiedad.Items.Add("No Disponible");
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
                case estado.Venta:
                    cmbx_EstadoPropiedad.Items.Add("En Venta");
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
                case estado.Alquiler:
                    cmbx_EstadoPropiedad.Items.Add("En Alquiler");
                    cmbx_EstadoPropiedad.SelectedIndex= 0;
                    break;
            }
            cmbx_CondicionPropiedad.IsReadOnly = true;
            cmbx_EstadoPropiedad.IsReadOnly = true;

        }
        public CrearPropiedad(Propiedad C, string email,int X)//inicio de ventana mostrar detalles inmueble seleccionado cliente
        {
            InitializeComponent();
            mostrar = true;
            mail = email;
            btn_AñadirPropiedad.Visibility = Visibility.Hidden;
            label_TituloCrearProp.Content = "MOSTRAR";
            //cmbx_CondicionPropiedad.Items.Add("En construccion");
            //cmbx_CondicionPropiedad.Items.Add("Habitable");
            //cmbx_CondicionPropiedad.IsReadOnly = true;
            //cmbx_EstadoPropiedad.Items.Add("No Disponible");
            //cmbx_EstadoPropiedad.Items.Add("En venta");
            //cmbx_EstadoPropiedad.IsReadOnly = true;
            txtb_nombrePropiedad.Text = C.NombreI;
            txtb_nombrePropiedad.IsReadOnly = true;
            txtb_DireccionPropiedad.Text = C.DireccionI;
            txtb_DireccionPropiedad.IsReadOnly = true;
            txtb_SuperficiePropiedad.Text = C.SuperficieI.ToString();
            txtb_SuperficiePropiedad.IsReadOnly = true;
            txtb_PrecioPropiedad.Text = C.PrecioI.ToString();
            txtb_PrecioPropiedad.IsReadOnly = true;
            txtb_CantBaños.Text = C.CantidadBanios.ToString();
            txtb_CantBaños.IsReadOnly = true;
            txtb_CantCocheras.Text = C.CantidadCocheras.ToString();
            txtb_CantCocheras.IsReadOnly = true;
            txtb_Canthabitaciones.Text = C.CantidadHabitaciones.ToString();
            txtb_Canthabitaciones.IsReadOnly = true;
            txtb_CantSuites.Text = C.CantidadSuites.ToString();
            txtb_CantSuites.IsReadOnly = true;
            txtb_FechaHabitablePropiedad.Text = C.FechaHabitable;
            txtb_FechaHabitablePropiedad.IsReadOnly = true;
            if (C.Condicion)
            {
                cmbx_CondicionPropiedad.Items.Add("Habitable");
                cmbx_CondicionPropiedad.SelectedIndex = 0;
            }
            else
            {
                cmbx_CondicionPropiedad.Items.Add("En Construcción");
                cmbx_CondicionPropiedad.SelectedIndex = 0;
            }

            switch (C.EstadoI)
            {
                case estado.NoDisponible:
                    cmbx_EstadoPropiedad.Items.Add("No Disponible");
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
                case estado.Venta:
                    cmbx_EstadoPropiedad.Items.Add("En Venta");
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
                case estado.Alquiler:
                    cmbx_EstadoPropiedad.Items.Add("En Alquiler");
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
            }
            cmbx_CondicionPropiedad.IsReadOnly = true;
            cmbx_EstadoPropiedad.IsReadOnly = true;

        }
        public CrearPropiedad(Contacto C,string email)//inicio de ventana crear
        {
            InitializeComponent();
            contacto = C;
            cmbx_CondicionPropiedad.Items.Add("En construccion");
            cmbx_CondicionPropiedad.Items.Add("Habitable");

            cmbx_EstadoPropiedad.Items.Add("En Alquiler");
            cmbx_EstadoPropiedad.Items.Add("No Disponible");
            cmbx_EstadoPropiedad.Items.Add("En venta");
            mail = email;
            
        }
        public CrearPropiedad(Propiedad C, string email, bool activar)//inicion de ventana modificacion
        {
            InitializeComponent();
            btn_AñadirPropiedad.Content = "Modificar";
            label_TituloCrearProp.Content = "Modificar Propiedad";
            cmbx_CondicionPropiedad.Items.Add("En construccion");
            cmbx_CondicionPropiedad.Items.Add("Habitable");
            modificar = activar;
            cmbx_EstadoPropiedad.Items.Add("En Alquiler");
            cmbx_EstadoPropiedad.Items.Add("No Disponible");
            cmbx_EstadoPropiedad.Items.Add("En venta");
            mail = email;
            txtb_nombrePropiedad.Text = C.NombreI;
            txtb_DireccionPropiedad.Text = C.DireccionI;
            txtb_SuperficiePropiedad.Text = C.SuperficieI.ToString();
            txtb_PrecioPropiedad.Text = C.PrecioI.ToString();
            txtb_CantBaños.Text = C.CantidadBanios.ToString();
            txtb_CantCocheras.Text = C.CantidadCocheras.ToString();
            txtb_Canthabitaciones.Text = C.CantidadHabitaciones.ToString();
            txtb_CantSuites.Text = C.CantidadSuites.ToString();
            txtb_FechaHabitablePropiedad.Text = C.FechaHabitable;
            if (C.Condicion)
            {
                cmbx_CondicionPropiedad.SelectedIndex = 1;
            }
            else
            {
                cmbx_CondicionPropiedad.SelectedIndex = 0;
            }
            
            switch (C.EstadoI)
            {
                case estado.Alquiler:
                    cmbx_EstadoPropiedad.SelectedIndex = 0;
                    break;
                case estado.NoDisponible:
                    cmbx_EstadoPropiedad.SelectedIndex = 1;
                    break;
                case estado.Venta:
                    cmbx_EstadoPropiedad.SelectedIndex = 2; 
                    break;
            }

        }

        private void Btn_cancelarAñadirPropiedad_Click(object sender, RoutedEventArgs e) // eventoq ue cierra la ventana mediante un click en el boton cancelar
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

        private void Btn_AñadirPropiedad_Click(object sender, RoutedEventArgs e) // evento que envia los datos ingresados de la nueva propiedad a la base de datos
        {
            string salida = "Propiedad Creada correctamente."; 
            if(!string.IsNullOrWhiteSpace(txtb_CantBaños.Text) && !string.IsNullOrWhiteSpace(txtb_CantCocheras.Text) && !string.IsNullOrWhiteSpace(txtb_Canthabitaciones.Text) &&
                !string.IsNullOrWhiteSpace(txtb_CantSuites.Text) && !string.IsNullOrWhiteSpace(txtb_DireccionPropiedad.Text) && !string.IsNullOrWhiteSpace(txtb_nombrePropiedad.Text)&&
                !string.IsNullOrWhiteSpace(txtb_PrecioPropiedad.Text) && !string.IsNullOrWhiteSpace(txtb_SuperficiePropiedad.Text)) // control para saber si se ingresaron todos los campos
            {
                Propiedad propiedad = new Propiedad();
                PropiedadABM propiedadABM = new PropiedadABM();
                propiedad.NombreI = txtb_nombrePropiedad.Text;
                propiedad.DireccionI = txtb_DireccionPropiedad.Text;
                propiedad.SuperficieI = int.Parse(txtb_SuperficiePropiedad.Text);
                propiedad.PrecioI = Convert.ToDouble(txtb_PrecioPropiedad.Text);
                propiedad.CantidadBanios = Convert.ToInt32(txtb_CantBaños.Text);
                propiedad.CantidadCocheras = Convert.ToInt32(txtb_CantCocheras.Text);
                propiedad.CantidadHabitaciones = Convert.ToInt32(txtb_Canthabitaciones.Text);
                propiedad.CantidadSuites = Convert.ToInt32(txtb_CantSuites.Text);
                propiedad.FechaHabitable = txtb_FechaHabitablePropiedad.Text;
                if (cmbx_CondicionPropiedad.SelectedItem.ToString() == "Habitable")
                {
                    propiedad.Condicion = true;
                }
                if (cmbx_CondicionPropiedad.SelectedItem.ToString() == "En Construccion")
                {
                    propiedad.Condicion = false;
                }
                switch (cmbx_EstadoPropiedad.SelectedIndex)
                {
                    case 0:
                        propiedad.EstadoI = estado.Alquiler;
                        break;
                    case 1:
                        propiedad.EstadoI = estado.NoDisponible;
                        break;
                    case 2:
                        propiedad.EstadoI = estado.Venta;
                        break;
                }
                if (modificar)//selecciona si crea o modifica
                {
                    propiedadABM.UpdatePropiedad(propiedad);
                    MessageBox.Show("Modificado con exito");
                }
                else
                {
                    propiedadABM.InsertPropiedad(propiedad, contacto);

                    MessageBox.Show(salida);
                }
            }
            else
            {
                salida = "Faltan Campos!"; // string que se mostrara en el msj de alerta
                MessageBox.Show(salida); // msj de alerta que se mostrara si no se completaron todos los campos
            }
        }
    }
}
