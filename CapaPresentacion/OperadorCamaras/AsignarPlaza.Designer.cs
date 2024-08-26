using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.OperadorCamaras
{
    partial class AsignarPlaza
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
            this.pDatos = new System.Windows.Forms.Panel();
            this.dgvPlaza = new System.Windows.Forms.DataGridView();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtPlaza = new System.Windows.Forms.TextBox();
            this.lblPlaza = new System.Windows.Forms.Label();
            this.lblTipoVehiculoTexto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblMarcaTexto = new System.Windows.Forms.Label();
            this.lblCICliente = new System.Windows.Forms.Label();
            this.pMatricula = new System.Windows.Forms.Panel();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblAsignarPlaza = new System.Windows.Forms.Label();
            this.pCedula = new System.Windows.Forms.Panel();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.btnBuscarCi = new System.Windows.Forms.Button();
            this.lblCi = new System.Windows.Forms.Label();
            this.pDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaza)).BeginInit();
            this.pMatricula.SuspendLayout();
            this.pCedula.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.dgvPlaza);
            this.pDatos.Controls.Add(this.lblTipoVehiculo);
            this.pDatos.Controls.Add(this.lblMarca);
            this.pDatos.Controls.Add(this.lblCedula);
            this.pDatos.Controls.Add(this.txtPlaza);
            this.pDatos.Controls.Add(this.lblPlaza);
            this.pDatos.Controls.Add(this.lblTipoVehiculoTexto);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblMarcaTexto);
            this.pDatos.Controls.Add(this.lblCICliente);
            this.pDatos.Location = new System.Drawing.Point(12, 200);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(794, 219);
            this.pDatos.TabIndex = 10;
            // 
            // dgvPlaza
            // 
            this.dgvPlaza.AllowUserToAddRows = false;
            this.dgvPlaza.AllowUserToDeleteRows = false;
            this.dgvPlaza.AllowUserToResizeColumns = false;
            this.dgvPlaza.AllowUserToResizeRows = false;
            this.dgvPlaza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlaza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaza.Location = new System.Drawing.Point(468, 8);
            this.dgvPlaza.MultiSelect = false;
            this.dgvPlaza.Name = "dgvPlaza";
            this.dgvPlaza.ReadOnly = true;
            this.dgvPlaza.RowTemplate.Height = 25;
            this.dgvPlaza.Size = new System.Drawing.Size(280, 200);
            this.dgvPlaza.TabIndex = 17;
            this.dgvPlaza.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlaza_CellClick);
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTipoVehiculo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTipoVehiculo.Location = new System.Drawing.Point(295, 90);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(28, 18);
            this.lblTipoVehiculo.TabIndex = 16;
            this.lblTipoVehiculo.Text = ".....";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarca.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarca.Location = new System.Drawing.Point(295, 52);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(28, 18);
            this.lblMarca.TabIndex = 15;
            this.lblMarca.Text = ".....";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCedula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCedula.Location = new System.Drawing.Point(295, 16);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(28, 18);
            this.lblCedula.TabIndex = 14;
            this.lblCedula.Text = ".....";
            // 
            // txtPlaza
            // 
            this.txtPlaza.BackColor = System.Drawing.Color.LightBlue;
            this.txtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlaza.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPlaza.Location = new System.Drawing.Point(264, 124);
            this.txtPlaza.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlaza.Multiline = true;
            this.txtPlaza.Name = "txtPlaza";
            this.txtPlaza.Size = new System.Drawing.Size(158, 25);
            this.txtPlaza.TabIndex = 13;
            this.txtPlaza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaza_KeyPress);
            // 
            // lblPlaza
            // 
            this.lblPlaza.AutoSize = true;
            this.lblPlaza.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPlaza.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPlaza.Location = new System.Drawing.Point(140, 131);
            this.lblPlaza.Name = "lblPlaza";
            this.lblPlaza.Size = new System.Drawing.Size(47, 18);
            this.lblPlaza.TabIndex = 12;
            this.lblPlaza.Text = "Plaza";
            // 
            // lblTipoVehiculoTexto
            // 
            this.lblTipoVehiculoTexto.AutoSize = true;
            this.lblTipoVehiculoTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTipoVehiculoTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTipoVehiculoTexto.Location = new System.Drawing.Point(140, 90);
            this.lblTipoVehiculoTexto.Name = "lblTipoVehiculoTexto";
            this.lblTipoVehiculoTexto.Size = new System.Drawing.Size(100, 18);
            this.lblTipoVehiculoTexto.TabIndex = 10;
            this.lblTipoVehiculoTexto.Text = "Tipo Vehículo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(298, 183);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 25);
            this.btnCancelar.TabIndex = 9;
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
            this.btnGuardar.Location = new System.Drawing.Point(193, 183);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 25);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblMarcaTexto
            // 
            this.lblMarcaTexto.AutoSize = true;
            this.lblMarcaTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMarcaTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMarcaTexto.Location = new System.Drawing.Point(140, 52);
            this.lblMarcaTexto.Name = "lblMarcaTexto";
            this.lblMarcaTexto.Size = new System.Drawing.Size(52, 18);
            this.lblMarcaTexto.TabIndex = 6;
            this.lblMarcaTexto.Text = "Marca";
            // 
            // lblCICliente
            // 
            this.lblCICliente.AutoSize = true;
            this.lblCICliente.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCICliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCICliente.Location = new System.Drawing.Point(140, 16);
            this.lblCICliente.Name = "lblCICliente";
            this.lblCICliente.Size = new System.Drawing.Size(57, 18);
            this.lblCICliente.TabIndex = 4;
            this.lblCICliente.Text = "Cliente";
            // 
            // pMatricula
            // 
            this.pMatricula.Controls.Add(this.txtMatricula);
            this.pMatricula.Controls.Add(this.btnBuscarMatricula);
            this.pMatricula.Controls.Add(this.lblMatricula);
            this.pMatricula.Location = new System.Drawing.Point(12, 146);
            this.pMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pMatricula.Name = "pMatricula";
            this.pMatricula.Size = new System.Drawing.Size(794, 50);
            this.pMatricula.TabIndex = 9;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(340, 12);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(158, 25);
            this.txtMatricula.TabIndex = 5;
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
            this.btnBuscarMatricula.Location = new System.Drawing.Point(517, 12);
            this.btnBuscarMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarMatricula.Name = "btnBuscarMatricula";
            this.btnBuscarMatricula.Size = new System.Drawing.Size(88, 25);
            this.btnBuscarMatricula.TabIndex = 6;
            this.btnBuscarMatricula.Text = "Buscar";
            this.btnBuscarMatricula.UseVisualStyleBackColor = false;
            this.btnBuscarMatricula.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(248, 14);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Matrícula";
            // 
            // lblAsignarPlaza
            // 
            this.lblAsignarPlaza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignarPlaza.AutoSize = true;
            this.lblAsignarPlaza.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblAsignarPlaza.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAsignarPlaza.Location = new System.Drawing.Point(302, 23);
            this.lblAsignarPlaza.Name = "lblAsignarPlaza";
            this.lblAsignarPlaza.Size = new System.Drawing.Size(253, 43);
            this.lblAsignarPlaza.TabIndex = 8;
            this.lblAsignarPlaza.Text = "Asignar Plaza";
            // 
            // pCedula
            // 
            this.pCedula.Controls.Add(this.txtCi);
            this.pCedula.Controls.Add(this.btnBuscarCi);
            this.pCedula.Controls.Add(this.lblCi);
            this.pCedula.Location = new System.Drawing.Point(12, 92);
            this.pCedula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCedula.Name = "pCedula";
            this.pCedula.Size = new System.Drawing.Size(794, 50);
            this.pCedula.TabIndex = 10;
            // 
            // txtCi
            // 
            this.txtCi.BackColor = System.Drawing.Color.LightBlue;
            this.txtCi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCi.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCi.Location = new System.Drawing.Point(340, 12);
            this.txtCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCi.Multiline = true;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(158, 25);
            this.txtCi.TabIndex = 5;
            this.txtCi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCi_KeyDown);
            // 
            // btnBuscarCi
            // 
            this.btnBuscarCi.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarCi.FlatAppearance.BorderSize = 0;
            this.btnBuscarCi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCi.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarCi.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCi.Location = new System.Drawing.Point(517, 12);
            this.btnBuscarCi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCi.Name = "btnBuscarCi";
            this.btnBuscarCi.Size = new System.Drawing.Size(88, 25);
            this.btnBuscarCi.TabIndex = 6;
            this.btnBuscarCi.Text = "Buscar";
            this.btnBuscarCi.UseVisualStyleBackColor = false;
            this.btnBuscarCi.Click += new System.EventHandler(this.btnBuscarCi_Click);
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCi.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCi.Location = new System.Drawing.Point(248, 14);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(58, 18);
            this.lblCi.TabIndex = 4;
            this.lblCi.Text = "Cedula";
            // 
            // AsignarPlaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pCedula);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pMatricula);
            this.Controls.Add(this.lblAsignarPlaza);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AsignarPlaza";
            this.Text = "AsignarPlaza";
            this.Load += new System.EventHandler(this.AsignarPlaza_Load);
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaza)).EndInit();
            this.pMatricula.ResumeLayout(false);
            this.pMatricula.PerformLayout();
            this.pCedula.ResumeLayout(false);
            this.pCedula.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pDatos;
        private TextBox txtPlaza;
        private Label lblPlaza;
        private Label lblTipoVehiculoTexto;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label lblMarcaTexto;
        private Label lblCICliente;
        private Panel pMatricula;
        private TextBox txtMatricula;
        private Button btnBuscarMatricula;
        private Label lblMatricula;
        private Label lblAsignarPlaza;
        private Label lblCedula;
        private Label lblMarca;
        private Label lblTipoVehiculo;
        private DataGridView dgvPlaza;
        private Panel pCedula;
        private TextBox txtCi;
        private Button btnBuscarCi;
        private Label lblCi;
    }
}