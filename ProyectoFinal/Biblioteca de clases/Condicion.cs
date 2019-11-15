using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public abstract class Condicion
    {
        protected string etapaConstruccion;
        protected DateTime fechaHabitable;

        //CONSTRUCTORES
        public Condicion()
        {
        }
        public Condicion(string _etapaConstruccion, DateTime _fechaHabitable)
        {
            this.etapaConstruccion = _etapaConstruccion;
            this.fechaHabitable = _fechaHabitable;
        }

        //GET Y SET
        public string EtapaConstruccion { get => etapaConstruccion; set => etapaConstruccion = value; }
        public DateTime FechaHabitable { get => fechaHabitable; set => fechaHabitable = value; }

        //internal abstract void FechaHabitable1(string fecha_habitable);
        // internal abstract void EtapaConstruccion1(DateTime etapa_construccion);
    }
}
