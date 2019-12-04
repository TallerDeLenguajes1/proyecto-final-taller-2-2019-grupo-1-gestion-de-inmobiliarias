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
    
    
    public partial class PrincipalCliente : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //Contacto contacto;
        List<Propiedad> listatodasPropiedades;
        List<Terreno> listatodosterrenos;
        List<Propiedad> listaPropiedades;
        List<Terreno> listaterrenos;
        PropiedadABM propiedadAmb;
        TerrenoABM terrenoAbm;
        List<Inmueble> listaprointeresados;
        //string mail;
        string direccion = null;
        string direccioninteresados = null;
        Cliente cliente;
        public PrincipalCliente(string email)//inicializa ventana
        {
            InitializeComponent();
            cliente = new Cliente();
            ClienteABM clienteABM = new ClienteABM();
            propiedadAmb = new PropiedadABM();
            terrenoAbm = new TerrenoABM();
            cliente.EmailC = email;
            clienteABM.SelectCliente(ref cliente);
            cbx_FiltroPorTipo.Items.Add("TERRENO");
            cbx_FiltroPorTipo.Items.Add("PROPIEDAD");
            listatodasPropiedades = new List<Propiedad>();
            listatodosterrenos = new List<Terreno>();

            listatodasPropiedades = propiedadAmb.SelectPropiedades();
            listatodosterrenos = terrenoAbm.SelectTerreno();


        }

        private void Btn_SalirCliente_Click(object sender, RoutedEventArgs e)//evento de boton salir
        {

            MainWindow X = new MainWindow();
            X.Show();
            this.Close();
        }



        private void Btn_ModificarDatosCliente_Click(object sender, RoutedEventArgs e) // evento que permite al cliente acceder a una ventana para modificar sus datos personales
        {
            Modificar_Cliente modificarCliente = new Modificar_Cliente(cliente);
            modificarCliente.ShowDialog();
        }

        private void Btn_ExportarExcelInmueblesTodos_Click(object sender, RoutedEventArgs e)//evento del boton exportar inmuebles filtrados
        {
            try
            {

                grid_inmueblesPorFiltro.SelectAllCells();
                grid_inmueblesPorFiltro.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, grid_inmueblesPorFiltro);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                grid_inmueblesPorFiltro.UnselectAllCells();
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

        private void Btn_ExportarExcelInteresados_Click(object sender, RoutedEventArgs e)//evento del boton exportar inmuebles interesados
        {
            try
            { 
                grid_inmueblesInteresadosCliente.SelectAllCells();
                grid_inmueblesInteresadosCliente.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, grid_inmueblesInteresadosCliente);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                grid_inmueblesInteresadosCliente.UnselectAllCells();
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

        private void Grid_inmueblesPorFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)//evento para seleccionar un inmueble de gridfiltrado 
        {
            direccion = grid_inmueblesPorFiltro.CurrentCell.Item.ToString();
        }

        private void Btn_FiltrarInmuebesPor_Click(object sender, RoutedEventArgs e)//evento del boton filtrar
        {
            if (radio_Tipo.IsChecked == true)
            {
                if (cbx_FiltroPorTipo.SelectedIndex == -1) // control para saber si se especifico el tipo en el combobox
                {
                    string salida = "Falta seleccionar el tipo de inmueble para realizar el filtro"; // string que se mostrara en el msj de alerta
                    MessageBox.Show(salida); // msj de alerta que mostrara si no se eligio el tipo de inmueble para realizar el filtrado
                }
                else
                {

                    //filtrar por tipo
                    if (cbx_FiltroPorTipo.SelectedIndex == 0)
                    {
                        grid_inmueblesPorFiltro.Items.Clear();
                        TerrenoABM terreno = new TerrenoABM();
                        List<Terreno> listaterrenos;
                        listaterrenos = terreno.SelectTerreno();

                        foreach (Terreno T in listaterrenos)
                        {
                            grid_inmueblesPorFiltro.Items.Add(T);
                        }
                    }
                    else
                    {
                        if (cbx_FiltroPorTipo.SelectedIndex == 1)
                        {
                            grid_inmueblesPorFiltro.Items.Clear();
                            PropiedadABM propiedad = new PropiedadABM();
                            List<Propiedad> listaPropiedades;
                            listaPropiedades = propiedad.SelectPropiedades();

                            foreach (Propiedad P in listaPropiedades)
                            {
                                grid_inmueblesPorFiltro.Items.Add(P);
                            }
                        }


                    }

                }
            }
            if (radio_Precio.IsChecked == true)
            {
                grid_inmueblesPorFiltro.Items.Clear();
                if (!string.IsNullOrWhiteSpace(txtb_FiltroPorPrecio.Text)) // control para saber si se ingreso el precio para realizar el filtro
                {
                    //filtrar por precio
                    TerrenoABM terreno = new TerrenoABM();
                    List<Terreno> listaterrenos;
                    listaterrenos = terreno.selecTerrenoporPrecio(Convert.ToDouble(txtb_FiltroPorPrecio.Text));

                    foreach (Terreno T in listaterrenos)
                    {
                        grid_inmueblesPorFiltro.Items.Add(T);

                    }
                    //grid_inmueblesPorFiltro.Items.Clear();
                    PropiedadABM propiedad = new PropiedadABM();
                    List<Propiedad> listaPropiedades;
                    listaPropiedades = propiedad.selecPropiedadporPrecio(Convert.ToDouble(txtb_FiltroPorPrecio.Text));

                    foreach (Propiedad P in listaPropiedades)
                    {
                        grid_inmueblesPorFiltro.Items.Add(P);
                    }
                }
                else
                {
                    string salida = "Falta alcarar el precio para realizar el filtro"; // string que se mostrara en el msj de alerta
                    MessageBox.Show(salida); // mensaje de alerta avisando que no ingreso el precio para realizar el filtrado
                }

            }
            if (radio_Superficie.IsChecked == true)
            {
                grid_inmueblesPorFiltro.Items.Clear();
                if (!string.IsNullOrWhiteSpace(txtb_FiltroPorSuperficie.Text)) // control para saber si se ingreso el precio para realizar el filtro
                {
                    //filtrar por precio
                    TerrenoABM terreno = new TerrenoABM();

                    listaterrenos = terreno.selecTerrenoporSuperficie(Convert.ToInt32(txtb_FiltroPorSuperficie.Text));

                    foreach (Terreno T in listaterrenos)
                    {
                        grid_inmueblesPorFiltro.Items.Add(T);

                    }
                    //grid_inmueblesPorFiltro.Items.Clear();
                    PropiedadABM propiedad = new PropiedadABM();

                    listaPropiedades = propiedad.selecPropiedadporSuperficie(Convert.ToInt32(txtb_FiltroPorSuperficie.Text));

                    foreach (Propiedad P in listaPropiedades)
                    {
                        grid_inmueblesPorFiltro.Items.Add(P);
                    }
                }
                else
                {
                    string salida = "Falta alcarar la superficie para realizar el filtro"; // string que se mostrara en el msj de alerta
                    MessageBox.Show(salida); // mensaje de alerta avisando que no ingreso el precio para realizar el filtrado
                }
            }
        }

        private void Btn_MostrarDetalCliente_Click(object sender, RoutedEventArgs e)
        {
            if (direccion != null)//veridica q este seleccionado despues controla si es terreno o propiedad
            {

                foreach (Propiedad propiedad in listatodasPropiedades)
                {
                    if (propiedad.DireccionI == direccion)
                    {
                        CrearPropiedad modificarpropiedad = new CrearPropiedad(propiedad, cliente.EmailC, 1);
                        modificarpropiedad.ShowDialog();
                        //this.Close();
                    }

                }

                foreach (Terreno terreno in listatodosterrenos)
                {
                    if (terreno.DireccionI == direccion)
                    {
                        CrearTerreno modificarterreno = new CrearTerreno(terreno, cliente.EmailC, 1);
                        modificarterreno.ShowDialog();
                        //this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un imbueble");
            }
            //CrearPropiedad modificarPropiedad = new CrearPropiedad(contacto); // creo la ventana para modificar una propiedad
            //modificarPropiedad.ShowDialog();
        }

        private void Btn_AddAInteresados_Click(object sender, RoutedEventArgs e)//agrega a la lista un inmueble seleccionado
        {
            if (direccion != null)//veridica q este seleccionado despues controla si es terreno o propiedad
            {
                foreach (Propiedad p in listatodasPropiedades)
                {
                    if (p.DireccionI == direccion)
                    {

                        grid_inmueblesInteresadosCliente.Items.Add(p);
                    }
                }
                foreach (Terreno t in listatodosterrenos)
                {
                    if (t.DireccionI == direccion)
                    {
                        grid_inmueblesInteresadosCliente.Items.Add(t);
                    }
                }
            }
        }

        private void Btn_QuitarDeInteresados_Click(object sender, RoutedEventArgs e)//quita de la lista el inmueble seleccionado
        {
            if (direccioninteresados != null)//veridica q este seleccionado despues controla si es terreno o propiedad
            {
                foreach (Propiedad p in listatodasPropiedades)
                {
                    if (p.DireccionI == direccioninteresados)
                    {
                        grid_inmueblesInteresadosCliente.Items.Remove(p);
                    }
                }
                foreach (Terreno t in listatodosterrenos)
                {
                    if (t.DireccionI == direccioninteresados)
                    {
                        grid_inmueblesInteresadosCliente.Items.Remove(t);
                    }
                }
            }
        }

        private void Grid_inmueblesInteresadosCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)//evento para seleccionar un inmueble de gridinteresados 
        {
            direccioninteresados = grid_inmueblesInteresadosCliente.CurrentCell.Item.ToString();
        }

       
    }
}
