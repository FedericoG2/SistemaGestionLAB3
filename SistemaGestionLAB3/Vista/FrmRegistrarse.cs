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
    public partial class FrmRegistrarse : Form
    {
        public FrmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtContraseña.Text;

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario y una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al método para registrar el usuario
            DbLogin dbLogin = new DbLogin();
            bool registroExitoso = dbLogin.RegistrarUsuario(nombreUsuario, password);

            // Si el registro fue exitoso, cerrar el formulario actual y abrir el formulario de inicio de sesión
            if (registroExitoso)
            {
                this.Hide();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
        }
    }
}
