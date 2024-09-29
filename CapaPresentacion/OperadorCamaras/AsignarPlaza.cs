using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.OperadorCamaras
{
    public partial class AsignarPlaza : Form
    {
        private Parking _parkingNegocio;

        public AsignarPlaza()
        {
            InitializeComponent();
            _parkingNegocio = new Parking(); // Inicializa la instancia de la capa de negocio
        }

        // Cargar formulario
        private void AsignarPlaza_Load(object sender, EventArgs e)
        {
            // Ocultar panel de datos inicialmente
            pDatos.Visible = false;
            pMatricula.Visible = false;
            dgvPlaza.DataBindingComplete -= asignarColor; // Evitar múltiples suscripciones
            dgvPlaza.DataBindingComplete += asignarColor;
        }

        // Cambiar color de las filas basado en el estado
        private void asignarColor(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPlaza.Rows)
            {
                if (row.Cells["Estado Plaza"].Value != null) // Verifica el nombre exacto
                {
                    string estado = row.Cells["Estado Plaza"].Value.ToString();
                    if (estado == "Libre")
                    {
                        row.Cells["Estado Plaza"].Style.ForeColor = Color.Green;
                    }
                    else if (estado == "Ocupada")
                    {
                        row.Cells["Estado Plaza"].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        // Validaciones de entrada
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 2);
        }

        // Buscar CI
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

                        lblCedula.Text = c.nombre + " " + c.apellido;
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

        // Botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
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

                        lblPlaza.Text = "";
                        lblMarca.Text = v.NombreMarca;
                        lblTipoVehiculo.Text = v.NombreTipo;

                        try
                        {
                            // Crear una instancia de la capa de negocio para plazas
                            CapaNegocio.Parking parkingNegocio = new CapaNegocio.Parking
                            {
                                conexion = Program.con
                            };

                            // Obtener la lista de plazas
                            DataTable dt = parkingNegocio.ListarPlazas();

                            // Verificar si el DataTable tiene filas
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                // Mostrar los datos recuperados para depuración
                                Console.WriteLine($"Número de filas recuperadas: {dt.Rows.Count}");

                                // Configurar el DataGridView para mostrar las plazas
                                dgvPlaza.AutoGenerateColumns = true;
                                dgvPlaza.DataSource = dt;

                                // Asegurar una única suscripción al evento DataBindingComplete
                                dgvPlaza.DataBindingComplete -= asignarColor;
                                dgvPlaza.DataBindingComplete += asignarColor;

                                // Forzar la actualización del DataGridView
                                dgvPlaza.Refresh();

                                // Desactivar la capacidad de ordenar las columnas
                                foreach (DataGridViewColumn column in dgvPlaza.Columns)
                                {
                                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                }
                            }
                            else
                            {
                                // Mostrar mensaje si no se encontraron datos de plazas
                                MessageBox.Show("No se encontraron datos de plazas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Manejo de excepciones al cargar los datos de plazas
                            MessageBox.Show("Error al cargar los datos de plazas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
        }


        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Parking p;
            p = new Parking();
            p.conexion = Program.con;

            string matricula = txtMatricula.Text;
            int ci = Int32.Parse(txtCi.Text);
            int plaza=0, plaza1=0;
            DateTime fecha = DateTime.Now;

            if (lblPlaza.Text.Length <= 2)
            {
                plaza = Int32.Parse(lblPlaza.Text);
            } else if (lblPlaza.Text.Length > 2)
            {
                // Divides el texto por la coma y el espacio
                string[] partes = lblPlaza.Text.Split(new string[] { ", " }, StringSplitOptions.None);

                // Convertir las partes a enteros
                plaza = Int32.Parse(partes[0]);
                plaza1 = Int32.Parse(partes[1]);
            }

            // Generar ticket
            switch (p.GenerarTicket(matricula, ci, plaza, plaza1, fecha))
            {
                case 0: // Se realizó sin problemas
                    MessageBox.Show("Se genero el ticket.");
                    p.CrearTicketPDF(matricula, ci, plaza, plaza1, fecha);
                    p.Plaza = int.Parse(lblPlaza.Text);
                    p.ActualizarPlaza();

                    txtCi.Text = "";
                    txtCi.Enabled = true;
                    btnBuscarCi.Enabled = true;
                    txtMatricula.Text = "";
                    txtMatricula.Enabled = true;
                    btnBuscarMatricula.Enabled = true;
                    pMatricula.Visible = false;
                    pDatos.Visible = false;
                    break;

                case 1: // Conexión cerrada
                    MessageBox.Show("Debe logearse nuevamente, la conexión está cerrada.");
                    break;

                case 2: MessageBox.Show("Error 2"); break;
                case 3: MessageBox.Show("Error 3"); break;
            }

            // Liberar memoria
            p = null;
        }


        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCi.Text = "";
            txtCi.Enabled = true;
            btnBuscarCi.Enabled = true;
            txtMatricula.Text = "";
            txtMatricula.Enabled = true;
            btnBuscarMatricula.Enabled = true;
            pMatricula.Visible = false;
            pDatos.Visible = false;
        }

        // Asignar plaza con click en el DataGridView

        private void dgvPlaza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de la fila sea válido (no es un encabezado)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow row = dgvPlaza.Rows[e.RowIndex];

                // Verifica si el estado de la plaza es "Libre" antes de asignarla
                if (row.Cells["Estado Plaza"].Value.ToString() == "Libre")
                {
                    // Obtiene el número de la plaza
                    int numPlaza = Convert.ToInt32(row.Cells["Número Plaza"].Value);

                    if ((numPlaza >= 1 && numPlaza <= 20) && lblTipoVehiculo.Text.Trim() == "Moto")
                    {
                        lblPlaza.Text = numPlaza.ToString();  // Asignar el número de plaza para moto
                    }
                    else if ((numPlaza >= 21 && numPlaza <= 60) && (lblTipoVehiculo.Text.Trim() == "Auto" || lblTipoVehiculo.Text.Trim() == "Camioneta"))
                    {
                        lblPlaza.Text = numPlaza.ToString();  // Asignar el número de plaza para auto/camioneta
                    }
                    else if ((numPlaza >= 21 && numPlaza <= 60) && (lblTipoVehiculo.Text.Trim() == "Pequenio camion" || lblTipoVehiculo.Text.Trim() == "Pequenio utilitario"))
                    {
                        // Verifica si la siguiente plaza (numPlaza + 1) está ocupada
                        if (e.RowIndex + 1 < dgvPlaza.Rows.Count)
                        {
                            // Obtiene la siguiente fila (numPlaza + 1)
                            DataGridViewRow nextRow = dgvPlaza.Rows[e.RowIndex + 1];

                            // Verifica si el estado de la próxima plaza es "Ocupada"
                            if (nextRow.Cells["Estado Plaza"].Value.ToString() == "Ocupada")
                            {
                                MessageBox.Show("La próxima plaza está ocupada, este vehiculo ocupa 2 plazas.");
                            }
                            else
                            {
                                // Asigna el número de las dos plazas si la siguiente está libre
                                lblPlaza.Text = numPlaza.ToString() + ", " + (numPlaza + 1).ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay más plazas disponibles para verificar.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta plaza no es para ese tipo de vehículo.");
                    }
                }
                else
                {
                    // Muestra un mensaje si la plaza está ocupada
                    MessageBox.Show("La plaza seleccionada está ocupada.");
                }
            }
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

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }
    }
}
