using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapaPresentacion.EjecutivoServicios
{
    partial class ABMCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.pCI = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.pDatos = new System.Windows.Forms.Panel();
            this.btnEliminarTelefono = new System.Windows.Forms.Button();
            this.btnAgregarTelefono = new System.Windows.Forms.Button();
            this.cbTelefonos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtNroPuerta = new System.Windows.Forms.TextBox();
            this.lblNroPuerta = new System.Windows.Forms.Label();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pCI.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 28.2F);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(343, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes";
            // 
            // pCI
            // 
            this.pCI.Controls.Add(this.btnBuscar);
            this.pCI.Controls.Add(this.txtCI);
            this.pCI.Controls.Add(this.lblCI);
            this.pCI.Controls.Add(this.btnListar);
            this.pCI.Location = new System.Drawing.Point(12, 128);
            this.pCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCI.Name = "pCI";
            this.pCI.Size = new System.Drawing.Size(826, 75);
            this.pCI.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(453, 28);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCI
            // 
            this.txtCI.BackColor = System.Drawing.Color.LightBlue;
            this.txtCI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCI.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCI.Location = new System.Drawing.Point(311, 28);
            this.txtCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCI.Multiline = true;
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(135, 25);
            this.txtCI.TabIndex = 1;
            this.txtCI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCI_KeyDown);
            this.txtCI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCI_KeyPress);
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCI.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCI.Location = new System.Drawing.Point(245, 32);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(58, 18);
            this.lblCI.TabIndex = 0;
            this.lblCI.Text = "Cédula";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(534, 28);
            this.btnListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 25);
            this.btnListar.TabIndex = 23;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.btnEliminarTelefono);
            this.pDatos.Controls.Add(this.btnAgregarTelefono);
            this.pDatos.Controls.Add(this.cbTelefonos);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnEliminar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.txtCiudad);
            this.pDatos.Controls.Add(this.lblCiudad);
            this.pDatos.Controls.Add(this.txtCalle);
            this.pDatos.Controls.Add(this.lblCalle);
            this.pDatos.Controls.Add(this.txtNroPuerta);
            this.pDatos.Controls.Add(this.lblNroPuerta);
            this.pDatos.Controls.Add(this.cbTipoCliente);
            this.pDatos.Controls.Add(this.lblTipoCliente);
            this.pDatos.Controls.Add(this.lblTelefono);
            this.pDatos.Controls.Add(this.txtApellido);
            this.pDatos.Controls.Add(this.lblApellido);
            this.pDatos.Controls.Add(this.txtNombre);
            this.pDatos.Controls.Add(this.lblNombre);
            this.pDatos.Location = new System.Drawing.Point(12, 209);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(826, 302);
            this.pDatos.TabIndex = 2;
            // 
            // btnEliminarTelefono
            // 
            this.btnEliminarTelefono.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminarTelefono.FlatAppearance.BorderSize = 0;
            this.btnEliminarTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTelefono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTelefono.ForeColor = System.Drawing.Color.White;
            this.btnEliminarTelefono.Location = new System.Drawing.Point(364, 98);
            this.btnEliminarTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarTelefono.Name = "btnEliminarTelefono";
            this.btnEliminarTelefono.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarTelefono.TabIndex = 26;
            this.btnEliminarTelefono.Text = "-";
            this.btnEliminarTelefono.UseVisualStyleBackColor = false;
            this.btnEliminarTelefono.Click += new System.EventHandler(this.btnEliminarTelefono_Click);
            // 
            // btnAgregarTelefono
            // 
            this.btnAgregarTelefono.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAgregarTelefono.FlatAppearance.BorderSize = 0;
            this.btnAgregarTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTelefono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTelefono.ForeColor = System.Drawing.Color.White;
            this.btnAgregarTelefono.Location = new System.Drawing.Point(333, 98);
            this.btnAgregarTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarTelefono.Name = "btnAgregarTelefono";
            this.btnAgregarTelefono.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarTelefono.TabIndex = 25;
            this.btnAgregarTelefono.Text = "+";
            this.btnAgregarTelefono.UseVisualStyleBackColor = false;
            this.btnAgregarTelefono.Click += new System.EventHandler(this.btnAgregarTelefono_Click);
            // 
            // cbTelefonos
            // 
            this.cbTelefonos.Font = new System.Drawing.Font("Arial", 12F);
            this.cbTelefonos.FormattingEnabled = true;
            this.cbTelefonos.Location = new System.Drawing.Point(191, 97);
            this.cbTelefonos.Name = "cbTelefonos";
            this.cbTelefonos.Size = new System.Drawing.Size(136, 26);
            this.cbTelefonos.TabIndex = 24;
            this.cbTelefonos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTelefonos_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(462, 240);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 25);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(373, 240);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(283, 240);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.Color.LightBlue;
            this.txtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCiudad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCiudad.Location = new System.Drawing.Point(513, 97);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCiudad.Multiline = true;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(166, 25);
            this.txtCiudad.TabIndex = 19;
            this.txtCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudad_KeyPress);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCiudad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCiudad.Location = new System.Drawing.Point(430, 100);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(59, 18);
            this.lblCiudad.TabIndex = 18;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.Color.LightBlue;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCalle.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCalle.Location = new System.Drawing.Point(513, 61);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCalle.Multiline = true;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(166, 25);
            this.txtCalle.TabIndex = 17;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCalle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCalle.Location = new System.Drawing.Point(430, 63);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(44, 18);
            this.lblCalle.TabIndex = 16;
            this.lblCalle.Text = "Calle";
            // 
            // txtNroPuerta
            // 
            this.txtNroPuerta.BackColor = System.Drawing.Color.LightBlue;
            this.txtNroPuerta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNroPuerta.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNroPuerta.Location = new System.Drawing.Point(512, 29);
            this.txtNroPuerta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNroPuerta.Multiline = true;
            this.txtNroPuerta.Name = "txtNroPuerta";
            this.txtNroPuerta.Size = new System.Drawing.Size(167, 25);
            this.txtNroPuerta.TabIndex = 15;
            this.txtNroPuerta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroPuerta_KeyPress);
            // 
            // lblNroPuerta
            // 
            this.lblNroPuerta.AutoSize = true;
            this.lblNroPuerta.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNroPuerta.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNroPuerta.Location = new System.Drawing.Point(430, 29);
            this.lblNroPuerta.Name = "lblNroPuerta";
            this.lblNroPuerta.Size = new System.Drawing.Size(81, 18);
            this.lblNroPuerta.TabIndex = 14;
            this.lblNroPuerta.Text = "Nro puerta";
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.BackColor = System.Drawing.Color.LightBlue;
            this.cbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCliente.Font = new System.Drawing.Font("Arial", 12F);
            this.cbTipoCliente.FormattingEnabled = true;
            this.cbTipoCliente.Items.AddRange(new object[] {
            "Mensual",
            "Sistematico",
            "Eventual"});
            this.cbTipoCliente.Location = new System.Drawing.Point(208, 134);
            this.cbTipoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(150, 26);
            this.cbTipoCliente.TabIndex = 13;
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTipoCliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTipoCliente.Location = new System.Drawing.Point(118, 137);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(87, 18);
            this.lblTipoCliente.TabIndex = 12;
            this.lblTipoCliente.Text = "Tipo cliente";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTelefono.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTelefono.Location = new System.Drawing.Point(118, 102);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 18);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.LightBlue;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Font = new System.Drawing.Font("Arial", 12F);
            this.txtApellido.Location = new System.Drawing.Point(191, 63);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.Multiline = true;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(167, 25);
            this.txtApellido.TabIndex = 6;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Arial", 12F);
            this.lblApellido.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblApellido.Location = new System.Drawing.Point(118, 65);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(65, 18);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LightBlue;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNombre.Location = new System.Drawing.Point(191, 29);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(167, 25);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Location = new System.Drawing.Point(118, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 18);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pCI);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ABMCliente";
            this.Text = "RegClientescs";
            this.Load += new System.EventHandler(this.ABMCliente_Load);
            this.pCI.ResumeLayout(false);
            this.pCI.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel pCI;
        private Button btnBuscar;
        private TextBox txtCI;
        private Label lblCI;
        private Panel pDatos;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblTelefono;
        private Label lblTipoCliente;
        private ComboBox cbTipoCliente;
        private Button btnGuardar;
        private TextBox txtCiudad;
        private Label lblCiudad;
        private TextBox txtCalle;
        private Label lblCalle;
        private TextBox txtNroPuerta;
        private Label lblNroPuerta;
        private Button btnCancelar;
        private Button btnEliminar;
        private Button btnListar;
        private ComboBox cbTelefonos;
        private Button btnAgregarTelefono;
        private Button btnEliminarTelefono;
    }
}