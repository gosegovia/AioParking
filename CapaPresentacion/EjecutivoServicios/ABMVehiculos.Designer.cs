using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapaPresentacion.EjecutivoServicios
{
    partial class ABMVehiculos
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
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.pMatricula = new System.Windows.Forms.Panel();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCICliente = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.cbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pMatricula.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblVehiculo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVehiculo.Location = new System.Drawing.Point(327, 24);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(164, 43);
            this.lblVehiculo.TabIndex = 0;
            this.lblVehiculo.Text = "Vehículo";
            // 
            // pMatricula
            // 
            this.pMatricula.Controls.Add(this.txtMatricula);
            this.pMatricula.Controls.Add(this.btnBuscar);
            this.pMatricula.Controls.Add(this.lblMatricula);
            this.pMatricula.Location = new System.Drawing.Point(6, 69);
            this.pMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pMatricula.Name = "pMatricula";
            this.pMatricula.Size = new System.Drawing.Size(787, 69);
            this.pMatricula.TabIndex = 1;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(330, 30);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(135, 25);
            this.txtMatricula.TabIndex = 5;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(482, 30);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(251, 31);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Matrícula";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarca.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarca.Location = new System.Drawing.Point(269, 53);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 18);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca";
            // 
            // txtCI
            // 
            this.txtCI.BackColor = System.Drawing.Color.LightBlue;
            this.txtCI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCI.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCI.Location = new System.Drawing.Point(330, 18);
            this.txtCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCI.Multiline = true;
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(135, 25);
            this.txtCI.TabIndex = 5;
            this.txtCI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCI_KeyPress);
            // 
            // lblCICliente
            // 
            this.lblCICliente.AutoSize = true;
            this.lblCICliente.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCICliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCICliente.Location = new System.Drawing.Point(241, 22);
            this.lblCICliente.Name = "lblCICliente";
            this.lblCICliente.Size = new System.Drawing.Size(76, 18);
            this.lblCICliente.TabIndex = 4;
            this.lblCICliente.Text = "CI Cliente";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.cbMarca);
            this.pDatos.Controls.Add(this.btnListar);
            this.pDatos.Controls.Add(this.cbTipoVehiculo);
            this.pDatos.Controls.Add(this.lblTipoVehiculo);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnEliminar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblMarca);
            this.pDatos.Controls.Add(this.txtCI);
            this.pDatos.Controls.Add(this.lblCICliente);
            this.pDatos.Location = new System.Drawing.Point(6, 142);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(787, 268);
            this.pDatos.TabIndex = 7;
            // 
            // cbMarca
            // 
            this.cbMarca.BackColor = System.Drawing.Color.LightBlue;
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Items.AddRange(new object[] {
            "Auto",
            "Utilitario",
            "Moto",
            "Camioneta",
            "Camion"});
            this.cbMarca.Location = new System.Drawing.Point(330, 49);
            this.cbMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(136, 26);
            this.cbMarca.TabIndex = 15;
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(486, 166);
            this.btnListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 25);
            this.btnListar.TabIndex = 14;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // cbTipoVehiculo
            // 
            this.cbTipoVehiculo.BackColor = System.Drawing.Color.LightBlue;
            this.cbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoVehiculo.Font = new System.Drawing.Font("Arial", 12F);
            this.cbTipoVehiculo.FormattingEnabled = true;
            this.cbTipoVehiculo.Items.AddRange(new object[] {
            "Auto",
            "Utilitario",
            "Moto",
            "Camioneta",
            "Camion"});
            this.cbTipoVehiculo.Location = new System.Drawing.Point(330, 83);
            this.cbTipoVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoVehiculo.Name = "cbTipoVehiculo";
            this.cbTipoVehiculo.Size = new System.Drawing.Size(136, 26);
            this.cbTipoVehiculo.TabIndex = 11;
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTipoVehiculo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTipoVehiculo.Location = new System.Drawing.Point(219, 87);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(100, 18);
            this.lblTipoVehiculo.TabIndex = 10;
            this.lblTipoVehiculo.Text = "Tipo Vehículo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(397, 166);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 9;
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
            this.btnEliminar.Location = new System.Drawing.Point(308, 166);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 8;
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
            this.btnGuardar.Location = new System.Drawing.Point(219, 166);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ABMVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(804, 418);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pMatricula);
            this.Controls.Add(this.lblVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ABMVehiculos";
            this.Text = "ABMVehiculos";
            this.Load += new System.EventHandler(this.ABMVehiculos_Load);
            this.pMatricula.ResumeLayout(false);
            this.pMatricula.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblVehiculo;
        private Panel pMatricula;
        private Button btnBuscar;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Label lblMarca;
        private TextBox txtCI;
        private Label lblCICliente;
        private Panel pDatos;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblTipoVehiculo;
        private Button btnListar;
        private ComboBox cbMarca;
        private ComboBox cbTipoVehiculo;
    }
}