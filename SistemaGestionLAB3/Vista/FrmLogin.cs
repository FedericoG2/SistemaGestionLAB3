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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
        if (txtContraseña.Text == "" || txtNombreUsuario.Text == "")
        {
            MessageBox.Show("Ingrese Datos Necesarios"); 
        }
        else
        {
           string nombreUsuario = txtNombreUsuario.Text;
           string passUsuario = txtContraseña.Text;

           //// instanciamos la clase
           DbLogin dbLogin = new DbLogin();
           if (dbLogin.VerificarUsuario(nombreUsuario, passUsuario))
           {
                MessageBox.Show("Ingreso exitoso!", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Crear el formulario de carga
                FrmInicio inicioForm = new FrmInicio();

                // Mostrar el formulario de carga de manera no modal
                inicioForm.Show();
           }
           else
           {
                MessageBox.Show("Usuario o contraseña incorrecto!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
          }
        }

        private void linkOlvideContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmOlvideContraseña frmOlvideContraseña = new FrmOlvideContraseña();
            frmOlvideContraseña.ShowDialog();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //Muestra el formulario de registro
            FrmRegistrarse frmRegistrarse = new FrmRegistrarse();
            frmRegistrarse.ShowDialog();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
