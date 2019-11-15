using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class EnConstruccion : Condicion
    {
        //CONSTRUCTORES
        public EnConstruccion()
        {
        }
        public EnConstruccion(string _etapaConstruccion, DateTime _fechaHabitable) : base(_etapaConstruccion, _fechaHabitable)
        {
        }

        //METODOS:
        //GET Y SET
        //public string EtapaConstruccion { get => etapaConstruccion; set => etapaConstruccion = value; }
        //public DateTime FechaHabitable { get => fechaHabitable; set => fechaHabitable = value; }

    }
}
