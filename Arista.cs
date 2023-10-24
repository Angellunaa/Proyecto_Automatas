using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public class Arista
    {
        //Atributos
        private Nodo n1;
        private Nodo n2;
        private string valor;
        private GraphicsPath path = new GraphicsPath();

        public Arista(Nodo n1, Nodo n2, string valor)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.valor = valor;
        }

        //Metodos get y set
        public Nodo Nodoinicio { get { return n1; } }
        public Nodo Nodofin { get { return n2; } }

        public void Dibujar(Graphics g)
        {
            //Variables
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
            
            if (n1 != n2)
            {
                angle = Math.Atan2(n2.Centro.Y - n1.Centro.Y, n2.Centro.X - n1.Centro.X);
            }
            else// Si es un bucle, apuntar hacia el nodo desde un ángulo
            {
                angle = Math.PI / 3.5;
            }

            // Calcular la posición del final de la flecha
            endX = (int)(n2.Centro.X - (Nodo.radio * Math.Cos(angle)));
            endY = (int)(n2.Centro.Y - (Nodo.radio * Math.Sin(angle)));

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
                int controlPointOffset = Nodo.radio * 3;  // Ajusta el tamaño del bucle
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
            SizeF textSize = g.MeasureString(valor, font);
            g.DrawString(valor, font, Brushes.Black, centerX - textSize.Width / 2, centerY - textSize.Height / 2);
        }

        public bool EstaDentro(Point click)
        {
            int tolerancia = 10;
            if (n1 != n2)
            {
                return path.IsOutlineVisible(click, new Pen(Color.Black, tolerancia));
            }
            else
            {
                return path.IsOutlineVisible(click, new Pen(Color.Black, tolerancia));
            }
        }
    }
}
