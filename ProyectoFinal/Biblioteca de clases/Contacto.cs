using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public abstract class Contacto
    {
        protected string nombre;
        protected string email;
        protected string direccion;
        protected int telefono;
        protected string contrasenia;

        protected List<Inmueble> inmuebles;

        //CONSTRUCTORES
        public Contacto()
        {
        }

        public Contacto(string _nombre, string _email, string _direccion, int _telefono, string _contrasenia)
        {
            this.nombre = _nombre;
            this.email = _email;
            this.direccion = _direccion;
            this.telefono = _telefono;
            this.contrasenia = _contrasenia;
        }

        //GETTERS y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Inmueble> Inmuebles { get => inmuebles; set => inmuebles = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }

        //METODOS:
        public double calcularMonto(double preciox)
        {
            return 0;
        }

        public void cargarInmueble(Inmueble I1)
        {
            Inmuebles.Add(I1);
        }

        public void quitarInmueble(Inmueble I1)
        {
            Inmuebles.Remove(I1);
        }

        public virtual string getTipo()
        { return "";
        }
    }
}
