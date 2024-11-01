using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Cajero
{
    public partial class ListarFacturas : Form
    {
        private int _currentPage = 0;
        private const int PageSize = 13; // Número de servicios a cargar por página
        private List<Factura> _serviciosCargados = new List<Factura>();

        public ListarFacturas()
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
            dgvServicios.Scroll += DataGridView_Scroll;
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

        private void CargarServicios(int? ciCliente = null, bool? facturaPaga = null)
        {
            estiloTabla();
            try
            {
                // Crear un objeto de Factura
                var facturaService = new Factura
                {
                    Conexion = Program.con
                };

                // Paginación de los servicios
                List<Factura> nuevosServicios = facturaService.ListarServicios(_currentPage, PageSize, ciCliente, facturaPaga);

                // Verificar si se encontraron nuevos servicios
                if (nuevosServicios != null && nuevosServicios.Any())
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
                        Plaza = serv.Parking?.Plaza.ToString() ?? "N/A",
                        Lavado = serv.Lavado?.LavadoNombre ?? "N/A",
                        Alineacion_Balanceo = serv.AlineacionBalanceo?.aybNombre ?? "N/A",
                        Neumatico = serv.Neumatico?.neumaticoNombre ?? "N/A",
                        Cantidad = serv.Neumatico?.neumaticoCantidad ?? 0
                    }).ToList();

                    // Vincular los datos al DataGridView
                    dgvServicios.DataSource = null;
                    dgvServicios.DataSource = datosServicios;

                    _currentPage++; // Avanzar a la siguiente página
                }
                else if (_currentPage == 0)
                {
                    // No hay servicios en la primera página
                    MessageBox.Show("No se encontraron servicios.");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar los servicios.");
            }
        }

        private void btnBuscarCi_Click(object sender, EventArgs e)
        {
            string ciBuscada = txtCI.Text.Trim();

            // Validar que se ha ingresado una cédula
            if (string.IsNullOrEmpty(ciBuscada))
            {
                MessageBox.Show("Por favor, ingrese una cédula para buscar.");
                return;
            }

            try
            {
                // Convertir la cédula ingresada a entero
                if (!int.TryParse(ciBuscada, out int ciCliente))
                {
                    MessageBox.Show("La cédula ingresada no es válida. Por favor, ingrese un número.");
                    return;
                }

                // Limpiar los servicios cargados y reiniciar la página
                _serviciosCargados.Clear();
                _currentPage = 0;

                // Verificar si el CheckBox de pago está marcado
                bool? facturaPaga = cbPaga.Checked ? (bool?)true : null;

                // Cargar los servicios filtrados por CI y factura_paga (pago)
                CargarServicios(ciCliente, facturaPaga);
            }
            catch
            {
                MessageBox.Show($"Ocurrió un error al buscar los servicios.");
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            ReiniciarCargaServicios();

            // Recargar todos los servicios
            CargarServicios();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPaga_CheckedChanged(object sender, EventArgs e)
        {
            // Reiniciar carga de servicios
            ReiniciarCargaServicios();

            string ciBuscada = txtCI.Text.Trim();

            // Limpiar el DataGridView antes de cargar nuevos datos
            dgvServicios.DataSource = null; // Esto es opcional, pero ayuda a evitar mezclas

            // Intentar convertir la cédula a entero solo si no está vacío
            if (!string.IsNullOrEmpty(ciBuscada) && int.TryParse(ciBuscada, out int ciCliente))
            {
                // Cargar servicios filtrados por CI y estado de pago
                CargarServicios(ciCliente, cbPaga.Checked);
            }
            else
            {
                // Asegurarse de reiniciar la página al cargar todos los servicios
                _currentPage = 0;

                // Cargar todos los servicios o solo pagados según el CheckBox
                CargarServicios(null, cbPaga.Checked);
            }
        }


        private void ReiniciarCargaServicios()
        {
            txtCI.Clear();
            // Limpiar los servicios cargados y reiniciar la página
            _serviciosCargados.Clear();
            _currentPage = 0;
        }

        public void estiloTabla()
        {
            // Fondo gris claro para las filas
            dgvServicios.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvServicios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvServicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvServicios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServicios.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvServicios.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvServicios.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvServicios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvServicios.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
    }
}
