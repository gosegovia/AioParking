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

        private void txtNeumatico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarNeumatico.Focus();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 3);
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
            CapaNegocio.Servicio s;
            Int32 neumatico;

            // Validar que la CI sea numérica
            if (!Int32.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El id neumatico debe ser numerico.");
            }
            else
            {
                s = new Servicio();
                s.neumaticoId = neumatico;
                s.Conexion = Program.con; // Asigna la conexión desde el programa principal

                switch (s.BuscarNeumatico())
                {
                    case 0:
                        if (s.neumaticoEstado == 0)
                        {
                            // Pregunta al usuario si desea recuperar al cliente inactivo
                            DialogResult estadoRespuesta = MessageBox.Show("¿Este neumatico esta dado de baja, desea recuperarlo?", "Inactivo", MessageBoxButtons.YesNo);
                            if (estadoRespuesta == DialogResult.Yes)
                            {
                                s.neumaticoEstado = 1; // Cambia el estado del cliente a activo
                            }
                            else
                            {
                                // Si no desea recuperar, limpia la CI y termina
                                txtNeumatico.Text = "";
                                return;
                            }
                        }

                        btnBuscarNeumatico.Enabled = false;
                        btnEliminar.Enabled = true;
                        txtNeumatico.Enabled = false;
                        pDatosNeumatico.Visible = true;

                        txtNombre.Text = s.neumaticoNombre;
                        txtPrecio.Text = s.neumaticoPrecio.ToString();
                        txtStock.Text = s.neumaticoCantidad.ToString();

                        switch (s.neumaticoMarca)
                        {
                            case "Michelin": cbModelo.SelectedIndex = 0; break;
                            case "Bridgestone": cbModelo.SelectedIndex = 1; break;
                            case "Pirelli": cbModelo.SelectedIndex = 2; break;
                        }
                    break;
                    case 1: // Error de conexión
                        MessageBox.Show("Debe logearse nuevamente");
                        break;

                    case 2: // Error en la ejecución
                        MessageBox.Show("Error 2");
                        break;
                    case 3: // No encontró neumatico
                        if (txtNeumatico.TextLength > 3)
                        {
                            MessageBox.Show("Formato incorrecto");
                        }
                        else
                        {
                            // Pregunta si desea dar de alta al nuevo neumatico
                            DialogResult respuesta = MessageBox.Show("¿Desea efectuar el alta?", "Alta", MessageBoxButtons.YesNo);
                            if (respuesta == DialogResult.Yes)
                            {
                                // Habilita el panel para ingresar los datos del nuevo neumatico
                                btnBuscarNeumatico.Enabled = false;
                                pDatosNeumatico.Visible = true;
                                btnEliminar.Enabled = false;
                                txtNombre.Clear();
                                txtPrecio.Clear();
                                txtStock.Clear();
                                cbModelo.SelectedIndex = 0;
                            }
                        }
                    break;
                }
                s = null;
            }
        } // Fin botón buscar neumático

        // Botón guardar neumático
        private void btnGuardarNeumatico_Click(object sender, EventArgs e)
        {
            CapaNegocio.Servicio s;
            Int32 neumatico;

            // Validaciónes
            if (!Int32.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El id neumatico debe ser numerico");
            } else
            {
                s = new Servicio();
                s.Conexion = Program.con;

                s.neumaticoId = Convert.ToInt32(txtNeumatico.Text);
                s.neumaticoNombre = txtNombre.Text;
                s.neumaticoPrecio = Convert.ToInt32(txtPrecio.Text);
                s.neumaticoCantidad = Convert.ToInt32(txtStock.Text);

                switch (cbModelo.SelectedIndex)
                {
                    case 0: s.neumaticoMarca = "Michelin"; break;
                    case 1: s.neumaticoMarca = "Bridgestone"; break;
                    case 2: s.neumaticoMarca = "Pirelli"; break;
                }

                switch (s.GuardarNeumatico(btnEliminar.Enabled))
                {
                    case 0:
                        MessageBox.Show("Se ingreso el neumatico.");

                        btnBuscarNeumatico.Enabled = true;
                        txtNeumatico.Text = "";
                        txtNeumatico.Enabled = true;
                        pDatosNeumatico.Visible = false;

                        txtNombre.Clear();
                        cbModelo.SelectedIndex = 0;
                        txtPrecio.Clear();
                        txtStock.Clear();
                    break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                    break;
                    case 2: MessageBox.Show("Error 2"); break;
                }
            }
        } // Fin botón guardar neumático

        // Botón eliminar neumático
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Servicio s;
            Int32 neumatico;

            // Verifica que el neumatico ingresada sea numérica
            if (!Int32.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El id neumatico debe ser numerico.");
            }
            else
            {
                s = new Servicio();
                s.Conexion = Program.con;
                s.neumaticoId = neumatico;

                // Pregunta al usuario si desea eliminar el cliente
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este neumatico?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si la respuesta es 'Yes', procede con la eliminación
                if (respuesta == DialogResult.Yes)
                {
                    // Llama al método Eliminar() y gestiona los diferentes resultados
                    switch (s.EliminarNeumatico())
                    {
                        case 0: // Eliminación exitosa
                            MessageBox.Show("Datos eliminados correctamente.");

                            btnBuscarNeumatico.Enabled = true;
                            txtNeumatico.Text = "";
                            txtNeumatico.Enabled = true;
                            pDatosNeumatico.Visible = false;

                            txtNombre.Clear();
                            cbModelo.SelectedIndex = 0;
                            txtPrecio.Clear();
                            txtStock.Clear();
                            break;
                        case 1: // Conexión cerrada
                            MessageBox.Show("Debe logearse nuevamente, la conexión está cerrada.");
                            break;
                        case 2: MessageBox.Show("Error 2."); break;
                    }
                }

                // Libera la instancia de la clase Servicio
                s = null;
            }
        } // Fin botón eliminar neumático

        // Botón cancelar neumático
        private void btnCancelarNeumatico_Click(object sender, EventArgs e)
        {
            btnBuscarNeumatico.Enabled = true;
            txtNeumatico.Text = "";
            txtNeumatico.Enabled = true;
            pDatosNeumatico.Visible = false;

            txtNombre.Clear();
            cbModelo.SelectedIndex = 0;
            txtPrecio.Clear();
            txtStock.Clear();
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

        private void lblNeumatico_Click(object sender, EventArgs e)
        {

        }

        private void txtNeumatico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
