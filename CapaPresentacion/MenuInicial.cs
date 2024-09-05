using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Vehiculo y asignar la conexión
            CapaNegocio.Vehiculo v = new CapaNegocio.Vehiculo();
            v.Conexion = Program.con;

            try
            {
                // Verificar que la conexión esté abierta
                if (!v.Conexion.Abierta())
                {
                    throw new InvalidOperationException("La conexión está cerrada.");
                }

                // Obtener la cantidad de vehículos por tipo
                var vehiculosPorTipo = v.VehiculosActuales();

                // Asignar los valores a las etiquetas basándose en el tipo de vehículo
                lblCantAutos.Text = vehiculosPorTipo.ContainsKey(1) ? vehiculosPorTipo[1].ToString() : "0";
                lblCantUtilitarios.Text = vehiculosPorTipo.ContainsKey(2) ? vehiculosPorTipo[2].ToString() : "0";
                lblCantMotos.Text = vehiculosPorTipo.ContainsKey(3) ? vehiculosPorTipo[3].ToString() : "0";
                lblCantCamionetas.Text = vehiculosPorTipo.ContainsKey(4) ? vehiculosPorTipo[4].ToString() : "0";
                lblCantCamiones.Text = vehiculosPorTipo.ContainsKey(5) ? vehiculosPorTipo[5].ToString() : "0";

                // Calcular el total de vehículos
                int totalVehiculos = vehiculosPorTipo.Values.Sum();

                // Asignar el total a lblCantTotal
                lblCantTotal.Text = totalVehiculos.ToString();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre una excepción
                MessageBox.Show("No se pudo cargar la información de vehículos. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
