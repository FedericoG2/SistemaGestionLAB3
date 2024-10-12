using SistemaGestionLAB3.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Vista
{
    public partial class FrmOlvideContraseña : Form
    {
        public FrmOlvideContraseña()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmOlvideContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cancela el formulario y abre el Login
            FrmLogin frmLogin = new FrmLogin();
            this.Close();
            frmLogin.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            string nombre = txtNombreUsuario.Text;
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, rellene ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbLogin dbLogin = new DbLogin();
            bool exito = dbLogin.OlvideContraseña(nombre, password);
            if (exito)
            {
                MessageBox.Show("Contraseña cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLogin.Show();
            }
            else
            {
                MessageBox.Show("No se encontró el usuario especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
