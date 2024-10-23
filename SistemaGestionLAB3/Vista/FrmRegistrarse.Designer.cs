namespace SistemaGestionLAB3.Vista
{
    partial class FrmRegistrarse
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.panelFirma = new System.Windows.Forms.Panel();
            this.lblIngreseFirma = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNuevaContraseña = new System.Windows.Forms.Label();
            this.lblNuevoNombre = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.panelFirma);
            this.groupBox1.Controls.Add(this.lblIngreseFirma);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnRegistrarse);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.lblNuevaContraseña);
            this.groupBox1.Controls.Add(this.lblNuevoNombre);
            this.groupBox1.Location = new System.Drawing.Point(683, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(424, 486);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Registro";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(14, 339);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(112, 35);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "Borrar Firma";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // panelFirma
            // 
            this.panelFirma.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelFirma.Location = new System.Drawing.Point(14, 226);
            this.panelFirma.Name = "panelFirma";
            this.panelFirma.Size = new System.Drawing.Size(403, 105);
            this.panelFirma.TabIndex = 8;
            // 
            // lblIngreseFirma
            // 
            this.lblIngreseFirma.AutoSize = true;
            this.lblIngreseFirma.Location = new System.Drawing.Point(10, 203);
            this.lblIngreseFirma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngreseFirma.Name = "lblIngreseFirma";
            this.lblIngreseFirma.Size = new System.Drawing.Size(132, 20);
            this.lblIngreseFirma.TabIndex = 7;
            this.lblIngreseFirma.Text = "Ingrese su Firma:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SistemaGestionLAB3.Properties.Resources.imgCerrar;
            this.btnCancelar.Location = new System.Drawing.Point(241, 403);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 73);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Image = global::SistemaGestionLAB3.Properties.Resources.imgUsuarios;
            this.btnRegistrarse.Location = new System.Drawing.Point(52, 403);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(152, 73);
            this.btnRegistrarse.TabIndex = 4;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(14, 152);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(292, 26);
            this.txtContraseña.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(14, 77);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(292, 26);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // lblNuevaContraseña
            // 
            this.lblNuevaContraseña.AutoSize = true;
            this.lblNuevaContraseña.Location = new System.Drawing.Point(9, 128);
            this.lblNuevaContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevaContraseña.Name = "lblNuevaContraseña";
            this.lblNuevaContraseña.Size = new System.Drawing.Size(168, 20);
            this.lblNuevaContraseña.TabIndex = 1;
            this.lblNuevaContraseña.Text = "Ingrese su contraseña";
            // 
            // lblNuevoNombre
            // 
            this.lblNuevoNombre.AutoSize = true;
            this.lblNuevoNombre.Location = new System.Drawing.Point(9, 52);
            this.lblNuevoNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevoNombre.Name = "lblNuevoNombre";
            this.lblNuevoNombre.Size = new System.Drawing.Size(220, 20);
            this.lblNuevoNombre.TabIndex = 0;
            this.lblNuevoNombre.Text = "Ingrese su nombre de usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaGestionLAB3.Properties.Resources.imgPrincipal;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(654, 477);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRegistrarse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRegistrarse";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.FrmRegistrarse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblNuevaContraseña;
        private System.Windows.Forms.Label lblNuevoNombre;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel panelFirma;
        private System.Windows.Forms.Label lblIngreseFirma;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}