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
    public partial class FrmInventario : Form
    {
        clsStock StockNuevo;
        public FrmInventario()
        {
            InitializeComponent();


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
        private clsStock guardarDatos()
        {
            clsStock stockNuevo = new clsStock();

            int codProveedor = cmbProveedor.SelectedIndex;
            int codigoStock = 1;
            //si tiene codigo lo usa, sino le pone 1 
            int.TryParse(txtCodigo.Text, out codigoStock);


            stockNuevo.Id = codigoStock;
            stockNuevo.Nombre = txtCantidad.Text;
            stockNuevo.Precio = int.Parse(txtPrecio.Text);
            stockNuevo.Stock = int.Parse(txtCantidad.Text);
            stockNuevo.Id_Proveedor = codProveedor + 1;

            return stockNuevo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InventarioDAL objProductos = new InventarioDAL();
            clsStock nuevoStock = guardarDatos(); // Guarda el nuevo stock
            objProductos.Agregar(nuevoStock); // Agrega el nuevo producto a la base de datos

            // Actualiza la grilla
            objProductos.Listar(dgvInventario);


            LlenarGrilla();
            LimpiarCampos();

        }
        public void LlenarGrilla()
        {
            InventarioDAL objProductos = new InventarioDAL();
            objProductos.Listar(dgvInventario);
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            cmbProveedor.SelectedIndex = -1; // Restablecer el combo
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            InventarioDAL prueba = new InventarioDAL();
            prueba.ProbarConexion();
        }
        private clsStock eliminarDatos()
        {
            clsStock stockNuevo = new clsStock();

            if (int.TryParse(txtCodigo.Text, out int codigoStock))
            {
                stockNuevo.Id = codigoStock; // Solo asignar si la conversión fue exitosa
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un código de producto válido.");
                return null; // Retornar null si la entrada no es válida
            }

            return stockNuevo;

        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {

            InventarioDAL produc = new InventarioDAL();
            produc.Eliminar(eliminarDatos());

            txtCodigo.Clear();
            LlenarGrilla();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            LlenarGrilla();
        }
    }
}
