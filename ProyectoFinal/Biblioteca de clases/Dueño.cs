using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Dueño : Contacto
    {
        private string horarioDeDisponibilidad;

        //CONSTRUCTORES
        public Dueño()
        {
        }
        public Dueño(string _nombre, string _email, string _direccion, int _telefono, string _horarioDeDisponibilidad) : base(_nombre, _email, _direccion, _telefono)
        {
            this.horarioDeDisponibilidad = _horarioDeDisponibilidad;
        }

        //GET Y SET
        public string HorarioDeDisponibilidad { get => horarioDeDisponibilidad; set => horarioDeDisponibilidad = value; }

        //METODOS:
        //public float calcularMonto(float preciox)
        //{
        //    return preciox;
        //}
    }
}
