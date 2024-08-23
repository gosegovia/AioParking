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

            // Verificar si el carácter ingresado es un número o una tecla de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo puede ingresar números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        } // Fin validar Números

        // Validar Texto
        public static void validacionTexto(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir letras, backspace y espacio
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo puede ingreser letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        } // Fin Validar Texto

        // Validar TextoNumero
        public static void validacionTextoNumero(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir letras, números y backspace
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                MessageBox.Show("Solo puede ingresar letras y números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        } // Fin Validar TextoNumero

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
    }
}
