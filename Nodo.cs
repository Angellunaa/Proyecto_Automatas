using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Proyecto_Automatas
{
    public class Nodo : Control 
    {
        //Atributos
        private Point centro;
        private string nombre;
        public const int radio = 40; //Radio del círculo
        private bool inicial;
        private bool final;
        private static int cont = 0;
        private Color c;//Color del nodo
        Pen pen; //Contorno del nodo
        Font font; //Estilo del nombre del nodo
        private Point inicio;
        private bool down = false;

        //Metodos
        public Nodo(Point coordenada)
        {
            centro = coordenada;
            nombre = "q" + cont; //Nombre por defecto consecutivo
            inicial = false; //Establece el nodo como no inicial
            final = false; //Establece el nodo como no final
            c = Color.Gold;
            pen = new Pen(Color.Black, 3); //Contorno del nodo
            font = new Font("Arial", 12, FontStyle.Bold);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 2 * radio, 2 * radio);
            this.Region = new Region(path);
            this.Width = radio * 2;
            this.Height = radio * 2;
            this.Location = new Point(coordenada.X - radio, coordenada.Y - radio);
            
            MouseDown += Ctr_MouseDown;
            MouseUp += Ctr_MouseUp;
            MouseMove += Ctr_MouseMove;
            MouseClick += Ctr_MouseClick;

            cont++;
        }

        //------------------------------------------------------------- Metodos get y set ---------------------------------------------------------------------
        public Point Centro { get { return centro; } }
        public Color Color { set { c = value; } }

        // --------------------------------------------------------- Metodos de la clase nodo -----------------------------------------------------------------

        public void predeterminado()
        {
            //Propiedades de la imagen
            c = Color.Gold;
            pen = new Pen(Color.Black, 4); //Contorno del nodo
            font = new Font("Arial", 12, FontStyle.Bold);
            //radio = 40; //Radio del círculo
        }

        public void Dibujar()//Dibuja el nodo
        {
            Bitmap png = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(png))
            {
                Rectangle rec = new Rectangle(2, 2, this.Width - 4, this.Height - 4);//Ajusto la imagen
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

                g.DrawEllipse(pen, rec);
                g.FillEllipse(new SolidBrush(c), rec);
                SizeF textSize = g.MeasureString(nombre, font);
                g.DrawString(nombre, font, Brushes.Black, (this.Width - textSize.Width) / 2, (this.Height - textSize.Width) / 2);
                BackgroundImage = png;//dibuja la imagen en el control
            }
        }

        public Arista Conectar(Nodo otroNodo, string valor) //Conecta dos nodos y resulta en una arista
        {
            // Crea una arista que conecta este nodo con otro nodo
            return new Arista(this, otroNodo, valor);
        }

        // ----------------------------------------------------------- Eventos para interactuar con nodo ----------------------------------------------------------

        public void Ctr_MouseClick(object sender, MouseEventArgs e)
        {
            if (Form1.estado == 4)//Agregar arista
            {
                if (Form1.Elegido)//Si ya existe un nodo elegido
                {
                    string valor = Interaction.InputBox("Ingrese el valor para la arista:", "Valor de la arista", "");//Pregunta por valor de la arista
                    Form1.ListaAristas.Add(Form1.nodo.Conectar(this, valor));
                    Form1.nodo.c = Color.Gold;
                    Form1.nodo.Dibujar();
                    //Form1.ListaAristas[Form1.ListaAristas.Count - 1].Dibujar(Form1.Pizarra.CreateGraphics());
                    Form1.Elegido = false;
                }
                else//Si no existe lo guardamos
                {
                    Form1.Elegido = true;
                    Form1.nodo = this;
                    c = Color.DeepSkyBlue;
                    Dibujar();
                }
            }
        }

        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(Form1.estado == 1)//Seleccionar
                {
                    down = true;
                    inicio = e.Location;
                    c = Color.DeepSkyBlue;//Cambia a color azul al ser seleccionado
                    Dibujar();
                }
                else if(Form1.estado == 3)//Eliminar
                {
                    List<Arista> aristasEliminar = Form1.ListaAristas.FindAll(a => a.Nodoinicio == this || a.Nodofin == this);//Busca todas las aristas conectadas al nodo
                    foreach (Arista a in aristasEliminar)//Elimina todas las aristas conectadas al nodo
                    {
                        Form1.ListaAristas.Remove(a);//Elimino todas las aristas que conectan al nodo
                    }
                    Form1.ListaNodos.Remove(this);//Lo saco de la lista de nodos
                    this.Dispose();//Destruyo el objeto
                }
            }
        }
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                this.Left = e.X + this.Left - inicio.X;
                this.Top = e.Y + this.Top - inicio.Y;
                centro.X = Location.X + radio;
                centro.Y = Location.Y + radio;
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e)
        {
            if(Form1.estado == 1)
            {
                down = false;
                c = Color.Gold;//Cambia a su color anterior
                Dibujar();
            }
        }

    }
}