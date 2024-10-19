using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ListarCliente : Form
    {
        private int _currentPage = 0;
        private const int PageSize = 15; // Número de clientes que se cargan por página
        private List<Cliente> _clientesCargados = new List<Cliente>();

        public ListarCliente()
        {
            InitializeComponent();
        }

        private void ListarCliente_Load(object sender, EventArgs e)
        {
            // Forzar a que aparezcan ambos scrollbars
            dgvCliente.ScrollBars = ScrollBars.Both;

            // Cargar la primera tanda de clientes
            CargarClientes();

            // Asignar el evento de Scroll para detectar cuando llegar al final del DataGridView
            dgvCliente.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }

        private void txtCI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscar.Focus();
            }
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar si se llegó al final de las filas visibles
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (dgvCliente.Rows.Count > 0 &&
                    dgvCliente.FirstDisplayedScrollingRowIndex + dgvCliente.DisplayedRowCount(false) >= dgvCliente.Rows.Count)
                {
                    // Si se llega al final, cargar más clientes
                    CargarClientes();
                }
            }
        }

        private void CargarClientes()
        {
            estiloTabla();
            try
            {
                Cliente c = new Cliente
                {
                    conexion = Program.con
                };

                // Llamar al método de paginación
                List<Cliente> nuevosClientes = c.ListarClientes(_currentPage, PageSize);

                if (nuevosClientes != null && nuevosClientes.Count > 0)
                {
                    _clientesCargados.AddRange(nuevosClientes);

                    var datosClientes = _clientesCargados
                        .Where(cl => cl.estado != 0)
                        .Select(cl => new
                        {
                            CI = cl.ci,
                            Nombre = cl.nombre,
                            Apellido = cl.apellido,
                            NumeroPuerta = cl.nroPuerta,
                            Calle = cl.calle,
                            Ciudad = cl.ciudad,
                            Tipo_Cliente = cl.TipoCliente,
                            Telefonos = string.Join(", ", cl.Telefonos)
                        }).ToList();

                    // Actualizamos el DataSource con todos los clientes cargados hasta ahora
                    dgvCliente.DataSource = null; // Desenlazamos la fuente actual
                    dgvCliente.DataSource = datosClientes; // Asignamos la nueva lista actualizada

                    _currentPage++; // Avanzar a la siguiente página para cargar más datos en el futuro
                }
                else if (_currentPage == 0)
                {
                    MessageBox.Show("No se encontraron clientes en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los clientes: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedulaBuscada = txtCI.Text.Trim();

            if (string.IsNullOrEmpty(cedulaBuscada))
            {
                MessageBox.Show("Por favor, ingrese una cédula para buscar.");
                return;
            }

            // Crear una instancia de Cliente
            Cliente c = new Cliente { conexion = Program.con };

            // Asignar la cédula a buscar
            c.ci = Convert.ToInt32(cedulaBuscada);

            // Llamar al método Buscar
            byte resultado = c.Buscar();

            if (c.estado == 0)
            {
                MessageBox.Show("No existe el cliente.");
            } else
            {
                switch (resultado)
                {
                    case 0: // Todo funcionó correctamente
                        var datosClientes = new List<object>
            {
                new
                {
                    CI = c.ci,
                    Nombre = c.nombre,
                    Apellido = c.apellido,
                    NumeroPuerta = c.nroPuerta,
                    Calle = c.calle,
                    Ciudad = c.ciudad,
                    Tipo_Cliente = c.TipoCliente,
                    Telefonos = string.Join(", ", c.Telefonos)
                }
            };

                        dgvCliente.DataSource = null; // Resetear el DataGridView
                        dgvCliente.DataSource = datosClientes; // Asignar el cliente encontrado
                        break;

                    case 1:
                        MessageBox.Show("La conexión a la base de datos está cerrada.");
                        break;

                    case 2:
                        MessageBox.Show("Error en la ejecución de la consulta.");
                        break;

                    case 3:
                        MessageBox.Show("No se encontró un cliente con esa cédula.");
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
            txtCI.Clear();

            // Resetear la lista de clientes cargados y la página actual
            _clientesCargados.Clear();
            _currentPage = 0;

            // Volver a cargar todos los clientes
            CargarClientes();
        }

        public void estiloTabla()
        {
            // Fondo gris claro para las filas
            dgvCliente.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvCliente.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvCliente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvCliente.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCliente.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvCliente.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvCliente.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvCliente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvCliente.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
    }
}
