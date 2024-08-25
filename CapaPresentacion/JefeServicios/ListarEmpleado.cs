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
        public ListarEmpleado()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ListarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de empleados desde la capa de negocio
                Empleado emp = new Empleado();
                emp.conexion = Program.cn;

                // Obtener la lista de empleados
                List<Empleado> empleados = emp.ListarEmpleado();

                if (empleados != null && empleados.Count > 0)
                {
                    // Filtrar los empleados para excluir aquellos con estado = 0
                    var empleadosFiltrados = empleados.Where(empe => empe.estado != 0).ToList();

                    if (empleadosFiltrados.Count > 0)
                    {
                        // Transformar los datos de los empleados para mostrarlos en el DataGridView
                        var datosEmpleados = empleadosFiltrados.Select(empe => new
                        {
                            CI = empe.ci,
                            Nombre = empe.nombre,
                            Apellido = empe.apellido,
                            NumeroPuerta = empe.nroPuerta,
                            Calle = empe.calle,
                            Ciudad = empe.ciudad,
                            Telefonos = string.Join(", ", empe.Telefonos), // Concatenar los teléfonos
                            Rol = empe.rol,
                            Usuario = empe.usuario
                        }).ToList();

                        // Asignar los datos al DataGridView
                        dgvEmpleado.DataSource = datosEmpleados;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron empleados activos en la base de datos.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron empleados en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los empleados: " + ex.Message);
            }
        }



        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual
            this.Close();
        } // Fin botón volver
    }
}
