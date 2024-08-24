using ADODB;
using CapaPresentacion;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion.EjecutivoServicios
{
    public partial class ABMVehiculos : Form
    {
        public ABMVehiculos()
        {
            InitializeComponent();
        }

        // VALIDACIONES
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        // FIN VALIDACIONES

        // Carga del Formulario
        private void ABMVehiculos_Load(object sender, EventArgs e)
        {
            // Ocultamos el panel de datos
            pDatos.Visible = false;
            CargarMarcas();
        } // Fin de carga del formulario

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Vehiculo v;
            CapaNegocio.Cliente c;
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("La matrícula no puede estar vacía");
            }
            else
            {
                c = new Cliente();
                v = new Vehiculo();
                v.conexion = Program.cn;
                v.matricula = matricula;

                switch (v.BuscarVehiculo(c))
                {
                    case 0: // Encontró
                        btnBuscar.Enabled = false;
                        txtMatricula.Enabled = false;
                        pDatos.Visible = true;
                        btnEliminar.Enabled = true;

                        txtMatricula.Text = v.matricula;
                        txtCI.Text = c.ci.ToString();

                        // Seleccionar marca
                        for (int i = 0; i < cbMarca.Items.Count; i++)
                        {
                            var item = (dynamic)cbMarca.Items[i];
                            if ((int)item.Value == v.marca)
                            {
                                cbMarca.SelectedIndex = i;
                                break;
                            }
                        }

                        // Seleccionar tipo de vehículo
                        switch (v.tipoVehiculo)
                        {
                            case 1:
                                cbTipoVehiculo.SelectedIndex = 0; // Opción 1
                                break;
                            case 2:
                                cbTipoVehiculo.SelectedIndex = 1; // Opción 2
                                break;
                            case 3:
                                cbTipoVehiculo.SelectedIndex = 2; // Opción 3
                                break;
                            case 4:
                                cbTipoVehiculo.SelectedIndex = 3; // Opción 4
                                break;
                            case 5:
                                cbTipoVehiculo.SelectedIndex = 4; // Opción 5
                                break;
                            default:
                                MessageBox.Show("Tipo de vehículo no reconocido");
                                break;
                        }
                        break;

                    case 1:
                        MessageBox.Show("Debe loguearse nuevamente");
                        break;

                    case 2:
                    case 4:
                        MessageBox.Show("Hubo errores al buscar. En caso de persistir, avise al admin");
                        break;

                    case 3: // No encontró
                        DialogResult respuesta = MessageBox.Show("¿Desea registrar un nuevo vehículo?", "Registro", MessageBoxButtons.YesNo);
                        if (respuesta == DialogResult.Yes)
                        {
                            btnBuscar.Enabled = false;
                            txtMatricula.Enabled = false;
                            pDatos.Visible = true;
                            btnEliminar.Enabled = false;

                            // Limpiar los campos para el nuevo registro
                            cbMarca.SelectedIndex = 0;
                            cbTipoVehiculo.SelectedIndex = 0;
                            txtCI.Clear();
                        }
                        break;
                }
                v = null; // Destruyo el objeto
                c = null;
            }
        }

        // Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Vehiculo v;
            CapaNegocio.Cliente c;
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("La matrícula no puede estar vacía");
            }
            else if (string.IsNullOrEmpty(txtCI.Text))
            {
                MessageBox.Show("Debe ingresar la cédula.");
                return; // Detener la ejecución si la cédula no es válida
            }
            else if (cbMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la marca.");
                return; // Detener la ejecución si la marca no es válida
            }
            else if (cbTipoVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de vehículo.");
                return; // Detener la ejecución si el tipo de vehículo no es válido
            } else
            {
                c = new Cliente();
                v = new Vehiculo();

                v.conexion = Program.cn;
                v.matricula = txtMatricula.Text;
                c.ci = int.Parse(txtCI.Text);
                v.marca = cbMarca.SelectedIndex + 1;
                v.tipoVehiculo = cbTipoVehiculo.SelectedIndex + 1;

                MessageBox.Show(v.marca.ToString());
                MessageBox.Show(v.tipoVehiculo.ToString());

                switch (v.Guardar(btnEliminar.Enabled, c))
                {
                    case 0:
                        MessageBox.Show("Se ingreso el vehiculo.");

                        btnBuscar.Enabled = true;
                        txtMatricula.Enabled = true;
                        txtMatricula.Text = "";
                        pDatos.Visible = false;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 3: MessageBox.Show("Error 3"); break;
                }
                c = null;
                v = null;
            }
        } // Fin botón guardar

        // Botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Vehiculo v;
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("La matrícula no puede estar vacía");
            } else
            {
                v = new Vehiculo();
                v.conexion = Program.cn;
                v.matricula = matricula;

                switch (v.Eliminar())
                {
                    case 0: // Se realizo sin problemas
                        MessageBox.Show("Datos eliminados correctamente.");
                        btnBuscar.Enabled = true;
                        txtMatricula.Enabled = true;
                        txtMatricula.Text = "";
                        pDatos.Visible = false;
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2"); break;
                    case 3: MessageBox.Show("Error 3"); break;
                    case 4: MessageBox.Show("Error 4"); break;
                }
                v = null;
            }
        } // Fin botón eliminar

        // Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            txtMatricula.Enabled = true;
            txtMatricula.Text = "";
            pDatos.Visible = false;
        } // Fin botón cancelar

        // Botón Listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            // Llamo al método para mostrar el formulario
            Program.frmPrincipal.mostrarListarVehiculo();
        } // Fin botón listar

        // Cargar marcas
        private void CargarMarcas()
        {
            try
            {
                // Crear una instancia de la clase Vehiculo
                CapaNegocio.Vehiculo vehiculoNegocio = new CapaNegocio.Vehiculo();
                vehiculoNegocio.conexion = Program.cn; // Asignar la conexión de la base de datos

                // Obtener la lista de marcas desde la capa de negocio
                List<CapaNegocio.Vehiculo.Marca> marcas = vehiculoNegocio.ObtenerMarcas();

                // Limpiar el ComboBox antes de cargarlo
                cbMarca.Items.Clear();

                // Agregar las marcas al ComboBox
                foreach (var marca in marcas)
                {
                    cbMarca.Items.Add(new { Text = marca.NombreMarca, Value = marca.IdMarca });
                }

                // Establecer el DisplayMember y ValueMember para el ComboBox
                cbMarca.DisplayMember = "Text";
                cbMarca.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las marcas: " + ex.Message);
            }
        }

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
