//Clase Grafo
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class Automata
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que 
        // almacena esa conexión
        public List<AristaG> valores { get; set; }

        //Variable para indicar el estado inicial
        public string inicial;
        public Automata(List<AristaG> v, string i)
        {
            //
            valores = v;
            inicial = i;
        }
        public void buscar_aristas(List<AristaG> conexiones, string begin)
        {
            foreach (AristaG nod in valores)
            {
                if (begin == nod.NodoInicio.Nombre)
                {
                    conexiones.Add(nod);
                }
            }
        }
        public void Evaluar_Cadena(NodoG nodo, string cadena, bool seguir, int c)
        {
            //Evaluamos si el nodo es válido
            if (nodo != null)
            {
                nodo.ColorFondo = Color.LightGray;
                nodo.Dibujar();
                MessageBox.Show("Estado actual: " + nodo.Nombre + "\n Cadena: ' " + cadena + " '", "Recorrido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                List<AristaG> conexiones = new List<AristaG>();
                //Se busca las conexiones del nodo inicial 
                buscar_aristas(conexiones, nodo.Nombre);
                string nueva = cadena;
                //Variable que nos indica si se ha llegado a final de la cadena
                if (seguir)
                {
                    //Si no hay aristas desde ese nodo, no se puede continuar
                    if (conexiones.Count > 0)
                    {
                        //Se compara si el caracter de la cadena es igual a uno de los valores que 
                        //existen en las aristas del nodo
                        string valor = "";
                        foreach (AristaG str in conexiones)
                        {
                            //Busca los valores que contiene el arista
                            foreach (string v in str.Valores)
                            {
                                //Si el valor es de longitud mayor a 1, y la cadena tiene 
                                //la longitud necesaria para evaluarlos
                                if (v.Length > 1 && (cadena.Length >= v.Length))
                                {
                                    valor = cadena.Substring(0, v.Length);
                                }
                                //Si el valor del arista es lambda
                                else if (v == "λ")
                                {
                                    valor = "λ";
                                }
                                //Si la cadena es vacía
                                else if (cadena.Equals(string.Empty))
                                {
                                    valor = "";
                                }
                                //Si no se cumple ninguna de la condiciones,
                                //Asignamos un solo caracter de la cadena
                                else
                                {
                                    valor = cadena[0].ToString();
                                }
                                //Si el valor que tomamos de la cadena, es igual al del arista
                                if (valor == v)
                                {
                                    //Si el valor que tomamos fue lambda, asignamos una cadena vacía
                                    if (valor == "λ") valor = "";
                                    //Indicamos que hubo una conexión
                                    c++;
                                    if (cadena.Length == valor.Length)
                                    {
                                        //Si la longitud que tomamos es igual a la de la cadena
                                        //No nos queda más por evaluar, entonces asignamos 
                                        //que la nueva cadena es vacía
                                        nueva = "";
                                    }
                                    else
                                    {
                                        //Si no es vacía, eliminamos el valor que tomamos de la cadena
                                        //Para poder evaluar el resto de la cadena
                                        if (!string.IsNullOrEmpty(cadena) && cadena.Length > valor.Length)
                                        {
                                            nueva = cadena.Substring(valor.Length);
                                        }
                                    }
                                    //Si la nueva cadena que nos queda evaluar, es vacía
                                    if (nueva.Length == 0)
                                    {
                                        //Asignamos que llegamos al final de la cadena
                                        seguir = false;
                                    }
                                    else
                                    {
                                        //Si aún no es vacía, indicamos que hay que seguir evaluando
                                        seguir = true;
                                    }
                                    //Llamado a la función con el nuevo nodo, el resto de la cadena,
                                    //la indicación de si se debe seguir evauando, y el número de conexiónes
                                    //en 0
                                    nodo.ColorFondo = Color.Gold;
                                    nodo.Dibujar();
                                    Evaluar_Cadena(str.n2, nueva, seguir, 0);
                                }
                            }
                        }
                        //Si no se pudo avanzar de nodo, y aún no se terminaba la cadena
                        if (c == 0)
                        {
                            //Indicamos que la cadena no es aceptada
                            nodo.ColorFondo = Color.OrangeRed;
                            nodo.Dibujar();
                            MessageBox.Show("La cadena no es aceptada en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            nodo.ColorFondo = Color.Gold;
                            nodo.Dibujar();
                        }
                    }
                    else
                    {
                        //Si no hay aristas disponibles para avanzar de nodo y 
                        //no habíamos llegado al final de la cadena
                        nodo.ColorFondo = Color.OrangeRed;
                        nodo.Dibujar();
                        MessageBox.Show("La cadena no es aceptada en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        nodo.ColorFondo = Color.Gold;
                        nodo.Dibujar();
                    }
                }
                else
                {
                    //Si el nodo actual es final
                    if (nodo.Final)
                    {
                        nodo.ColorFondo = Color.GreenYellow;
                        nodo.Dibujar();
                        MessageBox.Show("La cadena es aceptada en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nodo.ColorFondo = Color.Gold;
                        nodo.Dibujar();
                    }
                    else
                    {
                        //Si no se encontró en los nodos terminales
                        nodo.ColorFondo = Color.OrangeRed;
                        nodo.Dibujar();
                        MessageBox.Show("La cadena no es aceptada en el nodo: " + nodo.Nombre, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        nodo.ColorFondo = Color.Gold;
                        nodo.Dibujar();
                    }
                    //Por último, también revisamos si el nodo tiene transiciones lambda
                    if (conexiones.Count > 0)
                    {
                        foreach (AristaG str in conexiones)
                        {
                            foreach (string v in str.Valores)
                            {
                                if (v == "λ")
                                {
                                    //Se llama a la función, para evaluar si el nodo
                                    //es final o no
                                    Evaluar_Cadena(str.n2, nueva, false, 0);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //Si el nodo es vacío
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
