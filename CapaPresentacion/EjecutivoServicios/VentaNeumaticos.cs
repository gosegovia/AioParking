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
    public partial class VentaNeumaticos : Form
    {
        public VentaNeumaticos()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void VentaNeumaticos_Load(object sender, EventArgs e)
        {
            // Ocultar el panel de datos
            pDatos.Visible = false;
        } // Fin carga del formulario



        // Botón buscar matrícula
        private void btnBuscarMatricula_Click(object sender, EventArgs e)
        {
            // Validar entrada de matrícula
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Debe ingresar la matrícula.");
                return;
            }

            // Verificar la matrícula ingresada
            if (txtMatricula.Text == "1")
            {
                // Mostrar el panel de datos y bloquear el TextBox de matrícula
                pDatos.Visible = true;
                txtMatricula.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("La matrícula no existe.");
            }
        } // Fin botón buscar matrícula

        // Botón buscar neumático
        private void btnBuscarNeumatico_Click(object sender, EventArgs e)
        {
            // Validar entrada de neumático
            if (string.IsNullOrEmpty(txtNeumatico.Text))
            {
                MessageBox.Show("Debe ingresar el neumático.");
                return;
            }

            // Simular búsqueda del neumático
            if (txtNeumatico.Text == "1")
            {
                // Mostrar datos del neumático
                txtMarca.Text = "Michelin";
                txtPrecio.Text = "1000";
            }
            else
            {
                MessageBox.Show("El neumático no existe.");
            }
        } // Fin botón buscar neumático

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar cantidad
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad.");
                return;
            }

            // Limpiar y ocultar datos después de guardar
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón guardar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar y restablecer el estado del formulario
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón cancelar

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtNeumatico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 5);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 3);
        }
    }
}
