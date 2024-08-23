using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.OperadorCamaras
{
    public partial class AsignarPlaza : Form
    {
        public AsignarPlaza()
        {
            InitializeComponent();
        }

        // Cargar formulario
        private void AsignarPlaza_Load(object sender, EventArgs e)
        {
            // Ocultar panel de datos inicialmente
            pDatos.Visible = false;
        } // Fin cargar formulario

        // Cambiar color de las filas basado en el estado
        private void asignarColor(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPlaza.Rows)
            {
                if (row.Cells["Estado"].Value != null)
                {
                    if (row.Cells["Estado"].Value.ToString() == "Libre")
                    {
                        row.Cells["Estado"].Style.BackColor = Color.Green;
                        row.Cells["Estado"].Style.ForeColor = Color.White;
                        row.Cells["Estado"].Style.Font = new Font(dgvPlaza.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                    else if (row.Cells["Estado"].Value.ToString() == "Ocupado")
                    {
                        row.Cells["Estado"].Style.BackColor = Color.Red;
                        row.Cells["Estado"].Style.ForeColor = Color.White;
                        row.Cells["Estado"].Style.Font = new Font(dgvPlaza.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                }
            }
        } // Fin cambiar color

        // VALIDACIONES
        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionTextoNumero(sender, e);
            Validaciones.validacionLongitud(sender, e, 10);
        }

        private void txtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validacionNumero(sender, e);
            Validaciones.validacionLongitud( sender, e, 3);
        }

        // FIN VALIDACIONES

        // Botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Debe ingresar la matrícula.");
            }
            else
            {
                // Si la matrícula es "1"
                if (txtMatricula.Text == "1")
                {
                    // Mostrar el panel de datos
                    pDatos.Visible = true;
                    // Bloquear el TextBox para que el usuario no pueda ingresar otra matrícula
                    txtMatricula.ReadOnly = true;

                    // TABLA PLAZA

                    // Crear la conexión ADODB
                    Recordset rs = new Recordset();

                    try
                    {
                        // Consulta SQL con el formato corregido
                        string sql = @"SELECT nro_plaza, estado FROM Plaza";

                        // Ejecutar el comando SQL
                        rs.Open(sql, Program.cn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, -1);

                        // Crear un DataTable para almacenar los datos
                        DataTable dt = new DataTable();

                        // Agregar columnas al DataTable
                        dt.Columns.Add("Número Plaza");
                        dt.Columns.Add("Estado");

                        // Llenar el DataTable con los datos del Recordset
                        while (!rs.EOF)
                        {
                            DataRow row = dt.NewRow();
                            row["Número Plaza"] = rs.Fields["nro_plaza"].Value;
                            row["Estado"] = rs.Fields["estado"].Value;
                            dt.Rows.Add(row);
                            rs.MoveNext();
                        }

                        // Suscribirse al evento DataBindingComplete para asignar colores
                        dgvPlaza.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(asignarColor);

                        // Vincular el DataTable al DataGridView
                        dgvPlaza.DataSource = dt;

                        // Deshabilitar la ordenación en todas las columnas
                        foreach (DataGridViewColumn column in dgvPlaza.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No existe la matrícula.");
                }
            }
        } // Fin botón buscar

        // Botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de la plaza
            if (string.IsNullOrEmpty(txtPlaza.Text))
            {
                MessageBox.Show("Debe ingresar la plaza.");
                return; // Detener la ejecución si la plaza no es válida
            }
            else
            {
                // Intentar convertir el texto a un número entero
                if (int.TryParse(txtPlaza.Text, out int plaza))
                {
                    // Verificar si el número está en el rango de 1 a 60
                    if (plaza >= 1 && plaza <= 60)
                    {
                        // Guardar el dato
                    }
                    else
                    {
                        // El número está fuera del rango
                        MessageBox.Show("El número de plaza debe estar entre 1 y 60.");
                    }
                }
                else
                {
                    // El texto no es un número válido
                    MessageBox.Show("El valor ingresado para la plaza no es válido.");
                }
            }

            txtMatricula.Text = "";
            txtMatricula.ReadOnly = false;
            pDatos.Visible = false;
        } // Fin botón guardar

        // Botón cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            pDatos.Visible = false;
            txtMatricula.ReadOnly = false;
        } // Fin botón cancelar

        // Función para asignar plaza con click
        private void dgvPlaza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el índice de la fila sea válido (no es un encabezado)
            if (e.RowIndex >= 0)
            {
                // Obtener la fila clickeada
                DataGridViewRow row = dgvPlaza.Rows[e.RowIndex];

                // Verificar el estado de la plaza
                if (row.Cells["Estado"].Value.ToString() == "Ocupado")
                {
                    MessageBox.Show("La plaza seleccionada está ocupada.");
                }
                else
                {
                    // Obtener el número de fila
                    int rowIndex = e.RowIndex + 1;
                    txtPlaza.Text = rowIndex.ToString();
                }
            }
        } // Fin función para asignar plaza con click
    }
}
