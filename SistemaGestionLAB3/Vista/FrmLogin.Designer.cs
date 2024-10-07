namespace SistemaGestionLAB3
{
    partial class FrmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkOlvideContraseña = new System.Windows.Forms.LinkLabel();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.linkOlvideContraseña);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.btnRegistrarse);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(445, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 303);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicio de Sesión";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // linkOlvideContraseña
            // 
            this.linkOlvideContraseña.AutoSize = true;
            this.linkOlvideContraseña.Location = new System.Drawing.Point(91, 161);
            this.linkOlvideContraseña.Name = "linkOlvideContraseña";
            this.linkOlvideContraseña.Size = new System.Drawing.Size(106, 13);
            this.linkOlvideContraseña.TabIndex = 5;
            this.linkOlvideContraseña.TabStop = true;
            this.linkOlvideContraseña.Text = "Olvidé mi contraseña";
            this.linkOlvideContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOlvideContraseña_LinkClicked);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(60, 128);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(196, 20);
            this.txtContraseña.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(60, 79);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(196, 20);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaGestionLAB3.Properties.Resources.imgPrincipal;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 303);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Image = global::SistemaGestionLAB3.Properties.Resources.entar;
            this.btnIngresar.Location = new System.Drawing.Point(28, 202);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(99, 64);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Image = global::SistemaGestionLAB3.Properties.Resources.imgUsuarios;
            this.btnRegistrarse.Location = new System.Drawing.Point(157, 202);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(99, 64);
            this.btnRegistrarse.TabIndex = 4;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 335);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel linkOlvideContraseña;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

