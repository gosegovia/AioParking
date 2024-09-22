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
                        lblHoraEntrada.Text = p.HoraEntrada.ToString();
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

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {


            // Limpiar los campos
            txtTicket.Text = "";
            txtTicket.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón guardar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTicket.Enabled = true;
            txtTicket.Text = "";
            btnBuscarTicket.Enabled = true;
            pDatos.Visible = false;
        } // Fin botón cancelar
    }
}
