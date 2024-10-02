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
            pMatricula.Visible = false;
        } // Fin carga del formulario

        private void btnBuscarCi_Click(object sender, EventArgs e)
        {
            CapaNegocio.Cliente c;
            Int32 cedula;

            if (!Int32.TryParse(txtCi.Text, out cedula))
            {
                MessageBox.Show("La cedula de identidad debe ser numerica");
            }
            else
            {
                c = new Cliente();
                c.ci = cedula;
                c.conexion = Program.con;

                switch (c.BuscarCI())
                {
                    case 0: // Encontro
                        txtCi.Enabled = false;
                        btnBuscarCi.Enabled = false;
                        pMatricula.Visible = true;
                        txtMatricula.Focus();

                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontró
                        if (txtCi.TextLength != 8)
                        {
                            MessageBox.Show("Formato incorrecto");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente con la cédula ingresada.");
                        }
                        break;
                    default: MessageBox.Show("Error al obtener la cedula."); break;
                }
                c = null; // Destruyo el objeto
            }
        }

        // Botón buscar matrícula
        private void btnBuscarMatricula_Click(object sender, EventArgs e)
        {
            CapaNegocio.Vehiculo v = new CapaNegocio.Vehiculo();
            string matricula = txtMatricula.Text.Trim();

            // Validar que la matrícula no esté vacía
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("La matrícula no puede estar vacía.");
                return;
            }

            // Validar que el CI no esté vacío y sea un número válido
            if (!int.TryParse(txtCi.Text.Trim(), out int ci))
            {
                MessageBox.Show("Ingrese un CI válido.");
                return;
            }

            // Asignar la conexión y la matrícula al objeto Vehiculo
            v.Conexion = Program.con;
            v.Matricula = matricula;

            try
            {
                // Realizar la búsqueda de la matrícula
                switch (v.BuscarMatricula(ci))
                {
                    case 0: // Vehículo encontrado
                        txtMatricula.Enabled = false;
                        btnBuscarMatricula.Enabled = false;
                        pDatos.Visible = true;

                        break;

                    case 1: // Error de sesión
                        MessageBox.Show("Debe logearse nuevamente.");
                        break;

                    case 2: // Error en la ejecución de la consulta SQL
                        MessageBox.Show("Error en la ejecución de la consulta.");
                        break;

                    case 3: // Vehículo no encontrado
                        MessageBox.Show("Este vehículo no está asociado al cliente seleccionado.");
                        break;

                    default: // Caso inesperado
                        MessageBox.Show("Error desconocido.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Liberar el objeto Vehiculo, aunque no es estrictamente necesario
                v = null;
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
                lblMarca.Text = "Michelin";
                lblPrecio.Text = "1000";
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

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void txtCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarCi.Focus();
            }
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarMatricula.Focus();
            }
        }
    }
}
