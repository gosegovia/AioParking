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
            this.btnBuscarTicket = new System.Windows.Forms.Button();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.lblTicket = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.lblPlazaTexto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.lblHoraEntradaTexto = new System.Windows.Forms.Label();
            this.lblPlaza = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblMatriculaTexto = new System.Windows.Forms.Label();
            this.lblCi = new System.Windows.Forms.Label();
            this.lblCiTexto = new System.Windows.Forms.Label();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.pCI.SuspendLayout();
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
            this.lblParking.Location = new System.Drawing.Point(351, 50);
            this.lblParking.Name = "lblParking";
            this.lblParking.Size = new System.Drawing.Size(148, 43);
            this.lblParking.TabIndex = 0;
            this.lblParking.Text = "Parking";
            // 
            // pCI
            // 
            this.pCI.Controls.Add(this.btnBuscarTicket);
            this.pCI.Controls.Add(this.txtTicket);
            this.pCI.Controls.Add(this.lblTicket);
            this.pCI.Location = new System.Drawing.Point(12, 123);
            this.pCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pCI.Name = "pCI";
            this.pCI.Size = new System.Drawing.Size(826, 62);
            this.pCI.TabIndex = 1;
            // 
            // btnBuscarTicket
            // 
            this.btnBuscarTicket.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarTicket.FlatAppearance.BorderSize = 0;
            this.btnBuscarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTicket.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarTicket.ForeColor = System.Drawing.Color.White;
            this.btnBuscarTicket.Location = new System.Drawing.Point(490, 22);
            this.btnBuscarTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarTicket.Name = "btnBuscarTicket";
            this.btnBuscarTicket.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarTicket.TabIndex = 2;
            this.btnBuscarTicket.Text = "Buscar";
            this.btnBuscarTicket.UseVisualStyleBackColor = false;
            this.btnBuscarTicket.Click += new System.EventHandler(this.btnBuscarCI_Click);
            // 
            // txtTicket
            // 
            this.txtTicket.BackColor = System.Drawing.Color.LightBlue;
            this.txtTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTicket.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTicket.Location = new System.Drawing.Point(344, 22);
            this.txtTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTicket.Multiline = true;
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(135, 25);
            this.txtTicket.TabIndex = 1;
            this.txtTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCI_KeyDown);
            this.txtTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCI_KeyPress);
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTicket.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTicket.Location = new System.Drawing.Point(272, 25);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(66, 18);
            this.lblTicket.TabIndex = 0;
            this.lblTicket.Text = "Ticket id";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.lblHoraEntrada);
            this.pDatos.Controls.Add(this.lblCi);
            this.pDatos.Controls.Add(this.lblCiTexto);
            this.pDatos.Controls.Add(this.lblMatricula);
            this.pDatos.Controls.Add(this.lblMatriculaTexto);
            this.pDatos.Controls.Add(this.lblPlaza);
            this.pDatos.Controls.Add(this.dtpSalida);
            this.pDatos.Controls.Add(this.lblPlazaTexto);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblHoraSalida);
            this.pDatos.Controls.Add(this.lblHoraEntradaTexto);
            this.pDatos.Location = new System.Drawing.Point(12, 189);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(826, 350);
            this.pDatos.TabIndex = 4;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSalida.Location = new System.Drawing.Point(375, 123);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(136, 20);
            this.dtpSalida.TabIndex = 11;
            // 
            // lblPlazaTexto
            // 
            this.lblPlazaTexto.AutoSize = true;
            this.lblPlazaTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPlazaTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPlazaTexto.Location = new System.Drawing.Point(267, 155);
            this.lblPlazaTexto.Name = "lblPlazaTexto";
            this.lblPlazaTexto.Size = new System.Drawing.Size(47, 18);
            this.lblPlazaTexto.TabIndex = 8;
            this.lblPlazaTexto.Text = "Plaza";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(403, 221);
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
            this.btnGuardar.Location = new System.Drawing.Point(316, 221);
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
            this.lblHoraSalida.Location = new System.Drawing.Point(267, 123);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(88, 18);
            this.lblHoraSalida.TabIndex = 5;
            this.lblHoraSalida.Text = "Hora salida";
            // 
            // lblHoraEntradaTexto
            // 
            this.lblHoraEntradaTexto.AutoSize = true;
            this.lblHoraEntradaTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraEntradaTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraEntradaTexto.Location = new System.Drawing.Point(267, 91);
            this.lblHoraEntradaTexto.Name = "lblHoraEntradaTexto";
            this.lblHoraEntradaTexto.Size = new System.Drawing.Size(99, 18);
            this.lblHoraEntradaTexto.TabIndex = 3;
            this.lblHoraEntradaTexto.Text = "Hora entrada";
            // 
            // lblPlaza
            // 
            this.lblPlaza.AutoSize = true;
            this.lblPlaza.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPlaza.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPlaza.Location = new System.Drawing.Point(372, 155);
            this.lblPlaza.Name = "lblPlaza";
            this.lblPlaza.Size = new System.Drawing.Size(20, 18);
            this.lblPlaza.TabIndex = 12;
            this.lblPlaza.Text = "...";
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(372, 62);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(20, 18);
            this.lblMatricula.TabIndex = 14;
            this.lblMatricula.Text = "...";
            // 
            // lblMatriculaTexto
            // 
            this.lblMatriculaTexto.AutoSize = true;
            this.lblMatriculaTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatriculaTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatriculaTexto.Location = new System.Drawing.Point(267, 62);
            this.lblMatriculaTexto.Name = "lblMatriculaTexto";
            this.lblMatriculaTexto.Size = new System.Drawing.Size(71, 18);
            this.lblMatriculaTexto.TabIndex = 13;
            this.lblMatriculaTexto.Text = "Matricula";
            // 
            // lblCi
            // 
            this.lblCi.AutoSize = true;
            this.lblCi.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCi.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCi.Location = new System.Drawing.Point(372, 34);
            this.lblCi.Name = "lblCi";
            this.lblCi.Size = new System.Drawing.Size(20, 18);
            this.lblCi.TabIndex = 16;
            this.lblCi.Text = "...";
            // 
            // lblCiTexto
            // 
            this.lblCiTexto.AutoSize = true;
            this.lblCiTexto.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCiTexto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCiTexto.Location = new System.Drawing.Point(267, 34);
            this.lblCiTexto.Name = "lblCiTexto";
            this.lblCiTexto.Size = new System.Drawing.Size(58, 18);
            this.lblCiTexto.TabIndex = 15;
            this.lblCiTexto.Text = "Cedula";
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraEntrada.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraEntrada.Location = new System.Drawing.Point(371, 91);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(20, 18);
            this.lblHoraEntrada.TabIndex = 17;
            this.lblHoraEntrada.Text = "...";
            // 
            // Parkings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.pCI);
            this.Controls.Add(this.lblParking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Parkings";
            this.Text = "Parking";
            this.Load += new System.EventHandler(this.Parking_Load);
            this.pCI.ResumeLayout(false);
            this.pCI.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblParking;
        private Panel pCI;
        private Button btnBuscarTicket;
        private TextBox txtTicket;
        private Label lblTicket;
        private Panel pDatos;
        private Button btnGuardar;
        private Label lblHoraSalida;
        private Label lblHoraEntradaTexto;
        private Label lblPlazaTexto;
        private Button btnCancelar;
        private DateTimePicker dtpSalida;
        private Label lblPlaza;
        private Label lblMatricula;
        private Label lblMatriculaTexto;
        private Label lblCi;
        private Label lblCiTexto;
        private Label lblHoraEntrada;
    }
}