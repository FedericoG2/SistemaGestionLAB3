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
    public partial class FrmEditarUsuario : Form
    {
        private int IdUsuario;
        public FrmEditarUsuario(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            IdUsuario = idUsuario;
            CargarComboBoxRol();
            CargarDatos();
        }
        private void CargarDatos()
        {
            DbLogin dbLogin = new DbLogin();
            dbLogin.DatosUsuario(IdUsuario,txtNombre,txtUsername,txtContraseña,txtMail,cmbRol);
        }
        private void CargarComboBoxRol()
        {
            try
            {
                DbRol dbRol = new DbRol();
                var roles = dbRol.ObtenerTodosLosRoles();

                //Limpiar el ComboBox y cargarlo
                cmbRol.DataSource = null; // Limpia cualquier DataSource anterior
                cmbRol.Items.Clear();

                // Asignar la fuente de datos
                cmbRol.DataSource = roles.Select(r => new { Id = r.Id, NombreRol = r.NombreRol }).ToList();
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DbLogin dbLogin = new DbLogin();
                dbLogin.ModificarUsuario(IdUsuario, txtNombre.Text, txtUsername.Text, txtMail.Text, txtContraseña.Text, cmbRol.SelectedValue.ToString());
            }


        }
    }
}
