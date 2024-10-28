using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Controlador
{
    internal class DbClientes
    {
        private string ruta = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=ModeloDB\Inventario_db.accdb";

        public void MostrarClientes (DataGridView dgvClientes) 
        {
            try 
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    using (OleDbCommand comando = new OleDbCommand())
                    {
                        comando.Connection = conexion;

                        // Consulta con JOIN para obtener los datos del inventario y los nombres de los proveedores
                        comando.CommandText = @"SELECT Clientes.Nombre, Clientes.Gmail, Clientes.Telefono, SubConsulta.Cantidad
                        FROM Clientes
                        INNER JOIN (
                            SELECT [Cliente-Compra].IdCliente, Compras.Cantidad
                            FROM [Cliente-Compra]
                            INNER JOIN Compras ON [Cliente-Compra].Id_Compra = Compras.Id_Compra
                        ) AS SubConsulta ON Clientes.IdCliente = SubConsulta.IdCliente;";
                        // Adaptar los datos
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            DataSet ds = new DataSet();
                            adaptador.Fill(ds);
                            dgvClientes.DataSource = ds.Tables[0]; // Muestra los datos en el DataGridView
                        }
                    }

                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        
        }

        public bool BuscarClientePorNombre(DataGridView dgvClientes, string nombreCliente)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    using (OleDbCommand comando = new OleDbCommand())
                    {
                        comando.Connection = conexion;

                        // Consulta para buscar por nombre de cliente
                        comando.CommandText = @"SELECT Clientes.Nombre, Clientes.Gmail, Clientes.Telefono, SubConsulta.Cantidad
                                        FROM Clientes
                                        INNER JOIN (
                                            SELECT [Cliente-Compra].IdCliente, Compras.Cantidad
                                            FROM [Cliente-Compra]
                                            INNER JOIN Compras ON [Cliente-Compra].Id_Compra = Compras.Id_Compra
                                        ) AS SubConsulta ON Clientes.IdCliente = SubConsulta.IdCliente
                                        WHERE Clientes.Nombre LIKE @NombreCliente";

                        // Añadir el parámetro para la búsqueda
                        comando.Parameters.AddWithValue("@NombreCliente", "%" + nombreCliente + "%");

                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            DataSet ds = new DataSet();
                            adaptador.Fill(ds);
                            dgvClientes.DataSource = ds.Tables[0]; // Muestra los datos en el DataGridView
                        }
                    }
                }

                if (dgvClientes.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún cliente con ese nombre.", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Retorna verdadero si se encontraron filas
                return dgvClientes.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // En caso de error, retornar falso
            }
        }
        public bool BuscarClientePorCantidad(DataGridView dgvClientes, int cantidad)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    using (OleDbCommand comando = new OleDbCommand())
                    {
                        comando.Connection = conexion;

                        // Consulta para buscar por cantidad
                        comando.CommandText = @"SELECT Clientes.Nombre, Clientes.Gmail, Clientes.Telefono, SubConsulta.Cantidad
                                        FROM Clientes
                                        INNER JOIN (
                                            SELECT [Cliente-Compra].IdCliente, Compras.Cantidad
                                            FROM [Cliente-Compra]
                                            INNER JOIN Compras ON [Cliente-Compra].Id_Compra = Compras.Id_Compra
                                        ) AS SubConsulta ON Clientes.IdCliente = SubConsulta.IdCliente
                                        WHERE SubConsulta.Cantidad = @Cantidad";

                        // Añadir el parámetro para la búsqueda
                        comando.Parameters.AddWithValue("@Cantidad", cantidad);

                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            DataSet ds = new DataSet();
                            adaptador.Fill(ds);
                            dgvClientes.DataSource = ds.Tables[0]; // Muestra los datos en el DataGridView
                        }
                    }
                }

                if (dgvClientes.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún cliente con esa cantidad.", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Retorna verdadero si se encontraron filas
                return dgvClientes.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // En caso de error, retornar falso
            }
        }
    }
}
