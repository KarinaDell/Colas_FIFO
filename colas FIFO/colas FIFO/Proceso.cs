using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colas_FIFO
{
    class Proceso
    {

        private int cuantos;
        private int duracion;
        public Proceso sig;

        public int Cuantos { get => cuantos; set => cuantos = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public Proceso (int cuantos, int duracion)
        {
            this.cuantos = cuantos;
            this.duracion = duracion;
        }

       
    }
}
