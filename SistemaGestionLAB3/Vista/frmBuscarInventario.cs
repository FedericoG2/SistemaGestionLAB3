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
    public partial class frmBuscarInventario : Form
    {
        public frmBuscarInventario()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtCodigo.Text);

            InventarioDAL buscarArticulo = new InventarioDAL();

            DataTable resultados = buscarArticulo.BuscarPorCodigo(codigo); // Obtiene los resultados

            // Verifica si se encontraron resultados
            if (resultados.Rows.Count > 0)
            {
                dgvArticulos.DataSource = resultados; // Asigna el DataTable al DataGridView
                txtCodigo.Clear();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }
        }

        private void btbBuscarDescrp_Click(object sender, EventArgs e)
        {
            string Nombre = txtDescripcion.Text;

            InventarioDAL buscarArticuloNombre = new InventarioDAL();

            DataTable resultados = buscarArticuloNombre.BuscarPorNombre(Nombre); // Obtiene los resultados

            // Verifica si se encontraron resultados
            if (resultados.Rows.Count > 0)
            {
                dgvArticulos.DataSource = resultados; // Asigna el DataTable al DataGridView
                txtCodigo.Clear();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }

        }
    }
}
