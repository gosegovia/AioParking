using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADODB;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Metodo login
        public void login()
        {
            try
            {
                Program.cn.Open("probd", txtUsuario.Text, txtContrasenia.Text);
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                txtUsuario.Text = "";
                txtUsuario.Focus();
                txtContrasenia.Text = "";
                return;
            }
            Program.cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            Program.doyPermisos(txtUsuario.Text);
            this.Close();
        } // Fin metodo login

        // Btn ingregar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Cuando presionamos el boton carga el login
            login();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Cambiar el foco a txtContrasenia
                txtContrasenia.Focus();
                // Evitar que el Enter sea visible en el TextBox
                e.SuppressKeyPress = true;
            }
        }

        // txtContrasenia configuracion enter
        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            // Si la tecla presionada es enter
            if (e.KeyCode == Keys.Enter)
            {
                // Hacemos el login
                login();
            }
        }
    }
}
