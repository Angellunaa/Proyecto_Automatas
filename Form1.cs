using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Proyecto_Automatas.Graficos;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            Page_Editor.Controls.Add(pizarra);//Agrego la pizarra al editor
            Tab_Automata.Controls.Remove(Page_Pasos);//Quita la pagina que evalua paso a paso la cadena de un automata
            Editor_Seleccionar.BackColor = Color.SkyBlue;//Se activa el boton seleccionar por defecto
        }

        // ---------------------------------- Botones de edicion ----------------------------------

        #region Botones de edicion
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

        #endregion

        // ---------------------------------- Botones de la BarraMenu ----------------------------------
        #region Botones BarraMenu
        private void Barra_EvaluarCadena_Click(object sender, EventArgs e)
        {

        }

        private void Barra_PasoAPaso_Click(object sender, EventArgs e)
        {
            if (pizarra.NodoInicial is null)
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                string cadena = Interaction.InputBox("Ingrese el valor para la cadena:", "Valor de la cadena", "");//Pregunta por valor de la cadena
                Barra_Probar.Enabled = false;
                if (string.IsNullOrWhiteSpace(cadena)) cadena = "";

                if (Seccion == 1)
                {
                    AutomataFinito automata = new AutomataFinito(Transicion.Convertir(pizarra._listaAristas), pizarra.NodoInicial);
                    Tab_Automata.Controls.Add(Page_Pasos);
                    Tab_Automata.SelectedTab = Page_Pasos;
                    Page_Editor.Enabled = false;
                    Page_Editor.Controls.Remove(pizarra);
                    TLP_Pasos.Controls.Add(pizarra, 1, 0);
                    pizarra._estado = 0;
                    automata.Evaluar_Cadena(pizarra.NodoInicial, cadena);
                    DGV_Tabla_Transiciones.DataSource = automata.data;
                }
                else
                {
                    bool op = false;
                    using (Aceptar input = new Aceptar())
                    {
                        if (input.DialogResult == DialogResult.OK)
                        {
                            if (input.Get_aceptar() == 1)
                            {
                                op = true;
                            }
                        }
                    }
                    AutomataPila automata = new AutomataPila(Transicion.Convertir(pizarra._listaAristas), pizarra.NodoInicial, op);
                    List<string> pila = new List<string>() { "Z" };
                    Tab_Automata.Controls.Add(Page_Pasos);
                    Tab_Automata.SelectedTab = Page_Pasos;
                    Page_Editor.Enabled = false;
                    Page_Editor.Controls.Remove(pizarra);
                    TLP_Pasos.Controls.Add(pizarra, 1, 0);
                    pizarra._estado = 0;
                    automata.Evaluar_Cadena(pizarra.NodoInicial, cadena, pila);
                    DGV_Tabla_Transiciones.DataSource = automata.data;
                }
            }
        }

        private void Barra_Regresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        // ---------------------------------- Eventos de las pestañas ----------------------------------

        #region Eventos de pestañas

        private void Tab_Automata_Selecting(object sender, TabControlCancelEventArgs e)//No permite que se abra el editor
        {
            // Cancelar la selección si la pestaña está deshabilitada
            if (e.TabPage is not null && e.TabPage.Enabled == false)
            {
                e.Cancel = true;
            }
        }

        private void BT_Cancelar_Click(object sender, EventArgs e)
        {
            TLP_Pasos.Controls.Remove(pizarra);
            DGV_Tabla_Transiciones.DataSource = null;
            Page_Editor.Controls.Add(pizarra);
            Page_Editor.Enabled = true;
            Editor_Seleccionar_Click(Barra_Editor, new EventArgs());
            Tab_Automata.SelectedTab = Page_Editor;
            Tab_Automata.Controls.Remove(Page_Pasos);
            Barra_Probar.Enabled = true;
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NodoG.Cont = 0;
            Program.menu.Show();
        }

        protected override void OnPaint(PaintEventArgs e) { }
    }
}