using SistemaGestionLAB3.Controlador;
using SistemaGestionLAB3.SistemaGestionLAB3.Controlador;
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
    public partial class FrmInventario : Form
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

            // Actualiza la dgvInventario
            objProductos.Listar(dgvInventario);


            LlenarGrilla();
            LimpiarCampos();  

        }
     
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice1 = e.RowIndex;
            dgvInventario.ClearSelection();

            if (indice1 >= 0)
            {
                dgvInventario.Rows[indice1].Selected = true;

                
                txtCodigo.Text = dgvInventario.Rows[indice1].Cells[0].Value?.ToString() ?? string.Empty;
                txtDescripcion.Text = dgvInventario.Rows[indice1].Cells[1].Value?.ToString() ?? string.Empty;
                txtCantidad.Text = dgvInventario.Rows[indice1].Cells[2].Value?.ToString() ?? string.Empty;
                txtPrecio.Text = dgvInventario.Rows[indice1].Cells[3].Value?.ToString() ?? string.Empty;

                int proveedorIndex = (int)dgvInventario.Rows[indice1].Cells[4].Value - 1;

                
                if (proveedorIndex >= 0 && proveedorIndex < cmbProveedor.Items.Count)
                {
                    
                    cmbProveedor.Text = cmbProveedor.Items[proveedorIndex].ToString();
                }
                else
                {
                    
                    cmbProveedor.Text = string.Empty; 
                }
            }

            btnModificar.Enabled = true;
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            InventarioDAL objProductos = new InventarioDAL();
            objProductos.Modificar(guardarDatos());


            LimpiarCampos();
            LlenarGrilla();
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
                MessageBox.Show("ingresa un código  válido.");
                return null; 
            }

            return stockNuevo;



        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
            InventarioDAL produc = new InventarioDAL();
            produc.Eliminar(eliminarDatos());

            txtCodigo.Clear();
            LlenarGrilla();
            LimpiarCampos();

        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            cmbProveedor.SelectedIndex = -1; // Restablecer el combo
        }
       

        //private void btnExportar_Click_1(object sender, EventArgs e)
        //{

        //    string proveedor = cmbProveedor.Text;
        //    int Codigo = Convert.ToInt32(txtCodigo.Text);
        //    int  Stock = Convert.ToInt32(txtCantidad.Text);
        //    int precio = Convert.ToInt32(txtPrecio.Text);
        //    //Enviar los datos escritos en la agenada para exportar
        //    archivInventario.Grabar(Codigo, txtDescripcion.Text,
        //    Stock,proveedor , precio );
        //    MessageBox.Show("Datos listos para exportar");

        //    LimpiarCampos();
        //}
    }
}
