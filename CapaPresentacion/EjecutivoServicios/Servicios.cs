﻿using CapaNegocio;
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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void Servicios_Load(object sender, EventArgs e)
        {
            // Ocultar el panel de datos
            rbLavado.Checked = true;
            pMatricula.Visible = false;
            pDatos.Visible = false;
        } // Fin de carga del formulario


        // VALIDACIONES
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
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
        // FIN VALIDACIONES

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

            // Realizar la búsqueda de la matrícula
            switch (v.BuscarMatricula(ci))
            {
                case 0: // Vehículo encontrado
                    if (rbLavado.Checked == true)
                    {
                        mostrarDatosLavado();
                    } else if (rbAYB.Checked == true)
                    {
                        mostrarDatosAyB();
                    }
                    rbLavado.Enabled = false;
                    rbAYB.Enabled = false;
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
            }

            // Liberar el objeto Vehiculo, aunque no es estrictamente necesario
            v = null;
        }

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Lavado l = new Lavado();
            l.Conexion = Program.con;
            int ci = Convert.ToInt32(txtCi.Text);

            if (lblID.Text == "6")
            {
                // Llamar al método y obtener el resultado y la fecha
                var (resultado, fecha) = l.UsoLavadoGratis(ci);

                switch (resultado)
                {
                    case 0:
                        MessageBox.Show("El cliente ya utilizó el lavado gratis, el día " + fecha?.ToString("d"));
                        break;

                    case 1:
                        MessageBox.Show("Error al obtener la conexión.");
                        break;

                    case 2:
                        MessageBox.Show("Error en la consulta.");
                        break;
                }
            }
        }

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            rbLavado.Enabled = true;
            rbAYB.Enabled = true;
            txtCi.Text = "";
            txtCi.Enabled = true;
            btnBuscarCi.Enabled = true;
            txtMatricula.Text = "";
            txtMatricula.Enabled = true;
            btnBuscarMatricula.Enabled = true;
            pMatricula.Visible = false;
            pDatos.Visible = false;
        } // Fin botón cancelar

        private void mostrarDatosLavado()
        {
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
                        Precio = lav.LavadoPrecio.ToString("C2")
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvServicio.DataSource = datosLavados;
                }
                else
                {
                    MessageBox.Show("No se encontraron lavados en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los lavados: " + ex.Message);
            }
        }

        private void mostrarDatosAyB()
        {
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
                        Precio = aybdata.aybPrecio.ToString("C2")
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvServicio.DataSource = datosAyB;
                }
                else
                {
                    MessageBox.Show("No se encontraron alineacion/balanceo en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message);
            }
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila no sea negativo (esto puede pasar si se hace clic en el encabezado de columna)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow filaSeleccionada = dgvServicio.Rows[e.RowIndex];

                    // Usar el método Convert.ChangeType para hacer la conversión de manera más segura
                    lblID.Text = filaSeleccionada.Cells["ID"].Value.ToString();
                    lblNombre.Text = (string)filaSeleccionada.Cells["Nombre"].Value;
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
