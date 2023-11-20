using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas
{
    public class Input1 : Form
    {

        public Input1(string Titulo, string Texto, string valor)
        {
            InitializeComponent();
            Text = Titulo;
            LB_Texto.Text = Texto;
            TB_Valor.Text = valor;
            ShowDialog();
        }

        private void InitializeComponent()
        {
            TB_Valor = new TextBox();
            BT_Aceptar = new Button();
            BT_Cancelar = new Button();
            LB_Texto = new Label();
            SuspendLayout();
            // 
            // TB_Valor
            // 
            TB_Valor.Location = new Point(36, 80);
            TB_Valor.Name = "TB_Valor";
            TB_Valor.Size = new Size(487, 29);
            TB_Valor.TabIndex = 0;
            TB_Valor.KeyPress += TB_Valor_KeyPress;
            // 
            // BT_Aceptar
            // 
            BT_Aceptar.Location = new Point(118, 134);
            BT_Aceptar.Name = "BT_Aceptar";
            BT_Aceptar.Size = new Size(94, 45);
            BT_Aceptar.TabIndex = 1;
            BT_Aceptar.Text = "Aceptar";
            BT_Aceptar.UseVisualStyleBackColor = true;
            BT_Aceptar.Click += BT_Aceptar_Click;
            // 
            // BT_Cancelar
            // 
            BT_Cancelar.Location = new Point(331, 134);
            BT_Cancelar.Name = "BT_Cancelar";
            BT_Cancelar.Size = new Size(94, 45);
            BT_Cancelar.TabIndex = 2;
            BT_Cancelar.Text = "Cancelar";
            BT_Cancelar.UseVisualStyleBackColor = true;
            BT_Cancelar.Click += BT_Cancelar_Click;
            // 
            // LB_Texto
            // 
            LB_Texto.AutoEllipsis = true;
            LB_Texto.Location = new Point(36, 37);
            LB_Texto.Name = "LB_Texto";
            LB_Texto.Size = new Size(487, 28);
            LB_Texto.TabIndex = 3;
            LB_Texto.Text = "Texto";
            LB_Texto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Input1
            // 
            ClientSize = new Size(554, 191);
            Controls.Add(LB_Texto);
            Controls.Add(BT_Cancelar);
            Controls.Add(BT_Aceptar);
            Controls.Add(TB_Valor);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Input1";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox TB_Valor;
        private Button BT_Aceptar;
        private Button BT_Cancelar;
        private Label LB_Texto;

        public string getValor() { return TB_Valor.Text; }

        private void BT_Aceptar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BT_Cancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TB_Valor_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void LB_Texto_Click(object sender, EventArgs e)
        {

        }
    }
}
