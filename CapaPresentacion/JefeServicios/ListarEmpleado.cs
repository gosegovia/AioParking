using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.JefeServicios
{
    public partial class ListarEmpleado : Form
    {
        private int _currentPage = 0;
        private const int PageSize = 15; // Número de empleados que se cargan por página
        private List<Empleado> _empleadosCargados = new List<Empleado>();

        public ListarEmpleado()
        {
            InitializeComponent();
        }

        private void ListarEmpleado_Load(object sender, EventArgs e)
        {
            // Forzar a que aparezcan ambos scrollbars
            dgvEmpleado.ScrollBars = ScrollBars.Both;

            // Cargar la primera tanda de empleados
            CargarEmpleados();

            // Asignar el evento de Scroll para detectar cuando llegar al final del DataGridView
            dgvEmpleado.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar si se llegó al final de las filas visibles
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (dgvEmpleado.Rows.Count > 0 &&
                    dgvEmpleado.FirstDisplayedScrollingRowIndex + dgvEmpleado.DisplayedRowCount(false) >= dgvEmpleado.Rows.Count)
                {
                    // Si se llega al final, cargar más empleados
                    CargarEmpleados();
                }
            }
        }

        private void CargarEmpleados()
        {
            estiloTabla();
            try
            {
                // Cambia el nombre de la variable para evitar conflictos
                Empleado empleado = new Empleado
                {
                    conexion = Program.con
                };

                // Llamar al método de paginación
                List<Empleado> nuevosEmpleados = empleado.ListarEmpleados(_currentPage, PageSize);

                if (nuevosEmpleados != null && nuevosEmpleados.Count > 0)
                {
                    _empleadosCargados.AddRange(nuevosEmpleados);

                    var datosEmpleados = _empleadosCargados
                        .Where(emp => emp.estado != 0)
                        .Select(emp => new
                        {
                            CI = emp.ci,
                            Nombre = emp.nombre,
                            Apellido = emp.apellido,
                            NumeroPuerta = emp.nroPuerta,
                            Calle = emp.calle,
                            Ciudad = emp.ciudad,
                            Rol = emp.Rol_Nombre,
                            Usuario = emp.usuario,
                            Telefonos = string.Join(", ", emp.Telefonos)
                        }).ToList();

                    // Actualizamos el DataSource con todos los empleados cargados hasta ahora
                    dgvEmpleado.DataSource = null; // Desenlazamos la fuente actual
                    dgvEmpleado.DataSource = datosEmpleados; // Asignamos la nueva lista actualizada

                    _currentPage++; // Avanzar a la siguiente página para cargar más datos en el futuro
                }
                else if (_currentPage == 0)
                {
                    MessageBox.Show("No se encontraron empleados en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los empleados: " + ex.Message);
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

            // Crear una instancia de Empleado
            Empleado emp = new Empleado { conexion = Program.con };

            // Asignar la cédula a buscar
            emp.ci = Convert.ToInt32(cedulaBuscada);

            // Llamar al método Buscar
            byte resultado = emp.BuscarEmpleado();

            if(emp.estado == 0)
            {
                MessageBox.Show("No existe el empleado.");
            }

            switch (resultado)
            {
                case 0: // Todo funcionó correctamente
                    var datosEmpleados = new List<object>
            {
                new
                {
                    CI = emp.ci,
                    Nombre = emp.nombre,
                    Apellido = emp.apellido,
                    NumeroPuerta = emp.nroPuerta,
                    Calle = emp.calle,
                    Ciudad = emp.ciudad,
                    Rol = emp.rol,
                    Usuario = emp.usuario,
                    Telefonos = string.Join(", ", emp.Telefonos)
                }
            };

                    dgvEmpleado.DataSource = null; // Resetear el DataGridView
                    dgvEmpleado.DataSource = datosEmpleados; // Asignar el empleado encontrado
                    break;

                case 1:
                    MessageBox.Show("La conexión a la base de datos está cerrada.");
                    break;

                case 2:
                    MessageBox.Show("Error 2");
                    break;

                case 3:
                    MessageBox.Show("Error 3");
                    break;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de búsqueda
            txtCI.Clear();

            // Resetear la lista de empleados cargados y la página actual
            _empleadosCargados.Clear();
            _currentPage = 0;

            // Volver a cargar todos los empleados
            CargarEmpleados();
        }

        public void estiloTabla()
        {
            // Fondo gris claro para las filas
            dgvEmpleado.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvEmpleado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvEmpleado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvEmpleado.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvEmpleado.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvEmpleado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmpleado.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvEmpleado.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvEmpleado.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvEmpleado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvEmpleado.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
    }
}
