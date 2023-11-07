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
    public interface IArista
    {
        public INodo NodoInicio { get; set; }
        public INodo NodoFinal { get; set; }
    }
}
