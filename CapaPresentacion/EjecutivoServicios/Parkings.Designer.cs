using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.EjecutivoServicios
{
    partial class Parkings
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
            this.lblParking = new System.Windows.Forms.Label();
            this.pCI = new System.Windows.Forms.Panel();
            this.btnBuscarCI = new System.Windows.Forms.Button();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.pMatricula = new System.Windows.Forms.Panel();
            this.btnBuscarMatricula = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.txtPlaza = new System.Windows.Forms.TextBox();
            this.lblPlaza = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.pCI.SuspendLayout();
            this.pMatricula.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblParking
            // 
            this.lblParking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParking.AutoSize = true;
            this.lblParking.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblParking.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblParking.Location = new System.Drawing.Point(351, 33);
            this.lblParking.Name = "lblParking";
            this.lblParking.Size = new System.Drawing.Size(148, 43);
            this.lblParking.TabIndex = 0;
            this.lblParking.Text = "Parking";
            // 
            // pCI
            // 
            this.pCI.Controls.Add(this.btnBuscarCI);
            this.pCI.Controls.Add(this.txtCI);
            this.pCI.Controls.Add(this.lblCI);
            this.pCI.Location = new System.Drawing.Point(9, 84);
            this.pCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCI.Name = "pCI";
            this.pCI.Size = new System.Drawing.Size(800, 62);
            this.pCI.TabIndex = 1;
            // 
            // btnBuscarCI
            // 
            this.btnBuscarCI.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarCI.FlatAppearance.BorderSize = 0;
            this.btnBuscarCI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCI.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarCI.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCI.Location = new System.Drawing.Point(457, 24);
            this.btnBuscarCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarCI.Name = "btnBuscarCI";
            this.btnBuscarCI.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarCI.TabIndex = 2;
            this.btnBuscarCI.Text = "Buscar";
            this.btnBuscarCI.UseVisualStyleBackColor = false;
            this.btnBuscarCI.Click += new System.EventHandler(this.btnBuscarCI_Click);
            // 
            // txtCI
            // 
            this.txtCI.BackColor = System.Drawing.Color.LightBlue;
            this.txtCI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCI.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCI.Location = new System.Drawing.Point(311, 24);
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
            this.lblCI.Location = new System.Drawing.Point(277, 26);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(23, 18);
            this.lblCI.TabIndex = 0;
            this.lblCI.Text = "CI";
            // 
            // pMatricula
            // 
            this.pMatricula.Controls.Add(this.btnBuscarMatricula);
            this.pMatricula.Controls.Add(this.txtMatricula);
            this.pMatricula.Controls.Add(this.lblMatricula);
            this.pMatricula.Location = new System.Drawing.Point(9, 150);
            this.pMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pMatricula.Name = "pMatricula";
            this.pMatricula.Size = new System.Drawing.Size(800, 54);
            this.pMatricula.TabIndex = 3;
            // 
            // btnBuscarMatricula
            // 
            this.btnBuscarMatricula.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarMatricula.FlatAppearance.BorderSize = 0;
            this.btnBuscarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarMatricula.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMatricula.Location = new System.Drawing.Point(474, 12);
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
            this.txtMatricula.Location = new System.Drawing.Point(328, 12);
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
            this.lblMatricula.Location = new System.Drawing.Point(250, 15);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matrícula";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.dtpSalida);
            this.pDatos.Controls.Add(this.dtpEntrada);
            this.pDatos.Controls.Add(this.txtPlaza);
            this.pDatos.Controls.Add(this.lblPlaza);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblHoraSalida);
            this.pDatos.Controls.Add(this.lblHoraEntrada);
            this.pDatos.Location = new System.Drawing.Point(9, 208);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(800, 233);
            this.pDatos.TabIndex = 4;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSalida.Location = new System.Drawing.Point(375, 39);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(136, 20);
            this.dtpSalida.TabIndex = 11;
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEntrada.Location = new System.Drawing.Point(375, 7);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(136, 20);
            this.dtpEntrada.TabIndex = 10;
            // 
            // txtPlaza
            // 
            this.txtPlaza.BackColor = System.Drawing.Color.LightBlue;
            this.txtPlaza.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlaza.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPlaza.Location = new System.Drawing.Point(375, 68);
            this.txtPlaza.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlaza.Multiline = true;
            this.txtPlaza.Name = "txtPlaza";
            this.txtPlaza.Size = new System.Drawing.Size(135, 25);
            this.txtPlaza.TabIndex = 9;
            this.txtPlaza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaza_KeyPress);
            // 
            // lblPlaza
            // 
            this.lblPlaza.AutoSize = true;
            this.lblPlaza.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPlaza.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPlaza.Location = new System.Drawing.Point(267, 71);
            this.lblPlaza.Name = "lblPlaza";
            this.lblPlaza.Size = new System.Drawing.Size(47, 18);
            this.lblPlaza.TabIndex = 8;
            this.lblPlaza.Text = "Plaza";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(403, 137);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 25);
            this.btnCancelar.TabIndex = 7;
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
            this.btnGuardar.Location = new System.Drawing.Point(316, 137);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraSalida.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraSalida.Location = new System.Drawing.Point(267, 39);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(88, 18);
            this.lblHoraSalida.TabIndex = 5;
            this.lblHoraSalida.Text = "Hora salida";
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraEntrada.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraEntrada.Location = new System.Drawing.Point(267, 7);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(99, 18);
            this.lblHoraEntrada.TabIndex = 3;
            this.lblHoraEntrada.Text = "Hora entrada";
            // 
            // Parking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pMatricula);
            this.Controls.Add(this.pCI);
            this.Controls.Add(this.lblParking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Parking";
            this.Text = "Parking";
            this.Load += new System.EventHandler(this.Parking_Load);
            this.pCI.ResumeLayout(false);
            this.pCI.PerformLayout();
            this.pMatricula.ResumeLayout(false);
            this.pMatricula.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblParking;
        private Panel pCI;
        private Button btnBuscarCI;
        private TextBox txtCI;
        private Label lblCI;
        private Panel pMatricula;
        private Button btnBuscarMatricula;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Panel pDatos;
        private Button btnGuardar;
        private Label lblHoraSalida;
        private Label lblHoraEntrada;
        private Label lblPlaza;
        private Button btnCancelar;
        private DateTimePicker dtpSalida;
        private DateTimePicker dtpEntrada;
        private TextBox txtPlaza;
    }
}