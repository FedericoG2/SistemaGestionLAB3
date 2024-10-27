namespace SistemaGestionLAB3.Vista
{
    partial class frmPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresupuesto));
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupCliente = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumPresu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecios = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.cmbTipoPresupuesto = new System.Windows.Forms.ComboBox();
            this.groupCliente.SuspendLayout();
            this.txtPrecio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::SistemaGestionLAB3.Properties.Resources.exporExcel;
            this.btnExportar.Location = new System.Drawing.Point(590, 416);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(104, 49);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Image = global::SistemaGestionLAB3.Properties.Resources.icoVolver;
            this.btnVolver.Location = new System.Drawing.Point(57, 420);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(103, 45);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // groupCliente
            // 
            this.groupCliente.Controls.Add(this.cmbTipoPresupuesto);
            this.groupCliente.Controls.Add(this.label4);
            this.groupCliente.Controls.Add(this.txtDireccion);
            this.groupCliente.Controls.Add(this.label3);
            this.groupCliente.Controls.Add(this.txtNumPresu);
            this.groupCliente.Controls.Add(this.label2);
            this.groupCliente.Controls.Add(this.txtNombreCliente);
            this.groupCliente.Controls.Add(this.label1);
            this.groupCliente.Location = new System.Drawing.Point(57, 12);
            this.groupCliente.Name = "groupCliente";
            this.groupCliente.Size = new System.Drawing.Size(637, 90);
            this.groupCliente.TabIndex = 4;
            this.groupCliente.TabStop = false;
            this.groupCliente.Text = "Datos Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo Presupuesto";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(277, 38);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(140, 20);
            this.txtDireccion.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Presupuesto N*";
            // 
            // txtNumPresu
            // 
            this.txtNumPresu.Location = new System.Drawing.Point(19, 38);
            this.txtNumPresu.Name = "txtNumPresu";
            this.txtNumPresu.Size = new System.Drawing.Size(100, 20);
            this.txtNumPresu.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Direccion";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(148, 38);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCliente.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Controls.Add(this.groupBox1);
            this.txtPrecio.Controls.Add(this.button2);
            this.txtPrecio.Controls.Add(this.label7);
            this.txtPrecio.Controls.Add(this.label6);
            this.txtPrecio.Controls.Add(this.label5);
            this.txtPrecio.Controls.Add(this.txtPrecios);
            this.txtPrecio.Controls.Add(this.txtCantidad);
            this.txtPrecio.Controls.Add(this.txtNombre);
            this.txtPrecio.Location = new System.Drawing.Point(57, 108);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(637, 84);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.TabStop = false;
            this.txtPrecio.Text = "Articulos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Articulos";
            // 
            // button1
            // 
            this.button1.Image = global::SistemaGestionLAB3.Properties.Resources.lupa;
            this.button1.Location = new System.Drawing.Point(18, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(68, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(87, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Image = global::SistemaGestionLAB3.Properties.Resources.imgCompras;
            this.button2.Location = new System.Drawing.Point(515, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cargar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Detalle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precio";
            // 
            // txtPrecios
            // 
            this.txtPrecios.Location = new System.Drawing.Point(395, 32);
            this.txtPrecios.Name = "txtPrecios";
            this.txtPrecios.Size = new System.Drawing.Size(91, 20);
            this.txtPrecios.TabIndex = 7;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(299, 32);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(80, 20);
            this.txtCantidad.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(190, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Location = new System.Drawing.Point(57, 200);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.Size = new System.Drawing.Size(637, 214);
            this.dgvPresupuesto.TabIndex = 6;
            // 
            // cmbTipoPresupuesto
            // 
            this.cmbTipoPresupuesto.FormattingEnabled = true;
            this.cmbTipoPresupuesto.Location = new System.Drawing.Point(453, 38);
            this.cmbTipoPresupuesto.Name = "cmbTipoPresupuesto";
            this.cmbTipoPresupuesto.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoPresupuesto.TabIndex = 7;
            // 
            // frmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.dgvPresupuesto);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.groupCliente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnExportar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presupuesto";
            this.Load += new System.EventHandler(this.frmPresupuesto_Load);
            this.groupCliente.ResumeLayout(false);
            this.groupCliente.PerformLayout();
            this.txtPrecio.ResumeLayout(false);
            this.txtPrecio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox groupCliente;
        private System.Windows.Forms.GroupBox txtPrecio;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNumPresu;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecios;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoPresupuesto;
    }
}