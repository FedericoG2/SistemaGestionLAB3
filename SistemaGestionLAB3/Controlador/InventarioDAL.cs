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
        private string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=ModeloDB\Inventario_db.accdb";


        private string Tabla = "Inventario";

        //Conexion y Prueba de conexion 
        public void conexiones()
        {
            //recibe la cadena de conexion
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();

            // Asocia el comando SQL a la conexión y define el tipo de comando (SQL)
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;

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
                conexiones();

                //Se edita lp que es la query 
                string query = "INSERT INTO Inventario (Id_Producto, Nombre, Precio_Venta, Stock, Id_Proveedor) VALUES (@IdProdc, @Nombre, @Precio, @Stock, @IdProveed)";

                comando.CommandText = query;
                // Asignar valores a los parámetros
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IdProdc", stock.Id);
                comando.Parameters.AddWithValue("@Nombre", stock.Nombre);
                comando.Parameters.AddWithValue("@Precio", stock.Precio);
                comando.Parameters.AddWithValue("@Stock", stock.Stock);
                comando.Parameters.AddWithValue("@IdProveed", stock.Id_Proveedor);

                // Ejecuta el comando (INSERT INTO) para insertar los datos en la base de datos
                comando.ExecuteNonQuery();

                MessageBox.Show("Producto agregado correctamente.");

            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EN BD " + e.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }



    }
}
