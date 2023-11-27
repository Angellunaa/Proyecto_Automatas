namespace Proyecto_Automatas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Page_Editor = new TabPage();
            Barra_Editor = new StatusStrip();
            Editor_Seleccionar = new ToolStripDropDownButton();
            Editor_Agregar = new ToolStripDropDownButton();
            Editor_Eliminar = new ToolStripDropDownButton();
            Editor_Conectar = new ToolStripDropDownButton();
            Tab_Automata = new TabControl();
            Page_Pasos = new TabPage();
            BT_Cancelar = new Button();
            TLP_Pasos = new TableLayoutPanel();
            DGV_Tabla_Transiciones = new DataGridView();
            LB_Descripcion = new Label();
            menuStrip1 = new MenuStrip();
            Barra_BTPaso = new ToolStripMenuItem();
            Barra_Menu = new MenuStrip();
            TSMI_Archivo = new ToolStripMenuItem();
            TSMI_Probar = new ToolStripMenuItem();
            Barra_EvaluarCadena = new ToolStripMenuItem();
            Barra_PasoAPaso = new ToolStripMenuItem();
            TSMI_Determinismo = new ToolStripMenuItem();
            TSMI_Regresar = new ToolStripMenuItem();
            Page_Editor.SuspendLayout();
            Barra_Editor.SuspendLayout();
            Tab_Automata.SuspendLayout();
            Page_Pasos.SuspendLayout();
            TLP_Pasos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Tabla_Transiciones).BeginInit();
            menuStrip1.SuspendLayout();
            Barra_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Page_Editor
            // 
            Page_Editor.BackColor = Color.White;
            Page_Editor.Controls.Add(Barra_Editor);
            Page_Editor.Location = new Point(4, 29);
            Page_Editor.Margin = new Padding(3, 4, 3, 4);
            Page_Editor.Name = "Page_Editor";
            Page_Editor.Padding = new Padding(3, 4, 3, 4);
            Page_Editor.Size = new Size(1127, 642);
            Page_Editor.TabIndex = 0;
            Page_Editor.Text = "Editor";
            // 
            // Barra_Editor
            // 
            Barra_Editor.Dock = DockStyle.Top;
            Barra_Editor.ImageScalingSize = new Size(24, 24);
            Barra_Editor.Items.AddRange(new ToolStripItem[] { Editor_Seleccionar, Editor_Agregar, Editor_Eliminar, Editor_Conectar });
            Barra_Editor.Location = new Point(3, 4);
            Barra_Editor.Name = "Barra_Editor";
            Barra_Editor.Padding = new Padding(1, 0, 16, 0);
            Barra_Editor.RenderMode = ToolStripRenderMode.Professional;
            Barra_Editor.Size = new Size(1121, 26);
            Barra_Editor.TabIndex = 0;
            Barra_Editor.Text = "Barra_Editor";
            // 
            // Editor_Seleccionar
            // 
            Editor_Seleccionar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Editor_Seleccionar.Image = (Image)resources.GetObject("Editor_Seleccionar.Image");
            Editor_Seleccionar.ImageTransparentColor = Color.Magenta;
            Editor_Seleccionar.Name = "Editor_Seleccionar";
            Editor_Seleccionar.ShowDropDownArrow = false;
            Editor_Seleccionar.Size = new Size(89, 24);
            Editor_Seleccionar.Text = "Seleccionar";
            Editor_Seleccionar.Click += Editor_Seleccionar_Click;
            // 
            // Editor_Agregar
            // 
            Editor_Agregar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Editor_Agregar.Image = (Image)resources.GetObject("Editor_Agregar.Image");
            Editor_Agregar.ImageTransparentColor = Color.Magenta;
            Editor_Agregar.Name = "Editor_Agregar";
            Editor_Agregar.ShowDropDownArrow = false;
            Editor_Agregar.Size = new Size(67, 24);
            Editor_Agregar.Text = "Agregar";
            Editor_Agregar.Click += Editor_Agregar_Click;
            // 
            // Editor_Eliminar
            // 
            Editor_Eliminar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Editor_Eliminar.Image = (Image)resources.GetObject("Editor_Eliminar.Image");
            Editor_Eliminar.ImageTransparentColor = Color.Magenta;
            Editor_Eliminar.Name = "Editor_Eliminar";
            Editor_Eliminar.ShowDropDownArrow = false;
            Editor_Eliminar.Size = new Size(67, 24);
            Editor_Eliminar.Text = "Eliminar";
            Editor_Eliminar.Click += Editor_Eliminar_Click;
            // 
            // Editor_Conectar
            // 
            Editor_Conectar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Editor_Conectar.Image = (Image)resources.GetObject("Editor_Conectar.Image");
            Editor_Conectar.ImageTransparentColor = Color.Magenta;
            Editor_Conectar.Name = "Editor_Conectar";
            Editor_Conectar.ShowDropDownArrow = false;
            Editor_Conectar.Size = new Size(72, 24);
            Editor_Conectar.Text = "Conectar";
            Editor_Conectar.Click += Editor_Conectar_Click;
            // 
            // Tab_Automata
            // 
            Tab_Automata.Controls.Add(Page_Editor);
            Tab_Automata.Controls.Add(Page_Pasos);
            Tab_Automata.Dock = DockStyle.Fill;
            Tab_Automata.Location = new Point(0, 30);
            Tab_Automata.Margin = new Padding(3, 4, 3, 4);
            Tab_Automata.Name = "Tab_Automata";
            Tab_Automata.SelectedIndex = 0;
            Tab_Automata.Size = new Size(1135, 675);
            Tab_Automata.TabIndex = 1;
            Tab_Automata.Selecting += Tab_Automata_Selecting;
            // 
            // Page_Pasos
            // 
            Page_Pasos.Controls.Add(BT_Cancelar);
            Page_Pasos.Controls.Add(TLP_Pasos);
            Page_Pasos.Controls.Add(menuStrip1);
            Page_Pasos.Location = new Point(4, 29);
            Page_Pasos.Margin = new Padding(3, 4, 3, 4);
            Page_Pasos.Name = "Page_Pasos";
            Page_Pasos.Padding = new Padding(3, 4, 3, 4);
            Page_Pasos.Size = new Size(1127, 642);
            Page_Pasos.TabIndex = 1;
            Page_Pasos.Text = "Paso a Paso";
            Page_Pasos.UseVisualStyleBackColor = true;
            // 
            // BT_Cancelar
            // 
            BT_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_Cancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BT_Cancelar.ForeColor = Color.Red;
            BT_Cancelar.Location = new Point(1087, 11);
            BT_Cancelar.Margin = new Padding(3, 4, 3, 4);
            BT_Cancelar.Name = "BT_Cancelar";
            BT_Cancelar.Size = new Size(26, 31);
            BT_Cancelar.TabIndex = 2;
            BT_Cancelar.Text = "X";
            BT_Cancelar.UseVisualStyleBackColor = true;
            BT_Cancelar.Click += BT_Cancelar_Click;
            // 
            // TLP_Pasos
            // 
            TLP_Pasos.ColumnCount = 2;
            TLP_Pasos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            TLP_Pasos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            TLP_Pasos.Controls.Add(DGV_Tabla_Transiciones, 0, 0);
            TLP_Pasos.Controls.Add(LB_Descripcion, 0, 1);
            TLP_Pasos.Dock = DockStyle.Fill;
            TLP_Pasos.Location = new Point(3, 4);
            TLP_Pasos.Margin = new Padding(3, 4, 3, 4);
            TLP_Pasos.Name = "TLP_Pasos";
            TLP_Pasos.RowCount = 2;
            TLP_Pasos.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            TLP_Pasos.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            TLP_Pasos.Size = new Size(1121, 604);
            TLP_Pasos.TabIndex = 0;
            // 
            // DGV_Tabla_Transiciones
            // 
            DGV_Tabla_Transiciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Tabla_Transiciones.ColumnHeadersHeight = 29;
            DGV_Tabla_Transiciones.Dock = DockStyle.Fill;
            DGV_Tabla_Transiciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGV_Tabla_Transiciones.Location = new Point(3, 4);
            DGV_Tabla_Transiciones.Margin = new Padding(3, 4, 3, 4);
            DGV_Tabla_Transiciones.Name = "DGV_Tabla_Transiciones";
            DGV_Tabla_Transiciones.RowHeadersVisible = false;
            DGV_Tabla_Transiciones.RowHeadersWidth = 51;
            DGV_Tabla_Transiciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV_Tabla_Transiciones.RowTemplate.Height = 25;
            DGV_Tabla_Transiciones.Size = new Size(352, 475);
            DGV_Tabla_Transiciones.TabIndex = 1;
            // 
            // LB_Descripcion
            // 
            LB_Descripcion.AutoSize = true;
            LB_Descripcion.Dock = DockStyle.Fill;
            LB_Descripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LB_Descripcion.Location = new Point(3, 483);
            LB_Descripcion.Name = "LB_Descripcion";
            LB_Descripcion.Size = new Size(352, 121);
            LB_Descripcion.TabIndex = 2;
            LB_Descripcion.Text = "\r\nDescripción:";
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Barra_BTPaso });
            menuStrip1.Location = new Point(3, 608);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1121, 30);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // Barra_BTPaso
            // 
            Barra_BTPaso.Name = "Barra_BTPaso";
            Barra_BTPaso.Size = new Size(53, 24);
            Barra_BTPaso.Text = "Paso";
            Barra_BTPaso.Click += Barra_BTPaso_Click;
            // 
            // Barra_Menu
            // 
            Barra_Menu.ImageScalingSize = new Size(20, 20);
            Barra_Menu.Items.AddRange(new ToolStripItem[] { TSMI_Archivo, TSMI_Probar, TSMI_Determinismo, TSMI_Regresar });
            Barra_Menu.Location = new Point(0, 0);
            Barra_Menu.Name = "Barra_Menu";
            Barra_Menu.Padding = new Padding(7, 3, 0, 3);
            Barra_Menu.Size = new Size(1135, 30);
            Barra_Menu.TabIndex = 2;
            Barra_Menu.Text = "Barra_Menu";
            // 
            // TSMI_Archivo
            // 
            TSMI_Archivo.Name = "TSMI_Archivo";
            TSMI_Archivo.Size = new Size(73, 24);
            TSMI_Archivo.Text = "Archivo";
            // 
            // TSMI_Probar
            // 
            TSMI_Probar.DropDownItems.AddRange(new ToolStripItem[] { Barra_EvaluarCadena, Barra_PasoAPaso });
            TSMI_Probar.Name = "TSMI_Probar";
            TSMI_Probar.Size = new Size(67, 24);
            TSMI_Probar.Text = "Probar";
            TSMI_Probar.ToolTipText = "Ingresar Cadena";
            // 
            // Barra_EvaluarCadena
            // 
            Barra_EvaluarCadena.Name = "Barra_EvaluarCadena";
            Barra_EvaluarCadena.Size = new Size(194, 26);
            Barra_EvaluarCadena.Text = "Evaluar Cadena";
            Barra_EvaluarCadena.Click += TSMI_EvaluarCadena_Click;
            // 
            // Barra_PasoAPaso
            // 
            Barra_PasoAPaso.Name = "Barra_PasoAPaso";
            Barra_PasoAPaso.Size = new Size(194, 26);
            Barra_PasoAPaso.Text = "Paso a Paso";
            Barra_PasoAPaso.Click += Barra_PasoAPaso_Click;
            // 
            // TSMI_Determinismo
            // 
            TSMI_Determinismo.Name = "TSMI_Determinismo";
            TSMI_Determinismo.Size = new Size(138, 24);
            TSMI_Determinismo.Text = "¿Es determinista?";
            TSMI_Determinismo.Click += TSMI_Determinismo_Click;
            // 
            // TSMI_Regresar
            // 
            TSMI_Regresar.Name = "TSMI_Regresar";
            TSMI_Regresar.Size = new Size(81, 24);
            TSMI_Regresar.Text = "Regresar";
            TSMI_Regresar.ToolTipText = "Volver al menu principal";
            TSMI_Regresar.Click += TSMI_Regresar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1135, 705);
            Controls.Add(Tab_Automata);
            Controls.Add(Barra_Menu);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Diseñador";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Page_Editor.ResumeLayout(false);
            Page_Editor.PerformLayout();
            Barra_Editor.ResumeLayout(false);
            Barra_Editor.PerformLayout();
            Tab_Automata.ResumeLayout(false);
            Page_Pasos.ResumeLayout(false);
            Page_Pasos.PerformLayout();
            TLP_Pasos.ResumeLayout(false);
            TLP_Pasos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Tabla_Transiciones).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            Barra_Menu.ResumeLayout(false);
            Barra_Menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabPage Page_Editor;
        private StatusStrip Barra_Editor;
        private ToolStripDropDownButton Editor_Seleccionar;
        private ToolStripDropDownButton Editor_Agregar;
        private ToolStripDropDownButton Editor_Eliminar;
        private ToolStripDropDownButton Editor_Conectar;
        private TabControl Tab_Automata;
        private TabPage Page_Pasos;
        private Button BT_Cancelar;
        private MenuStrip menuStrip1;
        private MenuStrip Barra_Menu;
        private ToolStripMenuItem TSMI_Archivo;
        private ToolStripMenuItem TSMI_Regresar;
        private ToolStripMenuItem TSMI_Probar;
        private ToolStripMenuItem Barra_EvaluarCadena;
        private ToolStripMenuItem Barra_PasoAPaso;
        private TableLayoutPanel TLP_Pasos;
        private DataGridView DGV_Tabla_Transiciones;
        private Label LB_Descripcion;
        private ToolStripMenuItem Barra_BTPaso;
        private ToolStripMenuItem TSMI_Determinismo;
    }
}