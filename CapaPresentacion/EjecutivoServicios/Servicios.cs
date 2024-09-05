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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void Servicios_Load(object sender, EventArgs e)
        {
            // Ocultar el panel de datos
            pDatos.Visible = false;

            // Inicializar los ComboBox con un valor predeterminado
            cbLavado.SelectedIndex = 6;
            cbMontaje.SelectedIndex = 1;
            cbAyB.SelectedIndex = 1;

            // Ocultar elementos de alineación y balanceo
            cbAlineacion.Visible = false;
            cbBalanceo.Visible = false;
            lblAlineacion.Visible = false;
            lblBalanceo.Visible = false;
        } // Fin de carga del formulario

        // Mostrar opciones de alineación y balanceo
        private void cbAyB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice seleccionado es 0
            if (cbAyB.SelectedIndex == 0)
            {
                cbAlineacion.Visible = true;
                cbBalanceo.Visible = true;
                lblAlineacion.Visible = true;
                lblBalanceo.Visible = true;

                cbAlineacion.SelectedIndex = 0;
                cbBalanceo.SelectedIndex = 0;
            }
            else
            {
                // Ocultar elementos de alineación y balanceo si no están seleccionados
                cbAlineacion.Visible = false;
                cbBalanceo.Visible = false;
                lblAlineacion.Visible = false;
                lblBalanceo.Visible = false;
            }
        }

        // VALIDACIONES
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }
        // FIN VALIDACIONES

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Servicio s;
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("La matrícula no puede estar vacía.");
            } else
            {
                s = new Servicio();
                s.Conexion = Program.con;

                switch (s.BuscarServicio(matricula))
                {
                    case 0:
                        txtMatricula.Enabled = false;
                        btnBuscar.Enabled = false;
                        pDatos.Visible = true;
                        break;
                    case 1:
                        MessageBox.Show("Error en la ejecución"); break;
                    case 2:
                        MessageBox.Show("No encontro"); break;
                }
            }
        }


        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación del lavado
            if (cbLavado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el lavado.");
                return; // Detener la ejecución
            }

            // Validación de alineación y balanceo
            if (cbAyB.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar alineación y balanceo.");
                return; // Detener la ejecución
            }

            // Validación del montaje
            if (cbMontaje.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el montaje.");
                return; // Detener la ejecución
            }

            if (cbAyB.SelectedIndex == 0)
            {
                // Validación de alineación
                if (cbAlineacion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar la alineación.");
                    return; // Detener la ejecución
                }

                // Validación de balanceo
                if (cbBalanceo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el balanceo.");
                    return; // Detener la ejecución
                }
            }

            // Limpiar los campos después de guardar
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón guardar

        // Botón eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se eliminaron los datos");

            // Limpiar los campos
            txtMatricula.Text = "";
            txtMatricula.Enabled = true;
            btnBuscar.Enabled = true;
            pDatos.Visible = false;
        } // Fin botón eliminar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            txtMatricula.Text = "";
            txtMatricula.Enabled = true;
            btnBuscar.Enabled = true;
            pDatos.Visible = false;
        } // Fin botón cancelar

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscar.Focus();
            }
        }
    }
}
