using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ListarVehiculo : Form
    {
        private List<Vehiculo> _vehiculosCargados = new List<Vehiculo>(); // Lista de vehículos cargados
        private int _currentPage = 0; // Página actual
        private const int PageSize = 13; // Tamaño de página (puedes ajustarlo según sea necesario)

        public ListarVehiculo()
        {
            InitializeComponent();
        }

        private void ListarVehiculo_Load(object sender, EventArgs e)
        {
            // Forzar que ambos scrollbars aparezcan
            dgvVehiculo.ScrollBars = ScrollBars.Both;

            // Cargar la primera tanda de vehículos
            CargarVehiculos();

            // Asignar el evento de scroll para detectar cuando llegar al final del DataGridView
            dgvVehiculo.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscar.Focus();
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e, false);
            Validaciones.validacionLongitud(sender, e, 10);
        }
        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar si se llegó al final de las filas visibles
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (dgvVehiculo.Rows.Count > 0 &&
                    dgvVehiculo.FirstDisplayedScrollingRowIndex + dgvVehiculo.DisplayedRowCount(false) >= dgvVehiculo.Rows.Count)
                {
                    // Si se llega al final, cargar más vehículos
                    CargarVehiculos();
                }
            }
        }

        private void CargarVehiculos()
        {
            estiloTabla();
            try
            {
                Vehiculo v = new Vehiculo
                {
                    Conexion = Program.con
                };

                // Llamar al método de paginación en el objeto Vehiculo
                Dictionary<string, int> vehiculosClientes;
                List<Vehiculo> nuevosVehiculos = v.ListarVehiculo(_currentPage, PageSize, out vehiculosClientes);

                if (nuevosVehiculos != null && nuevosVehiculos.Count > 0)
                {
                    _vehiculosCargados.AddRange(nuevosVehiculos);

                    var datosVehiculos = _vehiculosCargados.Select(ve => new
                    {
                        Matricula = ve.Matricula,
                        Ci = ve.Cliente?.ci ?? 0, // Cliente (ci)
                        TipoVehiculo = ve.NombreVehiculo,
                        Marca = ve.NombreMarca,
                    }).ToList();

                    // Actualizar el DataGridView con todos los vehículos cargados hasta ahora
                    dgvVehiculo.DataSource = null;
                    dgvVehiculo.DataSource = datosVehiculos;

                    _currentPage++; // Incrementar página para futuras cargas
                }
                else if (_currentPage == 0)
                {
                    MessageBox.Show("No se encontraron vehículos en la base de datos.");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar los vehículos.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string matriculaBuscada = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matriculaBuscada))
            {
                MessageBox.Show("Por favor, ingrese una matrícula para buscar.");
                return;
            }

            Vehiculo v = new Vehiculo { Conexion = Program.con };

            // Asignar la matrícula a buscar
            v.Matricula = matriculaBuscada;

            // Llamar al método Buscar en la clase Vehiculo
            byte resultado = v.BuscarVehiculo();
            
            if (!v.EstadoVehiculo)
            {
                MessageBox.Show("No existe este vehículo.");
            } else
            {
                switch (resultado)
                {
                    case 0: // Todo funcionó correctamente
                        var datosVehiculo = new List<object>
                    {
                        new
                        {
                            Matricula = v.Matricula,
                            Ci = v.Cliente?.ci ?? 0,
                            TipoVehiculo = v.NombreTipo,
                            Marca = v.NombreMarca
                        }
                    };

                        dgvVehiculo.DataSource = null; // Resetear el DataGridView
                        dgvVehiculo.DataSource = datosVehiculo; // Mostrar el vehículo encontrado
                        break;

                    case 1:
                        MessageBox.Show("La conexión a la base de datos está cerrada.");
                        break;

                    case 2:
                        MessageBox.Show("Error en la ejecución de la consulta.");
                        break;

                    case 3:
                        MessageBox.Show("No se encontró un vehículo con esa matrícula.");
                        break;

                    default:
                        MessageBox.Show("Error desconocido.");
                        break;
                }
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de búsqueda
            txtMatricula.Clear();

            // Resetear la lista de vehículos cargados y la página actual
            _vehiculosCargados.Clear();
            _currentPage = 0;

            // Volver a cargar todos los vehículos
            CargarVehiculos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar la ventana actual
        }

        public void estiloTabla()
        {
            // Fondo gris claro para las filas
            dgvVehiculo.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvVehiculo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvVehiculo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvVehiculo.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvVehiculo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvVehiculo.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehiculo.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvVehiculo.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvVehiculo.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvVehiculo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvVehiculo.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
    }
}
