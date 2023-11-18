using Proyecto_Automatas.Graficos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    internal class Pila
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que 
        // almacena esa conexión
        private List<Transicion> Transiciones;
        private INodo inicial;
        public DataTable data = new DataTable();
        private int u;
        private bool vaciar;
        private string pila_actual="Z";
        private string[] valores_p;//Lista para almacenar los valores de una arista en el
                                       //autómata de pila
        public Pila(List<Transicion> Transiciones, INodo inicial, bool v)
        {
            vaciar = v;
            u = 1;
            this.Transiciones = Transiciones;
            this.inicial = inicial;
            data.Columns.Add("Universo");
            data.Columns.Add("Función de transición");
            data.Columns.Add("Estado actual");
            data.Columns.Add("Estado siguiente");
            data.Columns.Add("Cadena");
            data.Columns.Add("Pila");
        }
        private void Insertar_valores(List<string> p2)
        {
            p2.RemoveAt((p2.Count - 1));
            if (valores_p[2] != "λ")
            {
                for (int i = (valores_p[2].Length-1); i >= 0; i--)
                {
                    p2.Add(valores_p[2][i].ToString());
                }
            }
            Pila_actual(p2);
            if (p2.Count == 0) p2.Add("λ");
        }
        public void Pila_actual(List<string> p)
        {
            if (p.Count == 0) pila_actual = "λ";
            else
            {
                pila_actual = "";
                foreach (string s in p)
                {
                    pila_actual += s;
                }
            }
        }
        public void Evaluar_Cadena(INodo estado, string cadena, List<string> p)//Evaluacion de DFA y NFA
        {
            List<string> rep = new List<string>();//Lista de strings para almacenar los posibles valores repetidos
            NodoG n = estado as NodoG;
            n.ColorFondo = Color.LightGray; n.Dibujar();
            MessageBox.Show("Estado actual: " + n.Nombre + "\n Cadena actual:' " + cadena + "'\nPila: " + pila_actual, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            n.ColorFondo = Color.Gold; n.Dibujar();
            if (string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    valores_p = trans.Valor.Split(',', ';');
                    if (estado == inicial && trans.NodoInicio == estado && valores_p[0] == "λ")
                    {
                        data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= {" + estado.Nombre + "," + valores_p[2] +"}", estado.Nombre, estado.Nombre,"' '", pila_actual);
                    }
                    if (trans.NodoInicio == estado && valores_p[0] == "λ" && pila_actual!= "λ" && p.Last() == valores_p[1]) //Si la transicion empieza en el nodo a evaluar y es lambda
                    {
                        u++;
                        List<string> p2 = new List<string>(p);
                        Insertar_valores(p2);
                        data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= {" + trans.NodoFinal.Nombre + "," + valores_p[2] + "}", estado.Nombre, estado.Nombre, "' '", pila_actual);
                        Evaluar_Cadena(trans.NodoFinal, cadena,p2);
                        Pila_actual(p);
                    }
                }
                if (estado.Final && !vaciar)
                {
                    n.ColorFondo = Color.GreenYellow; n.Dibujar();
                    MessageBox.Show("La cadena es aceptada y acabó en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
                else if (vaciar && pila_actual== "λ")
                {
                    n.ColorFondo = Color.GreenYellow;n.Dibujar();
                    MessageBox.Show("La cadena es aceptada y acabó en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
                else 
                {
                    n.ColorFondo = Color.Red; n.Dibujar();
                    MessageBox.Show("La cadena no fue aceptada y acabó en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
            }
            else//Si la cadena no es vacia
            {
                bool vacio = true;
                foreach (Transicion trans in Transiciones)
                {
                    valores_p = trans.Valor.Split(',', ';');
                    if (trans.NodoInicio == estado) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (valores_p[0] == "λ" && p.Last() == valores_p[1])
                        {
                            List<string> p2 = new List<string>(p);
                            Insertar_valores(p2);
                            data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= {" + trans.NodoFinal.Nombre + "," + valores_p[2] + "}", estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '",pila_actual);
                            Evaluar_Cadena(trans.NodoFinal, cadena,p2);
                            Pila_actual(p);
                            u++;
                        }
                        else if (valores_p[0].Length <= cadena.Length)
                        {
                            string sub = cadena.Substring(0, valores_p[0].Length);
                            if (valores_p[0] == sub && p[p.Count-1] == valores_p[1])
                            {
                                for (int i = valores_p[0].Length; i > 0; i--)
                                {
                                    sub = cadena.Substring(0, i);
                                    if (rep.Contains(sub))
                                    {
                                        if (trans.NodoInicio != trans.NodoFinal) u++;
                                    }
                                    else rep.Add(sub);
                                }
                                List<string> p2 = new List<string>(p);
                                Insertar_valores(p2);
                                data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= {" + trans.NodoFinal.Nombre + "," + valores_p[2] + "}", estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '",pila_actual);
                                Evaluar_Cadena(trans.NodoFinal, cadena.Substring(valores_p[0].Length),p2);
                                Pila_actual(p);
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio)
                {
                    data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= ∅", estado.Nombre, "∅", "' " + cadena + " '",pila_actual);
                    n.ColorFondo = Color.DarkGray; n.Dibujar();
                    MessageBox.Show("La cadena no fue aceptada y acabó en el VACIO en el nodo: " + estado.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    n.ColorFondo = Color.Gold; n.Dibujar();
                }
            }
        }
    }
}
