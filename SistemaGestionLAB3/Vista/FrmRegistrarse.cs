using SistemaGestionLAB3.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Vista
{
    public partial class FrmRegistrarse : Form
    {
        // instanciamos lo necesario
        private bool dibujando = false;
        private Point puntoAnterior;
        private Bitmap imagenFirma;
        public FrmRegistrarse()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // metodo para convertir bitmap a byte
        private byte[] ConvertirFirmaABytes(Bitmap firmaBitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                firmaBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);  // Guardar la firma en formato PNG
                return ms.ToArray();  // Convertir el MemoryStream en un byte[]
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtContraseña.Text;

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario y una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir la firma a byte[]
            byte[] firmaBytes = ConvertirFirmaABytes(imagenFirma);

            // Llamar al método para registrar el usuario
            DbLogin dbLogin = new DbLogin();
            bool registroExitoso = dbLogin.RegistrarUsuario(nombreUsuario, password,firmaBytes);

            // Si el registro fue exitoso, cerrar el formulario actual y abrir el formulario de inicio de sesión
            if (registroExitoso)
            {
                this.Close();
            }
        }
        // metodo para capturar la firma
        // instanciamos apenas abrimos el form
        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {
            imagenFirma = new Bitmap(panelFirma.Width, panelFirma.Height);
            panelFirma.BackgroundImage = imagenFirma;

            // Asociamos los eventos del panel
            panelFirma.MouseDown += panelFirma_MouseDown;
            panelFirma.MouseMove += panelFirma_MouseMove;
            panelFirma.MouseUp += panelFirma_MouseUp;
        }

        // Evento MouseDown: El usuario comienza a dibujar
        private void panelFirma_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dibujando = true;
                puntoAnterior = e.Location;
            }
        }

        // Evento MouseMove: Mientras el usuario mueve el mouse y está presionado, se dibuja
        private void panelFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando)
            {
                using (Graphics g = Graphics.FromImage(imagenFirma))
                {
                    g.DrawLine(Pens.Black, puntoAnterior, e.Location);
                }
                puntoAnterior = e.Location;
                panelFirma.Invalidate();  // Redibuja el panel para mostrar la nueva línea
            }
        }

        // Evento MouseUp: El usuario suelta el botón del mouse
        private void panelFirma_MouseUp(object sender, MouseEventArgs e)
        {
            dibujando = false;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Limpiamos la imagen del bitmap para borrar el dibujo
            imagenFirma.Dispose();
            imagenFirma = new Bitmap(panelFirma.Width, panelFirma.Height);
            panelFirma.BackgroundImage = imagenFirma;
            panelFirma.Invalidate();
        }
    }
}
