using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class NodoG : Control, INodo
    {
        //Atributos
        private Point centro;// Coordenadas del centro del nodo
        public const int radio = 40; //Radio del círculo
        private static int cont = 0;
        private static NodoG? actual; //Guarda el nodo a conectar
        private bool down = false;//Indica si el nodo esta siendo arrastrado
        Pizarra pizarra;//Regresa la pizarra en la que esta

        //Atributos visuales
        private Color ColorFondo;//Color del nodo
        Pen pen; //Contorno del nodo
        Font font; //Estilo del nombre del nodo
        private Point inicio;

        //Metodos de la interfaz
        public string Nombre { get; set; }
        public bool Inicial { get; set; }
        public bool Final { get; set; }

        //------------------------------------------------------------- Metodos get y set ---------------------------------------------------------------------
        public Point Centro { get { return centro; } set { centro = value; } }

    //Metodos
        public NodoG(Point coordenada)
        {
            centro = coordenada;
            Nombre = "q" + cont; //Nombre consecutivo por defecto
            Inicial = false; //Establece el nodo como no inicial
            Final = true; //Establece el nodo como no final

            ColorFondo = Color.Gold;
            pen = new Pen(Color.Black, 4); //Contorno del nodo
            font = new Font("Arial", 12, FontStyle.Bold);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 2 * radio, 2 * radio);
            this.Region = new Region(path);
            this.Width = radio * 2;
            this.Height = radio * 2;
            this.Location = new Point(coordenada.X - radio, coordenada.Y - radio);

            //Suscripcion a eventos
            MouseDown += Ctr_MouseDown;
            MouseUp += Ctr_MouseUp;
            MouseMove += Ctr_MouseMove;
            MouseClick += Ctr_MouseClick;

            cont++;//Aumenta el contador del nombre
        }

        // --------------------------------------------------------- Metodos de la clase nodo -----------------------------------------------------------------

        public void Dibujar()//Dibuja el nodo
        {
            Bitmap png = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(png))
            {
                int ajuste = (int)(pen.Width / 2);
                Rectangle rec = new Rectangle(ajuste, ajuste, this.Width - ajuste*2, this.Height - ajuste*2);//Ajusto la imagen
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

                g.DrawEllipse(pen, rec);
                if(Final)
                {
                    // Falta dibujar el circulo de adentro
                    // g.DrawEllipse(new Pen(Color.Green, 8), );

                }
                g.FillEllipse(new SolidBrush(ColorFondo), rec);
                SizeF textSize = g.MeasureString(Nombre, font);
                g.DrawString(Nombre, font, Brushes.Black, (this.Width - textSize.Width) / 2, (this.Height - textSize.Width) / 2);
                BackgroundImage = png;//dibuja la imagen en el control
            }
        }

        // ----------------------------------------------------------- Eventos para interactuar con nodo ----------------------------------------------------------

        public void Ctr_MouseClick(object sender, MouseEventArgs e)
        {
            pizarra = Parent as Pizarra;
            if (pizarra._estado == 4)//Agregar arista
            {
                if (actual != null)//Si ya existe un nodo elegido
                {
                    string valor = Interaction.InputBox("Ingrese el valor para la arista:", "Valor de la arista", "");//Pregunta por valor de la arista

                    //Se crea una arista dependiendo el tipo
                    AristaG a = new AristaG(actual, this, valor);
                    pizarra._listaAristas.Add(a);//Agrego la nueva arista a la lista
                    actual.ColorFondo = Color.Gold;
                    actual.Dibujar();//Dibuja el nodo en su color original
                    pizarra.Invalidate();//Dibuja las aristas
                    actual = null;
                }
                else//Si no existe lo guardamos
                {
                    actual = this;
                    ColorFondo = Color.DeepSkyBlue;
                    Dibujar();
                }
            }
            else if (pizarra._estado == 3)//Eliminar
            {
                foreach (AristaG a in pizarra._listaAristas)//Elimina todas las aristas conectadas al nodo
                {
                    if (a.NodoInicio == this || a.NodoFinal == this)//Busca todas las aristas conectadas al nodo
                    {
                        pizarra._listaAristas.Remove(a);//Elimino todas las aristas que conectan al nodo
                    }
                }
                pizarra._listaNodos.Remove(this);//Saco el nodo de la lista de nodos
                pizarra.Controls.Remove(this);//Saca el nodo de la pizarra
                this.Dispose();//Destruyo el nodo
            }
        }

        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            pizarra = Parent as Pizarra;
            if (e.Button == MouseButtons.Left)
            {
                if (pizarra._estado == 1)//Seleccionar, arrastrar
                {
                    down = true;
                    inicio = e.Location;//Punto donde inicio a moverse
                    ColorFondo = Color.DeepSkyBlue;//Cambia a color azul al ser seleccionado
                    Dibujar();//Dibuja el nodo color azul
                }
            }
        }

        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            pizarra = Parent as Pizarra;
            if (down)
            {
                Cursor = Pizarra.Agarrar;//Cambia el cursor
                //Actualizo la posicion del control y del centro del nodo
                this.Left = e.X + this.Left - inicio.X;
                this.Top = e.Y + this.Top - inicio.Y;
                centro.X = Location.X + radio;
                centro.Y = Location.Y + radio;
                pizarra.Invalidate();
            }
            else if (pizarra._estado == 1)
            {
                Cursor = Cursors.Hand;
            }
            else if (pizarra._estado == 2)
            {
                Cursor = Cursors.No;
            }
            else if (pizarra._estado == 3)
            {
                Cursor = Pizarra.Eliminar;
            }
            else
            {
                Cursor=Cursors.Default;
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e)
        {
            pizarra = Parent as Pizarra;
            if (pizarra._estado == 1)
            {
                down = false;
                ColorFondo = Color.Gold;//Cambia a su color anterior
                Dibujar();
            }
        }

        protected override void OnPaint(PaintEventArgs e){}

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
    }
}
