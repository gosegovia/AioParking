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
    public partial class Facturas : Form
    {
        public Facturas()
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
                MessageBox.Show("La cédula de identidad debe ser numérica.");
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
                        MessageBox.Show("Debe logearse nuevamente."); break;
                    case 2:
                        MessageBox.Show("Hubo errores al buscar. En caso de persister avisar al admin"); break;
                    case 3: // No encontró
                        if (txtCi.TextLength != 8)
                        {
                            MessageBox.Show("Formato incorrecto.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente con la cédula ingresada.");
                        }
                        break;
                    default: MessageBox.Show("Error al obtener la cédula."); break;
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
                MessageBox.Show("Ingrese una cédula válida.");
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

                    CapaNegocio.Factura f = new CapaNegocio.Factura();
                    f.Conexion = Program.con;

                    switch (f.BuscarServicios(matricula))
                    {
                        case 0:
                            if (f.AlineacionBalanceo.aybNombre == "ne")
                            {
                                txtAyB.Text = "No aplica";
                            }
                            else
                            {
                                if (f.AlineacionBalanceo.aybNombre == "Pack alineacion, 4 balanceos para camioneta y valvulas")
                                {
                                    f.AlineacionBalanceo.aybNombre = "Pack alineacion";
                                }
                                txtAyB.Text = f.AlineacionBalanceo.aybNombre + " $ " + f.AlineacionBalanceo.aybPrecio;
                            }

                            if (f.Lavado.LavadoNombre == "ne")
                            {
                                txtLavado.Text = "No aplica";
                            }
                            else
                            {
                                txtLavado.Text = f.Lavado.LavadoNombre + " $ " + f.Lavado.LavadoPrecio;
                            }

                            if (f.Neumatico.neumaticoNombre == "ne")
                            {
                                txtCompraNeumatico.Text = "No aplica";
                            }
                            else
                            {
                                txtCompraNeumatico.Text = f.Neumatico.neumaticoNombre + " / " + f.Neumatico.neumaticoCantidad + " x $ " + f.Neumatico.neumaticoPrecio / f.Neumatico.neumaticoCantidad;
                            }

                            if (f.Parking.precioParking == 0)
                            {
                                txtHoraEntrada.Text = "No aplica";
                                txtHoraSalida.Text = "No aplica";
                                txtHorasTotales.Text = "No aplica";
                                txtPrecio.Text = "No aplica";
                            }
                            else
                            {
                                txtHoraEntrada.Text = f.Parking.HoraEntrada.ToString("HH:mm") + " hs";
                                txtHoraSalida.Text = f.Parking.HoraSalida.ToString("HH:mm") + " hs";
                                // Calcula la diferencia de tiempo
                                TimeSpan horasTotales = f.Parking.HoraSalida - f.Parking.HoraEntrada;
                                // Redondea hacia arriba las horas totales
                                double horasRedondeadas = Math.Ceiling(horasTotales.TotalHours);
                                // Muestra las horas totales redondeadas como un valor numérico
                                txtHorasTotales.Text = horasRedondeadas.ToString() + " hs";

                                txtPrecio.Text = "$ " + f.Parking.precioParking.ToString();
                            }

                            double precioTotal = f.AlineacionBalanceo.aybPrecio + f.Lavado.LavadoPrecio + f.Neumatico.neumaticoPrecio + f.Parking.precioParking;
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
            Factura f = new Factura();
            f.Conexion = Program.con;
            int ci = Convert.ToInt32(txtCi.Text);
            string matricula = txtMatricula.Text;

            f.BuscarServicios(matricula);
            f.GenerarFacturaPDF(matricula);

            switch(f.facturaPaga(ci, matricula))
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
                case 2: MessageBox.Show("Error 2."); break;
                case 3: MessageBox.Show("Error 3."); break;
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
