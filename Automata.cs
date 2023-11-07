//Clase Grafo
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Automatas.Graficos;

namespace Proyecto_Automatas
{
    public class Automata
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que 
        // almacena esa conexión
        public List<Transicion> Transiciones { get; set; }

        //Variable para indicar el estado inicial
        public string inicial;

        public Automata(List<Transicion> Transiciones, string ini)
        {
            this.Transiciones = Transiciones;
            inicial = ini;
        }

        public void Evaluar_Cadena(INodo nodo, string cadena)//Evaluacion de DFA y NFA
        {
            if(string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == nodo && trans.Valor == "λ") //Si la transicion empieza en el nodo a evaluar y es lambda
                    {
                        Evaluar_Cadena(trans.NodoFinal, cadena);
                    }
                }
                if (nodo.Final)
                {
                    MessageBox.Show("La cadena es aceptada y acabo en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La cadena no fue aceptada y acabo en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else//Si la cadena no es vacia
            {
                bool vacio = true;
                foreach(Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == nodo) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (trans.Valor == "λ") Evaluar_Cadena(trans.NodoFinal, cadena);
                        else if (trans.Valor.Length <= cadena.Length)
                        {
                            string sub = cadena.Substring(0,trans.Valor.Length);
                            if (trans.Valor == sub)
                            {
                                Evaluar_Cadena(trans.NodoFinal, cadena.Substring(trans.Valor.Length));
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio) MessageBox.Show("La cadena no fue aceptada y acabo en el VACIO en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
