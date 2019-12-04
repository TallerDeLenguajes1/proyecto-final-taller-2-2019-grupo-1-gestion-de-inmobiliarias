using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Propiedad: Inmueble
    {
        private int cantidadBanios;
        private int cantidadHabitaciones;
        private int cantidadCocheras;
        private int cantidadSuites;
        private bool condicion;
        private string fechaHabitable;

        //CONSTRUCTORES
        public Propiedad()
        {
        }
        public Propiedad(string _nombreI, string _direccionI, int _superficieI, estado _estadoI, double _precioI, Contacto _contacto1, int _cantidadBanios, int _cantidadHabitaciones, int _cantidadCocheras, int _cantidadSuites,  bool _condicion, string _fechaHabitable): base(_nombreI, _direccionI, _superficieI, _estadoI, _precioI, _contacto1)
        {
            this.cantidadBanios = _cantidadBanios;
            this.cantidadHabitaciones = _cantidadHabitaciones;
            this.cantidadCocheras = _cantidadCocheras;
            this.cantidadSuites = _cantidadSuites;
            this.condicion = _condicion;
            this.fechaHabitable = _fechaHabitable;
        }

        //GET Y SET
        public int CantidadBanios { get => cantidadBanios; set => cantidadBanios = value; }
        public int CantidadHabitaciones { get => cantidadHabitaciones; set => cantidadHabitaciones = value; }
        public int CantidadCocheras { get => cantidadCocheras; set => cantidadCocheras = value; }
        public int CantidadSuites { get => cantidadSuites; set => cantidadSuites = value; }
        public bool Condicion { get => condicion; set => condicion = value; }
        public string FechaHabitable { get => fechaHabitable; set => fechaHabitable = value; }

        //METODOS:
        public override string ToString()
        {
            return this.DireccionI;
        }

    }
}
