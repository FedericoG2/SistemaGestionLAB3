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
            llenarGrilla();

            cmbProveedor.Items.Clear();
            cmbProveedor.Items.Add("MagicCloth");
            cmbProveedor.Items.Add("Importados");
            cmbProveedor.Items.Add("C.A");

        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public void llenarGrilla()
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

            // Actualiza la dgvInventario
            objProductos.Listar(dgvInventario);


            llenarGrilla();
            LimpiarCampos();  
        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            cmbProveedor.SelectedIndex = -1; // Restablecer el combo
        }
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            InventarioDAL objProductos = new InventarioDAL();
            objProductos.Modificar(guardarDatos());

            LimpiarCampos();


            llenarGrilla();
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
            llenarGrilla();
            LimpiarCampos();
        }

        private void seleccionar(object sender, DataGridViewCellEventArgs e)
        {

            int indice1 = e.RowIndex;
            dgvInventario.ClearSelection();

            
            if (indice1 >= 0)
            {
                txtCodigo.Text = dgvInventario.Rows[indice1].Cells[0].Value.ToString();
                txtDescripcion.Text = dgvInventario.Rows[indice1].Cells[1].Value.ToString();
                txtCantidad.Text = dgvInventario.Rows[indice1].Cells[3].Value.ToString();
                txtPrecio.Text = dgvInventario.Rows[indice1].Cells[2].Value.ToString();
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Instancia para la conexion
           InventarioDAL conexion = new InventarioDAL();
            // DataTable para almacenar datos de la BD 
            DataTable resultadoBusqueda = new DataTable();

            int codigo = int.Parse(txtCodigo.Text);

            resultadoBusqueda = conexion.BuscarPorCodigo(codigo);

            dgvInventario.DataSource = resultadoBusqueda;
            LimpiarCampos();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            clsArcInventario obj= new clsArcInventario();

            string textoSeleccionado = cmbProveedor.SelectedItem.ToString();

            obj.grabar(txtCodigo.Text, txtDescripcion.Text, txtCantidad.Text,txtPrecio.Text, textoSeleccionado); ;
            MessageBox.Show("Cargados");
            LimpiarCampos();

        }
    }
}
