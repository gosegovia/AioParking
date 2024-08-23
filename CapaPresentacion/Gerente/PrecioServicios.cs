using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Gerente
{
    public partial class PrecioServicios : Form
    {
        public PrecioServicios()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void PrecioServicios_Load(object sender, EventArgs e)
        {
            // Ocultar los paneles con datos
            pDatosNeumatico.Visible = false;
            pDatosLavado.Visible = false;
            pDatosAyB.Visible = false;
        } // Fin carga del formulario

        // VALIDACIONES
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtNeumatico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 5);
        }

        private void txtLavado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 5);
        }

        private void txtNombreLavado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void txtPrecioLavado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 5);
        }

        private void txtAyB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 5);
        }

        private void txtNombreAyB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 50);
        }

        private void txtPrecioAyB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        // FIN VALIDACIONES

        // Botón buscar neumático
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Si el texto está vacío, solicita que ingrese el neumático nuevamente
            if (string.IsNullOrEmpty(txtNeumatico.Text))
            {
                MessageBox.Show("Debe ingresar la ID del neumático.");
            }
            else
            {
                // Si el neumático es igual a 1
                if (txtNeumatico.Text == "1")
                {
                    // Mostrar el panel de datos
                    pDatosNeumatico.Visible = true;
                    // Bloquear el TextBox
                    txtNeumatico.ReadOnly = true;
                }
                else
                {
                    // Mostrar el MessageBox con dos botones
                    DialogResult resultado = MessageBox.Show("No existe este neumático, ¿desea ingresarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Evaluar la opción seleccionada por el usuario
                    if (resultado == DialogResult.Yes)
                    {
                        // El usuario seleccionó "Sí"
                        pDatosNeumatico.Visible = true;
                    }
                    else if (resultado == DialogResult.No)
                    {
                        // El usuario seleccionó "No"
                        pDatosNeumatico.Visible = false;
                    }
                }
            }
        } // Fin botón buscar neumático

        // Botón guardar neumático
        private void btnGuardarNeumatico_Click(object sender, EventArgs e)
        {
            // Validación modelo
            if (cbModelo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el modelo.");
                return; // Detener la ejecución
            }
            else
            {
                // Guardar el dato
            }

            if (string.IsNullOrEmpty(txtPrecioNeumatico.Text))
            {
                MessageBox.Show("Debe ingresar el precio del neumático.");
                return; // Detener la ejecución
            }
            else
            {
                // Guardar el dato
            }

            txtNeumatico.Text = "";
            pDatosNeumatico.Visible = false;
            txtNeumatico.ReadOnly = false;
        } // Fin botón guardar neumático

        // Botón eliminar neumático
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar neumático
            MessageBox.Show("Datos eliminados correctamente.");

            txtNeumatico.Text = "";
            pDatosNeumatico.Visible = false;
            txtNeumatico.ReadOnly = false;
        } // Fin botón eliminar neumático

        // Botón cancelar neumático
        private void btnCancelarNeumatico_Click(object sender, EventArgs e)
        {
            txtNeumatico.Text = "";
            pDatosNeumatico.Visible = false;
            txtNeumatico.ReadOnly = false;
        } // Fin botón cancelar neumático

        // Botón buscar lavado
        private void btnBuscarLavado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLavado.Text))
            {
                MessageBox.Show("Debe ingresar la ID del lavado.");
            }
            else
            {
                // Si el lavado es 1
                if (txtLavado.Text == "1")
                {
                    // Mostrar los datos
                    pDatosLavado.Visible = true;
                    // Bloquear el TextBox
                    txtLavado.ReadOnly = true;
                }
                else
                {
                    // Si no existe, mostrar un mensaje
                    MessageBox.Show("No existe ese servicio.");
                }
            }
        } // Fin botón buscar lavado

        // Botón guardar lavado
        private void btnGuardarLavado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecioLavado.Text))
            {
                MessageBox.Show("Debe ingresar el precio del lavado.");
                return; // Detener la ejecución
            }
            else
            {
                // Guardar el dato
            }

            txtLavado.Text = "";
            pDatosLavado.Visible = false;
            txtLavado.ReadOnly = false;
        } // Fin botón guardar lavado

        // Botón cancelar lavado
        private void btnCancelarLavado_Click(object sender, EventArgs e)
        {
            txtLavado.Text = "";
            pDatosLavado.Visible = false;
            txtLavado.ReadOnly = false;
        } // Fin botón cancelar lavado

        // Botón buscar AyB
        private void btnBuscarAyB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAyB.Text))
            {
                MessageBox.Show("Debe ingresar la ID de alineación y balanceo.");
            }
            else
            {
                // Si AyB es 1
                if (txtAyB.Text == "1")
                {
                    // Mostrar los datos
                    pDatosAyB.Visible = true;
                    txtAyB.ReadOnly = true;
                }
                else
                {
                    // Si no existe, mostrar un mensaje
                    MessageBox.Show("No existe ese servicio.");
                }
            }
        } // Fin botón buscar AyB

        // Botón guardar AyB
        private void btnGuardarAyB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecioAyB.Text))
            {
                MessageBox.Show("Debe ingresar el precio de alineación y balanceo.");
                return; // Detener la ejecución
            }
            else
            {
                // Guardar el dato
            }

            txtAyB.Text = "";
            pDatosAyB.Visible = false;
            txtAyB.ReadOnly = false;
        } // Fin botón guardar AyB

        // Botón cancelar AyB
        private void btnCancelarAyB_Click(object sender, EventArgs e)
        {
            txtAyB.Text = "";
            pDatosAyB.Visible = false;
            txtAyB.ReadOnly = false;
        } // Fin botón cancelar AyB

        private void txtLavado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
