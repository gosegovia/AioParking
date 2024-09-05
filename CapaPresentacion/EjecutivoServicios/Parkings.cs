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
            pMatricula.Visible = false;
            pDatos.Visible = false;
        } // Fin carga del menú

        // VALIDACIONES

        private void txtCI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarCI.Focus();
            }
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarMatricula.Focus();
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
        }

        private void txtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
        }

        // FIN VALIDACIONES

        // Botón buscar cédula
        private void btnBuscarCI_Click(object sender, EventArgs e)
        {
            CapaNegocio.Cliente c;
            Int32 cedula;

            if (!Int32.TryParse(txtCI.Text, out cedula))
            {
                MessageBox.Show("La cedula de identidad debe ser numerica");
            }
            else
            {
                // Asigno una nueva instancia de la clase Cliente al objeto c de dicha clase
                c = new Cliente();
                c.ci = cedula;

                switch (c.BuscarCI())
                {
                    case 0: // Encontro
                        txtCI.Enabled = false;
                        btnBuscarCI.Enabled = false;
                        pMatricula.Visible = true;
                        txtMatricula.Focus();
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontro
                        if (txtCI.TextLength < 8)
                        {
                            MessageBox.Show("Formato incorrecto");
                        }
                        break;
                }
                c = null; // Destruyo el objeto
            }
        } // Fin botón buscar cédula

        // Botón buscar matrícula
        private void btnBuscarMatricula_Click(object sender, EventArgs e)
        {
            
        }


        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si la fecha y hora de dtpEntrada es mayor que la de dtpSalida
            if (dtpEntrada.Value > dtpSalida.Value)
            {
                MessageBox.Show("La hora de entrada no puede ser mayor que la hora de salida");
                return; // Detener la ejecución si la plaza no es válida
            }

            // Validación de la plaza
            if (string.IsNullOrEmpty(txtPlaza.Text))
            {
                MessageBox.Show("Debe ingresar la plaza.");
                return; // Detener la ejecución si la plaza no es válida
            }

            // Limpiar los campos
            txtCI.Text = "";
            txtCI.ReadOnly = false;
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón guardar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCI.Enabled = true;
            txtCI.Text = "";
            btnBuscarCI.Enabled = true;
            txtMatricula.Enabled = true;
            txtMatricula.Text = "";
            btnBuscarMatricula.Enabled = true;
            pMatricula.Visible = false;
            pDatos.Visible = false;
        } // Fin botón cancelar
    }
}
