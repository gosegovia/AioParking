using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Cajero
{
    partial class Factura
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
            this.lblFactura = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.txtHoraSalida = new System.Windows.Forms.Label();
            this.txtHoraEntrada = new System.Windows.Forms.Label();
            this.lblPesos = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.Label();
            this.lblPrecioText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHorasTotales = new System.Windows.Forms.Label();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.pDatosServicios = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCompraNeumatico = new System.Windows.Forms.Label();
            this.lblCompraText = new System.Windows.Forms.Label();
            this.txtAyB = new System.Windows.Forms.Label();
            this.lblAyBText = new System.Windows.Forms.Label();
            this.txtLavado = new System.Windows.Forms.Label();
            this.lblLavadoText = new System.Windows.Forms.Label();
            this.lblOtrosServicios = new System.Windows.Forms.Label();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pDatos.SuspendLayout();
            this.pDatosServicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFactura
            // 
            this.lblFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Arial", 28.2F);
            this.lblFactura.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFactura.Location = new System.Drawing.Point(366, 34);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(148, 43);
            this.lblFactura.TabIndex = 0;
            this.lblFactura.Text = "Factura";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtMatricula);
            this.panel1.Controls.Add(this.lblMatricula);
            this.panel1.Location = new System.Drawing.Point(12, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 83);
            this.panel1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(523, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(334, 32);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(180, 25);
            this.txtMatricula.TabIndex = 4;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(248, 36);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 3;
            this.lblMatricula.Text = "Matrícula";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.txtHoraSalida);
            this.pDatos.Controls.Add(this.txtHoraEntrada);
            this.pDatos.Controls.Add(this.lblPesos);
            this.pDatos.Controls.Add(this.txtPrecio);
            this.pDatos.Controls.Add(this.lblPrecioText);
            this.pDatos.Controls.Add(this.label7);
            this.pDatos.Controls.Add(this.txtHorasTotales);
            this.pDatos.Controls.Add(this.lblHorasTotales);
            this.pDatos.Controls.Add(this.lblHoraSalida);
            this.pDatos.Controls.Add(this.lblHoraEntrada);
            this.pDatos.Location = new System.Drawing.Point(66, 192);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(369, 187);
            this.pDatos.TabIndex = 2;
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.AutoSize = true;
            this.txtHoraSalida.Font = new System.Drawing.Font("Arial", 12F);
            this.txtHoraSalida.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtHoraSalida.Location = new System.Drawing.Point(163, 63);
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(28, 18);
            this.txtHoraSalida.TabIndex = 17;
            this.txtHoraSalida.Text = ".....";
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.AutoSize = true;
            this.txtHoraEntrada.Font = new System.Drawing.Font("Arial", 12F);
            this.txtHoraEntrada.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtHoraEntrada.Location = new System.Drawing.Point(165, 24);
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(28, 18);
            this.txtHoraEntrada.TabIndex = 16;
            this.txtHoraEntrada.Text = ".....";
            // 
            // lblPesos
            // 
            this.lblPesos.AutoSize = true;
            this.lblPesos.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPesos.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPesos.Location = new System.Drawing.Point(165, 144);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(17, 18);
            this.lblPesos.TabIndex = 15;
            this.lblPesos.Text = "$";
            // 
            // txtPrecio
            // 
            this.txtPrecio.AutoSize = true;
            this.txtPrecio.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPrecio.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtPrecio.Location = new System.Drawing.Point(184, 144);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(28, 18);
            this.txtPrecio.TabIndex = 14;
            this.txtPrecio.Text = ".....";
            // 
            // lblPrecioText
            // 
            this.lblPrecioText.AutoSize = true;
            this.lblPrecioText.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPrecioText.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecioText.Location = new System.Drawing.Point(35, 144);
            this.lblPrecioText.Name = "lblPrecioText";
            this.lblPrecioText.Size = new System.Drawing.Size(54, 18);
            this.lblPrecioText.TabIndex = 13;
            this.lblPrecioText.Text = "Precio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(193, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "hs";
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.AutoSize = true;
            this.txtHorasTotales.Font = new System.Drawing.Font("Arial", 12F);
            this.txtHorasTotales.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtHorasTotales.Location = new System.Drawing.Point(165, 105);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(28, 18);
            this.txtHorasTotales.TabIndex = 11;
            this.txtHorasTotales.Text = ".....";
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHorasTotales.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHorasTotales.Location = new System.Drawing.Point(35, 105);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(83, 18);
            this.lblHorasTotales.TabIndex = 10;
            this.lblHorasTotales.Text = "Total horas";
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraSalida.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraSalida.Location = new System.Drawing.Point(35, 63);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(88, 18);
            this.lblHoraSalida.TabIndex = 8;
            this.lblHoraSalida.Text = "Hora salida";
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Font = new System.Drawing.Font("Arial", 12F);
            this.lblHoraEntrada.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHoraEntrada.Location = new System.Drawing.Point(35, 24);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(99, 18);
            this.lblHoraEntrada.TabIndex = 6;
            this.lblHoraEntrada.Text = "Hora entrada";
            // 
            // pDatosServicios
            // 
            this.pDatosServicios.Controls.Add(this.panel4);
            this.pDatosServicios.Controls.Add(this.txtCompraNeumatico);
            this.pDatosServicios.Controls.Add(this.lblCompraText);
            this.pDatosServicios.Controls.Add(this.txtAyB);
            this.pDatosServicios.Controls.Add(this.lblAyBText);
            this.pDatosServicios.Controls.Add(this.txtLavado);
            this.pDatosServicios.Controls.Add(this.lblLavadoText);
            this.pDatosServicios.Controls.Add(this.lblOtrosServicios);
            this.pDatosServicios.Location = new System.Drawing.Point(453, 192);
            this.pDatosServicios.Name = "pDatosServicios";
            this.pDatosServicios.Size = new System.Drawing.Size(283, 187);
            this.pDatosServicios.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 193);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1048, 56);
            this.panel4.TabIndex = 17;
            // 
            // txtCompraNeumatico
            // 
            this.txtCompraNeumatico.AutoSize = true;
            this.txtCompraNeumatico.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCompraNeumatico.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtCompraNeumatico.Location = new System.Drawing.Point(232, 142);
            this.txtCompraNeumatico.Name = "txtCompraNeumatico";
            this.txtCompraNeumatico.Size = new System.Drawing.Size(28, 18);
            this.txtCompraNeumatico.TabIndex = 15;
            this.txtCompraNeumatico.Text = ".....";
            // 
            // lblCompraText
            // 
            this.lblCompraText.AutoSize = true;
            this.lblCompraText.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCompraText.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCompraText.Location = new System.Drawing.Point(22, 142);
            this.lblCompraText.Name = "lblCompraText";
            this.lblCompraText.Size = new System.Drawing.Size(144, 18);
            this.lblCompraText.TabIndex = 14;
            this.lblCompraText.Text = "Compra Neumático";
            // 
            // txtAyB
            // 
            this.txtAyB.AutoSize = true;
            this.txtAyB.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAyB.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtAyB.Location = new System.Drawing.Point(231, 99);
            this.txtAyB.Name = "txtAyB";
            this.txtAyB.Size = new System.Drawing.Size(28, 18);
            this.txtAyB.TabIndex = 13;
            this.txtAyB.Text = ".....";
            // 
            // lblAyBText
            // 
            this.lblAyBText.AutoSize = true;
            this.lblAyBText.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAyBText.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAyBText.Location = new System.Drawing.Point(22, 99);
            this.lblAyBText.Name = "lblAyBText";
            this.lblAyBText.Size = new System.Drawing.Size(162, 18);
            this.lblAyBText.TabIndex = 12;
            this.lblAyBText.Text = "Alineación y Balanceo";
            // 
            // txtLavado
            // 
            this.txtLavado.AutoSize = true;
            this.txtLavado.Font = new System.Drawing.Font("Arial", 12F);
            this.txtLavado.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLavado.Location = new System.Drawing.Point(230, 61);
            this.txtLavado.Name = "txtLavado";
            this.txtLavado.Size = new System.Drawing.Size(28, 18);
            this.txtLavado.TabIndex = 11;
            this.txtLavado.Text = ".....";
            // 
            // lblLavadoText
            // 
            this.lblLavadoText.AutoSize = true;
            this.lblLavadoText.Font = new System.Drawing.Font("Arial", 12F);
            this.lblLavadoText.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblLavadoText.Location = new System.Drawing.Point(22, 61);
            this.lblLavadoText.Name = "lblLavadoText";
            this.lblLavadoText.Size = new System.Drawing.Size(60, 18);
            this.lblLavadoText.TabIndex = 8;
            this.lblLavadoText.Text = "Lavado";
            // 
            // lblOtrosServicios
            // 
            this.lblOtrosServicios.AutoSize = true;
            this.lblOtrosServicios.Font = new System.Drawing.Font("Arial", 12F);
            this.lblOtrosServicios.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOtrosServicios.Location = new System.Drawing.Point(91, 22);
            this.lblOtrosServicios.Name = "lblOtrosServicios";
            this.lblOtrosServicios.Size = new System.Drawing.Size(115, 18);
            this.lblOtrosServicios.TabIndex = 6;
            this.lblOtrosServicios.Text = "Otros Servicios";
            // 
            // btnFactura
            // 
            this.btnFactura.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFactura.FlatAppearance.BorderSize = 0;
            this.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactura.Font = new System.Drawing.Font("Arial", 12F);
            this.btnFactura.ForeColor = System.Drawing.Color.White;
            this.btnFactura.Location = new System.Drawing.Point(332, 403);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(100, 30);
            this.btnFactura.TabIndex = 6;
            this.btnFactura.Text = "Facturar";
            this.btnFactura.UseVisualStyleBackColor = false;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(439, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.pDatosServicios);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFactura);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Factura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.pDatosServicios.ResumeLayout(false);
            this.pDatosServicios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFactura;
        private Panel panel1;
        private Button btnBuscar;
        private TextBox txtMatricula;
        private Label lblMatricula;
        private Panel pDatos;
        private Label label7;
        private Label txtHorasTotales;
        private Label lblHorasTotales;
        private Label lblHoraSalida;
        private Label lblHoraEntrada;
        private Label lblPesos;
        private Label txtPrecio;
        private Label lblPrecioText;
        private Panel pDatosServicios;
        private Label txtLavado;
        private Label lblLavadoText;
        private Label lblOtrosServicios;
        private Panel panel4;
        private Label txtCompraNeumatico;
        private Label lblCompraText;
        private Label txtAyB;
        private Label lblAyBText;
        private Button btnFactura;
        private Label txtHoraEntrada;
        private Label txtHoraSalida;
        private Button btnCancelar;
    }
}