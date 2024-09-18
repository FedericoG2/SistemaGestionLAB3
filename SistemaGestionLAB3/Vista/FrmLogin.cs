using SistemaGestionLAB3.Controlador;
using SistemaGestionLAB3.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string passUsuario = txtContraseña.Text;

            // instanciamos la clase
            DbLogin dbLogin = new DbLogin();
            if (dbLogin.VerificarUsuario(nombreUsuario, passUsuario))
            {
                MessageBox.Show("Ingreso exitoso!", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkOlvideContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOlvideContraseña frmOlvideContraseña = new FrmOlvideContraseña();
            frmOlvideContraseña.ShowDialog();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistrarse frmRegistrarse = new FrmRegistrarse();
            frmRegistrarse.ShowDialog();
        }
    }
}
