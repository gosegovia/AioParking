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
    public partial class ListarEmpleado : Form
    {
        public ListarEmpleado()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ListarEmpleado_Load(object sender, EventArgs e)
        {
            // Empleado emp;
            //emp = new Empleado();
            // emp.Listar(dgvEmpleado);
        } // Fin de carga del formulario

        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana actual
            this.Close();
        } // Fin botón volver
    }
}
