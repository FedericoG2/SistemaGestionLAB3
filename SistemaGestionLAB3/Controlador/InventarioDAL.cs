using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
        //private string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ModeloDB\Inventario_db.accdb";
        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\Usuario\\Desktop\\LAB\\Lab3\\SistemaGestionLAB3\\ModeloDB\\Inventario_db.accdb";
                                          
        private string Tabla = "Inventario";

        //Conexion y Prueba de conexion 
        public void conexiones()
        {
            try
            {
                // Establece la cadena de conexión
                conexion.ConnectionString = cadenaConexion;
                conexion.Open(); // Intenta abrir la conexión

                // Asocia el comando SQL a la conexión y define el tipo de comando (SQL)
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                MessageBox.Show("Conexión abierta correctamente."); // Mensaje de éxito
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

        public void Listar(DataGridView dgvInventario)
        {
            try
            {
                //recibe la cadena de conexion
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();

                //comandos de ordenes
                comando.Connection = conexion;
                //ponemos el tipo de comando, (3 tipos
                //text(envia instrucciones sql),
                //tabletDirect(trae la tabla))
                comando.CommandType = CommandType.TableDirect;
                //nombre de la tabla que vamos a traer 
                comando.CommandText = Tabla;



                //adaptamos el comando configurado
                adaptador = new OleDbDataAdapter(comando);
                //objeto de clase dataset para poder cargar los datos 
                DataSet ds = new DataSet();
                //adaptamos el dataset
                adaptador.Fill(ds);

                //dATAsOURCE TOMA EL CONTENDIDO COMPLETO DEL DATASET
                dgvInventario.DataSource = ds.Tables[0];

                //cerramos la conexion 
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD " + e.ToString());
            }
        }

        public void Agregar(clsStock stock)
        {
            try
            {
                conexiones(); // Asegúrate de que la conexión se abre correctamente.
                string query = "INSERT INTO Inventario ( Nombre, Precio_Venta, Stock, Id_Proveedor) VALUES ( @Nombre, @Precio, @Stock, @IdProveed);";

                comando.CommandText = query;

                // Asignar valores a los parámetros
                comando.Parameters.Clear();
                
                comando.Parameters.AddWithValue("@Nombre", stock.Nombre);
                comando.Parameters.AddWithValue("@Precio", stock.Precio);
                comando.Parameters.AddWithValue("@Stock", stock.Stock);
                comando.Parameters.AddWithValue("@IdProveed", stock.Id_Proveedor);

                comando.ExecuteNonQuery(); // Asegúrate de que esta línea se ejecute.
                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD: " + e.Message); // Verifica el mensaje de error.
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
                conexiones(); // Método para abrir la conexión con la base de datos
                comando.CommandText = "DELETE FROM Inventario WHERE Id_Producto = ?";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("?", stock.Id); // Pasar el parámetro del código del producto

                comando.ExecuteNonQuery(); // Ejecutar el comando

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

