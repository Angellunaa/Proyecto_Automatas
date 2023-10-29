using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public class AristaG : IArista
    {
        //Atributos
        private NodoG n1;
        private NodoG n2;
        public short Tipo; //0

        //Metodos de la interface
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
        public string Valor { get; set; }
        //Atributos graficos
        protected GraphicsPath path { get; set; }
        protected Pen pen { get; set; }
        protected Font font { get; set; }
        protected Color color { get; set; }
        protected int grosor { get; set; }
        protected string familiafuente { get; set; }
        protected int tamletra { get; set; }


        public AristaG(NodoG nodoinicial, NodoG nodofinal, string valor)
        {
            this.NodoInicio = nodoinicial;
            this.NodoFinal = nodofinal;
            this.Valor = valor;
            grosor = 2;
            color = Color.Black;
            familiafuente = "Arial";
            tamletra = 12;

            path = new GraphicsPath();
            pen = new Pen(color, grosor);
            font = new Font(familiafuente, tamletra);
            n1 = nodoinicial;
            n2 = nodofinal;

            if(n1 != n2)
            {
                Tipo = 0;
            }
            else
            {
                Tipo = 3;
            }
        }

        public void DibujarLinea(Graphics g)
        {
            //Variables
            int endX;
            int endY;
            int centerX;
            int centerY;
            double angle = Math.Atan2(n2.Centro.Y - n1.Centro.Y, n2.Centro.X - n1.Centro.X);
            double arrowAngle = Math.PI / 6;  // Ángulo de la cabeza de la flecha
            int arrowLength = 10;  // Tamaño de la cabeza de la flecha

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calcular la posición del final de la flecha
            endX = (int)(n2.Centro.X - (NodoG.radio * Math.Cos(angle)));
            endY = (int)(n2.Centro.Y - (NodoG.radio * Math.Sin(angle)));

            // Guarda la linea de la flecha
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            path.Reset();
            path.AddLine(n1.Centro.X, n1.Centro.Y, endX, endY);

            // Calcular las coordenadas de los puntos de la flecha
            Point[] arrowPoints = new Point[]
            {
            new Point(endX, endY),
            new Point((int)(endX - arrowLength * Math.Cos(angle - arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle - arrowAngle))),
            new Point((int)(endX - arrowLength * Math.Cos(angle + arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle + arrowAngle)))
            };

            // Dibujar la flecha
            path.AddPolygon(arrowPoints);
            g.DrawPath(pen, path);
            g.FillPolygon(Brushes.Black, arrowPoints);

            // Calcular la posición para mostrar el valor en el medio de la arista
            centerX = (n1.Centro.X + endX) / 2;
            centerY = (n1.Centro.Y + endY) / 2 - 15;

            // Dibujar el valor en el medio de la arista
            g.DrawString(Valor, font, Brushes.Black, centerX - font.Size / 2, centerY - font.Size / 2);
        }

        public void DibujarBucle(Graphics g)
        {
            //Variables
            int endX;
            int endY;
            double angle = Math.PI / 3.5;
            double arrowAngle = Math.PI / 6;  // Ángulo de la flecha
            int arrowLength = 10;  // Tamaño de la cabeza de la flecha

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calcular la posición del final de la flecha
            endX = (int)(n2.Centro.X - (NodoG.radio * Math.Cos(angle)));
            endY = (int)(n2.Centro.Y - (NodoG.radio * Math.Sin(angle)));

            // Dibujar la línea de la arista
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            // Si es un bucle, dibujar un arco curvado
            int controlPointOffset = NodoG.radio * 3;  // Ajusta el tamaño del bucle
            Point control = new Point(n1.Centro.X + controlPointOffset, n1.Centro.Y - controlPointOffset);

            path.Reset();
            path.AddBezier(n1.Centro.X, n1.Centro.Y, control.X, control.Y, n1.Centro.X - controlPointOffset, control.Y, n1.Centro.X, n1.Centro.Y);

            // Calcular las coordenadas de los puntos de la flecha
            Point[] arrowPoints = new Point[]
            {
            new Point(endX, endY),
            new Point((int)(endX - arrowLength * Math.Cos(angle - arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle - arrowAngle))),
            new Point((int)(endX - arrowLength * Math.Cos(angle + arrowAngle)), (int)(endY - arrowLength * Math.Sin(angle + arrowAngle)))
            };

            // Dibujar la flecha
            path.AddPolygon(arrowPoints);
            g.DrawPath(pen, path);
            g.FillPolygon(Brushes.Black, arrowPoints);

            // Dibujar el valor en el medio de la arista
            g.DrawString(Valor, font, Brushes.Black, n1.Centro.X - font.Size / 2, control.Y + 25 - font.Size / 2);
        }

        public bool EstaDentro(Point click)
        {
            //La tolerancia es el segundo valor de la pluma (pen)
            return path.IsOutlineVisible(click, new Pen(Color.Black, 10));
        }
    }
}
