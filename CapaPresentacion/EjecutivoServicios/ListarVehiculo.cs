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
    public partial class ListarVehiculo : Form
    {
        public ListarVehiculo()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ListarVehiculo_Load(object sender, EventArgs e)
        {
        } // Fin carga del formulario

        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra la ventana
            this.Close();
        } // Fin botón volver

        // Botón entregar
        private void btnEntregar_Click(object sender, EventArgs e)
        {

        } // Fin botón entregar
    }
}
