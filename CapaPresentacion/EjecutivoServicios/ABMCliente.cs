using System;
using System.Windows.Forms;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        // Cuando carga el menú ABMCliente
        private void ABMCliente_Load(object sender, EventArgs e)
        {
            // Oculto los datos para que solo ingrese la cédula
            pDatos.Visible = false;
        }

        // VALIDACIONES
        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void txtNroPuerta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 6);
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
        }

        private void cbTelefonos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitudCB(sender, e, 10);
        }

        private void txtCI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscar.Focus();
            }
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            if (cbTelefonos.Items.IndexOf(cbTelefonos.Text) < 0)
            {
                cbTelefonos.Items.Add(cbTelefonos.Text);
            }
            else
            {
                MessageBox.Show("El telefono ya existe en la lista");
            }
        }

        private void btnEliminarTelefono_Click(object sender, EventArgs e)
        {
            if (cbTelefonos.Items.IndexOf(cbTelefonos.Text) < 0)
            {
                MessageBox.Show("El telefono no exste en la lista");
            }
            else
            {
                cbTelefonos.Items.Remove(cbTelefonos.Text);
            }
        }

        // FIN VALIDACIONES

        // Botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
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
                c.conexion = Program.cn;
                c.ci = cedula;

                switch (c.Buscar())
                {
                    case 0: // Encontro
                        if (c.estado == 0)
                        {
                            DialogResult estadoRespuesta = MessageBox.Show("¿Este cliente esta dado de baja, desea recuperarlo?", "Inactivo", MessageBoxButtons.YesNo);
                            if (estadoRespuesta == DialogResult.Yes)
                            {
                                c.estado = 1;
                            }
                            else
                            {
                                txtCI.Text = "";
                                // Ver despues
                                return;
                            }
                        }

                        btnBuscar.Enabled = false;
                        txtCI.Enabled = false;
                        pDatos.Visible = true;
                        btnEliminar.Enabled = true;

                        txtNombre.Text = c.nombre;
                        txtApellido.Text = c.apellido;
                        txtNroPuerta.Text = c.nroPuerta.ToString();
                        txtCalle.Text = c.calle;
                        txtCiudad.Text = c.ciudad;

                        switch (c.TipoCliente)
                        {
                            case "Mensual":
                                cbTipoCliente.SelectedIndex = 0; break;
                            case "Sistemático":
                                cbTipoCliente.SelectedIndex = 1; break;
                            case "Eventual":
                                cbTipoCliente.SelectedIndex = 2; break;
                            default:
                                MessageBox.Show("Error con el tipo de cliente"); break;
                        }

                        string telefono;
                        cbTelefonos.Items.Clear();
                        foreach (string tel in c.Telefonos)
                        {
                            telefono = "0" + tel;
                            cbTelefonos.Items.Add(telefono);
                        }
                        cbTelefonos.SelectedIndex = 0;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2:
                    case 4:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontro
                        if (txtCI.TextLength < 8)
                        {
                            MessageBox.Show("Formato incorrecto");
                        }
                        else
                        {
                            DialogResult respuesta = MessageBox.Show("¿Desea efectuar el alta?", "Alta", MessageBoxButtons.YesNo);
                            if (respuesta == DialogResult.Yes)
                            {
                                btnBuscar.Enabled = false;
                                pDatos.Visible = true;
                                btnEliminar.Enabled = false;
                                txtNombre.Clear();
                                txtApellido.Clear();
                                txtNroPuerta.Clear();
                                txtCalle.Clear();
                                txtCiudad.Clear();
                                cbTelefonos.Items.Clear();
                                cbTelefonos.Text = "";
                                cbTipoCliente.SelectedIndex = 0;
                            }
                        }
                        break;
                }
                c = null; // Destruyo el objeto
            }
        } // Fin botón buscar

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Cliente c;
            Int32 cedula;

            // Validaciónes
            if (!Int32.TryParse(txtCI.Text, out cedula))
            {
                MessageBox.Show("La cedula de identidad debe ser numerica.");
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre o revisar su formato.");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido o revisar su formato.");
            }
            else if (cbTelefonos.SelectedIndex == -1 || string.IsNullOrEmpty(cbTelefonos.Text))
            {
                MessageBox.Show("Debe seleccionar el telefono o ingresar uno.");
            }
            else if (cbTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de cliente.");
            }
            else if (string.IsNullOrEmpty(txtNroPuerta.Text))
            {
                MessageBox.Show("Debe ingresar el número de puerta o revisar su formato.");
            }
            else if (string.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Debe ingresar la calle o revisar su formato.");
            }
            else if (string.IsNullOrEmpty(txtCiudad.Text))
            {
                MessageBox.Show("Debe ingresar la ciudad o revisar su formato.");
            }
            else
            {
                c = new Cliente();
                c.conexion = Program.cn;
                c.ci = cedula;
                c.nombre = txtNombre.Text;
                c.apellido = txtApellido.Text;
                c.nroPuerta = int.Parse(txtNroPuerta.Text);
                c.calle = txtCalle.Text;
                c.ciudad = txtCiudad.Text;
                c.TipoCliente = cbTipoCliente.SelectedItem.ToString();
                c.estado = 1;

                // Para cada telefono de string del combo box
                foreach (string telefono in cbTelefonos.Items)
                {
                    c.Telefonos.Add(telefono); // Agrego cada telefono que tenga el combo box
                }

                switch (c.Guardar(btnEliminar.Enabled))
                {
                    case 0: // Se realizo sin problemas
                        MessageBox.Show("Se ingreso el cliente.");

                        txtCI.Text = "";
                        btnBuscar.Enabled = true;
                        txtCI.Enabled = true;
                        pDatos.Visible = false;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 3: MessageBox.Show("Error 3"); break;
                    case 4: MessageBox.Show("Error 4"); break;
                }
                c = null; // Liberar memoria
            }
        } // Fin botón guardar

        // Botón eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Cliente c;
            Int32 cedula;

            if (!Int32.TryParse(txtCI.Text, out cedula))
            {
                MessageBox.Show("La cedula de identidad debe ser numerica.");
            }
            else
            {
                c = new Cliente();
                c.conexion = Program.cn;
                c.ci = cedula;

                switch (c.Eliminar())
                {
                    case 0: // Se realizo sin problemas
                        MessageBox.Show("Datos eliminados correctamente.");
                        txtCI.Text = "";
                        btnBuscar.Enabled = true;
                        txtCI.Enabled = true;
                        pDatos.Visible = false;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 3: MessageBox.Show("Error 3"); break;
                }
                c = null; // Liberar memoria
            }
        } // Fin botón eliminar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCI.Text = "";
            btnBuscar.Enabled = true;
            txtCI.Enabled = true;
            pDatos.Visible = false;
        } // Fin botón cancelar

        // Botón listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            // Llamo al método para que se muestren los clientes
            Program.frmPrincipal.mostrarListarCliente();
        } // Fin botón listar
    }
}
