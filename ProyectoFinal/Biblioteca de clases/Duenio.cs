using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Duenio: Contacto
    {
        private string horarioDeDisponibilidad;

        //CONSTRUCTORES
        public Duenio()
        {
        }
        public Duenio(string _nombre, string _email, string _direccion, int _telefono, string _horarioDeDisponibilidad, string _contrasenia) : base(_nombre, _email, _direccion, _telefono, _contrasenia)
        {
            this.horarioDeDisponibilidad = _horarioDeDisponibilidad;
        }

        //GET Y SET
        public string HorarioDeDisponibilidad { get => horarioDeDisponibilidad; set => horarioDeDisponibilidad = value; }

        //METODOS:
        public float calcularMonto(float preciox)
        {
            return preciox;
        }

        public override string getTipo()
        {
            return "Duenio";
        }
    }
}
