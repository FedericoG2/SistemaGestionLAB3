namespace SistemaGestionLAB3.Vista
{
    partial class frmEliminarPresu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEliminarPresu));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroPresu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarPresu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Presupuesto Numero";
            // 
            // txtNumeroPresu
            // 
            this.txtNumeroPresu.Location = new System.Drawing.Point(6, 46);
            this.txtNumeroPresu.Name = "txtNumeroPresu";
            this.txtNumeroPresu.Size = new System.Drawing.Size(137, 20);
            this.txtNumeroPresu.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnEliminarPresu);
            this.groupBox1.Controls.Add(this.txtNumeroPresu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(46, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar Presupusto";
            // 
            // btnEliminarPresu
            // 
            this.btnEliminarPresu.Image = global::SistemaGestionLAB3.Properties.Resources.eliminar;
            this.btnEliminarPresu.Location = new System.Drawing.Point(31, 82);
            this.btnEliminarPresu.Name = "btnEliminarPresu";
            this.btnEliminarPresu.Size = new System.Drawing.Size(84, 39);
            this.btnEliminarPresu.TabIndex = 1;
            this.btnEliminarPresu.Text = "Eliminar";
            this.btnEliminarPresu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarPresu.UseVisualStyleBackColor = true;
            this.btnEliminarPresu.Click += new System.EventHandler(this.btnEliminarPresu_Click);
            // 
            // frmEliminarPresu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 191);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEliminarPresu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Presupuesto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarPresu;
        private System.Windows.Forms.TextBox txtNumeroPresu;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}