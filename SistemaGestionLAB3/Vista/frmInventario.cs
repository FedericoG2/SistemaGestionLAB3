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
    public partial class frmInventario : Form
    {

        
        public frmInventario()
        {
            InitializeComponent();
            LlenarGrilla();

            cmbProveedor.Items.Clear();
            cmbProveedor.Items.Add("MagicCloth");
            cmbProveedor.Items.Add("Importados");
            cmbProveedor.Items.Add("C.A");

        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void LlenarGrilla()
        {
            InventarioDAL objProductos = new InventarioDAL();
            objProductos.Listar(dgvInventario);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
