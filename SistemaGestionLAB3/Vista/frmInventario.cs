using SistemaGestionLAB3.Controlador;
using System;
using System.Collections;
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
        clsStock StockNuevo; 
        
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
        private clsStock guardarDatos()
        {
            clsStock stockNuevo = new clsStock();

            int codProveedor = cmbProveedor.SelectedIndex; 
            int codigoStock = 1;
            //si tiene codigo lo usa, sino le pone 1 
            int.TryParse(txtCodigo.Text, out codigoStock);


            stockNuevo.Id = codigoStock;
            stockNuevo.Nombre = txtDescripcion.Text;
            stockNuevo.Precio = int.Parse(txtPrecio.Text);
            stockNuevo.Stock = int.Parse(txtCantidad.Text);
            stockNuevo.Id_Proveedor = codProveedor + 1 ;

            return stockNuevo;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InventarioDAL objProductos = new InventarioDAL();
            clsStock nuevoStock = guardarDatos(); // Guarda el nuevo stock
            objProductos.Agregar(nuevoStock); // Agrega el nuevo producto a la base de datos

            // Actualiza la grilla
            objProductos.Listar(dgvInventario);



            // limpiar();  
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
