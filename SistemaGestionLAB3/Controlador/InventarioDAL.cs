using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Controlador
{
    internal class InventarioDAL
    {
        //creamos objeto para conectarnos con la bd
        private OleDbConnection conexion = new OleDbConnection();
        //para enviar las ordenes a la bd 
        private OleDbCommand comando = new OleDbCommand();
        //nos sirve para adaptar los datos que estan mal en la bd   
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();
        private string cadenaConexion = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=..\..\ModeloDB\Inventario_db.accdb";
        private string Tabla = "Inventario";
        private string TablaProvee = "Proveedores";

        //Conexion y Prueba de conexion 
        public void conexiones()
        {
            try
            {

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();


                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message); // Muestra el error si ocurre
            }
        }
        public void conexionesProvee()
        {
            try
            {

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();


                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message); // Muestra el error si ocurre
            }
        }


        public void ProbarConexion()
        {
            try
            {
                // Configurar la cadena de conexión
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                MessageBox.Show("Conexión a la base de datos exitosa.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }



        //public void Listar(DataGridView dgvInventario)
        //{
        //    try
        //    {
        //        using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
        //        {
        //            conexion.Open();

        //            using (OleDbCommand comando = new OleDbCommand())
        //            {
        //                comando.Connection = conexion;
        //                comando.CommandType = CommandType.TableDirect;
        //                comando.CommandText = Tabla;

        //                // Adaptar los datos
        //                using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
        //                {
        //                    DataSet ds = new DataSet();
        //                    adaptador.Fill(ds);
        //                    dgvInventario.DataSource = ds.Tables[0];
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("ERROR EN BD: " + e.Message);
        //    }
        //}

        public void Listar(DataGridView dgvInventario)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (OleDbCommand comando = new OleDbCommand())
                    {
                        comando.Connection = conexion;

                        // Consulta con JOIN para obtener los datos del inventario y los nombres de los proveedores
                        comando.CommandText = "SELECT i.id_Producto, i.Nombre AS Producto, i.Precio_Venta, i.Stock, p.Nombre_prov AS Proveedor " +
                                              "FROM Inventario i " +
                                              "INNER JOIN Proveedores p ON i.Id_Proveedor = p.Id_proveedor";
                        
                        // Adaptar los datos
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            DataSet ds = new DataSet();
                            adaptador.Fill(ds);
                            dgvInventario.DataSource = ds.Tables[0]; // Muestra los datos en el DataGridView
                        }

                        
                        foreach (DataGridViewRow fila in dgvInventario.Rows)
                        {
                            if (fila.Cells["Stock"].Value != null && int.TryParse(fila.Cells["Stock"].Value.ToString(), out int stock))
                            {
                                if (stock < 5)
                                {
                                    fila.DefaultCellStyle.BackColor = Color.Red; // Resalta en rojo las filas con bajo stock
                                    fila.DefaultCellStyle.ForeColor = Color.White; // Cambia el texto a blanco para mejor visibilidad
                                }
                            }
                        }



                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD: " + e.Message);
            }
        }
        public void Agregar(clsStock stock)
        {
            try
            {
                conexiones();
                string query = "INSERT INTO Inventario ( Nombre, Precio_Venta, Stock, Id_Proveedor) VALUES ( @Nombre, @Precio, @Stock, @IdProveed);";

                comando.CommandText = query;


                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Nombre", stock.Nombre);
                comando.Parameters.AddWithValue("@Precio", stock.Precio);
                comando.Parameters.AddWithValue("@Stock", stock.Stock);
                comando.Parameters.AddWithValue("@IdProveed", stock.Id_Proveedor + 1);

                comando.ExecuteNonQuery();
                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD: " + e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close(); // Asegúrate de cerrar la conexión.
                }
            }
        }
        public void Eliminar(clsStock stock)
        {
            try
            {
                conexiones();
                comando.CommandText = "DELETE FROM Inventario WHERE Id_Producto = ?";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("?", stock.Id);

                comando.ExecuteNonQuery();

                MessageBox.Show("Producto eliminado correctamente.");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD " + e.ToString());
            }
            finally
            {
                conexion.Close(); // Asegúrate de cerrar la conexión después de ejecutar el comando
            }
        }
        public void Modificar(clsStock stock)
        {
            try
            {
                conexiones();

                //  SQL para modificar los valores
                comando.CommandText = "UPDATE Inventario SET Nombre = ?, Precio_Venta = ?, Stock = ?, Id_Proveedor = ? WHERE Id_Producto = ?";

                
                comando.Parameters.Clear();

               
                comando.Parameters.AddWithValue("?", stock.Nombre);
                comando.Parameters.AddWithValue("?", stock.Precio);
                comando.Parameters.AddWithValue("?", stock.Stock);
                comando.Parameters.AddWithValue("?", stock.Id_Proveedor + 1);
                if(stock.Id < 5) {
                    MessageBox.Show("Stock inferior a 5"); 
                comando.Parameters.AddWithValue("?", stock.Id);
                }
                // Ejecuta el comando 
                comando.ExecuteNonQuery();

                MessageBox.Show("Modificado correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD " + e.ToString());
            }
            finally
            {
                
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public DataTable BuscarPorCodigo(int codigo)
        {
            conexiones(); // Método que abre la conexión

            string query = "SELECT * FROM Inventario WHERE id_Producto = @Codigo";
            comando.CommandText = query;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Codigo", codigo);

            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            DataTable resultados = new DataTable();
            adaptador.Fill(resultados); // Llena el DataTable con los resultados de la consulta

            conexion.Close(); // Cierra la conexión
            return resultados; // Retorna los resultados
        }
        public void LlenarComboBoxProveedores(ComboBox cmbProveedores)
        {
            try
            {
                conexiones(); 

                string query = "SELECT Id_proveedor, Nombre_prov FROM Proveedores"; // Consulta para obtener los datos de los proveedores
                comando.CommandText = query;
                comando.Parameters.Clear();

                // Ejecuta el comando y obtiene los resultados
                using (OleDbDataReader reader = comando.ExecuteReader())
                {
                    // Limpia el ComboBox antes de llenarlo
                    cmbProveedores.Items.Clear();

                    // Recorre los resultados y agrega cada proveedor al ComboBox
                    while (reader.Read())
                    {
                        
                        cmbProveedores.Items.Add(new KeyValuePair<int, string>((int)reader["Id_proveedor"], reader["Nombre_prov"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close(); // Asegura cerrar la conexión
                }
            }

            // Configura el ComboBox para mostrar el nombre del proveedor y ocultar el ID
            cmbProveedores.DisplayMember = "Value";
            cmbProveedores.ValueMember = "Key";
        }

    }

}

