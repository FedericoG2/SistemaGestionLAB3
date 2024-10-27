using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing;

namespace SistemaGestionLAB3.Controlador
{
    internal class ClsPresupuesto
    {   //creamos objeto para conectarnos con la bd
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
        public void pruebaConexion()
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

        public DataTable BucarArticulos(int Codigo)
        {
            conexiones();

            string query = "Select Nombre,Precio_Venta,Stock FROM Inventario WHERE id_Producto = @Codigo";
            comando.CommandText = query;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Codigo", Codigo);


            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            DataTable resultados = new DataTable();
            adaptador.Fill(resultados);

            conexion.Close(); // Cierra la conexión
            return resultados; // Retorna los resultados

        }

        public void AgregarPresupuesto(Cls_dbPresupuesto nuevoPresu)
        {
            try
            {
                conexiones();
                string query = "INSERT INTO Presupuesto ( Nombre_cliente, Direccion_Mail, Tipo_Presupuesto,Detalle_Art,Cantidad_Art,Precio_Art) VALUES ( @Nombre, @Direccion, @Tipo , @Detalle,@Cantidad,@Precio_Art);";

                comando.CommandText = query;


                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@Nombre", nuevoPresu.Nombre);
                
                comando.Parameters.AddWithValue("@Direccion", nuevoPresu.Direccion);
                comando.Parameters.AddWithValue("@Tipo", nuevoPresu.Tipo_Presupuesto);
                comando.Parameters.AddWithValue("@Detalle", nuevoPresu.detalleArticulo);
                comando.Parameters.AddWithValue("@Cantidad", nuevoPresu.Cantidad);
                comando.Parameters.AddWithValue("@Precio_Art", nuevoPresu.Precio);
                
                comando.ExecuteNonQuery();
                MessageBox.Show("Nuevo Presupuesto Agregado y Guardado");
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
        public void Listar(DataGridView dgvPresupuesto)
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
                        comando.CommandText = "SELECT * FROM Presupuesto"; 
                        
                        // Adaptar los datos
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            DataSet ds = new DataSet();
                            adaptador.Fill(ds);
                            dgvPresupuesto.DataSource = ds.Tables[0]; // Muestra los datos en el DataGridView
                        }


                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD: " + e.Message);
            }
        }

        public DataTable BuscarPorCodigo(int codigo)
        {
            conexiones(); // Método que abre la conexión

            string query = "SELECT * FROM Presupuesto WHERE id_Presupuesto = @Codigo";
            comando.CommandText = query;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Codigo", codigo);

            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            DataTable resultados = new DataTable();
            adaptador.Fill(resultados); // Llena el DataTable con los resultados de la consulta

            conexion.Close(); // Cierra la conexión
            return resultados; // Retorna los resultados
        }
        public DataTable BuscarPorNombre(string Nombre)
        {
            conexiones(); // Método que abre la conexión

            string query = "SELECT * FROM Presupuesto WHERE Nombre_Cliente LIKE @Nombre";
            comando.CommandText = query;
            comando.Parameters.Clear();
            
            comando.Parameters.AddWithValue("@NombreCliente", "%" + Nombre + "%");

            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            DataTable resultados = new DataTable();
            adaptador.Fill(resultados); // Llena el DataTable con los resultados de la consulta

            conexion.Close(); // Cierra la conexión
            return resultados; // Retorna los resultados
        }
        public DataTable BuscarPorArt(string NombreArt)
        {
            conexiones(); // Método que abre la conexión

            string query = "SELECT * FROM Presupuesto WHERE Detalle_Art LIKE @NombreArt";
            comando.CommandText = query;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@NombreCliente", "%" + NombreArt + "%");

            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            DataTable resultados = new DataTable();
            adaptador.Fill(resultados); // Llena el DataTable con los resultados de la consulta

            conexion.Close(); // Cierra la conexión
            return resultados; // Retorna los resultados
        }
        public void Eliminar(int numeroPresu)
        {
            try
            {
                conexiones();
                comando.CommandText = "DELETE FROM Presupuesto WHERE Id_Presupuesto = ?";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("?", numeroPresu );

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

    }

}