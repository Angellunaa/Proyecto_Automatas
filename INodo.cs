using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas
{
    public interface INodo
    {
        public string Nombre { get; set; }
        public bool Inicial {  get; set; }
        public bool Final { get; set; }
    }
}
