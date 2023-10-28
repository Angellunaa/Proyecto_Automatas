using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public abstract class AristaG : Control, IArista
    {
        //Atributos graficos
        protected GraphicsPath path;
        protected Pen pen;
        protected Font font;
        protected Color color;
        protected int grosor;
        protected string familiafuente;
        protected int tamletra;
        
        //Metodos de la interfaz
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
        public string Valor { get; set; }
    
        //Contructores
        public AristaG(NodoG nodo, string valor)//Si el nodo inicial y final es el mismo
        {
            this.NodoInicio = nodo;
            this.NodoFinal = nodo;
            this.Valor = valor;
            grosor = 2;
            color = Color.Black;
            familiafuente = "Arial";
            tamletra = 12;

            path = new GraphicsPath();
            pen = new Pen(color, grosor);
            font = new Font(familiafuente, tamletra);
        }

        public AristaG(NodoG nodoinicial, NodoG nodofinal, string valor)//Si el nodo inicial y final son diferentes
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
        }

        //Metodos de la clase abstracta 
        public abstract void Dibujar();

        public abstract void Mover(Point point);
    }
}
