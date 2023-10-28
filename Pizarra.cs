using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    internal class Pizarra : Panel
    {
        //Atributos
        private int estado = 1;//Indica que se esta haciendo en la pizarra
        private List<NodoG> listaNodos = new List<NodoG>();//Lista de nodos
        private List<AristaG> listaAristas = new List<AristaG>();//Lista de aristas

        public Pizarra()//Contructor
        {
            //Propiedades del panel
            this.Location = new Point(3,30);
            this.Dock = DockStyle.Fill;
            this.Enabled = true;

            //Suscribir a eventos
            MouseClick += Pizarra_MouseClick;
        }

        public int _estado { get { return estado; } set {  estado = value; } }
        public List<AristaG> _listaAristas { get { return listaAristas; } set { listaAristas = value; } }
        public List<NodoG> _listaNodos { get { return listaNodos; } set { listaNodos = value; } }

        // ----------------------------------------------------------- Dibujo de Automata -----------------------------------------------------

        private void Pizarra_MouseClick(object sender, MouseEventArgs e)
        {
            switch (estado)
            {
                case 2: //Agrega un Nodo

                    NodoG nodo = new NodoG(e.Location);
                    listaNodos.Add(nodo);
                    Controls.Add(nodo);
                    nodo.Dibujar();
                    break;
            }
        }
    }
}
