using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Proyecto_Automatas.Graficos;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Automatas
{
    public partial class Form1 : Form
    {
        //Atributos
        private Pizarra pizarra;
        public bool continuar = false;
        public short Seccion { get; set; }//Determina que seccion se eligio en el menu
        private CancellationTokenSource? TokenCancel;

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

        // ---------------------------------- Botones de la BarraMenu ----------------------------------
        #region Botones BarraMenu

        private void TSMI_EvaluarCadena_Click(object sender, EventArgs e)
        {
            //CancellationToken cancellationToken = cancellationTokenSource.Token;
            if (pizarra.NodoInicial is null)
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string cadena = Interaction.InputBox("Ingrese el valor para la cadena:", "Valor de la cadena", "");//Pregunta por valor de la cadena
                if (string.IsNullOrWhiteSpace(cadena)) cadena = "";

                List<INodo> Nodos = pizarra._listaNodos.ConvertAll((n) => (INodo)n);

                if (Seccion == 1)
                {
                    AutomataFinito automata = new AutomataFinito(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial);
                    if (automata.EsAceptada(pizarra.NodoInicial, cadena))
                    {
                        MessageBox.Show("La cadena fue ACEPTADA", "Evaluar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La cadena fue RECHAZADA", "Evaluar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    AutomataPila automata = new AutomataPila(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial, op);
                    List<string> pila = new List<string>() { "Z" };
                    //automata.EsAceptada(pizarra.NodoInicial, cadena, pila);
                }
            }
        }

        private async void Barra_PasoAPaso_Click(object sender, EventArgs e)
        {
            if (pizarra.NodoInicial is null)
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string cadena;
                using (Input1 input = new Input1("Ingrese el valor para la cadena:", "Valor de la cadena", ""))
                {
                    if (input.DialogResult == DialogResult.OK) cadena = input.getValor();
                    else
                    {
                        return;//Ya no continua con la tarea
                    }
                }
                TSMI_Probar.Enabled = false;
                if (string.IsNullOrWhiteSpace(cadena)) cadena = "";

                List<INodo> Nodos = pizarra._listaNodos.ConvertAll((n) => (INodo)n);
                TokenCancel = new CancellationTokenSource();

                if (Seccion == 1)
                {

                    AutomataFinito automata = new AutomataFinito(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial);
                    Invoke((MethodInvoker)delegate
                    {
                        Tab_Automata.Controls.Add(Page_Pasos);
                        Tab_Automata.SelectedTab = Page_Pasos;
                        Page_Editor.Enabled = false;
                        Page_Editor.Controls.Remove(pizarra);
                        TLP_Pasos.Controls.Add(pizarra, 1, 0);
                        pizarra._estado = 0;
                    });
                    await Task.Run(() => automata.Evaluar_Cadena(pizarra.NodoInicial, cadena),TokenCancel.Token);
                    Invoke((MethodInvoker)delegate { DGV_Tabla_Transiciones.DataSource = automata.data; });
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
                    AutomataPila automata = new AutomataPila(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial, op);
                    List<string> pila = new List<string>() { "Z" };
                    Invoke((MethodInvoker)delegate
                    {
                        Tab_Automata.Controls.Add(Page_Pasos);
                        Tab_Automata.SelectedTab = Page_Pasos;
                        Page_Editor.Enabled = false;
                        Page_Editor.Controls.Remove(pizarra);
                        TLP_Pasos.Controls.Add(pizarra, 1, 0);
                    });
                    pizarra._estado = 0;
                    await Task.Run(() => automata.Evaluar_Cadena(pizarra.NodoInicial, cadena, pila), TokenCancel.Token);
                    Invoke((MethodInvoker)delegate { DGV_Tabla_Transiciones.DataSource = automata.data; });
                }
            }
        }

        private void TSMI_Determinismo_Click(object sender, EventArgs e)
        {
            if (pizarra.NodoInicial is null)
            {
                MessageBox.Show("No se ha indicado un nodo inicial", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                List<INodo> Nodos = pizarra._listaNodos.ConvertAll((n) => (INodo)n);

                if (Seccion == 1)
                {
                    AutomataFinito automata = new AutomataFinito(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial);
                    if (automata.EsDeterminista())
                    {
                        MessageBox.Show("El automata es determinista", "Determinismo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El automata no es determinista", "Determinismo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    AutomataPila automata = new AutomataPila(Transicion.Convertir(pizarra._listaAristas), Nodos, pizarra.NodoInicial, false);
                    if (automata.EsDeterminista())
                    {
                        MessageBox.Show("El automata es determinista", "Determinismo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("El automata no es determinista", "Determinismo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void TSMI_Regresar_Click(object sender, EventArgs e)
        {
            Close(); // Hace lo que esta en el evento Form1_FormClosing
        }

        #endregion

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

        // ---------------------------------- Eventos de las pestañas ----------------------------------

        #region Eventos de pestañas

        private void Tab_Automata_Selecting(object sender, TabControlCancelEventArgs e)//No permite que se abran otras pestañas
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

            foreach (NodoG n in pizarra._listaNodos)
            {
                n.Dibujar();
            }

            Editor_Seleccionar_Click(Barra_Editor, new EventArgs());
            Tab_Automata.SelectedTab = Page_Editor;
            Tab_Automata.Controls.Remove(Page_Pasos);
            TSMI_Probar.Enabled = true;
            Automata.continuar = false;
            TokenCancel?.Cancel();
        }
        #endregion

        // ---------------------------------- Otros Eventos ----------------------------------

        public void SetDescripcion(string text)
        {
            LB_Descripcion.Text = "\tDescripcion\n\n" + text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NodoG.Cont = 0;
            Automata.continuar = false;
            TokenCancel?.Cancel();
            pizarra.Dispose();
            Program.menu.Show();
        }

        protected override void OnPaint(PaintEventArgs e) { }

        private void Barra_BTPaso_Click(object sender, EventArgs e)
        {
            Automata.continuar = true;
        }
    }
}