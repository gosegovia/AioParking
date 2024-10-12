using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Cajero
{
    public partial class ListarFactura : Form
    {
        private int _currentPage = 0;
        private int PageSize = 15; // Número de servicios a cargar por página
        private List<Servicio> _serviciosCargados = new List<Servicio>();

        public ListarFactura()
        {
            InitializeComponent();
        }

        private void ListarFactura_Load(object sender, EventArgs e)
        {
            // Forzar la aparición de ambas barras de desplazamiento
            dgvServicios.ScrollBars = ScrollBars.Both;

            // Cargar la primera página de servicios
            CargarServicios();

            // Asignar el evento de desplazamiento para detectar cuando se alcanza el final del DataGridView
            dgvServicios.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }

        private void txtCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que la tecla Enter inserte una nueva línea
                btnBuscar.Focus();
            }
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que sólo se ingresen números y limitar la longitud
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar si el desplazamiento vertical ha llegado al final
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (dgvServicios.Rows.Count > 0 &&
                    dgvServicios.FirstDisplayedScrollingRowIndex + dgvServicios.DisplayedRowCount(false) >= dgvServicios.Rows.Count)
                {
                    // Si se alcanza el final, cargar más servicios
                    CargarServicios();
                }
            }
        }

        private void CargarServicios()
        {
            try
            {
                Servicio s = new Servicio
                {
                    Conexion = Program.con
                };

                // Paginación de los servicios
                List<Servicio> nuevosServicios = s.ListarServicios(_currentPage, PageSize);

                // Verificar si se encontraron nuevos servicios
                if (nuevosServicios != null && nuevosServicios.Count > 0)
                {
                    // Agregar nuevos servicios a la lista cargada
                    _serviciosCargados.AddRange(nuevosServicios);

                    // Transformar la lista de servicios para el DataGridView
                    var datosServicios = _serviciosCargados.Select(serv => new
                    {
                        Factura = serv.facturaId,
                        CI_Cliente = serv.Cliente.ci,
                        CI_Empleado = serv.Empleado.ci,
                        Matricula = serv.Vehiculo.Matricula,
                        Fecha = serv.facturaFecha.ToString("dd/MM/yyyy HH:mm"),
                        HoraEntrada = serv.Parking?.HoraEntrada.ToString("HH:mm"),
                        HoraSalida = serv.Parking?.HoraSalida.ToString("HH:mm"),
                        Plaza = serv.Parking != null ? serv.Parking.Plaza.ToString() : "N/A",
                        Lavado = serv.Lavado.LavadoNombre,
                        Alineacion_Balanceo = serv.AlineacionBalanceo.aybNombre,
                        Neumatico = serv.neumaticoNombre,
                        Cantidad = serv.neumaticoCantidad
                    }).ToList();

                    // Vincular los datos al DataGridView
                    dgvServicios.DataSource = null; // Limpiar el DataGridView
                    dgvServicios.DataSource = datosServicios; // Vincular los nuevos datos

                    _currentPage++; // Avanzar a la siguiente página
                }
                else if (_currentPage == 0)
                {
                    // No hay servicios en la primera página
                    MessageBox.Show("No se encontraron servicios en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Ocurrió un error al cargar los servicios: " + ex.Message);
            }
        }

        private void btnBuscarCi_Click(object sender, EventArgs e)
        {
            string ciBuscada = txtCI.Text.Trim(); // Captura la cédula ingresada en el textbox

            if (string.IsNullOrEmpty(ciBuscada))
            {
                MessageBox.Show("Por favor, ingrese una cédula para buscar.");
                return;
            }

            try
            {
                // Asegúrate de que la cédula se pueda convertir a entero
                if (!int.TryParse(ciBuscada, out int ciCliente))
                {
                    MessageBox.Show("La cédula ingresada no es válida. Por favor, ingrese un número.");
                    return;
                }

                Servicio s = new Servicio
                {
                    Conexion = Program.con
                };

                // Llamar al método que filtra los servicios por CI, pasando la cédula como parámetro
                List<Servicio> serviciosFiltrados = s.ListarServiciosPorCi(ciCliente);

                if (serviciosFiltrados != null && serviciosFiltrados.Count > 0)
                {
                    var datosServicios = serviciosFiltrados.Select(serv => new
                    {
                        Factura = serv.facturaId,
                        CI_Cliente = serv.Cliente.ci,
                        CI_Empleado = serv.Empleado.ci,
                        Matricula = serv.Vehiculo.Matricula,
                        Fecha = serv.facturaFecha.ToString("dd/MM/yyyy HH:mm"),
                        HoraEntrada = serv.Parking?.HoraEntrada.ToString("HH:mm"),
                        HoraSalida = serv.Parking?.HoraSalida.ToString("HH:mm"),
                        Plaza = serv.Parking != null ? serv.Parking.Plaza.ToString() : "N/A",
                        Lavado = serv.Lavado.LavadoNombre,
                        Alineacion_Balanceo = serv.AlineacionBalanceo.aybNombre,
                        Neumatico = serv.neumaticoNombre,
                        Cantidad = serv.neumaticoCantidad
                    }).ToList();

                    // Vincular los datos filtrados al DataGridView
                    dgvServicios.DataSource = null;
                    dgvServicios.DataSource = datosServicios;
                }
                else
                {
                    MessageBox.Show("No se encontraron servicios para el CI proporcionado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar los servicios: " + ex.Message);
            }
        }


        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de búsqueda
            txtCI.Clear();

            // Reiniciar los servicios cargados y la página actual
            _serviciosCargados.Clear();
            _currentPage = 0;

            // Recargar todos los servicios
            CargarServicios();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void cbPaga_CheckedChanged(object sender, EventArgs e)
        {
            CargarServiciosPagos();
        }

        private void CargarServiciosPagos()
        {
            _currentPage = 0;
            PageSize = 15;

            try
            {
                // Limpiar los datos actuales en el DataGridView
                dgvServicios.DataSource = null;

                // Crear un objeto de servicio
                Servicio servicio = new Servicio
                {
                    Conexion = Program.con
                };

                List<Servicio> servicios;

                // Verificar si el CheckBox está marcado
                if (cbPaga.Checked)
                {
                    // Cargar solo los servicios pagados
                    servicios = servicio.ListarServiciosPagos();
                }
                else
                {
                    servicios = servicio.ListarServicios(_currentPage, PageSize);
                }

                if (servicios != null && servicios.Count > 0)
                {
                    var datosServicios = servicios.Select(serv => new
                    {
                        Factura = serv.facturaId,
                        CI_Cliente = serv.Cliente.ci,
                        CI_Empleado = serv.Empleado.ci,
                        Matricula = serv.Vehiculo.Matricula,
                        Fecha = serv.facturaFecha.ToString("dd/MM/yyyy HH:mm"),
                        HoraEntrada = serv.Parking?.HoraEntrada.ToString("HH:mm"),
                        HoraSalida = serv.Parking?.HoraSalida.ToString("HH:mm"),
                        Plaza = serv.Parking != null ? serv.Parking.Plaza.ToString() : "N/A",
                        Lavado = serv.Lavado.LavadoNombre,
                        Alineacion_Balanceo = serv.AlineacionBalanceo.aybNombre,
                        Neumatico = serv.neumaticoNombre,
                        Cantidad = serv.neumaticoCantidad
                    }).ToList();

                    // Vincular los datos filtrados al DataGridView
                    dgvServicios.DataSource = null;
                    dgvServicios.DataSource = datosServicios;
                }
                else
                {
                    MessageBox.Show("No se encontraron servicios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los servicios: " + ex.Message);
            }
        }
    }
}