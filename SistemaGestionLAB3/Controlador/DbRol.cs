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

        public String Rol(int RolId)
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


    }
}
