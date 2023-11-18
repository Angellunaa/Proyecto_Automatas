namespace Proyecto_Automatas
{
    partial class Aceptar
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(62, 27);
            label1.Name = "label1";
            label1.Size = new Size(381, 29);
            label1.TabIndex = 0;
            label1.Text = "¿Cómo quieres aceptar tu cadena?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ControlLight;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 25;
            comboBox1.Items.AddRange(new object[] { "Si el estado es final", "Si la pila está vacía" });
            comboBox1.Location = new Point(132, 94);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(264, 33);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Location = new Point(200, 165);
            button1.Name = "button1";
            button1.Size = new Size(131, 55);
            button1.TabIndex = 1;
            button1.Text = "Aceptar\r\n";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Aceptar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 249);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "Aceptar";
            Text = "Aceptar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
    }
}