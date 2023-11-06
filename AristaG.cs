using Microsoft.VisualBasic.Devices;
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
using static System.Windows.Forms.DataFormats;

namespace Proyecto_Automatas
{
    public class AristaG : IArista
    {
        //Atributos
        private NodoG n1;
        private NodoG n2;
        HashSet<string> valores = new HashSet<string>();
        public short Tipo; //0 linea, 1 Arco, 2 Bucle

        //Metodos de la interface
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
        public HashSet<string> Valores { get { return valores; } set { value = valores; } }

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
            this.Valores.Add(valor);
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

            if(n1 == n2) Tipo = 2;//Bucle
            else Tipo = 0;//Linea
        }

        public bool EsIgual(AristaG otraArista)//Determina si dos aristas tienen nodo inicial y final igual
        {
            if(otraArista == null) { return false; }
            else if(n1 == otraArista.n1 && n2 == otraArista.n2) return true;
            else return false; 
        }

        public bool EstaDentro(Point click)//Determina si se hace un clic sobre la arista
        {
            //La tolerancia es el segundo valor de la pluma (pen)
            return path.IsOutlineVisible(click, new Pen(Color.Black, 10));
        }

        //------------------------------------------------------------- Metodos de dibujo -------------------------------------------------------------------------

        public void DibujarLinea(Graphics g)//Dibuja una arista con forma lineal
        {
            Point medio = new Point((n1.Centro.X + n2.Centro.X) / 2, (n1.Centro.Y + n2.Centro.Y) / 2);// Calcular la posición en el medio de la arista
            double dx = n2.Centro.X - n1.Centro.X; //Diferencial de x
            double dy = n2.Centro.Y - n1.Centro.Y; //Diferencial de y
            double length = Math.Sqrt(dx * dx + dy * dy); //Calcula la distancia entre el nodo inicial y el final
            double angle = Math.Atan2(dy, dx); //Angulo de la flecha en radianes
            int cos = (int)(NodoG.radio * Math.Cos(angle));
            int sen = (int)(NodoG.radio * Math.Sin(angle));

            // Calcular la posición inicial y final de la flecha
            Point start = new Point(n1.Centro.X + cos, n1.Centro.Y + sen);
            Point end = new Point(n2.Centro.X - cos, n2.Centro.Y - sen);

            //Reseteo el path, le agrego la flecha y la dibujo
            pen.StartCap = LineCap.Flat; //indica como sera el inicio de la linea
            pen.CustomEndCap = flecha; //Crea la cabeza de la flecha

            path.Reset();
            path.AddLine(start.X, start.Y, end.X, end.Y);
            g.DrawPath(pen, path);

            // Calcula las coordenadas del punto en la línea perpendicular
            dx = -1 * dy;
            dy = n2.Centro.X - n1.Centro.X;
            dx = dx / length;
            dy = dy / length;

            //Angulo de la palabra
            float nuevoangulo = ((angle>=-Math.PI && angle < -Math.PI/2) || (angle >= Math.PI / 2 && angle <= Math.PI)) ? (float)(-Math.PI + angle) : (float)angle;
            nuevoangulo = (float)(nuevoangulo * (180 / Math.PI));//Convierto el angulo a grados
            int sep = 24; //Separacion entre cada palabra
            float sepin = font.Size; //Separacion entre la linea y primer valor
            StringFormat Formato = new StringFormat();//Formate de la cadena
            Formato.Alignment = StringAlignment.Center; //Alinea en el centro horizontal
            Formato.LineAlignment = StringAlignment.Center; //Alinea en el centro vertical

            //Dibujo de los valores de la arista
            for (int i = 0; i < valores.Count; i++)
            {
                string v = valores.ElementAt(i);
                g.TranslateTransform((float)(medio.X - dx * (sep * i + sepin)), (float)(medio.Y - dy * (sep * i + sepin)));
                g.RotateTransform((float)nuevoangulo);
                g.DrawString(v, font, Brushes.Black, Point.Empty, Formato);
                g.ResetTransform();
            }
        }

        public void DibujarArco(Graphics g)//Dibuja una arista con forma de arco
        {
            int altura = 40;//Altura del arco
            Point medio = new Point((n1.Centro.X + n2.Centro.X) / 2, (n1.Centro.Y + n2.Centro.Y) / 2);// Calcular la posición en el medio de la arista
            double dx = n2.Centro.X - n1.Centro.X; //Diferencial de x
            double dy = n2.Centro.Y - n1.Centro.Y; //Diferencial de y
            double length = Math.Sqrt(dx * dx + dy * dy); //Calcula la distancia entre el nodo inicial y el final
            double angle = Math.Atan2(dy, dx); //Angulo de la flecha en radianes
            int cos = (int)(NodoG.radio * Math.Cos(angle));
            int sen = (int)(NodoG.radio * Math.Sin(angle));

            // Calcular la posición inicial y final de la flecha
            //Point start = new Point(n1.Centro.X + cos, n1.Centro.Y + sen);
            Point end = new Point(n2.Centro.X - cos, n2.Centro.Y - sen);

            // Calcula las coordenadas del punto en la línea perpendicular
            dx = -1 * dy;
            dy = n2.Centro.X - n1.Centro.X;
            dx = dx / length;
            dy = dy / length;

            //Dibujo de arista
            pen.StartCap = LineCap.Flat; //indica como sera el inicio de la linea
            pen.CustomEndCap = flecha; //Crea la cabeza de la flecha

            Point perpendicular = new Point((int)(medio.X - dx * altura), (int)(medio.Y - dy * altura));//Punto mas alto de la arista
            path.Reset();//Reseteo el path
            path.AddBezier(n1.Centro, perpendicular, perpendicular, end);
            g.DrawPath(pen, path);//Dibujo la arista

            //Angulo de la palabra
            float nuevoangulo = ((angle >= -Math.PI && angle < -Math.PI / 2) || (angle >= Math.PI / 2 && angle <= Math.PI)) ? (float)(-Math.PI + angle) : (float)angle;
            nuevoangulo = (float)(nuevoangulo * (180 / Math.PI));//Convierto el angulo a grados
            int sep = 24; //Separacion entre cada palabra
            StringFormat Formato = new StringFormat();//Formate de la cadena
            Formato.Alignment = StringAlignment.Center; //Alinea en el centro horizontal
            Formato.LineAlignment = StringAlignment.Center; //Alinea en el centro vertical

            //Diubujo de los valores de la arista
            for (int i = 0; i < valores.Count; i++)
            {
                string v = valores.ElementAt(i);
                g.TranslateTransform((float)(medio.X - dx * (altura + sep * i)), (float)(medio.Y - dy * (altura + sep * i)));
                g.RotateTransform((float)nuevoangulo);
                g.DrawString(v, font, Brushes.Black, Point.Empty, Formato);
                g.ResetTransform();
            }
        }

        public void DibujarBucle(Graphics g)//Dibuja una arista con forma de bucle
        {
            int altura = n1.Location.Y - (int)(NodoG.radio * 1.4);  // Ajusta el tamaño del bucle

            // Dibujar un arco curvado
            pen.CustomStartCap = flecha;
            pen.EndCap = LineCap.Flat; //Crea la cabeza de la flecha
            path.Reset();
            Rectangle r = new Rectangle(n1.Location.X, altura, NodoG.radio * 2, NodoG.radio * 2);
            path.AddArc(r, 135, 270);

            g.DrawPath(pen, path);

            // Dibujar los valores en el medio de la arista
            for(int i = 0; i < valores.Count; i++)
            {
                string v = valores.ElementAt(i);
                SizeF textSize = g.MeasureString(v, font);
                g.DrawString(v, font, Brushes.Black, n1.Centro.X - (textSize.Width / 2), altura - textSize.Height * (i + 1));
            }
        }
    }
}
