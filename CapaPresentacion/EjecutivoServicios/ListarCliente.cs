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
    public partial class ListarCliente : Form
    {
        public ListarCliente()
        {
            InitializeComponent();
        }

        // Carga del formulario
        private void ListarCliente_Load(object sender, EventArgs e)
        {

        }

        // Botón volver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierro la ventana
            this.Close();
        } // Fin botón volver
    }
}
