using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        //funcion para Salir del Programa
        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton para 
        private void BT_Ajustes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no disponible por el momento");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 diseñor = new Form1();
            diseñor.Show();
            this.Hide();
        }
    }
}
