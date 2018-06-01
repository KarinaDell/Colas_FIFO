using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colas_FIFO
{
    class Procesador
    {
        Proceso proceso;
        private Proceso inicio  = null;
        static Random rnd = new Random();
        private int cont, vacio, completo, ultimo, ciclo;
        private int ciclos = 300;

     public void iniciarProceso()
        {
            ciclos = 300;
            while(ciclos > 0)
            {
                atenderProceso();
                if (inicio != null)
                    reducirCiclos();
                else
                    vacio++;
                ciclos--;
            }
            completo = inicio.Cuantos - 1;
            ultimo = obtenerUltimoProceso(inicio) - completo;

        }

        private void atenderProceso()
        {
            int r;
           for(int i = 1; i <=300; i++)
            {
                r = rnd.Next(1, 101);
                if (r <= 35)
                    proceso.agregarPrceso();
            }
        }

       private void agregarProceso()
        {
            if (inicio == null)
                inicio = proceso = new Proceso(cont++, rnd.Next(4, 15));
            else
                agregarProcesoRecursivo(inicio);
        }

        private void agregarProcesoRecursivo(Proceso t)
        {
            if (t.sig == null)
                t.sig = proceso = new Proceso(cont++, rnd.Next(4, 15));
            else
                agregarProcesoRecursivo(t.sig);
        }

        }
    }
}
