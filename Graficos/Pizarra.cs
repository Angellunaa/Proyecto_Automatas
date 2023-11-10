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

namespace Proyecto_Automatas.Graficos
{
    public class Pizarra : Panel
    {
        //Atributos
        private short estado = 1;//Indica que se esta haciendo en la pizarra
        private List<NodoG> listaNodos = new List<NodoG>();//Lista de nodos
        private List<IArista> conexiones = new List<IArista>();//Lista de aristas
        private List<AristaG> listaAristas = new List<AristaG>();//Lista de aristas
        private static string? FolderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);//Directorio del proyecto
        public static Cursor Eliminar = new Cursor(FolderPath + "\\src\\Cursores\\Eliminar.cur");//Cursor para eliminar
        public static Cursor Agarrar = new Cursor(FolderPath + "\\src\\Cursores\\ManoCerrada.cur");//Cursor para agarrar objetos
        public NodoG? NodoInicial = null;
        
        //Metodos Get y Set
        public short _estado { get { return estado; } set { estado = value; } }
        public List<AristaG> _listaAristas { get { return listaAristas; } set { listaAristas = value; } }
        public List<IArista> _conexiones { get { return conexiones; } set { conexiones = value; } }
        public List<NodoG> _listaNodos { get { return listaNodos; } set { listaNodos = value; } }
        public short seccion { get;}

        public Pizarra(short seccion)//Contructor
        {
            //Propiedades del panel
            Location = new Point(3, 30);
            Dock = DockStyle.Fill;
            Enabled = true;

            //Suscribir a eventos
            MouseClick += Pizarra_MouseClick;
            MouseMove += Pizarra_MouseMove;
            Paint += Pizarra_Paint;
            this.seccion = seccion;
        }

        private void Pizarra_MouseClick(object? sender, MouseEventArgs e)
        {
            switch (estado)
            {
                case 2: //Agrega un Nodo

                    NodoG nodo = new NodoG(e.Location);
                    listaNodos.Add(nodo);
                    Controls.Add(nodo);
                    nodo.pizarra = this;//Le indica al nodo que esta contenido en esta pizarra
                    break;

                case 3://Eliminar
                    foreach (AristaG a in listaAristas)
                    {
                        int val = a.EstaDentro(e.Location);
                        if (val != -1)
                        {
                            if (a.path.Count() <= 2)
                            {
                                AristaG? ar = listaAristas.Find(arista => arista.NodoFinal == a.NodoInicio && arista.NodoInicio == a.NodoFinal);
                                if (ar is not null) ar.Tipo = 0;
                                listaAristas.Remove(a);
                            }
                            a.Eliminar(val);
                            break;
                        }
                    }
                    Invalidate();
                    break;
            }
        }

        private void Pizarra_MouseMove(object? sender, MouseEventArgs e)
        {
            if (estado == 3)
            {
                foreach (AristaG a in listaAristas)
                {
                    if (a.EstaDentro(e.Location) != -1)
                    {
                        Cursor = Eliminar;
                        break;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }

        // -------------------------------------------------------------- Dibujo de Automata ----------------------------------------------------------

        private void Pizarra_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Mejora la calidad de imagen

            if (NodoInicial is not null)//Dibuja el nodo inicial
            {
                // Puntos del triangulo
                Point[] puntos =
                {
                    new Point(NodoInicial.Centro.X-NodoG.radio, NodoInicial.Centro.Y),
                    new Point(NodoInicial.Centro.X-NodoG.radio*2, NodoInicial.Centro.Y-NodoG.radio),
                    new Point(NodoInicial.Centro.X-NodoG.radio*2, NodoInicial.Centro.Y+NodoG.radio)
                };

                g.DrawPolygon(new Pen(Brushes.Black, 2), puntos);
            }
            foreach (AristaG a in listaAristas)
            {
                if (a.Tipo == 0) a.DibujarLinea(g); //Linea
                else if (a.Tipo == 1) a.DibujarArco(g);//Arco
                else a.DibujarBucle(g); //Bucle
            }
        }

        protected override CreateParams CreateParams //Ayuda a minimizar el parpadeo
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
