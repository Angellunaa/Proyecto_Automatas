using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatas.Graficos
{
    public class MenuCNodo : ContextMenuStrip
    {
        //Atributos
        private NodoG nodo;
        private ToolStripMenuItem ItemFinal;
        private ToolStripMenuItem ItemInicial;
        private ToolStripMenuItem ItemNombre;
        private ToolStripMenuItem ItemNota;
        private ToolStripMenuItem ItemEliminarNota;
        private ToolStripMenuItem ItemEliminar;
        public MenuCNodo(NodoG nodo) : base()
        {
            this.nodo = nodo;

            ItemFinal = new ToolStripMenuItem("Final");
            ItemFinal.Checked = nodo.Final ? true : false;
            Items.Add(ItemFinal);

            ItemInicial = new ToolStripMenuItem("Inicial");
            if (nodo.pizarra.NodoInicial != null) ItemInicial.Checked = nodo == nodo.pizarra.NodoInicial ? true : false;
            else ItemInicial.Checked = false;
            Items.Add(ItemInicial);

            ItemNombre = new ToolStripMenuItem("Cambiar nombre");
            Items.Add(ItemNombre);

            ItemNota = new ToolStripMenuItem("Agregar/Editar nota");
            Items.Add(ItemNota);
            ItemEliminarNota = new ToolStripMenuItem("Eliminar nota");
            Items.Add(ItemEliminarNota);

            ItemEliminar = new ToolStripMenuItem("Eliminar estado");
            Items.Add(ItemEliminar);

            //Suscripcion a eventos
            ItemFinal.Click += ItemFinal_Click;
            ItemInicial.Click += ItemInicial_Click;
            ItemNombre.Click += ItemNombre_Click;
            ItemNota.Click += ItemNota_Click;
            ItemEliminarNota.Click += ItemEliminarNota_Click;
            ItemEliminar.Click += ItemEliminar_Click;
        }

        //Eventos
        private void ItemFinal_Click(object? sender, EventArgs e)
        {
            if (!nodo.Final)//Si no es final lo vuelve final
            {
                nodo.Final = true;
                ItemFinal.Checked = true;
                nodo.Dibujar();
            }
            else
            {
                nodo.Final = false;
                ItemFinal.Checked = false;
                nodo.Dibujar();
            }
        }

        private void ItemInicial_Click(object? sender, EventArgs e)
        {
            nodo.pizarra.NodoInicial = nodo;
            nodo.pizarra.Invalidate();
        }

        private void ItemNombre_Click(object? sender, EventArgs e)
        {
            string valor = Interaction.InputBox("Ingrese el nombre del nodo:", "Nombre del nodo", "");//Pregunta por valor de la arista
            if (!string.IsNullOrWhiteSpace(valor))//Solo si la cadena no esta vacia o llena de espacios
            {
                nodo.Nombre = valor;
                nodo.Dibujar();
            }
            nodo.Nombre = valor;
        }

        private void ItemNota_Click(object? sender, EventArgs e)
        {
            string texto = Interaction.InputBox("Agrega una nota:", "Nota del nodo", "");//Pregunta por valor de la arista
            if (!string.IsNullOrWhiteSpace(texto)) nodo.EditarNota(texto);
        }

        private void ItemEliminarNota_Click(object? sender, EventArgs e)
        {
            nodo.EliminarNota();
        }

        private void ItemEliminar_Click(object? sender, EventArgs e)
        {
            nodo.Eliminar();
        }
    }
}
