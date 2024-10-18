using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaGestionLAB3.Vista
{
    public partial class Ventas : Form
    {
        private List<Venta> ventas; // Definir la lista de ventas como una variable de instancia

        public Ventas()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarVentas();
            cmbFecha.Items.Add("Más reciente a más antigua");
            cmbFecha.Items.Add("Más antigua a más reciente");
        }

        private void ConfigurarDataGridView()
        {
            // Ajusta el tamaño de las columnas para que se distribuyan uniformemente
            dataGridVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CargarVentas()
        {
            // Lista de productos
            var productosVenta1 = new List<Producto>
            {
                new Producto("Camiseta", 500, 1),
                new Producto("Gorra", 300, 2),
                new Producto("Botella de Agua", 150, 1)
            };

            var productosVenta2 = new List<Producto>
            {
                new Producto("Zapatillas", 1500, 1),
                new Producto("Pantalón", 800, 1),
                new Producto("Cinturón", 400, 1)
            };

            var productosVenta3 = new List<Producto>
            {
                new Producto("Gorra", 300, 1),
                new Producto("Sudadera", 1200, 1),
                new Producto("Calcetines", 200, 5)
            };

            var productosVenta4 = new List<Producto>
            {
                new Producto("Camisa", 600, 1),
                new Producto("Chaleco", 900, 1)
            };

            var productosVenta5 = new List<Producto>
            {
                new Producto("Short", 700, 1),
                new Producto("Chaqueta", 1800, 1)
            };

            var productosVenta6 = new List<Producto>
            {
                new Producto("Gafas de Sol", 400, 1),
                new Producto("Mochila", 1000, 1),
                new Producto("Botines", 1700, 1)
            };

            var productosVenta7 = new List<Producto>
            {
                new Producto("Toalla Deportiva", 250, 2),
                new Producto("Guantes de Correr", 350, 1)
            };

            var productosVenta8 = new List<Producto>
            {
                new Producto("Banda Elástica", 300, 1),
                new Producto("Pelota de Fútbol", 800, 1)
            };

            var productosVenta9 = new List<Producto>
            {
                new Producto("Gorra", 300, 1),
                new Producto("Pantalón Corto", 700, 1)
            };

            var productosVenta10 = new List<Producto>
            {
                new Producto("Chaqueta", 1800, 1),
                new Producto("Tirantes", 450, 1)
            };

            // Inicializar la variable de instancia
            ventas = new List<Venta>
            {
                new Venta(DateTime.Parse("01/10/2024"), "Consumidor Final", 0, "Efectivo", productosVenta1),
                new Venta(DateTime.Parse("02/10/2024"), "Factura A", 0, "Mercado Pago", productosVenta2),
                new Venta(DateTime.Parse("03/10/2024"), "Factura B", 0, "Efectivo", productosVenta3),
                new Venta(DateTime.Parse("04/10/2024"), "Consumidor Final", 0, "Tarjeta de Crédito", productosVenta4),
                new Venta(DateTime.Parse("05/10/2024"), "Factura A", 0, "Efectivo", productosVenta5),
                new Venta(DateTime.Parse("06/10/2024"), "Factura B", 0, "Débito", productosVenta6),
                new Venta(DateTime.Parse("07/10/2024"), "Consumidor Final", 0, "Efectivo", productosVenta7),
                new Venta(DateTime.Parse("08/10/2024"), "Factura A", 0, "Mercado Pago", productosVenta8),
                new Venta(DateTime.Parse("09/10/2024"), "Factura B", 0, "Efectivo", productosVenta9),
                new Venta(DateTime.Parse("10/10/2024"), "Consumidor Final", 0, "Efectivo", productosVenta10)
            };

            // Calcula el importe basado en los productos de cada venta
            foreach (var venta in ventas)
            {
                venta.Importe = venta.CalcularTotal();
            }

            // Ordenar las ventas por fecha, de la más reciente a la más antigua
            var ventasOrdenadas = ventas.OrderByDescending(v => v.Fecha).ToList();

            // Configurar las columnas del DataGridView
            dataGridVentas.ColumnCount = 5;
            dataGridVentas.Columns[0].Name = "Fecha";
            dataGridVentas.Columns[1].Name = "Tipo de Factura";
            dataGridVentas.Columns[2].Name = "Importe";
            dataGridVentas.Columns[3].Name = "Forma de Pago";
            dataGridVentas.Columns[4].Name = "Productos";

            // Agregar las ventas ordenadas al DataGridView
            foreach (var venta in ventasOrdenadas)
            {
                // Concatenar los nombres de los productos de cada venta
                string nombresProductos = string.Join(", ", venta.Productos.Select(p => p.Nombre));
                dataGridVentas.Rows.Add(venta.Fecha.ToString("dd/MM/yyyy"), venta.TipoFactura, venta.Importe, venta.FormaPago, nombresProductos);
            }
        }

        private void BuscarVentas(string searchTerm)
        {
            // Limpiar el DataGridView antes de mostrar los resultados
            dataGridVentas.Rows.Clear();

            // Asegurarte de que el término de búsqueda no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Filtrar la lista de ventas solo por forma de pago o nombres de productos
            var resultados = ventas.Where(v =>
                v.FormaPago.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                v.Productos.Any(p => p.Nombre.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            // Agregar los resultados al DataGridView
            foreach (var venta in resultados)
            {
                // Concatenar los nombres de los productos de cada venta
                string nombresProductos = string.Join(", ", venta.Productos.Select(p => p.Nombre));
                dataGridVentas.Rows.Add(venta.Fecha.ToString("dd/MM/yyyy"), venta.TipoFactura, venta.Importe, venta.FormaPago, nombresProductos);
            }

            // Verificar si no se encontraron ventas
            if (!resultados.Any())
            {
                MessageBox.Show("No se encontraron ventas con el término de búsqueda especificado.", "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.Trim(); // Asegurarse de eliminar espacios innecesarios
            BuscarVentas(searchTerm); // Llama a la función para buscar ventas
        }

        private void cmbFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de agregar nuevas filas
            dataGridVentas.Rows.Clear();

            List<Venta> ventasOrdenadas;

            // Verificar la selección del ComboBox
            if (cmbFecha.SelectedItem.ToString() == "Más reciente a más antigua")
            {
                // Ordenar las ventas por fecha descendente (de más reciente a más antigua)
                ventasOrdenadas = ventas.OrderByDescending(v => v.Fecha).ToList();
            }
            else if (cmbFecha.SelectedItem.ToString() == "Más antigua a más reciente")
            {
                // Ordenar las ventas por fecha ascendente (de más antigua a más reciente)
                ventasOrdenadas = ventas.OrderBy(v => v.Fecha).ToList();
            }
            else
            {
                // Si por algún motivo no se seleccionó una opción válida, no hacer nada
                return;
            }

            // Agregar las ventas ordenadas al DataGridView
            foreach (var venta in ventasOrdenadas)
            {
                string productos = string.Join(", ", venta.Productos.Select(p => p.Nombre));
                dataGridVentas.Rows.Add(venta.Fecha.ToString("dd/MM/yyyy"), venta.TipoFactura, venta.Importe, venta.FormaPago, productos);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPrincipal principal = new FrmPrincipal();
            principal.Show();
            this.Hide();
        }
    }

    // Clase Producto que representa los productos vendidos
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, double precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Método para calcular el subtotal de un producto
        public double Subtotal()
        {
            return Precio * Cantidad;
        }
    }

    // Clase Venta que representa cada transacción de venta
    public class Venta
    {
        public DateTime Fecha { get; set; }
        public string TipoFactura { get; set; }
        public double Importe { get; set; }
        public string FormaPago { get; set; }
        public List<Producto> Productos { get; set; } // Lista de productos en la venta

        public Venta(DateTime fecha, string tipoFactura, double importe, string formaPago, List<Producto> productos)
        {
            Fecha = fecha;
            TipoFactura = tipoFactura;
            Importe = importe;
            FormaPago = formaPago;
            Productos = productos;
        }

        // Método para calcular el total de la venta en función de los productos
        public double CalcularTotal()
        {
            return Productos.Sum(p => p.Subtotal());
        }
    }
}
