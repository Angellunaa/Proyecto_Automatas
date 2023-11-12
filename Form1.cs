using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Data;
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
            if (NodoG.conectar is not null)
            {
                NodoG.conectar.Dibujar();
                NodoG.conectar = null;
            }
        }

        private void Editor_Agregar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 2;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.SkyBlue;
            Editor_Eliminar.BackColor = Color.Transparent;
            Editor_Conectar.BackColor = Color.Transparent;
            if (NodoG.conectar is not null)
            {
                NodoG.conectar.Dibujar();
                NodoG.conectar = null;
            }
        }

        private void Editor_Eliminar_Click(object sender, EventArgs e)
        {
            pizarra._estado = 3;
            Editor_Seleccionar.BackColor = Color.Transparent;
            Editor_Agregar.BackColor = Color.Transparent;
            Editor_Eliminar.BackColor = Color.SkyBlue;
            Editor_Conectar.BackColor = Color.Transparent;
            if (NodoG.conectar is not null)
            {
                NodoG.conectar.Dibujar();
                NodoG.conectar = null;
            }
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

        private void Barra_Probar_ButtonClick(object sender, EventArgs e)
        {
            List<string> t = new List<string>();
            string n_inicial = "";
            string cadena = Interaction.InputBox("Ingrese el valor para la cadena:", "Valor de la cadena", "");//Pregunta por valor de la cadena
            if (cadena.Equals(string.Empty))
            {
                cadena = "";
            }
            if (pizarra.NodoInicial == null)
            {
                n_inicial = "";
            }
            else
            {
                n_inicial = pizarra.NodoInicial.Nombre;
            }
            // Llama al método DataBind     
            Automata automata = new Automata(pizarra._listaAristas, n_inicial);
            automata.Evaluar_Cadena(pizarra.NodoInicial, cadena);
            dataGridView1.DataSource = automata.data;
            dataGridView1.Dock = DockStyle.Right;
            dataGridView1.Visible = true;

        }
    }
}