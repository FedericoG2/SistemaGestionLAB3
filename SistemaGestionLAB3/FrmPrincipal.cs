using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            //Propiedad para expandir a lo ancho de la pantalla el group box que contiene botones 
            this.Resize += new EventHandler(Form1_Resize);

            //Reproduccion de sonido Apertura sistema
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = @"C:\Users\mauro\OneDrive\Desktop\facultad\lab3Prueba\SistemaGestionLAB3\Resources\sonidoInicio.wav";
            //player.Play();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //Propiedad para expandir a lo ancho de la pantalla el group box que contiene botones 
            this.WindowState = FormWindowState.Maximized;
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Propiedad para expandir a lo ancho de la pantalla el group box que contiene botones 
            groupBox1.Width = this.ClientSize.Width - groupBox1.Left;
        }
        //Cerrar Sistema
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
