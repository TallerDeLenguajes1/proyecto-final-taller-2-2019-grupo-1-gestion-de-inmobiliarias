using AccesoDatos;
using Biblioteca_de_clases;
using NLog;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Clipboard = System.Windows.Clipboard;
using DataFormats = System.Windows.DataFormats;
using MessageBox = System.Windows.MessageBox;

namespace Aplicacion_WPF.Vistas
{
    /// <summary>
    /// Lógica de interacción para Principal_Contacto.xaml
    /// </summary>
    public partial class Principal_Contacto : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        UsuarioABM usuario;
        Contacto contacto;
        List<Propiedad> listaPropiedadesContacto;
        List<Terreno> listaTerrenosContacto;
        PropiedadABM propiedadAmb;
        TerrenoABM terrenoAbm;
        
        string mail;
        string direccion=null;
        public Principal_Contacto(string email)
        {
            InitializeComponent();
            usuario = new UsuarioABM();
            propiedadAmb = new PropiedadABM();
            terrenoAbm = new TerrenoABM();
            mail = email; 
            if (usuario.tipoContacto(email))
            {
                contacto = new Duenio();
                contacto.Email = email;
                //DuenioABM duenioAbm = new DuenioABM();
            }
            else
            {
                contacto = new Inmobiliaria();
                contacto.Email = email;
            }
            
            
            listaPropiedadesContacto = propiedadAmb.SelectPropiedad(contacto);
            listaTerrenosContacto = terrenoAbm.SelectTerreno(contacto);

            
            foreach (Propiedad propiedad in listaPropiedadesContacto)
            {
                grid_InmueblesPropietarios.Items.Add(propiedad);
                
            }

            foreach (Terreno terreno in listaTerrenosContacto)
            {
               grid_InmueblesPropietarios.Items.Add(terreno);
             
            }

            
            
        }

        private void Btn_SalirContacto_Click(object sender, RoutedEventArgs e)  // boton para cerrar salir de la ventana principal contacto
        {
           
            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }

        private void Btn_agregarInmueble_Click(object sender, RoutedEventArgs e) // evento que envia a una ventana para seleccionar que tipo de inmueble voy a crear
        {
            elegirTipoInmueble elegir = new elegirTipoInmueble(contacto,mail);
            elegir.Show();
            this.Close();
        }

        private void Btn_ModificarInm_Click(object sender, RoutedEventArgs e) // Evento que me abre la opcion, dada una propiedad seleccionada, modificar sus atributos
        {
            
            if (direccion!=null)//veridica q este seleccionado despues controla si es terreno o propiedad
            {

                foreach (Propiedad propiedad in listaPropiedadesContacto)
                {
                    if (propiedad.DireccionI == direccion)
                    {
                        CrearPropiedad modificarpropiedad = new CrearPropiedad(propiedad, contacto.Email, true);
                        modificarpropiedad.Show();
                        this.Close();
                    }

                }

                foreach (Terreno terreno in listaTerrenosContacto)
                {
                    if (terreno.DireccionI == direccion)
                    {
                        CrearTerreno modificarterreno = new CrearTerreno(terreno, contacto.Email, true);
                        modificarterreno.Show();
                        this.Close();
                    }
                }
            }
           else  {
                MessageBox.Show("Seleccione un inmueble");
            }
           
        }

        private void Btn_ModificarDatosContacto_Click(object sender, RoutedEventArgs e) // evento que me habilita una ventana para modificar los datos personales del contacto
        {
            if (contacto.getTipo()=="Duenio")
            {
                Duenio duenio = new Duenio();
                duenio.Email = contacto.Email;
                Modificar_Duenio D = new Modificar_Duenio(duenio);
                D.Show();
                this.Close();
                
            }
            else
            {
                Inmobiliaria I = new Inmobiliaria();
                I.Email = contacto.Email;
                Modifica_Inmobiliaria X = new Modifica_Inmobiliaria(I);
                X.Show();
                this.Close();
            }
        }

        private void Btn_ElominarInmy_Click(object sender, RoutedEventArgs e) // evento que me permite, dado un inmueble selecionado, eliminarlo
        {
           
            if (direccion!=null)//veridica q este seleccionado un inmeble
            {
                var result = MessageBox.Show("Seguro q desea eliminar", "Alerta",
                                  MessageBoxButton.YesNo,
                                  MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        try
                        {

                            foreach (Propiedad propiedad in listaPropiedadesContacto)
                            {
                                if (propiedad.DireccionI == direccion)
                                {
                                    propiedadAmb.DeletePropiedad(propiedad);

                                    grid_InmueblesPropietarios.Items.Remove(propiedad);
                                }

                            }

                            foreach (Terreno terreno in listaTerrenosContacto)
                            {
                                if (terreno.DireccionI == direccion)
                                {
                                    terrenoAbm.DeleteTerreno(terreno);
                                    grid_InmueblesPropietarios.Items.Remove(terreno);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.Error("ERROR al eliminar-> {0}", ex.ToString());
                            MessageBox.Show("error al eliminar");
                        }
                         break;
                }
               
            }
                
                   else
            {
                MessageBox.Show("Seleccione un inmueble");
            }
                
        }
      

       



        private void Btn_ExportarDatosINMContacto_Click(object sender, RoutedEventArgs e) // eventodel boton Exportar Excel que me permite exportar a un archivo excel. los datos que tengo en el DataGrid
        {
            try
            {

                grid_InmueblesPropietarios.SelectAllCells();
                grid_InmueblesPropietarios.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, grid_InmueblesPropietarios);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                grid_InmueblesPropietarios.UnselectAllCells();
                SaveFileDialog salvar_archivo = new SaveFileDialog();//creando ventana de guardado
                salvar_archivo.Filter = "archivo xml|*.xls";//filtro para la extencion como se puede guardar el archivo
                salvar_archivo.Title = "Guandar archivo excel";//nombre de la ventana de guardado
                salvar_archivo.ShowDialog();//abre la ventana de guardado
                if (salvar_archivo.FileName != "")
                {
                    //System.IO.FileStream fileStream = (System.IO.FileStream)salvar_archivo.OpenFile();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter((System.IO.FileStream)salvar_archivo.OpenFile());
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();
                }

                MessageBox.Show("se exportaron los datos correctamente");
            }
            catch (Exception ex)
            {
                logger.Error("ERROR al exportar inmueblesfiltro-> {0}", ex.ToString());
                MessageBox.Show("error exportar");

            }



        }

        private void Btn_MostrarDetallesINM_Click(object sender, RoutedEventArgs e)
        {
            
            if (direccion != null)//veridica q este seleccionado despues controla si es terreno o propiedad
            {

                foreach (Propiedad propiedad in listaPropiedadesContacto)
                {
                    if (propiedad.DireccionI == direccion)
                    {
                        CrearPropiedad modificarpropiedad = new CrearPropiedad(propiedad,contacto.Email);
                        modificarpropiedad.Show();
                        this.Close();
                    }

                }

                foreach (Terreno terreno in listaTerrenosContacto)
                {
                    if (terreno.DireccionI == direccion)
                    {
                        CrearTerreno modificarterreno = new CrearTerreno(terreno,contacto.Email);
                        modificarterreno.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un inmueble");
            }
            //CrearPropiedad modificarPropiedad = new CrearPropiedad(contacto); // creo la ventana para modificar una propiedad
            //modificarPropiedad.ShowDialog();
        }

        private void Grid_InmueblesPropietarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            direccion = grid_InmueblesPropietarios.CurrentCell.Item.ToString();
        }
    }
    
}
