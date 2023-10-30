using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public class Pizarra : Panel
    {
        //Atributos
        private short estado = 1;//Indica que se esta haciendo en la pizarra
        private List<NodoG> listaNodos = new List<NodoG>();//Lista de nodos
        private List<AristaG> listaAristas = new List<AristaG>();//Lista de aristas
        private static string FolderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);//Directorio del proyecto
        public static Cursor Eliminar = new Cursor(FolderPath + "\\src\\Cursores\\Eliminar.cur");//Cursor para eliminar
        public static Cursor Agarrar = new Cursor(FolderPath + "\\src\\Cursores\\ManoCerrada.cur");//Cursor para agarrar objetos

        //Metodos Get y Set
        public short _estado { get { return estado; } set { estado = value; } }
        public List<AristaG> _listaAristas { get { return listaAristas; } set { listaAristas = value; } }
        public List<NodoG> _listaNodos { get { return listaNodos; } set { listaNodos = value; } }


        public Pizarra()//Contructor
        {
            //Propiedades del panel
            this.Location = new Point(3,30);
            this.Dock = DockStyle.Fill;
            this.Enabled = true;

            //Suscribir a eventos
            MouseClick += Pizarra_MouseClick;
            Paint += Pizarra_Paint;
        }

        private void Pizarra_MouseClick(object? sender, MouseEventArgs e)
        {
            switch (estado)
            {
                case 2: //Agrega un Nodo

                    NodoG nodo = new NodoG(e.Location);
                    listaNodos.Add(nodo);
                    Controls.Add(nodo);
                    nodo.Dibujar();
                    break;
                case 3://Eliminar

                    foreach(AristaG a in listaAristas)
                    {
                        if (a.EstaDentro(e.Location)) listaAristas.Remove(a);
                    }

                    Invalidate();
                    break;
            }
        }

        // ----------------------------------------------------------- Dibujo de Automata -----------------------------------------------------
        protected override CreateParams CreateParams //Ayuda a minimizar el parpadeo
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Pizarra_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (AristaG a in listaAristas)
            {
                if (a.Tipo == 0) a.DibujarLinea(g); //Linea
                else if (a.Tipo == 1) { }//Arco
                else a.DibujarBucle(g); //Bucle
            }
        }        
    }
}
