using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Automatas.Graficos
{
    public class Input2 : Form
    {

        public Input2(string Titulo, string Texto, string valor)
        {
            InitializeComponent();
            Text = Titulo;
            LB_Texto.Text = Texto;
            TB_Leer.Text = valor;
            TB_Meter.Text = valor;
            TB_Sacar.Text = valor;
            ShowDialog();
        }

        private void InitializeComponent()
        {
            TB_Leer = new TextBox();
            BT_Aceptar = new Button();
            BT_Cancelar = new Button();
            LB_Texto = new Label();
            TB_Sacar = new TextBox();
            TB_Meter = new TextBox();
            LB_Leer = new Label();
            LB_Sacar = new Label();
            LB_Meter = new Label();
            SuspendLayout();
            // 
            // TB_Leer
            // 
            TB_Leer.Location = new Point(36, 80);
            TB_Leer.Name = "TB_Leer";
            TB_Leer.Size = new Size(150, 34);
            TB_Leer.TabIndex = 0;
            TB_Leer.KeyPress += TB_Valor_KeyPress;
            // 
            // BT_Aceptar
            // 
            BT_Aceptar.Location = new Point(152, 134);
            BT_Aceptar.Name = "BT_Aceptar";
            BT_Aceptar.Size = new Size(94, 45);
            BT_Aceptar.TabIndex = 1;
            BT_Aceptar.Text = "Aceptar";
            BT_Aceptar.UseVisualStyleBackColor = true;
            BT_Aceptar.Click += BT_Aceptar_Click;
            // 
            // BT_Cancelar
            // 
            BT_Cancelar.Location = new Point(322, 134);
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
            LB_Texto.Location = new Point(36, 9);
            LB_Texto.Name = "LB_Texto";
            LB_Texto.Size = new Size(487, 28);
            LB_Texto.TabIndex = 3;
            LB_Texto.Text = "Texto";
            LB_Texto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TB_Sacar
            // 
            TB_Sacar.Location = new Point(208, 80);
            TB_Sacar.Name = "TB_Sacar";
            TB_Sacar.Size = new Size(150, 34);
            TB_Sacar.TabIndex = 4;
            TB_Sacar.KeyPress += TB_Sacar_KeyPress;
            // 
            // TB_Meter
            // 
            TB_Meter.Location = new Point(373, 80);
            TB_Meter.Name = "TB_Meter";
            TB_Meter.Size = new Size(150, 34);
            TB_Meter.TabIndex = 5;
            TB_Meter.KeyPress += TB_Meter_KeyPress;
            // 
            // LB_Leer
            // 
            LB_Leer.AutoEllipsis = true;
            LB_Leer.Location = new Point(49, 49);
            LB_Leer.Name = "LB_Leer";
            LB_Leer.Size = new Size(123, 28);
            LB_Leer.TabIndex = 6;
            LB_Leer.Text = "Leer";
            LB_Leer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LB_Sacar
            // 
            LB_Sacar.AutoEllipsis = true;
            LB_Sacar.Location = new Point(223, 49);
            LB_Sacar.Name = "LB_Sacar";
            LB_Sacar.Size = new Size(123, 28);
            LB_Sacar.TabIndex = 7;
            LB_Sacar.Text = "Sacar";
            LB_Sacar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LB_Meter
            // 
            LB_Meter.AutoEllipsis = true;
            LB_Meter.Location = new Point(387, 49);
            LB_Meter.Name = "LB_Meter";
            LB_Meter.Size = new Size(123, 28);
            LB_Meter.TabIndex = 8;
            LB_Meter.Text = "Meter";
            LB_Meter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Input2
            // 
            ClientSize = new Size(554, 191);
            Controls.Add(LB_Meter);
            Controls.Add(LB_Sacar);
            Controls.Add(LB_Leer);
            Controls.Add(TB_Meter);
            Controls.Add(TB_Sacar);
            Controls.Add(LB_Texto);
            Controls.Add(BT_Cancelar);
            Controls.Add(BT_Aceptar);
            Controls.Add(TB_Leer);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Input2";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox TB_Leer;
        private Button BT_Aceptar;
        private Button BT_Cancelar;
        private TextBox TB_Sacar;
        private TextBox TB_Meter;
        private Label LB_Leer;
        private Label LB_Sacar;
        private Label LB_Meter;
        private Label LB_Texto;

        public string[] getValores()
        {
            string[] Valores = { TB_Leer.Text, TB_Sacar.Text, TB_Meter.Text };
            return Valores;
        }

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
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Right))
            {
                TB_Sacar.Select();
            }
        }

        private void TB_Sacar_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Right))
            {
                TB_Meter.Select();
            }
        }

        private void TB_Meter_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
