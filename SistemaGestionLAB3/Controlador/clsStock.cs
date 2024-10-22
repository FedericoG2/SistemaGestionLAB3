using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionLAB3.Controlador
{
    internal class clsStock
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

    }
}
