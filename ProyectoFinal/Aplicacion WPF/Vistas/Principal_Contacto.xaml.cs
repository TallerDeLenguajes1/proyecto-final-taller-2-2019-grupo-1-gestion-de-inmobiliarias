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
    /// Lógica de interacción para Principal_Contacto.xaml
    /// </summary>
    public partial class Principal_Contacto : Window
    {
        public Principal_Contacto()
        {
            InitializeComponent();
        }

        private void Btn_ExportarDatosINMContacto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_agregarInmueble_Click(object sender, RoutedEventArgs e)
        {
            elegirTipoInmueble nuevoInmueble = new elegirTipoInmueble();
            nuevoInmueble.ShowDialog();
        }
    }
}
