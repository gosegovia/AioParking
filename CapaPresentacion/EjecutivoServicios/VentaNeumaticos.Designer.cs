using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    partial class VentaNeumaticos
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
            this.lblVentaNeumaticos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.lblSignoPeso = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnBuscarNeumatico = new System.Windows.Forms.Button();
            this.txtNeumatico = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblNeumatico = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVentaNeumaticos
            // 
            this.lblVentaNeumaticos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVentaNeumaticos.AutoSize = true;
            this.lblVentaNeumaticos.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblVentaNeumaticos.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVentaNeumaticos.Location = new System.Drawing.Point(251, 30);
            this.lblVentaNeumaticos.Name = "lblVentaNeumaticos";
            this.lblVentaNeumaticos.Size = new System.Drawing.Size(360, 43);
            this.lblVentaNeumaticos.TabIndex = 0;
            this.lblVentaNeumaticos.Text = "Venta de Neumático";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscarMatricula);
            this.panel1.Controls.Add(this.txtMatricula);
            this.panel1.Controls.Add(this.lblMatricula);
            this.panel1.Location = new System.Drawing.Point(9, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarMatricula.FlatAppearance.BorderSize = 0;
            this.btnBuscarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarMatricula.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMatricula.Location = new System.Drawing.Point(477, 10);
            this.btnBuscarMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarMatricula.TabIndex = 2;
            this.btnBuscarMatricula.Text = "Buscar";
            this.btnBuscarMatricula.UseVisualStyleBackColor = false;
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscarMatricula_Click);
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(331, 10);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(135, 25);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(255, 12);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matrícula";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.lblSignoPeso);
            this.pDatos.Controls.Add(this.txtPrecio);
            this.pDatos.Controls.Add(this.txtMarca);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblPrecio);
            this.pDatos.Controls.Add(this.lblMarca);
            this.pDatos.Controls.Add(this.btnBuscarNeumatico);
            this.pDatos.Controls.Add(this.txtNeumatico);
            this.pDatos.Controls.Add(this.txtCantidad);
            this.pDatos.Controls.Add(this.lblNeumatico);
            this.pDatos.Controls.Add(this.lblCantidad);
            this.pDatos.Location = new System.Drawing.Point(9, 154);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(800, 285);
            this.pDatos.TabIndex = 2;
            // 
            // lblSignoPeso
            // 
            this.lblSignoPeso.AutoSize = true;
            this.lblSignoPeso.Font = new System.Drawing.Font("Arial", 12F);
            this.lblSignoPeso.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSignoPeso.Location = new System.Drawing.Point(357, 123);
            this.lblSignoPeso.Name = "lblSignoPeso";
            this.lblSignoPeso.Size = new System.Drawing.Size(17, 18);
            this.lblSignoPeso.TabIndex = 15;
            this.lblSignoPeso.Text = "$";
            // 
            // txtPrecio
            // 
            this.txtPrecio.AutoSize = true;
            this.txtPrecio.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPrecio.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtPrecio.Location = new System.Drawing.Point(377, 123);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(28, 18);
            this.txtPrecio.TabIndex = 14;
            this.txtPrecio.Text = ".....";
            // 
            // txtMarca
            // 
            this.txtMarca.AutoSize = true;
            this.txtMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMarca.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtMarca.Location = new System.Drawing.Point(357, 89);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(28, 18);
            this.txtMarca.TabIndex = 13;
            this.txtMarca.Text = ".....";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(409, 166);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 25);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(322, 166);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecio.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecio.Location = new System.Drawing.Point(275, 123);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(54, 18);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarca.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarca.Location = new System.Drawing.Point(275, 89);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 18);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca";
            // 
            // btnBuscarNeumatico
            // 
            this.btnBuscarNeumatico.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarNeumatico.FlatAppearance.BorderSize = 0;
            this.btnBuscarNeumatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNeumatico.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarNeumatico.ForeColor = System.Drawing.Color.White;
            this.btnBuscarNeumatico.Location = new System.Drawing.Point(476, 16);
            this.btnBuscarNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarNeumatico.Name = "btnBuscarNeumatico";
            this.btnBuscarNeumatico.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarNeumatico.TabIndex = 5;
            this.btnBuscarNeumatico.Text = "Buscar";
            this.btnBuscarNeumatico.UseVisualStyleBackColor = false;
            this.btnBuscarNeumatico.Click += new System.EventHandler(this.btnBuscarNeumatico_Click);
            // 
            // txtNeumatico
            // 
            this.txtNeumatico.BackColor = System.Drawing.Color.LightBlue;
            this.txtNeumatico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNeumatico.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNeumatico.Location = new System.Drawing.Point(331, 16);
            this.txtNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNeumatico.Multiline = true;
            this.txtNeumatico.Name = "txtNeumatico";
            this.txtNeumatico.Size = new System.Drawing.Size(135, 25);
            this.txtNeumatico.TabIndex = 4;
            this.txtNeumatico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNeumatico_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightBlue;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCantidad.Location = new System.Drawing.Point(357, 55);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidad.Multiline = true;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(135, 25);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblNeumatico
            // 
            this.lblNeumatico.AutoSize = true;
            this.lblNeumatico.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNeumatico.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNeumatico.Location = new System.Drawing.Point(241, 17);
            this.lblNeumatico.Name = "lblNeumatico";
            this.lblNeumatico.Size = new System.Drawing.Size(83, 18);
            this.lblNeumatico.TabIndex = 3;
            this.lblNeumatico.Text = "Neumático";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCantidad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCantidad.Location = new System.Drawing.Point(275, 57);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(72, 18);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // VentaNeumaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVentaNeumaticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VentaNeumaticos";
            this.Text = "VentaNeumaticos";
            this.Load += new System.EventHandler(this.VentaNeumaticos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblVentaNeumaticos;
        private Panel panel1;
        private Button btnBuscarMatricula;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Panel pDatos;
        private Button btnBuscarNeumatico;
        private TextBox txtNeumatico;
        private TextBox txtCantidad;
        private Label lblNeumatico;
        private Label lblCantidad;
        private Label lblMarca;
        private Label lblPrecio;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label lblSignoPeso;
        private Label txtPrecio;
        private Label txtMarca;
    }
}