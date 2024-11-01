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
                MessageBox.Show("El ticket debe ser numérico.");
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
                        MessageBox.Show("Debe logearse nuevamente."); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin."); break;
                    case 3: // No encontro
                        MessageBox.Show("Formato incorrecto.");
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
                MessageBox.Show("La hora de entrada no puede ser mayor o igual a la hora de salida.");
            }
            else
            {
                p = new Parking();
                p.conexion = Program.con;
                p.Cliente.ci = Convert.ToInt32(lblCi.Text);
                p.Empleado.ci = Program.frmPrincipal.CiEmpleado;
                p.Vehiculo.Matricula = lblMatricula.Text;
                p.HoraEntrada = dtpEntrada.Value;
                p.HoraSalida = dtpSalida.Value;
                p.Plaza = Convert.ToInt32(lblPlaza.Text);

                switch (p.calcularPrecio())
                {
                    case 0:
                        switch (p.GuardarParking())
                        {
                            case 0:
                                MessageBox.Show("El parking se guardo correctamente.");

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
                            case 3: MessageBox.Show("Error 3"); break;
                            case 4: MessageBox.Show("Error 4"); break;
                            case 5: MessageBox.Show("Error 5"); break;
                            case 6: MessageBox.Show("Error 6"); break;
                            case 7: MessageBox.Show("Error 7"); break;
                            case 8: MessageBox.Show("Error 8"); break;
                            case 9: MessageBox.Show("Error 9"); break;
                            case 10: MessageBox.Show("Error 10"); break;
                            case 11: MessageBox.Show("Error 11"); break;
                            case 12: MessageBox.Show("Error 12"); break;
                        }
                        break;
                    case 1: MessageBox.Show("Error al obtener la conexión."); break;
                    case 2: MessageBox.Show("Error 2."); break;
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
