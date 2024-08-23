using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ListarCliente : Form
    {
        public ListarCliente()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ListarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de Cliente desde la capa de negocio
                Cliente c = new Cliente();
                c.conexion = Program.cn;

                // Obtener la lista de clientes
                List<Cliente> clientes = c.ListarClientes();

                if (clientes != null && clientes.Count > 0)
                {
                    // Filtrar los clientes para excluir aquellos con estado = 0
                    var clientesFiltrados = clientes.Where(cl => cl.estado != 0).ToList();

                    if (clientesFiltrados.Count > 0)
                    {
                        // Transformar los datos de los clientes para mostrarlos en el DataGridView
                        var datosClientes = clientesFiltrados.Select(cl => new
                        {
                            CI = cl.ci,
                            Nombre = cl.nombre,
                            Apellido = cl.apellido,
                            NumeroPuerta = cl.nroPuerta,
                            Calle = cl.calle,
                            Ciudad = cl.ciudad,
                            TipoCliente = cl.TipoCliente,
                            Telefonos = string.Join(", ", cl.Telefonos) // Concatenar los teléfonos
                        }).ToList();

                        // Asignar los datos al DataGridView
                        dgvCliente.DataSource = datosClientes;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron clientes activos en la base de datos.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron clientes en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los clientes: " + ex.Message);
            }
        }


        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana
            this.Close();
        } // Fin botón volver
    }
}
