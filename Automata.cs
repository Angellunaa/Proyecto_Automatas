//Clase Grafo
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Automatas.Graficos;

namespace Proyecto_Automatas
{
    public abstract class Automata
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que almacena esa conexión
        protected List<Transicion> Transiciones;
        protected INodo inicial;
        public DataTable data = new DataTable();
        protected int u;

        public Automata(List<Transicion> Transiciones, INodo inicial)
        {
            u = 1;
            this.Transiciones = Transiciones;
            this.inicial = inicial;
        }
    }
}
