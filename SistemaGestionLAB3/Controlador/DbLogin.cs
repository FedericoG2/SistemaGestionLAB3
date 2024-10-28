using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Reflection;

namespace SistemaGestionLAB3.Controlador
{
    public class DbLogin
    {
        // Ruta
        private string ruta = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=ModeloDB\Inventario_db.accdb";

        // Metodo para ingresar
        public bool VerificarUsuario(string nombre, string password)
        {
            bool loginOk = false;

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    //abrimos de nuevo
                    string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Username = ? AND Contraseña = ?";
                    using (OleDbCommand comando = new OleDbCommand(queryVerificar, conexion))
                    {
                        comando.Parameters.AddWithValue("@Username", nombre);
                        comando.Parameters.AddWithValue("@Contraseña", password);

                        // Agregamos un valor como contador
                        int count = (int)comando.ExecuteScalar();
                        if (count == 1)
                        {
                            loginOk = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar!", ex + "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return loginOk;
        }

        // Metodo olvide contraseña
        public bool OlvideContraseña(string nombre, string nuevoPassword)
        {
            bool resultado = false;
            string query = "UPDATE Usuarios SET Contraseña = ? WHERE Username = ?";
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("?", nuevoPassword);
                        comando.Parameters.AddWithValue("?", nombre);
                        // Verificamos
                        int filasAfectadas = comando.ExecuteNonQuery();
                        // Devuelve true si algo se actualizo
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cambiar contraseña!" + e, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        // Metodo para registrarse
        public bool RegistrarUsuario(string nombre, string password, byte[] firma)
        {
            bool resultado = false;
            // Primero, verificar si el usuario ya existe
            string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Username = ?";
            // String queryInsertar
            string queryInsertar = "INSERT INTO Usuarios ([Username], [Contraseña],[IdRoles],[Firma]) VALUES (?, ?, 1, ?)";

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    // Verificar si el usuario ya existe
                    using (OleDbCommand comandoVerificar = new OleDbCommand(queryVerificar, conexion))
                    {
                        comandoVerificar.Parameters.AddWithValue("?", nombre);

                        int usuarioExistente = (int)comandoVerificar.ExecuteScalar();

                        if (usuarioExistente > 0)
                        {
                            MessageBox.Show("El nombre de usuario ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // Si no existe, lo insertamos en la base de datos
                    using (OleDbCommand comandoInsertar = new OleDbCommand(queryInsertar, conexion))
                    {
                        comandoInsertar.Parameters.AddWithValue("?", nombre);
                        comandoInsertar.Parameters.AddWithValue("?", password);
                        comandoInsertar.Parameters.AddWithValue("?", firma);

                        int filasAfectadas = comandoInsertar.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }

                    // Si el registro fue exitoso, mostrar un mensaje y retornar true
                    if (resultado)
                    {
                        MessageBox.Show("Registro con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //Metodo para traer todos los usuarios y cargarlo en una grilla
        public void CargarUsuariosEnGrid(DataGridView dgv)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "SELECT U.Id_Usuario AS ID,U.Nombre,U.Username,U.Contraseña,U.Mail, R.Rol AS Rol FROM Usuarios U INNER JOIN Roles R ON U.IdRoles = R.Id";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv.DataSource = dt;  // Cargar los datos en el DataGridView
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch(OleDbException oleDbEx) 
            {
                MessageBox.Show("Error de base de datos: " + oleDbEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en el DataGridView!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para la Busqueda los datos de un usuario y los carga en el formulario de editar Usuario
        public void DatosUsuario(int id, TextBox txtNombre,TextBox txtUsername, TextBox txtContraseña,TextBox txtMail, ComboBox cmbRol)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "SELECT U.Id_Usuario AS ID, U.Nombre, U.Username, U.Contraseña, U.Mail, R.Id AS RolId FROM Usuarios U INNER JOIN Roles R ON U.IdRoles = R.Id WHERE U.Id_Usuario = ?";
                    
                    using (OleDbCommand comandoTraer = new OleDbCommand(query, conexion))
                    {
                        comandoTraer.Parameters.AddWithValue("?", id);
                        using (OleDbDataReader lector = comandoTraer.ExecuteReader())
                        {
                            // Verificar si hay datos
                            if (lector.Read())
                            {
                                // Asignar los valores al formulario
                                txtNombre.Text = lector["Nombre"].ToString();
                                txtContraseña.Text = lector["Contraseña"].ToString();
                                txtMail.Text = lector["Mail"].ToString();
                                txtUsername.Text = lector["Username"].ToString();
                                cmbRol.SelectedValue = Convert.ToUInt32(lector["RolId"]);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para la actualizacion de Usuarios
        public void ModificarUsuario(int id, string Nombre, string Username, string Mail, string Contraseña, string RolId)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "UPDATE Usuarios SET Nombre = ?, Username = ?, Contraseña = ?, Mail = ?, IdRoles = ? WHERE Id_Usuario = ?";

                    using (OleDbCommand comandoModificar = new OleDbCommand(query, conexion))
                    {
                        comandoModificar.Parameters.AddWithValue("?", Nombre);
                        comandoModificar.Parameters.AddWithValue("?", Username);
                        comandoModificar.Parameters.AddWithValue("?", Contraseña);
                        comandoModificar.Parameters.AddWithValue("?", Mail);
                        comandoModificar.Parameters.AddWithValue("?", RolId);

                        // Ejecutar la consulta
                        comandoModificar.ExecuteNonQuery();

                    }
                }
            }
            catch (OleDbException oleDbEx)
            {
                MessageBox.Show("Error de base de datos: " + oleDbEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar Usuario!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Metodo para eliminar un usuario
        public void EliminarUsuario(int id)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "DELETE FROM Usuarios WHERE Id_Usuario = ?";

                    using (OleDbCommand comandoEliminar = new OleDbCommand(query, conexion))
                    {
                        comandoEliminar.Parameters.AddWithValue("?", id);

                        // Ejecutar la consulta
                        comandoEliminar.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException oleDbEx)
            {
                MessageBox.Show("Error de base de datos: " + oleDbEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar Usuario!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
