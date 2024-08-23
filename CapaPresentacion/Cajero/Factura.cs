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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        // Cargar formulario
        private void Factura_Load(object sender, EventArgs e)
        {
            // Ocultar los paneles
            pDatos.Visible = false;
            pDatosServicios.Visible = false;
            btnFactura.Visible = false;
            btnCancelar.Visible = false;
        } // Fin cargar formulario

        // VALIDACIONES
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        // FIN VALIDACIONES

        // Botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Si es nulo, pide que ingrese la matrícula nuevamente
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Debe ingresar la matrícula.");
            }
            else
            {
                // Si la matrícula ingresada es 1
                if (txtMatricula.Text == "1")
                {
                    // Le permitimos el acceso a los datos
                    pDatos.Visible = true;
                    pDatosServicios.Visible = true;
                    btnFactura.Visible = true;
                    btnCancelar.Visible = true;
                    // Bloquear el TextBox para que el usuario no pueda ingresar otra matrícula
                    txtMatricula.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("La matrícula no existe.");
                }
            }
        } // Fin botón buscar

        // Botón Factura
        private void btnFactura_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Factura generada.");

            pDatos.Visible = false;
            pDatosServicios.Visible = false;
            btnFactura.Visible = false;
            btnCancelar.Visible = false;
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
        } // Fin botón factura

        // Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pDatos.Visible = false;
            pDatosServicios.Visible = false;
            btnFactura.Visible = false;
            btnCancelar.Visible = false;
            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
        } // Fin botón cancelar
    }
}
