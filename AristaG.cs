using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Proyecto_Automatas
{
    public class AristaG : IArista
    {
        //Atributos
        private NodoG n1;
        private NodoG n2;
        public short Tipo; //0 linea, 1 Arco, 2 Bucle

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

        protected AdjustableArrowCap flecha;


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
            flecha = new AdjustableArrowCap(grosor*3, grosor * 3);
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

        public bool EsIgual(AristaG otraArista)//Determina si dos aristas son iguales
        {
            if(otraArista == null) { return false; }
            else if(n1 == otraArista.n1 && n2 == otraArista.n2 && Valor == otraArista.Valor) return true;
            else return false; 
        }

        public void DibujarLinea(Graphics g)
        {
            //Variables
            int centerX;
            int centerY;
            double dx = n2.Centro.X - n1.Centro.X; //Diferencial de x
            double dy = n2.Centro.Y - n1.Centro.Y; //Diferencial de y
            double angle = Math.Atan2(dy, dx);//Angulo de la flecha en radianes
            int cos = (int)(NodoG.radio * Math.Cos(angle));
            int sen = (int)(NodoG.radio * Math.Sin(angle));

            // Calcular la posición inicial y final de la flecha
            int startX = n1.Centro.X - cos;
            int startY = n1.Centro.Y - sen;
            int endX = n2.Centro.X - cos;
            int endY = n2.Centro.Y - sen;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Mejora la calidad de imagen
            pen.StartCap = LineCap.Flat;
            pen.CustomEndCap = flecha; //Crea la cabeza de la flecha
            
            //Reseteo el path, le agrego la flecha y la dibujo
            path.Reset();
            path.AddLine(startX, startY, endX, endY);
            g.DrawPath(pen, path);

            // Calcular la posición para mostrar el valor en el medio de la arista
            centerX = (n1.Centro.X + n2.Centro.X) / 2;
            centerY = (n1.Centro.Y + n2.Centro.Y) / 2;

            /*//Calculo la rotacion de la arista
            Matrix originalTransform = g.Transform;//Guardo el estado de la pizarra
            g.TranslateTransform(centerX, centerY); // Mover al centro
            
            angle = (Math.PI / 2 < Math.Abs(angle) && Math.Abs(angle) < Math.PI) ? Math.PI - angle : angle;
            float nuevoang = (float)(angle * (180 / Math.PI));
            g.RotateTransform(nuevoang); // Rotar
            g.TranslateTransform(-centerX, -centerY); // Mover de regreso al origen
            */

            // Calcula las coordenadas del punto en la línea perpendicular
            dx = -1 * (n2.Centro.Y - n1.Centro.Y);
            dy = (n2.Centro.X - n1.Centro.X);
            double length = Math.Sqrt(dx * dx + dy * dy);// Calcula el vector perpendicular (en este caso, simplemente invierte las coordenadas x e y)
            dx = dx / length;
            dy = dy / length;

            SizeF textSize = g.MeasureString(Valor, font);
            int perpendicularX = (int)(centerX - (dx * textSize.Width));
            int perpendicularY = (int)(centerY - (dy * textSize.Height));

            RectangleF r = new RectangleF(perpendicularX - 2, perpendicularY - 2, textSize.Width, textSize.Height);
            g.DrawString(Valor, font, Brushes.Black, r);

            //g.Transform = originalTransform;//Regreso la pizarra a la normalidad
        }

        public void DibujarArco(Graphics g)
        {
            //Variables
            int altura = 50; //Altura del arco
            double dx = n2.Centro.X - n1.Centro.X; //Diferencial de x
            double dy = n2.Centro.Y - n1.Centro.Y; //Diferencial de y
            double angle = Math.Atan2(dy, dx);//Angulo de la flecha en radianes
            int cos = (int)(NodoG.radio * Math.Cos(angle));
            int sen = (int)(NodoG.radio * Math.Sin(angle));

            // Calcular la posición inicial y final de la flecha
            Point start = new Point(n1.Centro.X - cos, n1.Centro.Y - sen);
            Point end = new Point(n2.Centro.X - cos, n2.Centro.Y - sen);

            // Calcula las coordenadas del punto en la línea perpendicular
            dx = -1 * (n2.Centro.Y - n1.Centro.Y);
            dy = (n2.Centro.X - n1.Centro.X);
            double length = Math.Sqrt(dx * dx + dy * dy);//Distancia entre el primer y segundo nodo
            dx = dx / length;
            dy = dy / length;

            // Calcular la posición de la mitad de la arista
            Point medio = new Point((n1.Centro.X + n2.Centro.X) / 2, (n1.Centro.Y + n2.Centro.Y) / 2 - altura);

            SizeF textSize = g.MeasureString(Valor, font);
            int perpendicularX = (int)(medio.X - (dx * textSize.Width));
            int perpendicularY = (int)(medio.Y - (dy * textSize.Height));
            
            //Dubujo de la arista

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = LineCap.Flat;
            pen.CustomEndCap = flecha; //Crea la cabeza de la flecha

            // Dibujar la arista arqueada
            path.Reset();
            path.AddBezier(n1.Centro, medio, medio, end);

            g.DrawPath(pen, path);
            
            RectangleF r = new RectangleF(perpendicularX - 2, perpendicularY - 2, textSize.Width, textSize.Height);
            g.DrawString(Valor, font, Brushes.Black, r);
        }

        public void DibujarBucle(Graphics g)
        {
            //Variables
            int altura = n1.Location.Y - (int)(NodoG.radio * 1.4);  // Ajusta el tamaño del bucle
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;///Mejora la calidad de la imagen
            pen.CustomStartCap = flecha;
            pen.EndCap = LineCap.Flat; //Crea la cabeza de la flecha

            // Dibujar un arco curvado
            path.Reset();
            Rectangle r = new Rectangle(n1.Location.X, altura, NodoG.radio * 2, NodoG.radio * 2);
            path.AddArc(r, 135, 270);

            g.DrawPath(pen, path);

            // Dibujar el valor en el medio de la arista
            SizeF textSize = g.MeasureString(Valor, font);
            g.DrawString(Valor, font, Brushes.Black, n1.Centro.X - (textSize.Width / 2), altura - font.Size * 2);
        }

        public bool EstaDentro(Point click)
        {
            //La tolerancia es el segundo valor de la pluma (pen)
            return path.IsOutlineVisible(click, new Pen(Color.Black, 10));
        }
    }
}
