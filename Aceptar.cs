using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Proyecto_Automatas
{
    public partial class Aceptar : Form
    {
        public Aceptar()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            comboBox1.SelectedItem = "Si el estado es final";
            MaximizeBox = false;
            MinimizeBox = false;
            ShowDialog();
        }
        public int Get_aceptar()
        {
            int valor = comboBox1.SelectedIndex;
            return valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
