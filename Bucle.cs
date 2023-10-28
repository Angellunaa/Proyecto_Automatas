using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class Bucle : AristaG
    {
        public Bucle(NodoG nodo, string valor) : base(nodo, valor)
        {
            Height = NodoG.radio * 3;//altura del bucle
            Width = NodoG.radio * 2;//Anchura del bucle
            Dibujar();

            //Suscripcion a evento
            MouseClick += Bucle_MouseClick;
        }

        public override void Dibujar()
        {
            //variables
            int endX;
            int endY;
            double angle = Math.PI / 3.5;
            double arrowAngle = Math.PI / 4;  // Ángulo de la flecha
            int arrowLength = 10;

            Bitmap png = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(png))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

                // Calcular la posición del final de la flecha
                endX = (int)(NodoG.radio - (NodoG.radio * Math.Cos(angle)));
                endY = (int)(this.Height - (NodoG.radio * Math.Sin(angle)));

                int control = NodoG.radio + this.Height;

                // Agregar la curva de Bézier cúbica al Path

                path.AddBezier(NodoG.radio, this.Height, control, 0, NodoG.radio - this.Height, 0, NodoG.radio, this.Height);
                g.DrawBezier(pen, NodoG.radio, this.Height, control, 0, NodoG.radio - this.Height, 0, NodoG.radio, this.Height);

                // Calcular las coordenadas de los puntos de la flecha
                Point[] arrowPoints = new Point[]
                {
                    new Point(endX, endY),
                    new Point((int)(endX - arrowLength * Math.Cos(angle - arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle - arrowAngle))),
                    new Point((int)(endX - arrowLength * Math.Cos(angle + arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle + arrowAngle)))
                };

                // Dibujo la cabeza de la flecha
                path.AddPolygon(arrowPoints);
                g.FillPolygon(Brushes.Black, arrowPoints);

                //Dibujo el valor de la arista
                g.DrawString(Valor, font, Brushes.Black, (float)(NodoG.radio - font.Size), (float)(font.Size / 2));
            }

            BackgroundImage = png;//dibuja la imagen en el control
        }

        public override void Mover(Point point)
        {
            Location = new Point(point.X - NodoG.radio, point.Y - Height);
        }

        public void Bucle_MouseClick(object sender, MouseEventArgs e)
        {
            Pizarra pizarra = Parent as Pizarra;
            if(pizarra._estado == 3 && EstaDentro(e.Location))
            {
                pizarra._listaAristas.Remove(this);
                pizarra.Controls.Remove(this);
                this.Dispose();
            }
        }

        public bool EstaDentro(Point click)
        {
            int tolerancia = 10;
            return path.IsOutlineVisible(click, new Pen(Color.Black, tolerancia));
        }
    }
}
