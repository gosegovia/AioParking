using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.JefeServicios
{
    partial class ABMEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.cbTelefonos = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtNroPuerta = new System.Windows.Forms.TextBox();
            this.lblNroPuerta = new System.Windows.Forms.Label();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblCargoEmleado = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblEmpleados.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblEmpleados.Location = new System.Drawing.Point(316, 26);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(209, 43);
            this.lblEmpleados.TabIndex = 0;
            this.lblEmpleados.Text = "Empleados";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtCI);
            this.panel1.Controls.Add(this.lblCI);
            this.panel1.Location = new System.Drawing.Point(9, 85);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 66);
            this.panel1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(447, 23);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // txtCI
            // 
            this.txtCI.BackColor = System.Drawing.Color.LightBlue;
            this.txtCI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCI.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCI.Location = new System.Drawing.Point(305, 22);
            this.txtCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCI.Multiline = true;
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(135, 25);
            this.txtCI.TabIndex = 1;
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCI.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCI.Location = new System.Drawing.Point(277, 26);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(23, 18);
            this.lblCI.TabIndex = 0;
            this.lblCI.Text = "CI";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.cbTelefonos);
            this.pDatos.Controls.Add(this.txtUsuario);
            this.pDatos.Controls.Add(this.lblUsuario);
            this.pDatos.Controls.Add(this.btnListar);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnEliminar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.txtCiudad);
            this.pDatos.Controls.Add(this.lblCiudad);
            this.pDatos.Controls.Add(this.txtCalle);
            this.pDatos.Controls.Add(this.lblCalle);
            this.pDatos.Controls.Add(this.txtNroPuerta);
            this.pDatos.Controls.Add(this.lblNroPuerta);
            this.pDatos.Controls.Add(this.cbEmpleado);
            this.pDatos.Controls.Add(this.lblCargoEmleado);
            this.pDatos.Controls.Add(this.lblTelefono);
            this.pDatos.Controls.Add(this.txtApellido);
            this.pDatos.Controls.Add(this.lblApellido);
            this.pDatos.Controls.Add(this.txtNombre);
            this.pDatos.Controls.Add(this.lblNombre);
            this.pDatos.Location = new System.Drawing.Point(9, 159);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(786, 251);
            this.pDatos.TabIndex = 2;
            // 
            // cbTelefonos
            // 
            this.cbTelefonos.Font = new System.Drawing.Font("Arial", 12F);
            this.cbTelefonos.FormattingEnabled = true;
            this.cbTelefonos.Location = new System.Drawing.Point(218, 75);
            this.cbTelefonos.Name = "cbTelefonos";
            this.cbTelefonos.Size = new System.Drawing.Size(149, 26);
            this.cbTelefonos.TabIndex = 45;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(507, 106);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 22);
            this.txtUsuario.TabIndex = 44;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Location = new System.Drawing.Point(423, 106);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 18);
            this.lblUsuario.TabIndex = 43;
            this.lblUsuario.Text = "Usuario";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(494, 206);
            this.btnListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 25);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(397, 206);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 25);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(309, 206);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(219, 206);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.Color.LightBlue;
            this.txtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCiudad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCiudad.Location = new System.Drawing.Point(507, 75);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCiudad.Multiline = true;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(150, 22);
            this.txtCiudad.TabIndex = 39;
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCiudad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCiudad.Location = new System.Drawing.Point(423, 75);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(59, 18);
            this.lblCiudad.TabIndex = 38;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.Color.LightBlue;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCalle.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCalle.Location = new System.Drawing.Point(507, 40);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCalle.Multiline = true;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(150, 22);
            this.txtCalle.TabIndex = 37;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCalle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCalle.Location = new System.Drawing.Point(423, 42);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(44, 18);
            this.lblCalle.TabIndex = 36;
            this.lblCalle.Text = "Calle";
            // 
            // txtNroPuerta
            // 
            this.txtNroPuerta.BackColor = System.Drawing.Color.LightBlue;
            this.txtNroPuerta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNroPuerta.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNroPuerta.Location = new System.Drawing.Point(507, 9);
            this.txtNroPuerta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNroPuerta.Multiline = true;
            this.txtNroPuerta.Name = "txtNroPuerta";
            this.txtNroPuerta.Size = new System.Drawing.Size(150, 22);
            this.txtNroPuerta.TabIndex = 35;
            // 
            // lblNroPuerta
            // 
            this.lblNroPuerta.AutoSize = true;
            this.lblNroPuerta.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNroPuerta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNroPuerta.Location = new System.Drawing.Point(423, 11);
            this.lblNroPuerta.Name = "lblNroPuerta";
            this.lblNroPuerta.Size = new System.Drawing.Size(81, 18);
            this.lblNroPuerta.TabIndex = 34;
            this.lblNroPuerta.Text = "Nro puerta";
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.BackColor = System.Drawing.Color.LightBlue;
            this.cbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpleado.Font = new System.Drawing.Font("Arial", 12F);
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Items.AddRange(new object[] {
            "Gerente",
            "Jefe de Servicio",
            "Ejecutivo de Servicio",
            "Cajero",
            "Operador de camarás"});
            this.cbEmpleado.Location = new System.Drawing.Point(218, 106);
            this.cbEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(149, 26);
            this.cbEmpleado.TabIndex = 33;
            // 
            // lblCargoEmleado
            // 
            this.lblCargoEmleado.AutoSize = true;
            this.lblCargoEmleado.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCargoEmleado.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCargoEmleado.Location = new System.Drawing.Point(147, 108);
            this.lblCargoEmleado.Name = "lblCargoEmleado";
            this.lblCargoEmleado.Size = new System.Drawing.Size(52, 18);
            this.lblCargoEmleado.TabIndex = 32;
            this.lblCargoEmleado.Text = "Cargo";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTelefono.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTelefono.Location = new System.Drawing.Point(147, 76);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 18);
            this.lblTelefono.TabIndex = 27;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.LightBlue;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Font = new System.Drawing.Font("Arial", 12F);
            this.txtApellido.Location = new System.Drawing.Point(216, 42);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(150, 22);
            this.txtApellido.TabIndex = 26;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Arial", 12F);
            this.lblApellido.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblApellido.Location = new System.Drawing.Point(147, 44);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(65, 18);
            this.lblApellido.TabIndex = 25;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LightBlue;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNombre.Location = new System.Drawing.Point(216, 11);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 22);
            this.txtNombre.TabIndex = 24;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Location = new System.Drawing.Point(147, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 18);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "Nombre";
            // 
            // ABMEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ABMEmpleado";
            this.Text = "ABMEmpleados";
            this.Load += new System.EventHandler(this.ABMEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblEmpleados;
        private Panel panel1;
        private Button btnBuscar;
        private TextBox txtCI;
        private Label lblCI;
        private Panel pDatos;
        private Button btnCancelar;
        private Button btnEliminar;
        private Button btnGuardar;
        private TextBox txtCiudad;
        private Label lblCiudad;
        private TextBox txtCalle;
        private Label lblCalle;
        private TextBox txtNroPuerta;
        private Label lblNroPuerta;
        private ComboBox cbEmpleado;
        private Label lblCargoEmleado;
        private Label lblTelefono;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnListar;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private ComboBox cbTelefonos;
    }
}