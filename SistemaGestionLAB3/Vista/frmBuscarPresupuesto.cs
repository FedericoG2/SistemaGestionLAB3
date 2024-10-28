using SistemaGestionLAB3.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Vista
{
    public partial class frmBuscarPresupuesto : Form
    {
        public frmBuscarPresupuesto()
        {
            InitializeComponent();
        }

       

        private void btnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtNumeroPresupuesto.Text);
            
            ClsPresupuesto buscarPresupuesto = new ClsPresupuesto();

            DataTable resultados = buscarPresupuesto.BuscarPorCodigo(codigo); // Obtiene los resultados

            // Verifica si se encontraron resultados
            if (resultados.Rows.Count > 0)
            {
                dgvBuscar.DataSource = resultados; // Asigna el DataTable al DataGridView
                txtNumeroPresupuesto.Clear();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombreCliente.Text;

            ClsPresupuesto buscarPresupuesto = new ClsPresupuesto();

            DataTable resultados = buscarPresupuesto.BuscarPorNombre(Nombre); // Obtiene los resultados

            // Verifica si se encontraron resultados
            if (resultados.Rows.Count > 0)
            {
                dgvBuscar.DataSource = resultados; // Asigna el DataTable al DataGridView
                txtNombreCliente.Clear();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnBuscarArt_Click(object sender, EventArgs e)
        {
            string NombreArt = txtArticulo.Text;

            ClsPresupuesto buscarPresupuesto = new ClsPresupuesto();

            DataTable resultados = buscarPresupuesto.BuscarPorArt(NombreArt); // Obtiene los resultados

            // Verifica si se encontraron resultados
            if (resultados.Rows.Count > 0)
            {
                dgvBuscar.DataSource = resultados; // Asigna el DataTable al DataGridView
                txtArticulo.Clear();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }
        }
    }
}
