using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public enum estado { Alquiler, Venta, NoDisponible}
    public abstract class Inmueble
    {
        protected string nombreI;
        protected string direccionI;
        protected int superficieI;
        protected estado estadoI;
        protected double precioI;

        protected Contacto contacto1; //Objeto de tipo Contacto, el inmeble tendra un Contacto
        protected List<Cliente> clientes; //Lita de Clientes interesados en el inmueble

        //CONSTRUCTORES:
        public Inmueble()
        {
        }
        public Inmueble(string _nombreI, string _direccionI, int _superficieI, estado _estadoI, double _precioI, Contacto _contacto1)
        {
            this.nombreI = _nombreI;
            this.direccionI = _direccionI;
            this.superficieI = _superficieI;
            this.estadoI = _estadoI;
            this.precioI = calcularPrecio(_precioI);
            this.Contacto1 = _contacto1; //El inmueble necesita tener un contacto
        }

        //GET Y SET: 
        //Algunos de los get y set son necesarios en caso de que el contacto se 
        //equivoque al ingresar los datos y deba modificarlos como la direccion o la superficie.
        public string NombreI { get => nombreI; set => nombreI = value; }
        public string DireccionI { get => direccionI; set => direccionI = value; }
        public int SuperficieI { get => superficieI; set => superficieI = value; }
        public estado EstadoI { get => estadoI; set => estadoI = value; }
        public double PrecioI { get => precioI; set => precioI = value; }
        public Contacto Contacto1 { get => contacto1; set => contacto1 = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }

        //METODOS:

        //Metodo para agregar clientes interesados en el inmueble
        public void cargarClientesInteresados(Cliente C1) 
        {
            Clientes.Add(C1);
        }
        //Sobrecarga para el comportamiento de clase inmueble
        public override string ToString()
        {
            return direccionI + " , " + estadoI + " , " + precioI;
        }

        public double calcularPrecio(double preciox)
        {
            return contacto1.calcularMonto(preciox);
        }


    }
}
