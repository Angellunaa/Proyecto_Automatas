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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            BT_Ajustes = new PictureBox();
            BT_Salir = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)BT_Ajustes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BT_Salir).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 132);
            button1.Name = "button1";
            button1.Size = new Size(246, 23);
            button1.TabIndex = 0;
            button1.Text = "DFA y NFA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(68, 29);
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
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(160, 22);
            label2.TabIndex = 2;
            label2.Text = "Primera Seccion";
            // 
            // BT_Ajustes
            // 
            BT_Ajustes.Image = Properties.Resources.Ajustes;
            BT_Ajustes.Location = new Point(204, 411);
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
            BT_Salir.Location = new Point(12, 411);
            BT_Salir.Name = "BT_Salir";
            BT_Salir.Size = new Size(56, 46);
            BT_Salir.SizeMode = PictureBoxSizeMode.Zoom;
            BT_Salir.TabIndex = 4;
            BT_Salir.TabStop = false;
            BT_Salir.Click += BT_Salir_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(272, 469);
            Controls.Add(BT_Salir);
            Controls.Add(BT_Ajustes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)BT_Ajustes).EndInit();
            ((System.ComponentModel.ISupportInitialize)BT_Salir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private PictureBox BT_Ajustes;
        private PictureBox BT_Salir;
    }
}