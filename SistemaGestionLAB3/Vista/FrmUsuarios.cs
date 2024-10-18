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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //Para manejar la seleccion de un usuario en la datagrid view y luego apretar el boton editar
            DgvUsuarios.CellClick += DgvUsuarios_CellClick;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                DbLogin login = new DbLogin();
                login.CargarUsuariosEnGrid(DgvUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioIdSeleccionado != -1) 
            {
                FrmEditarUsuario editarUsuarioForm = new FrmEditarUsuario(usuarioIdSeleccionado);
                editarUsuarioForm.ShowDialog();

                // Volver a cargar la grilla después de cerrar el formulario
                DbLogin login = new DbLogin();
                login.CargarUsuariosEnGrid(DgvUsuarios);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int usuarioIdSeleccionado = -1; // Variable para almacenar el ID del usuario seleccionado

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                usuarioIdSeleccionado = Convert.ToInt32(DgvUsuarios.Rows[e.RowIndex].Cells["ID"].Value);
            }
        }
        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén los datos del usuario por el ID
                int idUsuario = Convert.ToInt32(DgvUsuarios.Rows[e.RowIndex].Cells["ID"].Value);

                // Abre el formulario de editar
                FrmEditarUsuario frmEditar = new FrmEditarUsuario(idUsuario);
                frmEditar.ShowDialog();

                // Volver a cargar la grilla después de cerrar el formulario
                DbLogin login = new DbLogin();
                login.CargarUsuariosEnGrid(DgvUsuarios);
            }
        }
    }
}
