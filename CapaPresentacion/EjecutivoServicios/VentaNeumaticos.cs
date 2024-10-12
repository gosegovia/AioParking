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
                        mostrarDatosNeumaticos();
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

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Servicio s;

            // Validaciones
            if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(lblStock.Text))
            {
                MessageBox.Show("La cantidad es mayor al stock");
            }
            else
            {
                s = new Servicio();
                s.Conexion = Program.con;

                s.Cliente.ci = Convert.ToInt32(txtCi.Text);
                s.Vehiculo.Matricula = txtMatricula.Text;

                s.neumaticoId = Convert.ToInt32(lblID.Text);
                s.neumaticoCantidad = Convert.ToInt32(txtCantidad.Text);
                double precio = Convert.ToDouble(lblPrecio.Text);
                s.neumaticoPrecio = precio * s.neumaticoCantidad;

                switch (s.ventaNeumatico())
                {
                    case 0:
                        MessageBox.Show("La compra de neumático se guardó correctamente!");

                        txtCi.Enabled = true;
                        txtCi.Text = "";
                        btnBuscarCi.Enabled = true;
                        txtMatricula.Enabled = true;
                        txtMatricula.Text = "";
                        btnBuscarMatricula.Enabled = true;
                        pMatricula.Visible = false;
                        pDatos.Visible = false;

                        lblID.Text = "...";
                        txtCantidad.Text = "";
                        lblStock.Text = "...";
                        lblNombre.Text = "...";
                        lblMarca.Text = "...";
                        lblPrecio.Text = "...";
                        break;

                    case 1:
                        MessageBox.Show("Error al obtener la conexión.");
                        break;

                    case 2:
                        MessageBox.Show("Error 2");
                        break;

                    case 3:
                        MessageBox.Show("Error 3");
                        break;

                    case 4:
                        MessageBox.Show("Error 4");
                        break;

                    case 5:
                        MessageBox.Show("Error 5");
                        break;

                    case 6:
                        MessageBox.Show("Error 6");
                        break;

                    case 7:
                        MessageBox.Show("Error 7");
                        break;
                    case 8:
                        MessageBox.Show("Error 8");
                        break;
                    case 9:
                        MessageBox.Show("Error 9");
                        break;
                }
            }
        } // Fin botón guardar


        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCi.Enabled = true;
            txtCi.Text = "";
            btnBuscarCi.Enabled = true;
            txtMatricula.Enabled = true;
            txtMatricula.Text = "";
            btnBuscarMatricula.Enabled = true;
            pMatricula.Visible = false;
            pDatos.Visible = false;

            lblID.Text = "...";
            txtCantidad.Text = "";
            lblStock.Text = "...";
            lblNombre.Text = "...";
            lblMarca.Text = "...";
            lblPrecio.Text = "...";
        } // Fin botón cancelar

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
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

        private void mostrarDatosNeumaticos()
        {
            try
            {
                // Crear una instancia de Servicio desde la capa de negocio
                Servicio s = new Servicio
                {
                    // Asegúrate de que la conexión esté asignada si es necesario
                    Conexion = Program.con // Asumiendo que Program.con es la conexión global
                };

                // Obtener la lista de neumáticos
                List<Servicio> neumaticos = s.ListarNeumaticos();

                if (neumaticos != null && neumaticos.Count > 0)
                {
                    // Transformar los datos de los neumáticos para mostrarlos en el DataGridView
                    var datosNeumaticos = neumaticos.Select(neu => new
                    {
                        ID = neu.neumaticoId, // ID del neumático
                        Nombre = neu.neumaticoNombre, // Nombre del neumático
                        Marca = neu.neumaticoMarca, // Marca del neumático
                        Precio = neu.neumaticoPrecio.ToString("C2"), // Precio con formato de moneda
                        Stock = neu.neumaticoCantidad // Cantidad en stock
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvNeumatico.DataSource = datosNeumaticos;
                }
                else
                {
                    MessageBox.Show("No se encontraron neumáticos en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los neumáticos: " + ex.Message);
            }
        }

        private void dgvNeumatico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila no sea negativo (esto puede pasar si se hace clic en el encabezado de columna)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow filaSeleccionada = dgvNeumatico.Rows[e.RowIndex];

                    // Usar el método Convert.ChangeType para hacer la conversión de manera más segura
                    lblID.Text = filaSeleccionada.Cells["ID"].Value.ToString();
                    lblNombre.Text = (string)filaSeleccionada.Cells["Nombre"].Value;
                    lblMarca.Text = (string)filaSeleccionada.Cells["Marca"].Value;
                    lblStock.Text = filaSeleccionada.Cells["Stock"].Value.ToString();
                    // Eliminar el símbolo de pesos si está presente
                    lblPrecio.Text = filaSeleccionada.Cells["Precio"].Value.ToString().Replace("$", "");

                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show("Error de conversión de datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al obtener los datos: " + ex.Message);
                }
            }
        }
    }
}
