using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Controlador
{
    internal class clsArcInventario
    {
        public string NombreArchivo = "InvntarioProductos.csv";

        public void grabar(string codigo, string Descrip, string cant, string precio, string proveedor)
        {
            StreamWriter ad = new StreamWriter(NombreArchivo, true);

            bool archivoExiste = File.Exists(NombreArchivo);
            if (!archivoExiste)
            {
                ad.Write("codigo" + ";");  
                ad.Write("Descrip" + ";");
                ad.Write("Stock" + ";");   
                ad.Write("Precio" + ";");  
                ad.Write("Proveedor");     
                ad.WriteLine();            
            }

            
            ad.Write(codigo + ";");  
            ad.Write(Descrip + ";"); 
            ad.Write(cant + ";");    
            ad.Write(precio + ";");  
            ad.Write(proveedor);     
            ad.WriteLine();

            ad.Close();
            ad.Dispose();
        }




    }
}
