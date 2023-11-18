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
    public partial class Tabla_transiciones : Form
    {
        public Tabla_transiciones(string cadena, DataTable datos)
        {
            InitializeComponent();
            label1.Text = "Tabla de transiciones de la cadena: ' " + cadena+" '";
            dataGridView1.DataSource = datos;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
