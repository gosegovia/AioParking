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
    public partial class Parkings : Form
    {
        public Parkings()
        {
            InitializeComponent();
        }

        // Carga del menú
        private void Parking_Load(object sender, EventArgs e)
        {
            // Ocultar los paneles
            pDatos.Visible = false;
        } // Fin carga del menú

        // VALIDACIONES

        private void txtCI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarTicket.Focus();
            }
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
        }

        private void txtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
        }

        // FIN VALIDACIONES

        // Botón buscar cédula
        private void btnBuscarCI_Click(object sender, EventArgs e)
        {
            CapaNegocio.Parking p;
            Int32 ticket;

            if (!Int32.TryParse(txtTicket.Text, out ticket))
            {
                MessageBox.Show("El ticket debe ser numerico.");
            }
            else
            {
                p = new Parking();
                p.Ticket = ticket;
                p.conexion = Program.con;

                switch (p.buscarTicket())
                {
                    case 0: // Encontro
                        lblCi.Text = p.Cliente.ci.ToString();
                        lblMatricula.Text = p.Vehiculo.Matricula;
                        dtpEntrada.Value = p.HoraEntrada;
                        lblPlaza.Text = p.Plaza.ToString();

                        txtTicket.Enabled = false;
                        btnBuscarTicket.Enabled = false;
                        pDatos.Visible = true;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontro
                        MessageBox.Show("Formato incorrecto");
                        break;
                }
                p = null; // Destruyo el objeto
            }
        } // Fin botón buscar cédula

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Parking p;



            // Validaciones
            if (dtpEntrada.Value >= dtpSalida.Value)
            {
                MessageBox.Show("La hora de entrada no puede ser mayor o igual a la hora de salida");
            }
            else
            {
                p = new Parking();
                p.conexion = Program.con;
                p.Cliente.ci = Convert.ToInt32(lblCi.Text);
                p.Vehiculo.Matricula = lblMatricula.Text;
                p.HoraEntrada = dtpEntrada.Value;
                p.HoraSalida = dtpSalida.Value;
                p.Plaza = Convert.ToInt32(lblPlaza.Text);

                /*
                // Calcular la duración en horas
                TimeSpan duracion = p.HoraSalida - p.HoraEntrada;
                double horas = duracion.TotalHours;
                if (horas < 1)
                {
                    horas = 1; // Cobrar al menos una hora
                }

                // Asignar el precio según el tipo de vehículo
                double precio = 0;
                switch (p.Vehiculo.TipoVehiculo)
                {
                    case 1:
                        precio = 50 * horas;
                        break;
                    case 2:
                        precio = 100 * horas;
                        break;
                    case 3:
                        precio = 120 * horas;
                        break;
                    case 4:
                        precio = 150 * horas;
                        break;
                    case 5:
                        precio = 150 * horas;
                        break;
                    default:
                        MessageBox.Show("Tipo de vehículo no reconocido.");
                        return;
                }
                */
                double precio = 100;

                switch (p.GuardarParking(precio))
                {
                    case 0:
                        MessageBox.Show("El parking se guardo correctamente!");

                        txtTicket.Enabled = true;
                        txtTicket.Text = "";
                        btnBuscarTicket.Enabled = true;
                        pDatos.Visible = false;
                        lblCi.Text = "";
                        lblMatricula.Text = "";
                        lblPlaza.Text = "";
                        break;
                    case 1:
                        MessageBox.Show("Error al obtener la conexion.");
                        break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 3: MessageBox.Show("Error 3 Error: No se insertó la factura (Filas afectadas)"); break;
                    case 4: MessageBox.Show("Error 4 Error: No se obtuvo el ID de la factura"); break;
                    case 5: MessageBox.Show("Error 5 Error en la inserción de la factura"); break;
                    case 6: MessageBox.Show("Error 6 Error: No se insertó el parking (Filas afectadas)"); break;
                    case 7: MessageBox.Show("Error 7 Error: No se obtuvo el ID del parking"); break;
                    case 8: MessageBox.Show("Error 8 Error: en la inserción del parking"); break;
                    case 9: MessageBox.Show("Error 9 Error: No se actualizó el estado de la plaza"); break;
                    case 10: MessageBox.Show("Error 10 Error: No se insertó la reserva"); break;
                    case 11: MessageBox.Show("Error 11 Error: No se insertó la solicitud"); break;
                    case 12: MessageBox.Show("Error 12  Error: en las consultas de actualización"); break;
                }
            }
        } // Fin botón guardar


        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTicket.Enabled = true;
            txtTicket.Text = "";
            btnBuscarTicket.Enabled = true;
            pDatos.Visible = false;
            lblCi.Text = "";
            lblMatricula.Text = "";
            lblPlaza.Text = "";
        } // Fin botón cancelar
    }
}
