using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Terreno: Inmueble
    {
        //CONSTRUCTORES
        public Terreno()
        {
        }
        public Terreno(string _nombreI, string _direccionI, int _superficieI, estado _estadoI, double _precioI, Contacto _contacto1) : base(_nombreI, _direccionI, _superficieI, _estadoI, _precioI, _contacto1)
        {

        }

        public override string ToString()
        {
            return this.DireccionI;
        }
    }
}
