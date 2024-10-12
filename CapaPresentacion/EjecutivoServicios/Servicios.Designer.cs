using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    partial class Servicios
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
            this.pMatricula = new System.Windows.Forms.Panel();
            this.rbAYB = new System.Windows.Forms.RadioButton();
            this.rbLavado = new System.Windows.Forms.RadioButton();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSignoPeso = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblPrecioTexto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pCi = new System.Windows.Forms.Panel();
            this.btnBuscarCi = new System.Windows.Forms.Button();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.lblCi = new System.Windows.Forms.Label();
            this.pMatricula.SuspendLayout();
            this.pDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.pCi.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(357, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicios";
            // 
            // pMatricula
            // 
            this.pMatricula.Controls.Add(this.rbAYB);
            this.pMatricula.Controls.Add(this.rbLavado);
            this.pMatricula.Controls.Add(this.txtMatricula);
            this.pMatricula.Controls.Add(this.btnBuscarMatricula);
            this.pMatricula.Controls.Add(this.lblMatricula);
            this.pMatricula.Location = new System.Drawing.Point(12, 159);
            this.pMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pMatricula.Name = "pMatricula";
            this.pMatricula.Size = new System.Drawing.Size(826, 49);
            this.pMatricula.TabIndex = 1;
            // 
            // rbAYB
            // 
            this.rbAYB.AutoSize = true;
            this.rbAYB.Location = new System.Drawing.Point(561, 25);
            this.rbAYB.Name = "rbAYB";
            this.rbAYB.Size = new System.Drawing.Size(125, 17);
            this.rbAYB.TabIndex = 4;
            this.rbAYB.TabStop = true;
            this.rbAYB.Text = "Alineacion_Balanceo";
            this.rbAYB.UseVisualStyleBackColor = true;
            // 
            // rbLavado
            // 
            this.rbLavado.AutoSize = true;
            this.rbLavado.Location = new System.Drawing.Point(561, 8);
            this.rbLavado.Name = "rbLavado";
            this.rbLavado.Size = new System.Drawing.Size(61, 17);
            this.rbLavado.TabIndex = 3;
            this.rbLavado.TabStop = true;
            this.rbLavado.Text = "Lavado";
            this.rbLavado.UseVisualStyleBackColor = true;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(331, 14);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(135, 25);
            this.txtMatricula.TabIndex = 2;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarMatricula.FlatAppearance.BorderSize = 0;
            this.btnBuscarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarMatricula.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMatricula.Location = new System.Drawing.Point(480, 14);
            this.btnBuscarMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarMatricula.TabIndex = 1;
            this.btnBuscarMatricula.Text = "Buscar";
            this.btnBuscarMatricula.UseVisualStyleBackColor = false;
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(252, 17);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matrícula";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.lblID);
            this.pDatos.Controls.Add(this.label4);
            this.pDatos.Controls.Add(this.dgvServicio);
            this.pDatos.Controls.Add(this.lblNombre);
            this.pDatos.Controls.Add(this.label2);
            this.pDatos.Controls.Add(this.lblSignoPeso);
            this.pDatos.Controls.Add(this.lblPrecio);
            this.pDatos.Controls.Add(this.lblPrecioTexto);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Location = new System.Drawing.Point(12, 212);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(826, 327);
            this.pDatos.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Arial", 12F);
            this.lblID.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblID.Location = new System.Drawing.Point(97, 28);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 18);
            this.lblID.TabIndex = 30;
            this.lblID.Text = ".....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(13, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "ID";
            // 
            // dgvServicio
            // 
            this.dgvServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvServicio.Location = new System.Drawing.Point(397, 28);
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.RowTemplate.Height = 25;
            this.dgvServicio.Size = new System.Drawing.Size(426, 221);
            this.dgvServicio.TabIndex = 28;
            this.dgvServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellClick);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Location = new System.Drawing.Point(97, 67);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(28, 18);
            this.lblNombre.TabIndex = 27;
            this.lblNombre.Text = ".....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre";
            // 
            // lblSignoPeso
            // 
            this.lblSignoPeso.AutoSize = true;
            this.lblSignoPeso.Font = new System.Drawing.Font("Arial", 12F);
            this.lblSignoPeso.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSignoPeso.Location = new System.Drawing.Point(94, 100);
            this.lblSignoPeso.Name = "lblSignoPeso";
            this.lblSignoPeso.Size = new System.Drawing.Size(17, 18);
            this.lblSignoPeso.TabIndex = 25;
            this.lblSignoPeso.Text = "$";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecio.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecio.Location = new System.Drawing.Point(106, 100);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(28, 18);
            this.lblPrecio.TabIndex = 24;
            this.lblPrecio.Text = ".....";
            // 
            // lblPrecioTexto
            // 
            this.lblPrecioTexto.AutoSize = true;
            this.lblPrecioTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecioTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecioTexto.Location = new System.Drawing.Point(12, 100);
            this.lblPrecioTexto.Name = "lblPrecioTexto";
            this.lblPrecioTexto.Size = new System.Drawing.Size(54, 18);
            this.lblPrecioTexto.TabIndex = 23;
            this.lblPrecioTexto.Text = "Precio";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(421, 285);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 25);
            this.btnCancelar.TabIndex = 17;
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
            this.btnGuardar.Location = new System.Drawing.Point(331, 285);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pCi
            // 
            this.pCi.Controls.Add(this.btnBuscarCi);
            this.pCi.Controls.Add(this.txtCi);
            this.pCi.Controls.Add(this.lblCi);
            this.pCi.Location = new System.Drawing.Point(12, 113);
            this.pCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCi.Name = "pCi";
            this.pCi.Size = new System.Drawing.Size(826, 42);
            this.pCi.TabIndex = 4;
            // 
            // btnBuscarCi
            // 
            this.btnBuscarCi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarCi.FlatAppearance.BorderSize = 0;
            this.btnBuscarCi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCi.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarCi.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCi.Location = new System.Drawing.Point(517, 10);
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
            this.txtCi.Location = new System.Drawing.Point(371, 10);
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
            this.lblCi.Location = new System.Drawing.Point(295, 12);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(58, 18);
            this.lblCi.TabIndex = 0;
            this.lblCi.Text = "Cedula";
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.pCi);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pMatricula);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            this.pMatricula.ResumeLayout(false);
            this.pMatricula.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.pCi.ResumeLayout(false);
            this.pCi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel pMatricula;
        private TextBox txtMatricula;
        private Button btnBuscarMatricula;
        private Label lblMatricula;
        private Panel pDatos;
        private Button btnGuardar;
        private Button btnCancelar;
        private Panel pCi;
        private Button btnBuscarCi;
        private TextBox txtCi;
        private Label lblCi;
        private Label lblID;
        private Label label4;
        private DataGridView dgvServicio;
        private Label lblNombre;
        private Label label2;
        private Label lblSignoPeso;
        private Label lblPrecio;
        private Label lblPrecioTexto;
        private RadioButton rbAYB;
        private RadioButton rbLavado;
    }
}