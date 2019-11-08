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
    /// Lógica de interacción para elegirTipoInmueble.xaml
    /// </summary>
    public partial class elegirTipoInmueble : Window
    {
        public elegirTipoInmueble()
        {
            InitializeComponent();
        }

        private void Btn_CrearTerreno_Click(object sender, RoutedEventArgs e)
        {
            CrearTerreno nuevoTerreno = new CrearTerreno();
            nuevoTerreno.ShowDialog();
        }

        private void Btn_CrearPropiedad_Click(object sender, RoutedEventArgs e)
        {
            CrearPropiedad nuevaPropiedad = new CrearPropiedad();
            nuevaPropiedad.ShowDialog();
        }
    }
}
