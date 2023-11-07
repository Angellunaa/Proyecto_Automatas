//Clase Grafo
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public struct TripleValor
    {
        public string inicio;
        public List<string> valor;
        public string final;
    }
    public class Automata
    {
        //Lista para almacenar las aristas, su nodo de inicio, nodo final, y los valores que 
        // almacena esa conexión
        public List<AristaG> valores { get; set; }
        //Lista que almacena los nodos que son terminales
        public List<string> terminales { get; set; }

        //Variable para indicar el estado inicial
        public string inicial;
        public Automata(List<AristaG> v, List<string> t, string i)
        {
            //
            valores = v;
            terminales = t;
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
        public void Evaluar_Cadena(string nodo, string cadena, bool seguir, int c)
        {
            List<AristaG> conexiones = new List<AristaG>();
            //Se busca las conexiones del nodo inicial 
            buscar_aristas(conexiones, nodo);
            string nueva = cadena;
            if (nodo != "")
            {
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
                            foreach (string v in str.Valores)
                            {
                                //Busca los valo
                                if (v.Length > 1 && (cadena.Length >= v.Length))
                                {
                                    valor = cadena.Substring(0, v.Length);
                                }
                                else if (v == "λ")
                                {
                                    valor = "λ";
                                }
                                else if (cadena.Equals(string.Empty))
                                {
                                    valor = "";
                                }
                                else
                                {
                                    valor = cadena[0].ToString();
                                }
                                if (valor == v)
                                {
                                    if (valor == "λ") valor = "";
                                    c++;
                                    if (cadena.Equals(string.Empty) || cadena.Length == valor.Length)
                                    {
                                        nueva = "";
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(cadena) && cadena.Length > valor.Length)
                                        {
                                            nueva = cadena.Substring(valor.Length);
                                        }
                                    }
                                    if (nueva.Length == 0)
                                    {
                                        seguir = false;
                                    }
                                    else
                                    {
                                        seguir = true;
                                    }
                                    Evaluar_Cadena(str.NodoFinal.Nombre, nueva, seguir, 0);
                                }
                            }
                        }
                        if (c == 0)
                        {
                            MessageBox.Show("La cadena no es aceptada en el nodo: "+nodo, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cadena no es aceptada en el nodo: "+nodo, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (conexiones.Count > 0)
                {
                    foreach(AristaG str in conexiones)
                    {
                        foreach(string v in str.Valores)
                        {
                            if(v == "λ")
                            {
                                Evaluar_Cadena(str.NodoFinal.Nombre, nueva, false, 0);
                            }
                        }
                    }
                }
                else
                {
                    seguir = false;
                    foreach (string str in terminales)
                    {
                        if (nodo == str)
                        {
                            seguir = true;
                            MessageBox.Show("La cadena es aceptada en el nodo: "+nodo, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (!seguir)
                    {
                        MessageBox.Show("La cadena no es aceptada en el nodo: "+nodo, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
