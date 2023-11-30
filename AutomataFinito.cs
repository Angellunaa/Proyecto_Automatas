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
        private readonly char[] Alfabeto;

        public AutomataFinito(List<Transicion> Transiciones, List<INodo> Nodos, INodo inicial) : base(Transiciones, Nodos, inicial)
        {
            data.Columns.Add("Universo");
            data.Columns.Add("Función de transición");
            data.Columns.Add("Estado actual");
            data.Columns.Add("Estado siguiente");
            data.Columns.Add("Cadena");
            Alfabeto = GetAlfabeto();
        }

        public char[] GetAlfabeto()
        {
            HashSet<char> result = new HashSet<char>();
            foreach (Transicion trans in Transiciones)
            {
                if (trans.Valor.Count() == 1 && trans.Valor != "λ") result.Add(trans.Valor[0]);
            }
            return result.ToArray();
        }

        public override bool EsDeterminista()
        {
            bool determinista;
            List<Transicion> temp;

            foreach (INodo n in Nodos)
            {
                temp = Transiciones.FindAll(t => t.NodoInicio == n);
                foreach (char simbolo in Alfabeto)
                {
                    if (temp.Count == 0) return false; //Si ya no hay transiciones y todavia hay simbolos en el alfabeto
                    determinista = false;
                    foreach (Transicion t in temp)
                    {
                        if (t.Valor == simbolo.ToString())
                        {
                            temp.Remove(t);
                            determinista = true;
                            break;
                        }
                    }
                    if (!determinista) return false; //No se encontro transicion para ese simbolo
                }
                if (temp.Count > 0) return false; //Si hay transiciones y ya se recorrio el alfabeto
            }
            return true;
        }

        public bool EsAceptada(INodo estado, string cadena)
        {
            if (string.IsNullOrEmpty(cadena))//Si la cadena es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado && trans.Valor == "λ") //Si la transicion empieza en el nodo a evaluar y es lambda
                    {
                        if (EsAceptada(trans.NodoFinal, cadena)) return true;
                    }
                }
                if (estado.Final) return true;//Si el nodo es final se acepta
            }
            else//Si la cadena no es vacia
            {
                foreach (Transicion trans in Transiciones)
                {
                    if (trans.NodoInicio == estado) //Si la transicion empieza en el nodo a evaluar
                    {
                        if (trans.Valor == "λ")
                        {
                            if(trans.NodoInicio != trans.NodoFinal) //Si no es un bucle
                            {
                                if (EsAceptada(trans.NodoFinal, cadena)) return true;
                            }
                        }
                        else if (trans.Valor.Length <= cadena.Length)
                        {
                            string sub = cadena.Substring(0, trans.Valor.Length);
                            if (trans.Valor == sub)
                            {
                                if(EsAceptada(trans.NodoFinal, cadena.Substring(trans.Valor.Length))) return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public async Task Evaluar_Cadena(INodo estado, string cadena, CancellationToken cancelacion)//Evaluacion de DFA y NFA
        {
            List<string> rep = new List<string>();//Lista de strings para almacenar los posibles valores repetidos

            NodoG n = (NodoG)estado;
            n.Dibujar(Color.LightGray);

            // Actualizar el formulario desde el hilo de la interfaz de usuario
            Program.menu.Formulario.Invoke((MethodInvoker)delegate
            {
                Program.menu.Formulario.SetDescripcion("Estado actual: " + n.Nombre + "\n Cadena actual:' " + cadena + "'");
            });
            Esperar(cancelacion);// Pausa hasta que el usuario presiona el botón paso
            n.Dibujar();

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
                        n.Dibujar(Color.Gray);
                        await Evaluar_Cadena(trans.NodoFinal, cadena, cancelacion);
                    }
                }
                if (estado.Final)
                {
                    n.Dibujar(Color.GreenYellow);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena es aceptada y acabo en el nodo: " + estado.Nombre);
                    });
                    Esperar(cancelacion);// Pausa hasta que el usuario presiona el botón paso
                    n.Dibujar();
                }
                else
                {
                    n.Dibujar(Color.Red);

                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena no fue aceptada y acabo en el nodo: " + estado.Nombre);
                    });
                    Esperar(cancelacion);// Pausa hasta que el usuario presione el botón paso
                    n.Dibujar();
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
                            data.Rows.Add(u, "δ(" + estado.Nombre + "," + trans.Valor + ") = " + trans.NodoFinal.Nombre, estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '");
                            await Evaluar_Cadena(trans.NodoFinal, cadena, cancelacion);
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
                                data.Rows.Add(u, "δ(" + estado.Nombre + "," + trans.Valor + ") = " + trans.NodoFinal.Nombre, estado.Nombre, trans.NodoFinal.Nombre, "' " + cadena + " '");
                                await Evaluar_Cadena(trans.NodoFinal, cadena.Substring(trans.Valor.Length), cancelacion);
                                vacio = false;
                            }
                        }
                    }
                }

                if (vacio)
                {
                    data.Rows.Add(u, "δ(" + estado.Nombre + "," + cadena + ") = ∅", estado.Nombre, estado.Nombre, "' " + cadena + " '");
                    n.Dibujar(Color.DarkGray);
                    // Actualizar el formulario desde el hilo de la interfaz de usuario
                    Program.menu.Formulario.Invoke((MethodInvoker)delegate
                    {
                        Program.menu.Formulario.SetDescripcion("La cadena no fue aceptada y acabó en el VACIO en el nodo: " + estado.Nombre);
                    });
                    Esperar(cancelacion);// Pausa hasta que el usuario presione el botón paso
                    n.Dibujar();
                }
            }
        }
    }
}
