using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Cliente
    {
        private string nombreC;
        private string apellidoC;
        private string emailC;
        private int telefonoC;

        private List<Inmueble> inmuebleInteres; //El cliente tendra una lista de inmuebles que le interesan

        //CONSTRUCTORES
        public Cliente()
        {
        }
        public Cliente(string _nombreC, string _apellidoC, string _emailC, int _telefonoC)
        {
            this.NombreC = _nombreC;
            this.ApellidoC = _apellidoC;
            this.EmailC = _emailC;
            this.TelefonoC = _telefonoC;
        }

        //GETTERS y SETTERS
        public string NombreC { get => nombreC; set => nombreC = value; }
        public string ApellidoC { get => apellidoC; set => apellidoC = value; }
        public string EmailC { get => emailC; set => emailC = value; }
        public int TelefonoC { get => telefonoC; set => telefonoC = value; }
        public List<Inmueble> InmuebleInteres { get => inmuebleInteres; set => inmuebleInteres = value; }

        //METODOS
        public void cargarInmuebleInteres(Inmueble I1)
        {
            InmuebleInteres.Add(I1);
        }

        public void quitarInmuebleInteres(Inmueble I1)
        {
            InmuebleInteres.Remove(I1);
        }
    }
}
