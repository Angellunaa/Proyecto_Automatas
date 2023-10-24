using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace Proyecto_Automatas
{
    public partial class Form1 : Form
    {
        //Atributos
        public static int estado = 1;
        /*  Estado:
            1.- Seleccionar
            2.- Agregar
            3.- Eliminar
            4.- Conectar
         */

        public static List<Nodo> ListaNodos = new List<Nodo>();//Lista de nodos
        public static List<Arista> ListaAristas = new List<Arista>();//Lista de aristas
        public static bool Elegido = false;
        public static Nodo nodo;
        //Metodos

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;//Abre la pantalla completa al inicializar la aplicacion
            Editor_Seleccionar.BackColor = Color.SkyBlue;
        }

        // ---------------------------------- Botones de edicion ----------------------------------
        private void Editor_Seleccionar_Click(object sender, EventArgs e)
        {
            estado = 1;
            Editor_Seleccionar.BackColor = Color.SkyBlue;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Agregar_Click(object sender, EventArgs e)
        {
            estado = 2;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.SkyBlue;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Eliminar_Click(object sender, EventArgs e)
        {
            estado = 3;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.SkyBlue;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Conectar_Click(object sender, EventArgs e)
        {
            estado = 4;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.SkyBlue;
        }

        // ----------------------------------- Dibujo de Automata ---------------------------------
        private void Pizarra_MouseClick(object sender, MouseEventArgs e)
        {
            switch (estado)
            {
                case 2: //Agrega un Nodo
                    nodo = new Nodo(e.Location);
                    ListaNodos.Add(nodo);
                    Pizarra.Controls.Add(nodo);
                    nodo.Dibujar();
                    break;

                case 3://Elimina una arista
                    foreach (Arista a in ListaAristas)//Eliminar una arista al hacer clic
                    {
                        if (a.EstaDentro(new Point(e.X, e.Y)))
                        {
                            ListaAristas.Remove(a);
                            Pizarra.Invalidate();
                            break;
                        }
                    }
                    break;
            }
        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                foreach (Arista a in ListaAristas)
                {
                    a.Dibujar(g);
                }
            }
        }
    }
}