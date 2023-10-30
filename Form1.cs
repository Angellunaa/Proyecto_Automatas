using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public partial class Form1 : Form
    {
        /*  Estado para pizarra
            1.- Seleccionar
            2.- Agregar
            3.- Eliminar
            4.- Conectar
         */

        //Atributos
        private Pizarra pizarra;

        //Metodos
        public Form1()//Constructor
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;//Abre la pantalla completa al inicializar la aplicacion
            Editor_Seleccionar.BackColor = Color.SkyBlue;
            pizarra = new Pizarra();//Creo la pizarra
            TabEditor.Controls.Add(pizarra);//Agrego la pizarra
        }

        // ---------------------------------- Botones de edicion ----------------------------------
        private void Editor_Seleccionar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 1;
            Editor_Seleccionar.BackColor = Color.SkyBlue;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Agregar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 2;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.SkyBlue;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Eliminar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 3;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.SkyBlue;
            Editor_Conectar.BackColor = Color.Transparent;
        }

        private void Editor_Conectar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 4;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.SkyBlue;
        }

        protected override void OnPaint(PaintEventArgs e) { }
    }
}