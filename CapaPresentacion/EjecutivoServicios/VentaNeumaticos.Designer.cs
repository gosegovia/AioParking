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
            this.pMatricula = new System.Windows.Forms.Panel();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.lblSignoPeso = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblPrecioTexto = new System.Windows.Forms.Label();
            this.lblMarcaTexto = new System.Windows.Forms.Label();
            this.btnBuscarNeumatico = new System.Windows.Forms.Button();
            this.txtNeumatico = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblNeumatico = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pCi = new System.Windows.Forms.Panel();
            this.btnBuscarCi = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.lblCi = new System.Windows.Forms.Label();
            this.pMatricula.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.pCi.SuspendLayout();
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
            // pMatricula
            // 
            this.pMatricula.Controls.Add(this.btnBuscarMatricula);
            this.pMatricula.Controls.Add(this.txtMatricula);
            this.pMatricula.Controls.Add(this.lblMatricula);
            this.pMatricula.Location = new System.Drawing.Point(9, 151);
            this.pMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pMatricula.Name = "pMatricula";
            this.pMatricula.Size = new System.Drawing.Size(800, 42);
            this.pMatricula.TabIndex = 1;
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
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
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
            this.pDatos.Controls.Add(this.lblNombre);
            this.pDatos.Controls.Add(this.label2);
            this.pDatos.Controls.Add(this.lblSignoPeso);
            this.pDatos.Controls.Add(this.lblPrecio);
            this.pDatos.Controls.Add(this.lblMarca);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblPrecioTexto);
            this.pDatos.Controls.Add(this.lblMarcaTexto);
            this.pDatos.Controls.Add(this.btnBuscarNeumatico);
            this.pDatos.Controls.Add(this.txtNeumatico);
            this.pDatos.Controls.Add(this.txtCantidad);
            this.pDatos.Controls.Add(this.lblNeumatico);
            this.pDatos.Controls.Add(this.lblCantidad);
            this.pDatos.Location = new System.Drawing.Point(9, 197);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(800, 242);
            this.pDatos.TabIndex = 2;
            // 
            // lblSignoPeso
            // 
            this.lblSignoPeso.AutoSize = true;
            this.lblSignoPeso.Font = new System.Drawing.Font("Arial", 12F);
            this.lblSignoPeso.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSignoPeso.Location = new System.Drawing.Point(357, 158);
            this.lblSignoPeso.Name = "lblSignoPeso";
            this.lblSignoPeso.Size = new System.Drawing.Size(17, 18);
            this.lblSignoPeso.TabIndex = 15;
            this.lblSignoPeso.Text = "$";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecio.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecio.Location = new System.Drawing.Point(377, 158);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(28, 18);
            this.lblPrecio.TabIndex = 14;
            this.lblPrecio.Text = ".....";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarca.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarca.Location = new System.Drawing.Point(357, 124);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(28, 18);
            this.lblMarca.TabIndex = 13;
            this.lblMarca.Text = ".....";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(409, 201);
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
            this.btnGuardar.Location = new System.Drawing.Point(322, 201);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblPrecioTexto
            // 
            this.lblPrecioTexto.AutoSize = true;
            this.lblPrecioTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecioTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecioTexto.Location = new System.Drawing.Point(275, 158);
            this.lblPrecioTexto.Name = "lblPrecioTexto";
            this.lblPrecioTexto.Size = new System.Drawing.Size(54, 18);
            this.lblPrecioTexto.TabIndex = 8;
            this.lblPrecioTexto.Text = "Precio";
            // 
            // lblMarcaTexto
            // 
            this.lblMarcaTexto.AutoSize = true;
            this.lblMarcaTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarcaTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarcaTexto.Location = new System.Drawing.Point(275, 124);
            this.lblMarcaTexto.Name = "lblMarcaTexto";
            this.lblMarcaTexto.Size = new System.Drawing.Size(52, 18);
            this.lblMarcaTexto.TabIndex = 6;
            this.lblMarcaTexto.Text = "Marca";
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
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Location = new System.Drawing.Point(359, 94);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(28, 18);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = ".....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(275, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nombre";
            // 
            // pCi
            // 
            this.pCi.Controls.Add(this.btnBuscarCi);
            this.pCi.Controls.Add(this.txtCi);
            this.pCi.Controls.Add(this.lblCi);
            this.pCi.Location = new System.Drawing.Point(9, 105);
            this.pCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCi.Name = "pCi";
            this.pCi.Size = new System.Drawing.Size(800, 42);
            this.pCi.TabIndex = 3;
            // 
            // btnBuscarCi
            // 
            this.btnBuscarCi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarCi.FlatAppearance.BorderSize = 0;
            this.btnBuscarCi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCi.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarCi.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCi.Location = new System.Drawing.Point(477, 10);
            this.btnBuscarCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCi.Name = "btnBuscarCi";
            this.btnBuscarCi.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarCi.TabIndex = 2;
            this.btnBuscarCi.Text = "Buscar";
            this.btnBuscarCi.UseVisualStyleBackColor = false;
            this.btnBuscarCi.Click += new System.EventHandler(this.btnBuscarCi_Click);
            // 
            // txtCi
            // 
            this.txtCi.BackColor = System.Drawing.Color.LightBlue;
            this.txtCi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCi.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCi.Location = new System.Drawing.Point(331, 10);
            this.txtCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCi.Multiline = true;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(135, 25);
            this.txtCi.TabIndex = 1;
            this.txtCi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCi_KeyDown);
            this.txtCi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCi_KeyPress);
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCi.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCi.Location = new System.Drawing.Point(255, 12);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(58, 18);
            this.lblCi.TabIndex = 0;
            this.lblCi.Text = "Cedula";
            // 
            // VentaNeumaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pCi);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pMatricula);
            this.Controls.Add(this.lblVentaNeumaticos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VentaNeumaticos";
            this.Text = "VentaNeumaticos";
            this.Load += new System.EventHandler(this.VentaNeumaticos_Load);
            this.pMatricula.ResumeLayout(false);
            this.pMatricula.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.pCi.ResumeLayout(false);
            this.pCi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblVentaNeumaticos;
        private Panel pMatricula;
        private Button btnBuscarMatricula;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Panel pDatos;
        private Button btnBuscarNeumatico;
        private TextBox txtNeumatico;
        private TextBox txtCantidad;
        private Label lblNeumatico;
        private Label lblCantidad;
        private Label lblMarcaTexto;
        private Label lblPrecioTexto;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label lblSignoPeso;
        private Label lblPrecio;
        private Label lblMarca;
        private Label lblNombre;
        private Label label2;
        private Panel pCi;
        private Button btnBuscarCi;
        private TextBox txtCi;
        private Label lblCi;
    }
}