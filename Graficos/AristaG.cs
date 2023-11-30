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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.DataFormats;

namespace Proyecto_Automatas.Graficos
{
    public class AristaG : IArista
    {
        //Atributos
        private readonly NodoG n1;
        private readonly NodoG n2;
        private HashSet<string> valores = new HashSet<string>();
        public short Tipo; //0 linea, 1 Arco, 2 Bucle

        //Atributos graficos
        public List<GraphicsPath> path { get; set; }
        private Pen pen;
        private Font font;
        private Color color;
        private int grosor;
        private string familiafuente;
        private int tamletra;
        private AdjustableArrowCap flecha;

        //Metodos de la interface
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }

        //Metodos Get y Set

        public HashSet<string> Valores { get { return valores; }}

        public AristaG(NodoG nodoinicial, NodoG nodofinal, string valor)
        {
            NodoInicio = nodoinicial;
            NodoFinal = nodofinal;
            valores.Add(valor);
            grosor = 2;
            color = Color.Black;
            familiafuente = "Arial";
            tamletra = 12;

            path = new List<GraphicsPath>() { new GraphicsPath(), new GraphicsPath() };
            pen = new Pen(color, grosor);
            flecha = new AdjustableArrowCap(grosor * 3, grosor * 3);
            font = new Font(familiafuente, tamletra);
            n1 = nodoinicial;
            n2 = nodofinal;

            if (n1 == n2) Tipo = 2;//Bucle
            else Tipo = 0;//Linea
        }

        public int EstaDentro(Point click)//Determina si se hace un clic sobre la arista
        {
            for (int i = 0; i < path.Count; i++)
            {
                //La tolerancia es el segundo valor de la pluma (pen)
                if (path.ElementAt(i).IsOutlineVisible(click, new Pen(Color.Black, 10)))
                {
                    return i;
                }
            }
            return -1;
        }

        public void AgregarValor(string valor)
        {
            valores.Add(valor);
            path.Add(new GraphicsPath());
        }

        public void Eliminar(int val)
        {
            if (val == 0 || val == 1)
            {
                path.RemoveAt(1);//Elimino el path y el valor
                valores.Remove(valores.ElementAt(0));
            }
            else
            {
                path.RemoveAt(val);
                valores.Remove(valores.ElementAt(val - 1));
            }
            if (path.Count == 1)//Si ya no hay valores elimino toda la arista
            {
                path.RemoveAt(0);
            }
        }

        //------------------------------------------------------------- Metodos de dibujo -------------------------------------------------------------------------
        #region Dibujo

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

            path.ElementAt(0).Reset();
            path.ElementAt(0).AddLine(start.X, start.Y, end.X, end.Y);
            g.DrawPath(pen, path.ElementAt(0));

            // Calcula las coordenadas del punto en la línea perpendicular
            dx = -1 * dy;
            dy = n2.Centro.X - n1.Centro.X;
            dx = dx / length;
            dy = dy / length;

            //Angulo de la palabra
            float nuevoangulo = angle >= -Math.PI && angle < -Math.PI / 2 || angle >= Math.PI / 2 && angle <= Math.PI ? (float)(-Math.PI + angle) : (float)angle;
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
                v = v.Replace('ǁ',',');
                PointF punto = new PointF((float)(medio.X - dx * (sep * i + sepin)), (float)(medio.Y - dy * (sep * i + sepin)));
                g.TranslateTransform(punto.X, punto.Y);
                g.RotateTransform(nuevoangulo);
                g.DrawString(v, font, Brushes.Black, Point.Empty, Formato);
                path.ElementAt(i + 1).Reset();
                path.ElementAt(i + 1).AddString(v, font.FontFamily, 0, font.Size, punto, Formato);
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
            path.ElementAt(0).Reset();//Reseteo el path
            path.ElementAt(0).AddBezier(n1.Centro, perpendicular, perpendicular, end);
            g.DrawPath(pen, path.ElementAt(0));//Dibujo la arista

            //Angulo de la palabra
            float nuevoangulo = angle >= -Math.PI && angle < -Math.PI / 2 || angle >= Math.PI / 2 && angle <= Math.PI ? (float)(-Math.PI + angle) : (float)angle;
            nuevoangulo = (float)(nuevoangulo * (180 / Math.PI));//Convierto el angulo a grados
            int sep = 24; //Separacion entre cada palabra
            StringFormat Formato = new StringFormat();//Formate de la cadena
            Formato.Alignment = StringAlignment.Center; //Alinea en el centro horizontal
            Formato.LineAlignment = StringAlignment.Center; //Alinea en el centro vertical

            //Diubujo de los valores de la arista
            for (int i = 0; i < valores.Count; i++)
            {
                string v = valores.ElementAt(i);
                v = v.Replace('ǁ', ',');
                PointF punto = new PointF((float)(medio.X - dx * (altura + sep * i)), (float)(medio.Y - dy * (altura + sep * i)));
                g.TranslateTransform(punto.X, punto.Y);
                g.RotateTransform(nuevoangulo);
                g.DrawString(v, font, Brushes.Black, Point.Empty, Formato);
                path.ElementAt(i + 1).Reset();
                path.ElementAt(i + 1).AddString(v, font.FontFamily, 0, font.Size, punto, Formato);
                g.ResetTransform();
            }
        }

        public void DibujarBucle(Graphics g)//Dibuja una arista con forma de bucle
        {
            int altura = n1.Location.Y - (int)(NodoG.radio * 1.4);  // Ajusta el tamaño del bucle

            // Dibujar un arco curvado
            pen.CustomStartCap = flecha;
            pen.EndCap = LineCap.Flat; //Crea la cabeza de la flecha
            path.ElementAt(0).Reset();
            Rectangle r = new Rectangle(n1.Location.X, altura, NodoG.radio * 2, NodoG.radio * 2);
            path.ElementAt(0).AddArc(r, 135, 270);

            g.DrawPath(pen, path.ElementAt(0));

            // Dibujar los valores en el medio de la arista
            for (int i = 0; i < valores.Count; i++)
            {
                string v = valores.ElementAt(i);
                v = v.Replace('ǁ', ',');
                SizeF textSize = g.MeasureString(v, font);
                PointF punto = new PointF((float)(n1.Centro.X - textSize.Width / 2), (float)(altura - textSize.Height * (i + 1)));
                g.DrawString(v, font, Brushes.Black, punto);
                path.ElementAt(i + 1).Reset();
                path.ElementAt(i + 1).AddString(v, font.FontFamily, 0, font.Size, punto, null);
            }
        }

        #endregion
    }
}
