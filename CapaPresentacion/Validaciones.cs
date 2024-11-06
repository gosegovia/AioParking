using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms; // Asegúrate de tener esta referencia

namespace CapaPresentacion
{
    internal class Validaciones
    {
        // Validar Números
        public static void validacionNumero(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir solo números y teclas de control (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo puede ingresar números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        public static void validacionTexto(object sender, KeyPressEventArgs e, bool permitirEspacios)
        {
            TextBox textBox = sender as TextBox;

            // Verificar si se permite el espacio y si el primer carácter es un espacio
            if (permitirEspacios && e.KeyChar == ' ')
            {
                MessageBox.Show("No se permiten espacios en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

            if (textBox.Text.Length == 0 && e.KeyChar == ' ')
            {
                MessageBox.Show("No se permite iniciar con espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

            // Permitir solo letras, control y (si se permite) espacios
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' ' || !permitirEspacios))
            {
                MessageBox.Show("Solo puede ingresar letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        public static void validacionTextoNumero(object sender, KeyPressEventArgs e, bool permitirEspacios)
        {
            TextBox textBox = sender as TextBox;

            if (permitirEspacios && e.KeyChar == ' ')
            {
                MessageBox.Show("No se permiten espacios en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

            if (textBox.Text.Length == 0 && e.KeyChar == ' ')
            {
                MessageBox.Show("No se permite iniciar con espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

            // Permitir letras, números, control y (si se permite) espacios
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != ' ' || !permitirEspacios))
            {
                MessageBox.Show("Solo puede ingresar letras y números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
        // Fin Validar TextoNumero

        public static void validacionTextoNumeroConEspacios(object sender, KeyPressEventArgs e, bool permitirEspacios)
        {
            TextBox textBox = sender as TextBox;

            // Evitar que el texto comience con un espacio
            if (textBox.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("No se permite iniciar con un espacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bloquear espacios si no se permiten
            if (!permitirEspacios && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Permitir letras, números, control (como backspace) y (si se permite) espacios intermedios
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != ' ' || !permitirEspacios))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras, números y (si se permite) espacios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void validacionLongitud(object sender, KeyPressEventArgs e, int longitudMaxima)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox.Text.Length >= longitudMaxima && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Cancela el evento KeyPress si la longitud máxima se excede.
                    MessageBox.Show($"El texto no puede superar los {longitudMaxima} caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void validacionLongitudCB(object sender, KeyPressEventArgs e, int longitudMaxima)
        {
            ComboBox textCB = sender as ComboBox;

            if (textCB != null)
            {
                if (textCB.Text.Length >= longitudMaxima && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Cancela el evento KeyPress si la longitud máxima se excede.
                    MessageBox.Show($"El texto no puede superar los {longitudMaxima} caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Clase Validaciones
        public static void validacionTextoEspacio(object sender, KeyPressEventArgs e, bool permitirEspacios = false)
        {
            TextBox textBox = sender as TextBox;

            // Evitar que el texto comience con un espacio
            if (textBox.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
                MessageBox.Show("No se permite iniciar con un espacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Permitir letras, control (como backspace) y espacios si están habilitados
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' ' || !permitirEspacios))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar letras y espacios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
