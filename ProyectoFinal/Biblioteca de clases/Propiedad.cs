using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Propiedad : Inmueble
    {
        private int cantidadBanios;
        private int cantidadHabitaciones;
        private int cantidadCocheras;
        private int cantidadSuites;

        private Condicion condicionP;

        //CONSTRUCTORES
        public Propiedad()
        {
        }
        public Propiedad(string _nombreI, string _direccionI, int _superficieI, estado _estadoI, float _precioI, Contacto _contacto1, int _cantidadBanios, int _cantidadHabitaciones, int _cantidadCocheras, int _cantidadSuites) : base(_nombreI, _direccionI, _superficieI, _estadoI, _precioI, _contacto1)
        {
            this.cantidadBanios = _cantidadBanios;
            this.cantidadHabitaciones = _cantidadHabitaciones;
            this.cantidadCocheras = _cantidadCocheras;
            this.cantidadSuites = _cantidadSuites;
            Condicion C = new Habitable();
            this.condicionP = C;
        }

        public Propiedad(string _nombreI, string _direccionI, int _superficieI, estado _estadoI, float _precioI, Contacto _contacto1, int _cantidadBanios, int _cantidadHabitaciones, int _cantidadCocheras, int _cantidadSuites, string _etapaConstruccion, DateTime _fechaHabitable) : base(_nombreI, _direccionI, _superficieI, _estadoI, _precioI, _contacto1)
        {
            this.cantidadBanios = _cantidadBanios;
            this.cantidadHabitaciones = _cantidadHabitaciones;
            this.cantidadCocheras = _cantidadCocheras;
            this.cantidadSuites = _cantidadSuites;
            Condicion EnCon = new EnConstruccion(_etapaConstruccion, _fechaHabitable);
            this.condicionP = EnCon;
        }

        //GET Y SET
        public int CantidadBanios { get => cantidadBanios; set => cantidadBanios = value; }
        public int CantidadHabitaciones { get => cantidadHabitaciones; set => cantidadHabitaciones = value; }
        public int CantidadCocheras { get => cantidadCocheras; set => cantidadCocheras = value; }
        public int CantidadSuites { get => cantidadSuites; set => cantidadSuites = value; }

        //METODOS:
        public void cambiarCondicion(string fecha_habitable, DateTime etapa_construccion)
        {
           // condicionP.FechaHabitable(fecha_habitable);
           // condicionP.EtapaConstruccion(etapa_construccion);
        }

    }
}
