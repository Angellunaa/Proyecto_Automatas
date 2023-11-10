using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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

        private void BT_Sec_1_Click(object sender, EventArgs e)
        {
            Form1 Seccion1 = new Form1(1);
            Seccion1.Show();
            this.Hide();
        }

        private void BT_Sec_2_Click(object sender, EventArgs e)
        {
            Form1 Seccion2 = new Form1(2);
            Seccion2.Show();
            this.Hide();
        }
    }
}
