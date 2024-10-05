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

namespace CapaPresentacion.Cajero
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        // Cargar formulario
        private void Factura_Load(object sender, EventArgs e)
        {
            // Ocultar los paneles
            pMatricula.Visible = false;
            pDatos.Visible = false;
            pDatosServicios.Visible = false;
            btnFactura.Visible = false;
            btnCancelar.Visible = false;
        } // Fin cargar formulario

        // VALIDACIONES
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

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
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

            // Realizar la búsqueda de la matrícula
            switch (v.BuscarMatricula(ci))
            {
                case 0: // Vehículo encontrado
                    txtMatricula.Enabled = false;
                    btnBuscarMatricula.Enabled = false;
                    pDatos.Visible = true;
                    pDatosServicios.Visible = true;
                    btnFactura.Visible = true;
                    btnCancelar.Visible = true;

                    CapaNegocio.Servicio s = new CapaNegocio.Servicio();
                    s.Conexion = Program.con;

                    switch (s.BuscarServicios(matricula))
                    {
                        case 0:
                            if (s.aybNombre == "ne")
                            {
                                txtAyB.Text = "No aplica";
                            }
                            else
                            {
                                if (s.aybNombre == "Pack alineacion, 4 balanceos para camioneta y valvulas")
                                {
                                    s.aybNombre = "Pack alineacion";
                                }
                                txtAyB.Text = s.aybNombre + " $ " + s.aybPrecio;
                            }

                            if (s.lavadoNombre == "ne")
                            {
                                txtLavado.Text = "No aplica";
                            }
                            else
                            {
                                txtLavado.Text = s.lavadoNombre + " $ " + s.lavadoPrecio;
                            }

                            if (s.neumaticoNombre == "ne")
                            {
                                txtCompraNeumatico.Text = "No aplica";
                            }
                            else
                            {
                                txtCompraNeumatico.Text = s.neumaticoNombre + " / " + s.neumaticoCantidad + " x $ " + s.neumaticoPrecio / s.neumaticoCantidad;
                            }

                            if (s.Parking.precioParking == 0)
                            {
                                txtHoraEntrada.Text = "No aplica";
                                txtHoraSalida.Text = "No aplica";
                                txtHorasTotales.Text = "No aplica";
                                txtPrecio.Text = "No aplica";
                            }
                            else
                            {
                                txtHoraEntrada.Text = s.Parking.HoraEntrada.ToString("HH:mm") + " hs";
                                txtHoraSalida.Text = s.Parking.HoraSalida.ToString("HH:mm") + " hs";
                                // Calcula la diferencia de tiempo
                                TimeSpan horasTotales = s.Parking.HoraSalida - s.Parking.HoraEntrada;
                                // Redondea hacia arriba las horas totales
                                double horasRedondeadas = Math.Ceiling(horasTotales.TotalHours);
                                // Muestra las horas totales redondeadas como un valor numérico
                                txtHorasTotales.Text = horasRedondeadas.ToString() + " hs";

                                txtPrecio.Text = "$ " + s.Parking.precioParking.ToString();
                            }

                            double precioTotal = s.aybPrecio + s.lavadoPrecio + s.neumaticoPrecio + s.Parking.precioParking;
                            lblPrecioTotal.Text = "Precio Total:          $ " + precioTotal;
                            break;
                        case 1: MessageBox.Show("Error 1"); break;
                        case 2:
                            MessageBox.Show("Error 2");
                            break;
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
            }
            // Liberar el objeto Vehiculo, aunque no es estrictamente necesario
            v = null;
        }

        // Botón Factura
        private void btnFactura_Click(object sender, EventArgs e)
        {
            CapaNegocio.Servicio s = new CapaNegocio.Servicio();
            s.Conexion = Program.con;
            int ci = Convert.ToInt32(txtCi.Text);
            string matricula = txtMatricula.Text;

            s.BuscarServicios(matricula);
            s.GenerarFacturaPDF(matricula);

            switch(s.facturaPaga(ci, matricula))
            {
                case 0:
                    MessageBox.Show("Factura generada.");

                    txtCi.Enabled = true;
                    btnBuscarCi.Enabled = true;
                    txtMatricula.Enabled = true;
                    btnBuscarMatricula.Enabled = true;
                    txtCi.Text = "";
                    txtMatricula.Text = "";
                    pMatricula.Visible = false;
                    pDatos.Visible = false;
                    pDatosServicios.Visible = false;
                    btnFactura.Visible = false;
                    btnCancelar.Visible = false;
                    break;
                case 1: MessageBox.Show("Debe logearse nuevamente."); break;
                case 2: MessageBox.Show("Error 1."); break;
                case 3: MessageBox.Show("Error 2."); break;
            }
        } // Fin botón factura

        // Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCi.Enabled = true;
            btnBuscarCi.Enabled = true;
            txtMatricula.Enabled = true;
            btnBuscarMatricula.Enabled = true;
            txtCi.Text = "";
            txtMatricula.Text = "";
            pMatricula.Visible = false;
            pDatos.Visible = false;
            pDatosServicios.Visible = false;
            btnFactura.Visible = false;
            btnCancelar.Visible = false;
        } // Fin botón cancelar

        private void btnLisarFactura_Click(object sender, EventArgs e)
        {
            Program.frmPrincipal.mostrarListarFactura();
        }
    }
}
