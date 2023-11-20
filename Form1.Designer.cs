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
            statusStrip1 = new StatusStrip();
            Barra_Archivo = new ToolStripSplitButton();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            Barra_Probar = new ToolStripSplitButton();
            Barra_EvaluarCadena = new ToolStripMenuItem();
            Barra_PasoAPaso = new ToolStripMenuItem();
            Barra_Regresar = new ToolStripStatusLabel();
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
            statusStrip1.SuspendLayout();
            Page_Editor.SuspendLayout();
            Barra_Editor.SuspendLayout();
            Tab_Automata.SuspendLayout();
            Page_Pasos.SuspendLayout();
            TLP_Pasos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Tabla_Transiciones).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Top;
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { Barra_Archivo, Barra_Probar, Barra_Regresar });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(993, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "Archivo";
            // 
            // Barra_Archivo
            // 
            Barra_Archivo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Barra_Archivo.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, abrirToolStripMenuItem, guardarToolStripMenuItem });
            Barra_Archivo.Image = (Image)resources.GetObject("Barra_Archivo.Image");
            Barra_Archivo.ImageTransparentColor = Color.Magenta;
            Barra_Archivo.Name = "Barra_Archivo";
            Barra_Archivo.Size = new Size(64, 20);
            Barra_Archivo.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.Size = new Size(116, 22);
            nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(116, 22);
            abrirToolStripMenuItem.Text = "Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(116, 22);
            guardarToolStripMenuItem.Text = "Guardar";
            // 
            // Barra_Probar
            // 
            Barra_Probar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Barra_Probar.DropDownItems.AddRange(new ToolStripItem[] { Barra_EvaluarCadena, Barra_PasoAPaso });
            Barra_Probar.Image = (Image)resources.GetObject("Barra_Probar.Image");
            Barra_Probar.ImageTransparentColor = Color.Magenta;
            Barra_Probar.Name = "Barra_Probar";
            Barra_Probar.Size = new Size(58, 20);
            Barra_Probar.Tag = "Ingresa una cadena para evaluar el automata";
            Barra_Probar.Text = "Probar";
            // 
            // Barra_EvaluarCadena
            // 
            Barra_EvaluarCadena.Name = "Barra_EvaluarCadena";
            Barra_EvaluarCadena.Size = new Size(153, 22);
            Barra_EvaluarCadena.Text = "Evaluar cadena";
            Barra_EvaluarCadena.Click += Barra_EvaluarCadena_Click;
            // 
            // Barra_PasoAPaso
            // 
            Barra_PasoAPaso.Name = "Barra_PasoAPaso";
            Barra_PasoAPaso.Size = new Size(153, 22);
            Barra_PasoAPaso.Text = "Paso a Paso";
            Barra_PasoAPaso.Click += Barra_PasoAPaso_Click;
            // 
            // Barra_Regresar
            // 
            Barra_Regresar.Name = "Barra_Regresar";
            Barra_Regresar.Size = new Size(98, 17);
            Barra_Regresar.Text = "Regresar al menu";
            Barra_Regresar.ToolTipText = "Regresa al menu principal";
            Barra_Regresar.Click += Barra_Regresar_Click;
            // 
            // Page_Editor
            // 
            Page_Editor.BackColor = Color.White;
            Page_Editor.Controls.Add(Barra_Editor);
            Page_Editor.Location = new Point(4, 24);
            Page_Editor.Name = "Page_Editor";
            Page_Editor.Padding = new Padding(3);
            Page_Editor.Size = new Size(985, 479);
            Page_Editor.TabIndex = 0;
            Page_Editor.Text = "Editor";
            // 
            // Barra_Editor
            // 
            Barra_Editor.Dock = DockStyle.Top;
            Barra_Editor.ImageScalingSize = new Size(24, 24);
            Barra_Editor.Items.AddRange(new ToolStripItem[] { Editor_Seleccionar, Editor_Agregar, Editor_Eliminar, Editor_Conectar });
            Barra_Editor.Location = new Point(3, 3);
            Barra_Editor.Name = "Barra_Editor";
            Barra_Editor.RenderMode = ToolStripRenderMode.Professional;
            Barra_Editor.Size = new Size(979, 22);
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
            Editor_Seleccionar.Size = new Size(71, 20);
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
            Editor_Agregar.Size = new Size(53, 20);
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
            Editor_Eliminar.Size = new Size(54, 20);
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
            Editor_Conectar.Size = new Size(59, 20);
            Editor_Conectar.Text = "Conectar";
            Editor_Conectar.Click += Editor_Conectar_Click;
            // 
            // Tab_Automata
            // 
            Tab_Automata.Controls.Add(Page_Editor);
            Tab_Automata.Controls.Add(Page_Pasos);
            Tab_Automata.Dock = DockStyle.Fill;
            Tab_Automata.Location = new Point(0, 22);
            Tab_Automata.Name = "Tab_Automata";
            Tab_Automata.SelectedIndex = 0;
            Tab_Automata.Size = new Size(993, 507);
            Tab_Automata.TabIndex = 1;
            Tab_Automata.Selecting += Tab_Automata_Selecting;
            // 
            // Page_Pasos
            // 
            Page_Pasos.Controls.Add(BT_Cancelar);
            Page_Pasos.Controls.Add(TLP_Pasos);
            Page_Pasos.Location = new Point(4, 24);
            Page_Pasos.Name = "Page_Pasos";
            Page_Pasos.Padding = new Padding(3);
            Page_Pasos.Size = new Size(985, 479);
            Page_Pasos.TabIndex = 1;
            Page_Pasos.Text = "Paso a Paso";
            Page_Pasos.UseVisualStyleBackColor = true;
            // 
            // BT_Cancelar
            // 
            BT_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_Cancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BT_Cancelar.ForeColor = Color.Red;
            BT_Cancelar.Location = new Point(954, 8);
            BT_Cancelar.Name = "BT_Cancelar";
            BT_Cancelar.Size = new Size(23, 23);
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
            TLP_Pasos.Dock = DockStyle.Fill;
            TLP_Pasos.Location = new Point(3, 3);
            TLP_Pasos.Name = "TLP_Pasos";
            TLP_Pasos.RowCount = 1;
            TLP_Pasos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLP_Pasos.Size = new Size(979, 473);
            TLP_Pasos.TabIndex = 0;
            // 
            // DGV_Tabla_Transiciones
            // 
            DGV_Tabla_Transiciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Tabla_Transiciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGV_Tabla_Transiciones.Dock = DockStyle.Fill;
            DGV_Tabla_Transiciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGV_Tabla_Transiciones.Location = new Point(3, 3);
            DGV_Tabla_Transiciones.Name = "DGV_Tabla_Transiciones";
            DGV_Tabla_Transiciones.RowHeadersVisible = false;
            DGV_Tabla_Transiciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV_Tabla_Transiciones.RowTemplate.Height = 25;
            DGV_Tabla_Transiciones.Size = new Size(307, 467);
            DGV_Tabla_Transiciones.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(993, 529);
            Controls.Add(Tab_Automata);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Diseñador";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            Page_Editor.ResumeLayout(false);
            Page_Editor.PerformLayout();
            Barra_Editor.ResumeLayout(false);
            Barra_Editor.PerformLayout();
            Tab_Automata.ResumeLayout(false);
            Page_Pasos.ResumeLayout(false);
            TLP_Pasos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGV_Tabla_Transiciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripSplitButton Barra_Archivo;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripSplitButton Barra_Probar;
        private ToolStripStatusLabel Barra_Regresar;
        private TabPage Page_Editor;
        private StatusStrip Barra_Editor;
        private ToolStripDropDownButton Editor_Seleccionar;
        private ToolStripDropDownButton Editor_Agregar;
        private ToolStripDropDownButton Editor_Eliminar;
        private ToolStripDropDownButton Editor_Conectar;
        private TabControl Tab_Automata;
        private TabPage Page_Pasos;
        private TableLayoutPanel TLP_Pasos;
        private Button BT_Cancelar;
        private ToolStripMenuItem Barra_EvaluarCadena;
        private ToolStripMenuItem Barra_PasoAPaso;
        private DataGridView DGV_Tabla_Transiciones;
    }
}