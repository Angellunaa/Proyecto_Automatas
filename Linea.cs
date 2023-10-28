using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public class Linea : AristaG
    {
        //Atributos
        NodoG n1;
        NodoG n2;
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
        public string Valor { get; set; }

        public Linea(NodoG nodoinicial, NodoG nodofinal, string valor) : base(nodoinicial, nodofinal, valor)
        {
            //Medidas del control
            n1 = nodoinicial;
            n2 = nodofinal;

            Mover(Point.Empty);
            BackColor = Color.Green;
            //Dibujar();
        }

        public override void Dibujar()
        {
            Bitmap png = new Bitmap(Width, Height);
            using (var pen = new Pen(Color.Black, 2))
            using (var g = Graphics.FromImage(png))
            {
                g.DrawLine(pen, n1.Right, n1.Bottom, this.Left, this.Top);
                g.DrawLine(pen, this.Right, this.Bottom, n2.Left, n2.Top);
            }
            BackgroundImage = png;
            /*//Variables
            int endX;
            int endY;
            int centerX;
            int centerY;
            double angle;
            double arrowAngle = Math.PI / 6;  // Ángulo de la flecha
            int arrowLength = 10;  // Tamaño de la flecha
            Pen pen = new Pen(Color.Black, 2);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Calcular el ángulo y la posición de la flecha

            angle = Math.Atan2(n2.Centro.Y - n1.Centro.Y, n2.Centro.X - n1.Centro.X);

            // Calcular la posición del final de la flecha
            endX = (int)(n2.Centro.X - (NodoG.radio * Math.Cos(angle)));
            endY = (int)(n2.Centro.Y - (NodoG.radio * Math.Sin(angle)));

            // Dibujar la línea de la arista
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            if (n1 != n2)
            {
                path.Reset();
                path.AddLine(n1.Centro.X, n1.Centro.Y, endX, endY);
                g.DrawPath(pen, path);
                // Calcular la posición para mostrar el valor en el medio de la arista
                centerX = (n1.Centro.X + endX) / 2;
                centerY = (n1.Centro.Y + endY) / 2 - 15;
            }
            else
            {
                // Si es un bucle, dibujar un arco curvado
                int controlPointOffset = NodoG.radio * 3;  // Ajusta el tamaño del bucle
                Point control = new Point(n1.Centro.X + controlPointOffset, n1.Centro.Y - controlPointOffset);
                path.Reset();
                path.AddBezier(n1.Centro.X, n1.Centro.Y, control.X, control.Y, n1.Centro.X - controlPointOffset, control.Y, n1.Centro.X, n1.Centro.Y);
                g.DrawPath(pen, path);
                centerX = n1.Centro.X;
                centerY = control.Y + 20;
            }

            // Calcular las coordenadas de los puntos de la flecha
            Point[] arrowPoints = new Point[]
            {
            new Point(endX, endY),
            new Point((int)(endX - arrowLength * Math.Cos(angle - arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle - arrowAngle))),
            new Point((int)(endX - arrowLength * Math.Cos(angle + arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle + arrowAngle)))
            };

            // Dibujar la cabeza de flecha
            g.FillPolygon(Brushes.Black, arrowPoints);

            // Dibujar el valor en el medio de la arista
            Font font = new Font("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString(Valor, font);
            g.DrawString(Valor, font, Brushes.Black, centerX - textSize.Width / 2, centerY - textSize.Height / 2);*/
        }

        public override void Mover(Point point)
        {
            // Calculamos la posición intermedia entre los dos nodos
            double angle = Math.Atan2(n2.Top - n1.Top, n2.Left - n1.Left);//Calcula el angulo de la arista
            double distance = Math.Sqrt(Math.Pow(n2.Left - n1.Left, 2) + Math.Pow(n2.Top - n1.Top, 2));
            Width = (int)distance;//Anchura del bucle
            Height = (int)distance;
            double newX = n1.Left + (distance / 2) * Math.Cos(angle);
            double newY = n1.Top + (distance / 2) * Math.Sin(angle);
            this.Location = new Point((int)newX, (int)newY);
        }
    } 
}
