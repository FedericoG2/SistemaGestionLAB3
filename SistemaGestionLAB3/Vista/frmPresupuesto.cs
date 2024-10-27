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
    public partial class frmPresupuesto : Form
    {

        Cls_dbPresupuesto nuevoPresupuesto;
        public frmPresupuesto()
        {
            InitializeComponent();
            listarGrilla();
           


            cmbTipoPresupuesto.Items.Clear();
            cmbTipoPresupuesto.Items.Add("Aprobado");
            cmbTipoPresupuesto.Items.Add("Provisional");
            cmbTipoPresupuesto.Items.Add("Rechazado");

            txtNumPresu.Enabled = false;

        }
        private void ExportarDatos()
        {
            if (cmbTipoPresupuesto.SelectedItem != null) // Asegúrate de que hay un tipo seleccionado
            {
                clsArcInventario presupuesto = new clsArcInventario();

                string textoSeleccionado = cmbTipoPresupuesto.SelectedItem.ToString();

                presupuesto.grabarPresupuestos(
                    txtNumPresu.Text,
                    txtNombreCliente.Text,
                    txtDireccion.Text,
                    textoSeleccionado,
                    txtNombre.Text,
                    txtCantidad.Text,
                    txtPrecios.Text
                );

                MessageBox.Show("Cargados");
            }
            else
            {
                MessageBox.Show("Seleccione un tipo de presupuesto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
        
            
        }

        private void frmPresupuesto_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "") { 
            int Codigo =int.Parse(txtCodigo.Text);

            ClsPresupuesto buscarArticulos = new ClsPresupuesto();
            DataTable resultado = buscarArticulos.BucarArticulos(Codigo);

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                txtNombre.Text = row["Nombre"].ToString();
                txtCantidad.Text = row["Stock"].ToString();
                txtPrecios.Text = row["Precio_Venta"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el código ingresado.");
            }
            }
            else
            {
                MessageBox.Show("Complete Codigo Articulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Cls_dbPresupuesto guardarDatos()
        {
            Cls_dbPresupuesto nuevoPresupuesto = new Cls_dbPresupuesto();

            string tipoPresupuesto = cmbTipoPresupuesto.SelectedItem.ToString(); 


            int codigoStock = 1;
            //si tiene codigo lo usa, sino le pone 1 
            int.TryParse(txtCodigo.Text, out codigoStock);


            nuevoPresupuesto.Id = codigoStock;
            nuevoPresupuesto.Nombre = txtNombreCliente.Text;
            nuevoPresupuesto.Direccion = txtDireccion.Text;
            nuevoPresupuesto.Tipo_Presupuesto = tipoPresupuesto;
            nuevoPresupuesto.detalleArticulo = txtNombre.Text;
            nuevoPresupuesto.Cantidad = txtCantidad.Text;  
            nuevoPresupuesto.Precio = txtPrecios.Text;



            return nuevoPresupuesto;
        }
        private void listarGrilla()
        {
            ClsPresupuesto listar = new ClsPresupuesto();
            listar.Listar(dgvPresupuesto);
        }
       
        private void limpiarDatos()
        {
            txtCantidad.Clear();
            txtDireccion.Clear();
            cmbTipoPresupuesto.SelectedIndex = -1;
            txtCodigo.Clear();  
            txtNombre.Clear();
            txtCantidad.Clear();
            txtPrecios.Clear();
            txtNombreCliente.Clear();
           
                
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
            
            if(txtNombreCliente.Text != "" && txtDireccion.Text != "" && txtNombre.Text != "" && txtCantidad.Text != "" && txtPrecios.Text != "" && cmbTipoPresupuesto.SelectedItem != null) 
            { 
            ClsPresupuesto nuevoPresupuesto = new ClsPresupuesto();
            Cls_dbPresupuesto nuevoPresu = guardarDatos(); // Guarda el nuevo stock
            nuevoPresupuesto.AgregarPresupuesto(nuevoPresu); // Agrega el nuevo producto a la base de datos
                ExportarDatos();
                limpiarDatos();
                listarGrilla();

                

            }
            else
            {
                MessageBox.Show("Complete Todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiarDatos();
            }


        
        }

        private void btnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            frmBuscarPresupuesto frmBuscar = new frmBuscarPresupuesto();
            frmBuscar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminarPresu eliminarPresu = new frmEliminarPresu();
            eliminarPresu.ShowDialog();
            listarGrilla();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
