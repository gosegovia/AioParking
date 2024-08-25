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

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ListarVehiculo : Form
    {
        public ListarVehiculo()
        {
            InitializeComponent();
        }

        private void ListarVehiculo_Load(object sender, EventArgs e)
        {
            try
            {
                Vehiculo v = new Vehiculo
                {
                    conexion = Program.cn
                };

                Dictionary<string, int> vehiculosClientes;
                List<Vehiculo> vehiculos = v.ListarVehiculo(out vehiculosClientes);

                if (vehiculos != null && vehiculos.Count > 0)
                {
                    var datosVehiculos = vehiculos.Select(ve => new
                    {
                        Matricula = ve.matricula,
                        Ci = vehiculosClientes.ContainsKey(ve.matricula) ? vehiculosClientes[ve.matricula] : 0,
                        TipoVehiculo = ve.NombreVehiculo, // Aquí se muestra el nombre del tipo de vehículo
                        Marca = ve.NombreMarca
                    }).ToList();

                    dgvVehiculo.DataSource = datosVehiculos;
                }
                else
                {
                    MessageBox.Show("No se encontraron vehículos en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los vehículos: " + ex.Message);
            }
        }

        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra la ventana
            this.Close();
        } // Fin botón volver

        // Botón entregar
        private void btnEntregar_Click(object sender, EventArgs e)
        {

        } // Fin botón entregar
    }
}
