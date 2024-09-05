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

namespace CapaPresentacion.JefeServicios
{
    public partial class ABMEmpleado : Form
    {
        public ABMEmpleado()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ABMEmpleado_Load(object sender, EventArgs e)
        {
            // Ocultamos el panel de datos
            pDatos.Visible = false;
        } // Fin de carga del formulario

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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitudCB(sender, e, 9);
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTexto(sender, e);
            Validaciones.validacionLongitud(sender, e, 20);
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
            CapaNegocio.Empleado emp;
            Int32 cedula;

            if (!Int32.TryParse(txtCI.Text, out cedula))
            {
                MessageBox.Show("La cedula de identidad debe ser numerica");
            }
            else
            {
                // Asigno una nueva instancia de la clase Cliente al objeto c de dicha clase
                emp = new Empleado();
                emp.conexion = Program.con;
                emp.ci = cedula;

                switch (emp.BuscarEmpleado())
                {
                    case 0: // Encontro
                        if (emp.estado == 0)
                        {
                            DialogResult estadoRespuesta = MessageBox.Show("¿Este empleado esta dado de baja, desea recuperarlo?", "Inactivo", MessageBoxButtons.YesNo);
                            if (estadoRespuesta == DialogResult.Yes)
                            {
                                emp.estado = 1;
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

                        txtNombre.Text = emp.nombre;
                        txtApellido.Text = emp.apellido;
                        txtNroPuerta.Text = emp.nroPuerta.ToString();
                        txtCalle.Text = emp.calle;
                        txtCiudad.Text = emp.ciudad;
                        txtUsuario.Text = emp.usuario;

                        switch (emp.rol)
                        {
                            case 1: cbEmpleado.SelectedIndex = 0; break;
                            case 2: cbEmpleado.SelectedIndex = 1; break;
                            case 3: cbEmpleado.SelectedIndex = 2; break;
                            case 4: cbEmpleado.SelectedIndex = 3; break;
                            case 5: cbEmpleado.SelectedIndex = 4; break;
                        }
                     
                        string telefono;
                        cbTelefonos.Items.Clear();
                        foreach (string tel in emp.Telefonos)
                        {
                            telefono = tel;
                            cbTelefonos.Items.Add(telefono);
                        }
                        cbTelefonos.SelectedIndex = 0;
                        break;
                    case 1: MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 4: MessageBox.Show("Error 4"); break;
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
                                txtUsuario.Clear();
                                cbTelefonos.Items.Clear();
                                cbTelefonos.Text = "";
                                cbEmpleado.SelectedIndex = 0;
                            }
                        }
                        break;
                }
                emp = null; // Destruyo el objeto
            }
        } // Fin de botón buscar

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Empleado emp;
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
            else if (cbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de empleado.");
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
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar el usuario o revisar su formato.");
            }
            else
            {
                emp = new Empleado();
                emp.conexion = Program.con;
                emp.ci = cedula;
                emp.nombre = txtNombre.Text;
                emp.apellido = txtApellido.Text;
                emp.nroPuerta = int.Parse(txtNroPuerta.Text);
                emp.calle = txtCalle.Text;
                emp.ciudad = txtCiudad.Text;
                emp.usuario = txtUsuario.Text;
                emp.estado = 1;
                emp.rol = cbEmpleado.SelectedIndex + 1;

                // Para cada telefono de string del combo box
                foreach (string telefono in cbTelefonos.Items)
                {
                    emp.Telefonos.Add(telefono); // Agrego cada telefono que tenga el combo box
                }

                switch (emp.Guardar(btnEliminar.Enabled))
                {
                    case 0: // Se realizo sin problemas
                        MessageBox.Show("Se ingreso el empleado.");

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
                emp = null; // Liberar memoria
            }
        } // Fin de botón guardar

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Empleado emp;
            Int32 cedula;

            if (!Int32.TryParse(txtCI.Text, out cedula))
            {
                MessageBox.Show("La cédula de identidad debe ser numérica.");
            }
            else
            {
                // Confirmar eliminación
                var confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este empleado?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    emp = new Empleado();
                    emp.conexion = Program.con;
                    emp.ci = cedula;

                    switch (emp.Eliminar())
                    {
                        case 0: // Se realizó sin problemas
                            MessageBox.Show("Datos eliminados correctamente.");
                            txtCI.Text = "";
                            btnBuscar.Enabled = true;
                            txtCI.Enabled = true;
                            pDatos.Visible = false;
                            break;
                        case 1:
                            MessageBox.Show("Debe logearse nuevamente, la conexión está cerrada.");
                            break;
                        case 2:
                            MessageBox.Show("Error 2");
                            break;
                        case 3:
                            MessageBox.Show("Error 3");
                            break;
                    }
                    emp = null; // Liberar memoria
                }
            }
        }


        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            txtCI.Enabled = true;
            txtCI.Text = "";
            pDatos.Visible = false;
        } // Fin de botón cancelar

        // Botón listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            // Mostramos el formulario
            Program.frmPrincipal.mostrarListarEmpleado();
        } // Fin de botón listar
    }
}
