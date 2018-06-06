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
        private int cont = 1, vacio, completo, ultimo, ciclo;
        private int ciclos = 300;

        public int Vacio { get => vacio; }
        public int Completo { get => completo; }
        public int Ultimo { get => ultimo; }
        public int Ciclo { get => ciclo;  }

        public void iniciarProcesador()
        {
            while(ciclos > 0)
            {
                int r = rnd.Next(1, 101);
                if (r <= 35)
                    agregarProceso( new Proceso(cont++, rnd.Next(4, 15)));
                if (inicio != null)
                    reducirCiclos();
                else
                    vacio++;
                ciclos--;
            }
            //completo = inicio.Cuantos - 1;
            ultimo = obtenerUltimoProceso(inicio);// - completo;

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
            {
                nuevoInicio();
                completo++;
            }

        }

        private int obtenerUltimoProceso(Proceso t)
        {
            //  1+2
            //     1+1
            //         1
            //  3  1000   6000     cuantos
            //  6  4   2     duracion
            if (t.sig == null)
                return 1;
            else
                return 1 + obtenerUltimoProceso(t.sig);
        }

        public int obtenerCiclosVacios()
        {
            if (inicio == null)
                return 0;
            else if (inicio.sig == null)
                return inicio.Duracion;
            else
                return obtenerCiclosVaciosR(inicio);
        }

        public int obtenerCiclosVaciosR(Proceso t)
        {
            if (t.sig == null)
                return t.Duracion;
            else
                return t.Duracion + obtenerCiclosVaciosR(t.sig);
        }


    }
}
