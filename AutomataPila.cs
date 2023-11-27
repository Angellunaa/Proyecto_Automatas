using Proyecto_Automatas.Graficos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    internal class AutomataPila : Automata
    {
        //private char[] AlfabetoEntrada;
        //private char[] AlfabetoPila;
        private readonly bool vaciar;
        private string pila_actual = "Z";
        private string[]? valores_p;//Lista para almacenar los valores de una arista en el autómata de pila

        public AutomataPila(List<Transicion> Transiciones, List<INodo> Nodos, INodo inicial, bool v) : base(Transiciones, Nodos, inicial)
        {
            vaciar = v;
            data.Columns.Add("Universo");
            data.Columns.Add("Función de transición");
            data.Columns.Add("Estado actual");
            data.Columns.Add("Estado siguiente");
            data.Columns.Add("Cadena");
            data.Columns.Add("Pila");
        }

        public bool EsDeterminista()
        {
            List<Transicion> temp;

            foreach (INodo n in Nodos) //Busca en cada nodo
            {
                temp = Transiciones.FindAll(t => t.NodoInicio == n);//Encuentro las transiciones del nodo

                foreach (Transicion t in temp)//Para cada transicion del nodo
                {
                    string[] valores = t.Valor.Split('ǁ');//Valores de la transicion a evaluar
                    if (valores[1] == "λ") return false; //Si no se saca nada de la pila sera no determinista
                    foreach (Transicion t2 in temp)
                    {
                        string[] valores2 = t2.Valor.Split('ǁ');
                        if (valores[0] == "λ")
                        {
                            if (t != t2 && valores[1] == valores2[1])
                            {
                                return false; //No es determinista
                            }
                        }
                        else
                        {
                            if (t != t2 && valores[0] == valores2[0] && valores[1] == valores2[1])
                            {
                                return false; //No es determinista
                            }
                        } 
                    }
                }
            }
            return true;
        }

        public bool EsAceptada(INodo estado, string cadena, List<string> p)
        {
            return false; //Agregar algoritmo
        }

        //Función para actualizar la pila
        private void Insertar_valores(List<string> p2)
        {
            //Eliminamos el tope de la pila
            p2.RemoveAt((p2.Count - 1));
            if (valores_p[2] != "λ")
            {
                //Se añaden los valores a la pila
                for (int i = (valores_p[2].Length-1); i >= 0; i--)
                {
                    p2.Add(valores_p[2][i].ToString());
                }
            }
            Pila_actual(p2);
            if (p2.Count == 0) p2.Add("λ");
        }

        //Función que devuelve los valores que hay en la pila en cadena
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

        public async Task Evaluar_Cadena(INodo estado, string cadena, List<string> p)//Evaluacion de automata de pila
        {
            List<string> rep = new List<string>();//Lista de strings para almacenar los posibles valores repetidos
            NodoG n = (NodoG)estado;
            n.Dibujar(Color.LightGray);

            // Actualizar el formulario desde el hilo de la interfaz de usuario
            Program.menu.Formulario.Invoke((MethodInvoker)delegate
            {
                Program.menu.Formulario.SetDescripcion("Estado actual: " + n.Nombre + "\n Cadena actual:' " + cadena + "'\nPila: " + pila_actual);
            });
            Esperar();// Pausa hasta que el usuario presiona el botón paso
            n.Dibujar();

            if (string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    //Leemos los valores de la arista separados
                    valores_p = trans.Valor.Split('ǁ');
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
                        await Evaluar_Cadena(trans.NodoFinal, cadena,p2);
                        Pila_actual(p);
                    }
                }
                if (estado.Final && !vaciar)//Si el nodo en el que terminó es final y no se tiene que aceptar por cadena vacía
                {
                    n.Dibujar(Color.GreenYellow);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena es aceptada y acabó en el nodo: " + estado.Nombre);
                    });
                    Esperar();// Pausa hasta que el usuario presiona el botón paso

                    n.Dibujar();
                }
                else if (vaciar && pila_actual== "λ")//Si la cadena se acepta cuando la pila está vacía y la pila es vacía
                {
                    n.Dibujar(Color.GreenYellow);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena es aceptada y acabó en el nodo: " + estado.Nombre);
                    });
                    Esperar();// Pausa hasta que el usuario presiona el botón paso

                    n.Dibujar();
                }
                else 
                {
                    n.Dibujar(Color.Red);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena no fue aceptada y acabó en el nodo: " + estado.Nombre);
                    });
                    Esperar();// Pausa hasta que el usuario presiona el botón paso

                    n.Dibujar();
                }
            }
            else//Si la cadena no es vacia
            {
                bool vacio = true;
                foreach (Transicion trans in Transiciones)
                {
                    valores_p = trans.Valor.Split('ǁ');
                    if (trans.NodoInicio == estado) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (valores_p[0] == "λ" && p.Last() == valores_p[1])
                        {
                            List<string> p2 = new List<string>(p);
                            Insertar_valores(p2);
                            data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= {" + trans.NodoFinal.Nombre + "," + valores_p[2] + "}", estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '",pila_actual);
                            await Evaluar_Cadena(trans.NodoFinal, cadena,p2);
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
                                await Evaluar_Cadena(trans.NodoFinal, cadena.Substring(valores_p[0].Length),p2);
                                Pila_actual(p);
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio)
                {
                    data.Rows.Add(u, "δ(" + estado.Nombre + "," + valores_p[0] + "," + valores_p[1] + ")= ∅", estado.Nombre, "∅", "' " + cadena + " '",pila_actual);
                    n.Dibujar(Color.DarkGray);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena no fue aceptada y acabó en el VACIO en el nodo: " + estado.Nombre);
                    });
                    Esperar();// Pausa hasta que el usuario presiona el botón paso

                    n.Dibujar();
                }
            }
        }
    }
}
