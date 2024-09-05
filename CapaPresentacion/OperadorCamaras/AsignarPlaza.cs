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
                    else if (estado == "Ocupado")
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
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente"); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontro
                        if (txtCi.TextLength < 8)
                        {
                            MessageBox.Show("Formato incorrecto");
                        }
                        break;
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

                        try
                        {
                            // Obtener datos de plazas
                            DataTable dt = _parkingNegocio.ListarPlazas();

                            // Configurar el DataGridView para mostrar las plazas
                            dgvPlaza.AutoGenerateColumns = true;
                            dgvPlaza.DataSource = dt;

                            // Asegurar una única suscripción al evento DataBindingComplete
                            dgvPlaza.DataBindingComplete -= asignarColor;
                            dgvPlaza.DataBindingComplete += asignarColor;

                            // Desactivar la capacidad de ordenar las columnas
                            foreach (DataGridViewColumn column in dgvPlaza.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Manejo de excepciones al cargar los datos de plazas
                            MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
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
            if (string.IsNullOrEmpty(txtPlaza.Text))
            {
                MessageBox.Show("Debe ingresar la plaza.");
                return;
            }
            else
            {
                if (int.TryParse(txtPlaza.Text, out int plaza))
                {
                    if (plaza >= 1 && plaza <= 60)
                    {
                        // Lógica para guardar la plaza asignada
                    }
                    else
                    {
                        MessageBox.Show("El número de plaza debe estar entre 1 y 60.");
                    }
                }
                else
                {
                    MessageBox.Show("El valor ingresado para la plaza no es válido.");
                }
            }

            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
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
                    string numeroPlaza = row.Cells["Número Plaza"].Value.ToString();

                    // Asigna el número de plaza al TextBox
                    txtPlaza.Text = numeroPlaza;
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
    }
}
