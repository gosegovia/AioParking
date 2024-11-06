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

            mostrarDatosNeumaticos();
            mostrarDatosLavado();
            mostrarDatosAyB();
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
            Validaciones.validacionLongitud(sender, e, 2);
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
            Validaciones.validacionTextoNumeroConEspacios(sender, e, true);
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

        private void txtLavado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarLavado.Focus();
            }
        }

        private void txtPrecioLavado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 8);
        }

        private void txtAyB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 3);
        }

        private void txtPrecioAyB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtAyB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar que el Enter inserte una nueva línea
                btnBuscarAyB.Focus();
            }
        }

        // FIN VALIDACIONES

        // Botón buscar neumático
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Neumatico n;
            Int32 neumatico;

            // Validar que la CI sea numérica
            if (!Int32.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El id neumatico debe ser numerico.");
            }
            else
            {
                n = new Neumatico();
                n.neumaticoId = neumatico;
                n.Conexion = Program.con; // Asigna la conexión desde el programa principal

                switch (n.BuscarNeumatico())
                {
                    case 0:
                        if (n.neumaticoEstado == 0)
                        {
                            // Pregunta al usuario si desea recuperar al cliente inactivo
                            DialogResult estadoRespuesta = MessageBox.Show("¿Este neumático está dado de baja, desea recuperarlo?", "Inactivo", MessageBoxButtons.YesNo);
                            if (estadoRespuesta == DialogResult.Yes)
                            {
                                n.neumaticoEstado = 1; // Cambia el estado del cliente a activo
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

                        txtNombre.Text = n.neumaticoNombre;
                        txtPrecio.Text = n.neumaticoPrecio.ToString();
                        txtStock.Text = n.neumaticoCantidad.ToString();

                        switch (n.neumaticoMarca)
                        {
                            case "Michelin": cbModelo.SelectedIndex = 0; break;
                            case "Bridgestone": cbModelo.SelectedIndex = 1; break;
                            case "Pirelli": cbModelo.SelectedIndex = 2; break;
                        }
                    break;
                    case 1: // Error de conexión
                        MessageBox.Show("Debe logearse nuevamente.");
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
                n = null;
            }
        } // Fin botón buscar neumático

        // Botón guardar neumático
        private void btnGuardarNeumatico_Click(object sender, EventArgs e)
        {
            Neumatico n;
            int neumatico;

            // Validaciones
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
            }
            else if (cbModelo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.");
            }
            else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("El precio no puede estar vacío.");
            }
            else if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a 0.");
            }
            else if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("El stock no puede estar vacío.");
            }
            else if (!int.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El ID neumático debe ser numérico.");
            }
            else
            {
                // Crear instancia de Neumatico y asignar propiedades
                n = new Neumatico
                {
                    Conexion = Program.con,
                    neumaticoId = neumatico,
                    neumaticoNombre = txtNombre.Text,
                    neumaticoPrecio = precio, // Usar el precio validado como decimal
                    neumaticoCantidad = Convert.ToInt32(txtStock.Text)
                };

                // Asignar la marca en función de la selección del ComboBox
                switch (cbModelo.SelectedIndex)
                {
                    case 0: n.neumaticoMarca = "Michelin"; break;
                    case 1: n.neumaticoMarca = "Bridgestone"; break;
                    case 2: n.neumaticoMarca = "Pirelli"; break;
                    default: n.neumaticoMarca = string.Empty; break; // Valor predeterminado por si se añade más lógica en el futuro
                }

                // Guardar el neumático y manejar los diferentes resultados
                switch (n.GuardarNeumatico(btnEliminar.Enabled))
                {
                    case 0:
                        MessageBox.Show("Se ingresó el neumático.");
                        mostrarDatosNeumaticos();

                        // Restablecer los controles después de guardar
                        btnBuscarNeumatico.Enabled = true;
                        txtNeumatico.Clear();
                        txtNeumatico.Enabled = true;
                        pDatosNeumatico.Visible = false;

                        txtNombre.Clear();
                        cbModelo.SelectedIndex = -1; // Deseleccionar opción
                        txtPrecio.Clear();
                        txtStock.Clear();
                        break;

                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexión está cerrada.");
                        break;

                    case 2:
                        MessageBox.Show("Error al guardar el neumático.");
                        break;
                }
            }

        } // Fin botón guardar neumático

        // Botón eliminar neumático
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Neumatico n;
            Int32 neumatico;

            // Verifica que el neumatico ingresada sea numérica
            if (!Int32.TryParse(txtNeumatico.Text, out neumatico))
            {
                MessageBox.Show("El ID neumático debe ser numérico.");
            }
            else
            {
                n = new Neumatico();
                n.Conexion = Program.con;
                n.neumaticoId = neumatico;

                // Pregunta al usuario si desea eliminar el cliente
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este neumático?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si la respuesta es 'Yes', procede con la eliminación
                if (respuesta == DialogResult.Yes)
                {
                    // Llama al método Eliminar() y gestiona los diferentes resultados
                    switch (n.EliminarNeumatico())
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
                n = null;
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

        private void mostrarDatosNeumaticos()
        {
            estiloTabla();
            try
            {
                // Crear una instancia de Servicio desde la capa de negocio
                Neumatico n = new Neumatico
                {
                    // Asegúrate de que la conexión esté asignada si es necesario
                    Conexion = Program.con // Asumiendo que Program.con es la conexión global
                };

                // Obtener la lista de neumáticos
                List<Neumatico> neumaticos = n.ListarNeumaticos();

                if (neumaticos != null && neumaticos.Count > 0)
                {
                    // Transformar los datos de los neumáticos para mostrarlos en el DataGridView
                    var datosNeumaticos = neumaticos.Select(neu => new
                    {
                        ID = neu.neumaticoId, // ID del neumático
                        Nombre = neu.neumaticoNombre, // Nombre del neumático
                        Marca = neu.neumaticoMarca, // Marca del neumático
                        Precio = neu.neumaticoPrecio, // Precio con formato de moneda
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
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar los neumáticos.");
            }
        }

        public void estiloTabla()
        {
            // Fondo gris claro para las filas
            dgvNeumatico.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvNeumatico.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvNeumatico.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvNeumatico.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvNeumatico.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvNeumatico.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNeumatico.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvNeumatico.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvNeumatico.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvNeumatico.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvNeumatico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvNeumatico.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        }

        // Botón buscar lavado
        private void btnBuscarLavado_Click(object sender, EventArgs e)
        {
            CapaNegocio.Lavado l;
            Int32 lavado;

            // Validar que la CI sea numérica
            if (!Int32.TryParse(txtLavado.Text, out lavado))
            {
                MessageBox.Show("El ID lavado debe ser numérico.");
            }
            else
            {
                l = new Lavado();
                l.LavadoId = lavado;
                l.Conexion = Program.con; // Asigna la conexión desde el programa principal

                switch (l.BuscarLavado())
                {
                    case 0:
                        btnBuscarLavado.Enabled = false;
                        txtLavado.Enabled = false;
                        pDatosLavado.Visible = true;

                        lblNombreLavado.Text = l.LavadoNombre.ToString();
                        txtPrecioLavado.Text = l.LavadoPrecio.ToString();
                        break;
                    case 1: // Error de conexión
                        MessageBox.Show("Debe logearse nuevamente.");
                        break;

                    case 2: // Error en la ejecución
                        MessageBox.Show("Error 2.");
                        break;
                    case 3: // No encontró lavado
                        MessageBox.Show("No existe el lavado.");
                        break;
                }
                l = null;
            }
        } // Fin botón buscar lavado

        // Botón guardar lavado
        private void btnGuardarLavado_Click(object sender, EventArgs e)
        {
            CapaNegocio.Lavado l;
            Int32 lavado;

            // Validaciónes
            if (string.IsNullOrEmpty(txtPrecioLavado.Text))
            {
                MessageBox.Show("El precio no puede estar vacío.");
            }
            else if (!double.TryParse(txtPrecioLavado.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a 0.");
            }
            else if (!Int32.TryParse(txtLavado.Text, out lavado))
            {
                MessageBox.Show("El ID lavado debe ser numérico.");
            }
            else
            {
                l = new Lavado();
                l.Conexion = Program.con;

                l.LavadoId = Convert.ToInt32(txtLavado.Text);
                l.LavadoPrecio = Convert.ToDouble(txtPrecioLavado.Text);

                switch (l.ActualizarLavado())
                {
                    case 0:
                        mostrarDatosLavado();
                        MessageBox.Show("Se actualizó el precio del lavado.");

                        txtLavado.Text = "";
                        txtLavado.Enabled = true;
                        btnBuscarLavado.Enabled = true;
                        pDatosLavado.Visible = false;

                        lblNombreLavado.Text = "";
                        txtPrecioLavado.Clear();
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2."); break;
                    case 3: MessageBox.Show("Error 3."); break;
                }
            }
        } // Fin botón guardar lavado

        // Botón cancelar lavado
        private void btnCancelarLavado_Click(object sender, EventArgs e)
        {
            txtLavado.Text = "";
            txtLavado.Enabled = true;
            btnBuscarLavado.Enabled = true;
            pDatosLavado.Visible = false;

            lblNombreLavado.Text = "";
            txtPrecioLavado.Clear();
        } // Fin botón cancelar lavado

        private void mostrarDatosLavado()
        {
            estiloTabla1();
            try
            {
                // Crear una instancia de Lavado desde la capa de negocio
                Lavado l = new Lavado
                {
                    // Asegúrate de que la conexión esté asignada si es necesario
                    Conexion = Program.con // Asumiendo que Program.con es la conexión global
                };

                // Obtener la lista de lavados
                List<Lavado> lavados = l.ListarLavados();

                if (lavados != null && lavados.Count > 0)
                {
                    // Transformar los datos de los lavados para mostrarlos en el DataGridView
                    var datosLavados = lavados.Select(lav => new
                    {
                        ID = lav.LavadoId,
                        Nombre = lav.LavadoNombre,
                        Precio = lav.LavadoPrecio
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvLavado.DataSource = datosLavados;
                }
                else
                {
                    MessageBox.Show("No se encontraron lavados en la base de datos.");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar los lavados.");
            }
        }

        public void estiloTabla1()
        {
            // Fondo gris claro para las filas
            dgvLavado.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvLavado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvLavado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvLavado.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvLavado.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvLavado.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLavado.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvLavado.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvLavado.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvLavado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvLavado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvLavado.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        // Botón buscar AyB
        private void btnBuscarAyB_Click(object sender, EventArgs e)
        {
            CapaNegocio.AlineacionBalanceo ayb;
            Int32 aybid;

            // Validar que la CI sea numérica
            if (!Int32.TryParse(txtAyB.Text, out aybid))
            {
                MessageBox.Show("El, id alineación y balanceo debe ser numéricos.");
            }
            else
            {
                ayb = new AlineacionBalanceo();
                ayb.aybId = aybid;
                ayb.Conexion = Program.con; // Asigna la conexión desde el programa principal

                switch (ayb.BuscarAyB())
                {
                    case 0:
                        btnBuscarAyB.Enabled = false;
                        txtAyB.Enabled = false;
                        pDatosAyB.Visible = true;

                        lblNombreAyB.Text = ayb.aybNombre.ToString();
                        txtPrecioAyB.Text = ayb.aybPrecio.ToString();
                        break;
                    case 1: // Error de conexión
                        MessageBox.Show("Debe logearse nuevamente.");
                        break;

                    case 2: // Error en la ejecución
                        MessageBox.Show("Error 2.");
                        break;
                    case 3: // No encontró lavado
                        MessageBox.Show("No existe la alineaciòn o balanceo.");
                        break;
                }
                ayb = null;
            }
        } // Fin botón buscar AyB

        // Botón guardar AyB
        private void btnGuardarAyB_Click(object sender, EventArgs e)
        {
            CapaNegocio.AlineacionBalanceo ayb;
            Int32 aybid;

            // Validaciónes
            if (string.IsNullOrEmpty(txtPrecioAyB.Text))
            {
                MessageBox.Show("El precio no puede estar vacío.");
            }
            else if (!double.TryParse(txtPrecioAyB.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a 0.");
            }
            else if (!Int32.TryParse(txtAyB.Text, out aybid))
            {
                MessageBox.Show("El, id alineación y balanceo debe ser numéricos.");
            }
            else
            {
                ayb = new AlineacionBalanceo();
                ayb.Conexion = Program.con;

                ayb.aybId = Convert.ToInt32(txtAyB.Text);
                ayb.aybPrecio = Convert.ToDouble(txtPrecioAyB.Text);

                switch (ayb.ActualizarAyB())
                {
                    case 0:
                        MessageBox.Show("Se actualizó el precio de alineación/balanceo.");
                        mostrarDatosAyB();

                        txtAyB.Text = "";
                        txtAyB.Enabled = true;
                        btnBuscarAyB.Enabled = true;
                        pDatosAyB.Visible = false;

                        lblNombreAyB.Text = "";
                        txtPrecioAyB.Clear();
                        break;
                    case 1:
                        MessageBox.Show("Debe logearse nuevamente, la conexion esta cerrada.");
                        break;
                    case 2: MessageBox.Show("Error 2."); break;
                    case 3: MessageBox.Show("Error 3."); break;
                }
            }
        } // Fin botón guardar AyB

        // Botón cancelar AyB
        private void btnCancelarAyB_Click(object sender, EventArgs e)
        {
            txtAyB.Text = "";
            txtAyB.Enabled = true;
            btnBuscarAyB.Enabled = true;
            pDatosAyB.Visible = false;

            lblNombreAyB.Text = "";
            txtPrecioAyB.Clear();
        } // Fin botón cancelar AyB

        private void mostrarDatosAyB()
        {
            estiloTabla2();
            try
            {
                // Crear una instancia de Lavado desde la capa de negocio
                AlineacionBalanceo ayb = new AlineacionBalanceo
                {
                    // Asegúrate de que la conexión esté asignada si es necesario
                    Conexion = Program.con // Asumiendo que Program.con es la conexión global
                };

                // Obtener la lista de lavados
                List<AlineacionBalanceo> ayblist = ayb.ListarAyB();

                if (ayblist != null && ayblist.Count > 0)
                {
                    // Transformar los datos de los lavados para mostrarlos en el DataGridView
                    var datosAyB = ayblist.Select(aybdata => new
                    {
                        ID = aybdata.aybId,
                        Nombre = aybdata.aybNombre,
                        Precio = aybdata.aybPrecio
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvServicio.DataSource = datosAyB;
                }
                else
                {
                    MessageBox.Show("No se encontraron alineacion/balanceo en la base de datos.");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al cargar los datos.");
            }
        }

        public void estiloTabla2()
        {
            // Fondo gris claro para las filas
            dgvServicio.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color gris claro
            dgvServicio.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Blanco

            // Fondo celeste suave para el encabezado
            dgvServicio.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); // Celeste claro
            dgvServicio.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Texto negro
            dgvServicio.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente en negrita

            // Mostrar solo líneas en el medio (entre celdas)
            dgvServicio.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServicio.GridColor = Color.Gray; // Color de las líneas

            // Color de la celda seleccionada
            dgvServicio.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; // Color azul pastel
            dgvServicio.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro en la selección

            // Alinear texto al centro en la cabecera
            dgvServicio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajuste de tamaño de columnas según el texto del encabezado
            dgvServicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Cambiar el estilo de las celdas seleccionadas para que el texto sea negrita
            dgvServicio.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void dgvNeumatico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el botón btnBuscarNeumatico está habilitado
            if (btnBuscarNeumatico.Enabled)
            {
                // Verifica que el índice de la fila sea válido
                if (e.RowIndex >= 0)
                {
                    // Obtiene el valor de la primera columna (columna del ID)
                    var idNeumatico = dgvNeumatico.Rows[e.RowIndex].Cells[0].Value;

                    // Asigna el valor obtenido al TextBox txtNeumatico
                    txtNeumatico.Text = idNeumatico?.ToString();
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void dgvLavado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el botón btnBuscarNeumatico está habilitado
            if (btnBuscarLavado.Enabled)
            {
                // Verifica que el índice de la fila sea válido
                if (e.RowIndex >= 0)
                {
                    // Obtiene el valor de la primera columna (columna del ID)
                    var idLavado = dgvLavado.Rows[e.RowIndex].Cells[0].Value;

                    // Asigna el valor obtenido al TextBox txtNeumatico
                    txtLavado.Text = idLavado?.ToString();
                    btnBuscarLavado_Click(sender, e);
                }
            }
        }

        private void dgvServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el botón btnBuscarNeumatico está habilitado
            if (btnBuscarAyB.Enabled)
            {
                // Verifica que el índice de la fila sea válido
                if (e.RowIndex >= 0)
                {
                    // Obtiene el valor de la primera columna (columna del ID)
                    var idAyB = dgvServicio.Rows[e.RowIndex].Cells[0].Value;

                    // Asigna el valor obtenido al TextBox txtNeumatico
                    txtAyB.Text = idAyB?.ToString();
                    btnBuscarAyB_Click(sender, e);
                }
            }
        }
    }
}
