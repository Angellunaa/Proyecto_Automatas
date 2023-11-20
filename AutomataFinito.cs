using Proyecto_Automatas.Graficos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class AutomataFinito : Automata
    {
        public AutomataFinito(List<Transicion> Transiciones, INodo inicial) : base(Transiciones, inicial)
        {
            data.Columns.Add("Universo");
            data.Columns.Add("Función de transición");
            data.Columns.Add("Estado actual");
            data.Columns.Add("Estado siguiente");
            data.Columns.Add("Cadena");
        }

        public bool EsAceptada(INodo estado, string cadena)
        {
            if (string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado && trans.Valor == "λ") //Si la transicion empieza en el nodo a evaluar y es lambda
                    {
                        EsAceptada(trans.NodoFinal, cadena);
                    }
                }
                if (estado.Final) return true;
                else return false;
            }
            else//Si la cadena no es vacia
            {
                bool vacio = true;
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (trans.Valor == "λ") Evaluar_Cadena(trans.NodoFinal, cadena);
                        else if (trans.Valor.Length <= cadena.Length)
                        {
                            string sub = cadena.Substring(0, trans.Valor.Length);
                            if (trans.Valor == sub)
                            {
                                Evaluar_Cadena(trans.NodoFinal, cadena.Substring(trans.Valor.Length));
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio) return false;
            }

            return false;
        }

        public void Evaluar_Cadena(INodo estado, string cadena)//Evaluacion de DFA y NFA
        {
            List<string> rep = new List<string>();//Lista de strings para almacenar los posibles valores repetidos
            NodoG n = (NodoG)estado ;
            n.ColorFondo = Color.LightGray; n.Dibujar();
            MessageBox.Show("Estado actual: " + n.Nombre + "\n Cadena actual:' " + cadena + "'", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            n.ColorFondo = Color.Gold; n.Dibujar();
            if (string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                if (estado == inicial)
                {
                    data.Rows.Add(u, "δ(" + estado.Nombre + ",λ)= " + estado.Nombre, estado.Nombre, estado.Nombre, "' '");
                }
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado && trans.Valor == "λ") //Si la transicion empieza en el nodo a evaluar y es lambda
                    {
                        u++;
                        data.Rows.Add(u, "δ(" + estado.Nombre + ",λ)= " + trans.NodoFinal.Nombre, estado.Nombre, trans.NodoFinal.Nombre, "' '");
                        n.ColorFondo = Color.Gray; n.Dibujar();
                        Evaluar_Cadena(trans.NodoFinal, cadena);
                    }
                }
                if (estado.Final)
                {
                    n.ColorFondo = Color.GreenYellow; n.Dibujar();
                    MessageBox.Show("La cadena es aceptada y acabo en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
                else
                {
                    n.ColorFondo = Color.Red; n.Dibujar();
                    MessageBox.Show("La cadena no fue aceptada y acabo en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
            }
            else//Si la cadena no es vacia
            {
                bool vacio = true;
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (trans.Valor == "λ")
                        {
                            data.Rows.Add(u, "δ(" + estado.Nombre + "," + trans.Valor + ")= " + trans.NodoFinal.Nombre, estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '");
                            Evaluar_Cadena(trans.NodoFinal, cadena);
                            u++;
                        }
                        else if (trans.Valor.Length <= cadena.Length)
                        {
                            string sub = cadena.Substring(0, trans.Valor.Length);
                            if (trans.Valor == sub)
                            {
                                for (int i = trans.Valor.Length; i > 0; i--)
                                {
                                    sub = cadena.Substring(0, i);
                                    if (!rep.Contains(sub)) rep.Add(sub);
                                    else u++;
                                }
                                data.Rows.Add(u, "δ(" + estado.Nombre + "," + trans.Valor + ")= " + trans.NodoFinal.Nombre, estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '");
                                Evaluar_Cadena(trans.NodoFinal, cadena.Substring(trans.Valor.Length));
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio)
                {
                    data.Rows.Add(u, "δ(" + estado.Nombre + "," + cadena + ")= ∅", estado.Nombre, estado.Nombre, "' " + cadena + " '");
                    n.ColorFondo = Color.DarkGray; n.Dibujar();
                    MessageBox.Show("La cadena no fue aceptada y acabó en el VACIO en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
            }
        }
    }
}
