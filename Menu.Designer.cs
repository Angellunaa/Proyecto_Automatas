namespace Proyecto_Automatas
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BT_Sec_1 = new Button();
            label1 = new Label();
            label2 = new Label();
            BT_Ajustes = new PictureBox();
            BT_Salir = new PictureBox();
            BT_Sec_2 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)BT_Ajustes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BT_Salir).BeginInit();
            SuspendLayout();
            // 
            // BT_Sec_1
            // 
            BT_Sec_1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BT_Sec_1.Location = new Point(12, 100);
            BT_Sec_1.Name = "BT_Sec_1";
            BT_Sec_1.Size = new Size(219, 158);
            BT_Sec_1.TabIndex = 0;
            BT_Sec_1.Text = "Aceptadores finitos";
            BT_Sec_1.UseVisualStyleBackColor = true;
            BT_Sec_1.Click += BT_Sec_1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(289, 7);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 1;
            label1.Text = "AUTOMATAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(42, 76);
            label2.Name = "label2";
            label2.Size = new Size(160, 22);
            label2.TabIndex = 2;
            label2.Text = "Primera Seccion";
            // 
            // BT_Ajustes
            // 
            BT_Ajustes.Image = Properties.Resources.Ajustes;
            BT_Ajustes.Location = new Point(639, 212);
            BT_Ajustes.Name = "BT_Ajustes";
            BT_Ajustes.Size = new Size(56, 46);
            BT_Ajustes.SizeMode = PictureBoxSizeMode.Zoom;
            BT_Ajustes.TabIndex = 3;
            BT_Ajustes.TabStop = false;
            BT_Ajustes.Click += BT_Ajustes_Click;
            // 
            // BT_Salir
            // 
            BT_Salir.Image = Properties.Resources.Salir;
            BT_Salir.Location = new Point(553, 212);
            BT_Salir.Name = "BT_Salir";
            BT_Salir.Size = new Size(56, 46);
            BT_Salir.SizeMode = PictureBoxSizeMode.Zoom;
            BT_Salir.TabIndex = 4;
            BT_Salir.TabStop = false;
            BT_Salir.Click += BT_Salir_Click;
            // 
            // BT_Sec_2
            // 
            BT_Sec_2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BT_Sec_2.Location = new Point(277, 100);
            BT_Sec_2.Name = "BT_Sec_2";
            BT_Sec_2.Size = new Size(219, 158);
            BT_Sec_2.TabIndex = 5;
            BT_Sec_2.Text = "Aceptadores de pila";
            BT_Sec_2.UseVisualStyleBackColor = true;
            BT_Sec_2.Click += BT_Sec_2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(309, 76);
            label3.Name = "label3";
            label3.Size = new Size(160, 22);
            label3.TabIndex = 6;
            label3.Text = "Segunda Seccion";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Location = new Point(512, 100);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 53);
            textBox1.TabIndex = 7;
            textBox1.Text = "Elaborado por:\r\nAngel Gerado Luna Romo\r\nMiguel Aaron Ramirez Sanchez";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(716, 281);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(BT_Sec_2);
            Controls.Add(BT_Salir);
            Controls.Add(BT_Ajustes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BT_Sec_1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)BT_Ajustes).EndInit();
            ((System.ComponentModel.ISupportInitialize)BT_Salir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BT_Sec_1;
        private Label label1;
        private Label label2;
        private PictureBox BT_Ajustes;
        private PictureBox BT_Salir;
        private Button BT_Sec_2;
        private Label label3;
        private TextBox textBox1;
    }
}