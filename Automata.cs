//Clase Grafo
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Proyecto_Automatas.Graficos;

namespace Proyecto_Automatas
{
    public abstract class Automata
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que almacena esa conexión
        protected readonly List<Transicion> Transiciones;
        protected readonly List<INodo> Nodos;
        protected readonly INodo inicial;
        public DataTable data = new DataTable();
        protected int u;
        public static bool continuar = false;

        public Automata(List<Transicion> Transiciones, List<INodo> Nodos, INodo inicial)
        {
            u = 1;
            this.Transiciones = Transiciones;
            this.inicial = inicial;
            this.Nodos = Nodos;
        }

        public abstract bool EsDeterminista();

        protected static void Esperar(CancellationToken cancelacion)
        {
            while (!continuar)
            {
                cancelacion.ThrowIfCancellationRequested();//Comprueba si se cancelo la tarea
                Application.DoEvents();
            }
            continuar = false;// Restablecer la bandera después de que el usuario presiona Continuar
        }
    }
}
