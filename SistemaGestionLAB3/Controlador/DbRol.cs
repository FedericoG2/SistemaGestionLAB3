using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Controlador
{
    internal class DbRol
    {

        // Ruta
        private string ruta = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=ModeloDB\Inventario_db.accdb";

        public String RolPorId(int RolId)
        {
            String nombre = "";

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "SELECT R.Rol FROM Roles R INNER JOIN Usuarios U ON U.IdRol = R.Id WHERE U.IdRol = ?";
                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@RolId", RolId);
                        using (OleDbDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                nombre = lector["NombreRol"].ToString();
                            }
                            else
                            {
                                nombre = "Rol no encontrado"; // Mensaje por defecto si no se encuentra
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro el rol", ex + "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombre;
        }

        //Metodo para obtener todos los roles y guardarlos en una lista con dos campos, Id y Rol
        public List<(int Id, string NombreRol)> ObtenerTodosLosRoles()
        {
            List<(int Id, string NombreRol)> roles = new List<(int Id, string NombreRol)>();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string query = "SELECT Id, Rol FROM Roles";

                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        using (OleDbDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int id = Convert.ToInt32(lector["Id"]);
                                string nombreRol = lector["Rol"].ToString();
                                roles.Add((id, nombreRol));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return roles;
        }
    }

}
