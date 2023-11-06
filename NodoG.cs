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
        public static int radio = 30; //Radio del círculo
        private static int cont = 0; //Contador de nodos
        private bool arrastrando = false;//Indica si el nodo esta siendo arrastrado
        
        //Atributos visuales
        private Color ColorFondo;//Color del nodo
        private Pen pen; //Contorno del nodo
        private Point inicio; //Punto donde empezo a moverse el nodo

        //------------------------------------------------------------- Metodos get y set ---------------------------------------------------------------------
        //Metodos de la interfaz
        public string Nombre { get; set; }
        public bool Final { get; set; }

        //Metodos de la clase NodoG
        public Point Centro { get { return centro; } set { centro = value; } }
        public Pizarra pizarra { get; set; } //Guarda la pizarra en la que esta el nodo
        public static NodoG? conectar { get; set; } //Guarda el nodo a conectar

        // -------------------------------------------------------------- Metodos de la clase NodoG ----------------------------------------------------------------
        public NodoG(Point coordenada) //Constructor
        {
            centro = coordenada;
            Nombre = "q" + cont; //Nombre consecutivo por defecto
            Final = false; //Establece el nodo como no final
            cont++;//Aumenta el contador del nombre

            ColorFondo = Color.Gold;//Agrega el  color por defecto
            pen = new Pen(Color.Black, 3); //Contorno del nodo
            Font = new Font("Arial", 12, FontStyle.Bold);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 2 * radio, 2 * radio);
            this.Region = new Region(path);
            this.Width = radio * 2;
            this.Height = radio * 2;
            this.Location = new Point(coordenada.X - radio, coordenada.Y - radio);
            Dibujar();

            //Suscripcion a eventos
            MouseDown += Ctr_MouseDown;
            MouseUp += Ctr_MouseUp;
            MouseMove += Ctr_MouseMove;
            MouseClick += Ctr_MouseClick;
        }

        public void Eliminar()
        {
            pizarra._listaAristas.RemoveAll(a => a.NodoInicio == this || a.NodoFinal == this);//Elimino todas las aristas que conectan al nodo
            if (this == pizarra.NodoInicial) pizarra.NodoInicial = null;//Si es inicial lo quita de NodoInicial
            pizarra._listaNodos.Remove(this);//Saco el nodo de la lista de nodos
            pizarra.Controls.Remove(this);//Saca el nodo de la pizarra
            pizarra.Invalidate();//Vuelve a dibujar las aristas que si estan en la pizarra
            this.Dispose();//Libero recursos del nodo
        }

        // ----------------------------------------------------------- Eventos para interactuar con un nodo ----------------------------------------------------------
        public void Ctr_MouseClick(object? sender, MouseEventArgs e)
        {
            if (pizarra._estado == 4)//Agregar arista
            {
                if (conectar != null)//Si ya existe un nodo elegido
                {
                    AristaG? Existe = null;//Guarda si ya existe la arista
                    string valor = Interaction.InputBox("Ingrese el valor para la arista:", "Valor de la arista", "λ");//Pregunta por valor de la arista
                    valor = string.IsNullOrWhiteSpace(valor)? "λ" : valor;

                    //Se crea una arista
                    foreach(AristaG a in pizarra._listaAristas) //Busca si la arista ya existe en la lista
                    {
                        if (a.NodoInicio == conectar && a.NodoFinal == this)
                        {
                            Existe = a;
                            break;
                        }

                    }
                    
                    if (Existe is null) //Si no existe arista entonces crea una nueva
                    {
                        AristaG nuevaarista = new AristaG(conectar, this, valor);
                        pizarra._listaAristas.Add(nuevaarista);
                        foreach (AristaG a in pizarra._listaAristas)
                        {
                            if (a != nuevaarista && a.NodoInicio == nuevaarista.NodoFinal && nuevaarista.NodoInicio == a.NodoFinal)//convierte las lineas en arcos
                            {
                                nuevaarista.Tipo = 1;
                                a.Tipo = 1;
                            }
                        }
                    }
                    else //Si ya existe agrega el nuevo valor
                    {
                        Existe.AgregarValor(valor);
                    }

                    conectar.Dibujar(ColorFondo);//Dibuja el nodo en su color original
                    pizarra.Invalidate();//Dibuja las aristas
                    conectar = null;
                }
                else//Si no existe lo guardamos
                {
                    conectar = this;
                    conectar.Dibujar(Color.DeepSkyBlue);//Dibuja el nodo de color azul
                }
            }
        }

        private void Ctr_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//Click izquierdo
            {
                if (pizarra._estado == 1)//Seleccionar, arrastrar
                {
                    arrastrando = true;
                    inicio = e.Location;//Punto donde inicio a moverse
                    Dibujar(Color.DeepSkyBlue);//Dibuja el nodo color azul
                }
                else if (pizarra._estado == 2) Cursor = Cursors.No; // No se puede agregar un nodo sobre otro
            }
            else//Click derecho
            {
                // Crea un nuevo menú contextual
                ContextMenuStrip contextMenu = new MenuCNodo(this); //Menu contextual del nodo
                this.ContextMenuStrip = contextMenu;// Asocia el menú contextual al nodo (por ejemplo, un formulario)
            }
        }

        private void Ctr_MouseMove(object? sender, MouseEventArgs e)//El nodo se esta arrastrando
        {
            if (arrastrando)
            {
                Cursor = Pizarra.Agarrar;//Cambia el cursor
                //Actualizo la posicion del control y del centro del nodo
                this.Left = e.X + this.Left - inicio.X;
                this.Top = e.Y + this.Top - inicio.Y;
                centro.X = Location.X + radio;
                centro.Y = Location.Y + radio;
                pizarra.Invalidate();
            }
            else if (pizarra._estado == 1) Cursor = Cursors.Hand;
            else if (pizarra._estado == 3) Cursor = Pizarra.Eliminar;
            else Cursor = Cursors.Default;
        }

        private void Ctr_MouseUp(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)//Verifica si es el click derecho
            {
                if (pizarra._estado == 1)//Se dejo de arrastrar
                {
                    arrastrando = false;
                    this.Dibujar(ColorFondo);//Cambia a su color anterior
                }
                else if (pizarra._estado == 3) Eliminar(); //Eliminar nodo
            }
        }

        //------------------------------------------------------------- Metodos de dibujo -------------------------------------------------------------------------

        #region Dibujo
        public void Dibujar()//Dibuja el nodo
        {
            Bitmap png = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(png))
            {
                int ajuste = (int)(pen.Width / 2) + 1;
                Rectangle rec = new Rectangle(ajuste, ajuste, this.Width - ajuste * 2, this.Height - ajuste * 2);//Ajusto la imagen

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.FillEllipse(new SolidBrush(ColorFondo), rec);
                g.DrawEllipse(pen, rec);


                if (Final)//Se dibuja un circulo interno si es nodo final
                {
                    int d = ajuste + ajuste / 2 + 3;
                    rec.X += d;
                    rec.Y += d;
                    rec.Width -= d * 2;
                    rec.Height -= d * 2;
                    g.DrawEllipse(new Pen(pen.Color, ajuste), rec);
                }

                SizeF textSize = g.MeasureString(Nombre, Font);
                g.DrawString(Nombre, Font, Brushes.Black, (this.Width - textSize.Width) / 2, (this.Height / 2) - Font.Size);
                BackgroundImage = png;//dibuja la imagen en el control
            }
        }

        public void Dibujar(Color select)//Dibuja el nodo seleccionado
        {
            Bitmap png = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(png))
            {
                int ajuste = (int)(pen.Width / 2) + 1;
                Rectangle rec = new Rectangle(ajuste, ajuste, this.Width - ajuste * 2, this.Height - ajuste * 2);//Ajusto la imagen

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.FillEllipse(new SolidBrush(select), rec);
                g.DrawEllipse(pen, rec);


                if (Final)//Se dibuja un circulo interno si es nodo final
                {
                    int d = ajuste + ajuste / 2 + 3;
                    rec.X += d;
                    rec.Y += d;
                    rec.Width -= d * 2;
                    rec.Height -= d * 2;
                    g.DrawEllipse(new Pen(pen.Color, ajuste), rec);
                }

                SizeF textSize = g.MeasureString(Nombre, Font);
                g.DrawString(Nombre, Font, Brushes.Black, (this.Width - textSize.Width) / 2, (this.Height / 2) - Font.Size);
                BackgroundImage = png;//dibuja la imagen en el control
            }
        }

        protected override void OnPaint(PaintEventArgs e) { }

        protected override CreateParams CreateParams//Sirve para que no se dibuje el fondo del nodo en la pizarra
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        #endregion
    }
}
