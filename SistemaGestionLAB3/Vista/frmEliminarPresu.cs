using SistemaGestionLAB3.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Vista
{
    public partial class frmEliminarPresu : Form
    {
        public frmEliminarPresu()
        {
            InitializeComponent();
        }

        private void btnEliminarPresu_Click(object sender, EventArgs e)
        {
            int numeroPresu = int.Parse(txtNumeroPresu.Text);

            ClsPresupuesto eliminar = new ClsPresupuesto();
            eliminar.Eliminar(numeroPresu);

            this.Close();
        }
    }
}
