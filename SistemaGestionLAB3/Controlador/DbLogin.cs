using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Controlador
{
    public class DbLogin
    {
        // ruta
        private string ruta = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DbLogin.accdb";

        // metodo para ingresar
        public bool VerificarUsuario(string nombre, string password)
        {
            bool loginOk = false;

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM DbLogin WHERE NOMBRE = ? AND PASSWORD = ?";
                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NOMBRE", nombre);
                        comando.Parameters.AddWithValue("@PASSWORD", password);
                        // agregamos un valor como contador
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

        // metodo olvide contraseña
        public bool OlvideContraseña(string nombre, string nuevoPassword)
        {
            bool resultado = false;
            string query = "UPDATE DbLogin SET PASSWORD = ? WHERE NOMBRE = ?";
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("?", nuevoPassword);
                        comando.Parameters.AddWithValue("?", nombre);
                        // verificamos
                        int filasAfectadas = comando.ExecuteNonQuery();
                        // devuelve true si algo se actualizo
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

        // metodo para registrarse
        public bool RegistrarUsuario(string nombre, string password)
        {
            bool resultado = false;

            // Primero, verificar si el usuario ya existe
            string queryVerificar = "SELECT COUNT(*) FROM DbLogin WHERE NOMBRE = ?";
            //string queryInsertar = "INSERT INTO DbLogin (NOMBRE,PASSWORD) VALUES (?,?)";
            string queryInsertar = "INSERT INTO DbLogin ([NOMBRE], [PASSWORD]) VALUES (?, ?)";

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
