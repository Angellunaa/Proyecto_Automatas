using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Proyecto_Automatas.Graficos;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public partial class Form1 : Form
    {
        //Atributos
        private Pizarra pizarra;
        public short Seccion { get; set; }//Determina que seccion se eligio en el menu

        //Metodos
        public Form1(short seccion)//Constructor
        {
            InitializeComponent();
            Seccion = seccion;
            pizarra = new Pizarra(seccion);//Creo la pizarra
            TabEditor.Controls.Add(pizarra);//Agrego la pizarra
            Editor_Seleccionar.BackColor = Color.SkyBlue;//Se activa el boton seleccionar por defecto
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

        private void Barra_Probar_ButtonClick(object sender, EventArgs e)
        {
            if (pizarra.NodoInicial is null)
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Automata automata = new Automata(Transicion.Convertir(pizarra._listaAristas), pizarra.NodoInicial);
                string cadena = Interaction.InputBox("Ingrese el valor para la cadena:", "Valor de la cadena", "");//Pregunta por valor de la cadena
                if (string.IsNullOrWhiteSpace(cadena)) cadena = "";
                automata.Evaluar_Cadena(pizarra.NodoInicial, cadena);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        protected override void OnPaint(PaintEventArgs e) { }
    }
}