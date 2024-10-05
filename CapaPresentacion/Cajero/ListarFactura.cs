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

namespace CapaPresentacion.Cajero
{
    public partial class ListarFactura : Form
    {
        public ListarFactura()
        {
            InitializeComponent();
        }

        private void ListarFactura_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana
            this.Close();
        }

        string dato = "";

        private void txtCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarCi.Focus();
            }
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void btnBuscarCi_Click(object sender, EventArgs e)
        {
            Busqueda_en_Grid(dgvServicios, 1);
        }

        private void mostrarDatos()
        {
            try
            {
                // Crear una instancia de Servicio desde la capa de negocio
                Servicio s = new Servicio
                {
                    // Asegúrate de que la conexión esté asignada si es necesario
                    Conexion = Program.con // Asumiendo que Program.con es la conexión global
                };

                // Obtener la lista de servicios
                List<Servicio> servicios = s.ListarServicios();

                if (servicios != null && servicios.Count > 0)
                {
                    // Transformar los datos de los servicios para mostrarlos en el DataGridView
                    var datosServicios = servicios.Select(serv => new
                    {
                        Factura = serv.facturaId,
                        CI = serv.Cliente.ci, // CI del cliente relacionado
                        Matricula = serv.Vehiculo.Matricula, // Matrícula del vehículo relacionado
                        Fecha = serv.facturaFecha.ToString("dd/MM/yyyy HH:mm"), // Formato de fecha
                        HoraEntrada = serv.Parking.HoraEntrada.ToString("HH:mm"),
                        HoraSalida = serv.Parking.HoraSalida.ToString("HH:mm"),
                        Plaza = serv.Parking.Plaza,
                        Lavado = serv.lavadoNombre,
                        Alineacion_Balanceo = serv.aybNombre,
                        Neumatico = serv.neumaticoNombre,
                        Cantidad = serv.neumaticoCantidad
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvServicios.DataSource = datosServicios;
                }
                else
                {
                    MessageBox.Show("No se encontraron servicios en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los servicios: " + ex.Message);
            }
        }

        private void Busqueda_en_Grid(DataGridView d, int col)
        {
            for(int i = 0; i < d.Rows.Count - 1; i++)
            {
                dato = Convert.ToString(d.Rows[i].Cells[col].Value);
                if(dato == txtCi.Text.Trim())
                {
                    MessageBox.Show("Se encontro la matricula");
                    break;
                }
            }
        }
    }
}
