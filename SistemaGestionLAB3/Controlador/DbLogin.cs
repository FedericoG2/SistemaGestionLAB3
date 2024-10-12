using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

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
                    string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Username = ? AND Contraseña = ?";
                    using (OleDbCommand comando = new OleDbCommand(queryVerificar, conexion))
                    {
                        comando.Parameters.AddWithValue("@NOMBRE", nombre);
                        comando.Parameters.AddWithValue("@PASSWORD", password);

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
        public bool RegistrarUsuario(string nombre, string password)
        {
            bool resultado = false;
            // Primero, verificar si el usuario ya existe
            string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Username = ?";
            // String queryInsertar = "INSERT INTO DbLogin (NOMBRE,PASSWORD) VALUES (?,?)";
            string queryInsertar = "INSERT INTO Usuarios ([Username], [Contraseña],[Rol]) VALUES (?, ?,1)";

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
    }
}
