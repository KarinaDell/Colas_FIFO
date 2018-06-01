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

        public void iniciarProcesador()
        {
           
            while(ciclos > 0)
            {
                int r;
                r = rnd.Next(1, 101);
                if (r <= 35)
                    agregarProceso( new Proceso(cont++, rnd.Next(4, 15)));
                //agregarProceso();
                if (inicio != null)
                    reducirCiclos();
                else
                    vacio++;
                ciclos--;
            }
            completo = inicio.Cuantos - 1;
            ultimo = obtenerUltimoProceso(inicio) - completo;

        }


       private void agregarProceso(Proceso nuevo)
        {
            

            if (inicio == null)
                inicio = nuevo;
            else
                agregarProcesoRec(inicio, nuevo);
        }

        private void agregarProcesoRec(Proceso t, Proceso nuevo)
        {
            if (t.sig == null)
                t.sig = proceso = nuevo;
            else
                agregarProcesoRec(t.sig, nuevo);
        }

        private void nuevoInicio()
        {
            inicio = inicio.sig;
        }

        private void reducirCiclos()
        {
            inicio.Duracion--;
            if (inicio.Duracion == 0)
                nuevoInicio();
        }

        private int obtenerUltimoProceso(Proceso t)
        {
            if (t.sig == null)
                return t.Cuantos;
            else
                return t.Cuantos + obtenerUltimoProceso(t.sig);
        }
        //3 4 1 
        public int obtenerCiclosVacios()
        {
            Proceso t = inicio;
            while(t != null)
            {
                ciclo += inicio.Duracion;
                t = t.sig;
            }
            return ciclo;
        }
        

        
        
    }
}
