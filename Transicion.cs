using Proyecto_Automatas.Graficos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class Transicion : IArista
    {
        private string valor;

        public Transicion(INodo nodoinicial, INodo nodofinal, string valor)
        {
            NodoInicio = nodoinicial;
            NodoFinal = nodofinal;
            this.valor = valor;
        }

        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
        public string Valor { get { return valor; } }
        
        public static List<Transicion> Convertir(List<AristaG> lista)
        {
            List<Transicion> listaTransiciones = new List<Transicion>();

            foreach (AristaG arista in lista)
            {
                foreach(string s in arista.Valores)
                {
                    listaTransiciones.Add(new Transicion(arista.NodoInicio, arista.NodoFinal, s));
                }
            }

            return listaTransiciones;
        }
    }
}
