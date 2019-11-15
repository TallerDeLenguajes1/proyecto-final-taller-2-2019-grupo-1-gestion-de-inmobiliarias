using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Inmobiliaria : Contacto
    {
        private string sitioWeb;

        //CONSTRUCTORES
        public Inmobiliaria()
        {
        }
        public Inmobiliaria(string _nombre, string _email, string _direccion, int _telefono, string _sitioWeb) : base(_nombre, _email, _direccion, _telefono)
        {
            this.sitioWeb = _sitioWeb;
        }

        //GET Y SET
        public string SitioWeb { get => sitioWeb; set => sitioWeb = value; }

        //METODOS:
        //public float calcularMonto(float preciox)
        //{
        //    return preciox * (float)1.1;
        //}
    }
}
