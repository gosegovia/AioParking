using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ListarVehiculo : Form
    {
        private List<Vehiculo> _vehiculosCargados = new List<Vehiculo>();
        private int _currentPage = 0;
        private const int PageSize = 15; // Ajusta según sea necesario

        public ListarVehiculo()
        {
            InitializeComponent();
        }

        private void ListarVehiculo_Load(object sender, EventArgs e)
        {
            // Forzar a que aparezcan ambos scrollbars
            dgvVehiculo.ScrollBars = ScrollBars.Both;

            // Cargar la primera tanda de vehículos
            CargarVehiculos(_currentPage, PageSize);
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                // Verificar si se llegó al final de las filas visibles
                if (dgvVehiculo.Rows.Count > 0 &&
                    dgvVehiculo.FirstDisplayedScrollingRowIndex + dgvVehiculo.DisplayedRowCount(false) >= dgvVehiculo.Rows.Count)
                {
                    // Cargar más vehículos solo si hay más por cargar
                    CargarVehiculos(_currentPage + 1, PageSize); // Cargar la siguiente página
                }
            }
        }

        private void CargarVehiculos(int numeroPagina, int tamanioPagina)
        {
            try
            {
                Vehiculo v = new Vehiculo
                {
                    Conexion = Program.con
                };

                Dictionary<string, int> vehiculosClientes;
                List<Vehiculo> nuevosVehiculos = v.ListarVehiculo(numeroPagina, tamanioPagina, out vehiculosClientes);

                if (nuevosVehiculos != null && nuevosVehiculos.Count > 0)
                {
                    // Cargar vehículos en tu DataGridView
                    var datosVehiculos = nuevosVehiculos.Select(ve => new
                    {
                        Matricula = ve.Matricula,
                        Ci = vehiculosClientes.ContainsKey(ve.Matricula) ? vehiculosClientes[ve.Matricula] : 0,
                        TipoVehiculo = ve.NombreVehiculo,
                        Marca = ve.NombreMarca
                    }).ToList();

                    // Actualizamos el DataSource con todos los vehículos cargados hasta ahora
                    _vehiculosCargados.AddRange(nuevosVehiculos); // Agregar nuevos vehículos a la lista
                    dgvVehiculo.DataSource = null; // Desenlazamos la fuente actual
                    dgvVehiculo.DataSource = _vehiculosCargados.Select(ve => new
                    {
                        Matricula = ve.Matricula,
                        Ci = vehiculosClientes.ContainsKey(ve.Matricula) ? vehiculosClientes[ve.Matricula] : 0,
                        TipoVehiculo = ve.NombreVehiculo,
                        Marca = ve.NombreMarca
                    }).ToList(); // Asignamos todos los vehículos cargados hasta ahora

                    _currentPage++; // Incrementar la página después de cargar
                }
                else
                {
                    // No hay más vehículos para cargar
                    MessageBox.Show("No hay más vehículos para cargar.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Error en el desplazamiento: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los vehículos: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string matriculaBuscada = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matriculaBuscada))
            {
                MessageBox.Show("Por favor, ingrese una matrícula para buscar.");
                return;
            }

            // Crear una instancia de Vehiculo
            Vehiculo v = new Vehiculo { Conexion = Program.con };

            // Asignar la matrícula a buscar
            v.Matricula = matriculaBuscada;

            // Llamar al método Buscar (esto debe implementarse en tu clase Vehiculo)
            byte resultado = v.BuscarVehiculo();

            switch (resultado)
            {
                case 0: // Todo funcionó correctamente
                    var datosVehiculo = new List<object>
                    {
                        new
                        {
                            Matricula = v.Matricula,
                            Ci = v.Cliente?.ci ?? 0, // Debes implementar lógica para obtener el CI correspondiente
                            TipoVehiculo = v.NombreVehiculo,
                            Marca = v.NombreMarca
                        }
                    };

                    dgvVehiculo.DataSource = null; // Resetear el DataGridView
                    dgvVehiculo.DataSource = datosVehiculo; // Asignar el vehículo encontrado
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

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de búsqueda
            txtMatricula.Clear();

            // Resetear la lista de vehículos cargados y la página actual
            _vehiculosCargados.Clear();
            _currentPage = 0;

            // Volver a cargar todos los vehículos
            CargarVehiculos(_currentPage, PageSize);
        }
    }
}
