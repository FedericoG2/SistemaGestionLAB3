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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            DbClientes conexion = new DbClientes();
            conexion.MostrarClientes(dgvClientes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombre.Text.Trim(); // Obtener el nombre del cliente desde el TextBox
            int? cantidad = null;

            // Intenta convertir el texto de cantidad a un número entero
            if (int.TryParse(txtCantidad.Text.Trim(), out int resultado))
            {
                cantidad = resultado; // Si se puede convertir, asigna el valor
            }

            DbClientes dbClientes = new DbClientes();
            bool resultadosEncontrados = false;

            // Verifica qué campo se ha completado para decidir qué búsqueda realizar
            if (!string.IsNullOrEmpty(nombreCliente))
            {
                // Buscar solo por nombre
                resultadosEncontrados = dbClientes.BuscarClientePorNombre(dgvClientes, nombreCliente);
            }

            if (cantidad.HasValue && !resultadosEncontrados)
            {
                // Buscar solo por cantidad si no se encontraron resultados en la búsqueda por nombre
                resultadosEncontrados = dbClientes.BuscarClientePorCantidad(dgvClientes, cantidad.Value);
            }

            // Mensaje si ambos campos están vacíos
            if (string.IsNullOrEmpty(nombreCliente) && !cantidad.HasValue)
            {
                MessageBox.Show("Por favor, ingrese un nombre de cliente o una cantidad válida para buscar.", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!resultadosEncontrados)
            {
                // Mensaje si no se encontraron resultados en la base de datos
                MessageBox.Show("No se encontraron datos que coincidan con la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
