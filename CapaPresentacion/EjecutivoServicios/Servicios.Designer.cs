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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pDatos = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbBalanceo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblBalanceo = new System.Windows.Forms.Label();
            this.cbAlineacion = new System.Windows.Forms.ComboBox();
            this.lblAlineacion = new System.Windows.Forms.Label();
            this.cbMontaje = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAyB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLavado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(335, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicios";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMatricula);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.lblMatricula);
            this.panel1.Location = new System.Drawing.Point(9, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 1;
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.LightBlue;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMatricula.Location = new System.Drawing.Point(339, 15);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(135, 25);
            this.txtMatricula.TabIndex = 2;
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
            this.btnBuscar.Location = new System.Drawing.Point(488, 15);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMatricula.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMatricula.Location = new System.Drawing.Point(260, 18);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(70, 18);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matrícula";
            // 
            // pDatos
            // 
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Controls.Add(this.cbBalanceo);
            this.pDatos.Controls.Add(this.btnGuardar);
            this.pDatos.Controls.Add(this.lblBalanceo);
            this.pDatos.Controls.Add(this.cbAlineacion);
            this.pDatos.Controls.Add(this.lblAlineacion);
            this.pDatos.Controls.Add(this.cbMontaje);
            this.pDatos.Controls.Add(this.label6);
            this.pDatos.Controls.Add(this.cbAyB);
            this.pDatos.Controls.Add(this.label5);
            this.pDatos.Controls.Add(this.cbLavado);
            this.pDatos.Controls.Add(this.label3);
            this.pDatos.Location = new System.Drawing.Point(9, 156);
            this.pDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(800, 286);
            this.pDatos.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(414, 235);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 25);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbBalanceo
            // 
            this.cbBalanceo.BackColor = System.Drawing.Color.LightBlue;
            this.cbBalanceo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBalanceo.Font = new System.Drawing.Font("Arial", 12F);
            this.cbBalanceo.FormattingEnabled = true;
            this.cbBalanceo.Items.AddRange(new object[] {
            "Bal auto + válv",
            "Bal cam + válv",
            "No"});
            this.cbBalanceo.Location = new System.Drawing.Point(429, 178);
            this.cbBalanceo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBalanceo.Name = "cbBalanceo";
            this.cbBalanceo.Size = new System.Drawing.Size(190, 26);
            this.cbBalanceo.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(330, 235);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblBalanceo
            // 
            this.lblBalanceo.AutoSize = true;
            this.lblBalanceo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblBalanceo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBalanceo.Location = new System.Drawing.Point(253, 180);
            this.lblBalanceo.Name = "lblBalanceo";
            this.lblBalanceo.Size = new System.Drawing.Size(74, 18);
            this.lblBalanceo.TabIndex = 13;
            this.lblBalanceo.Text = "Balanceo";
            // 
            // cbAlineacion
            // 
            this.cbAlineacion.BackColor = System.Drawing.Color.LightBlue;
            this.cbAlineacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlineacion.Font = new System.Drawing.Font("Arial", 12F);
            this.cbAlineacion.FormattingEnabled = true;
            this.cbAlineacion.Items.AddRange(new object[] {
            "Alineación",
            "Un tren desde R17",
            "Dos trenes",
            "Pack alin y 4 bal cam. + válv",
            "No"});
            this.cbAlineacion.Location = new System.Drawing.Point(429, 143);
            this.cbAlineacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAlineacion.Name = "cbAlineacion";
            this.cbAlineacion.Size = new System.Drawing.Size(190, 26);
            this.cbAlineacion.TabIndex = 12;
            // 
            // lblAlineacion
            // 
            this.lblAlineacion.AutoSize = true;
            this.lblAlineacion.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAlineacion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAlineacion.Location = new System.Drawing.Point(253, 146);
            this.lblAlineacion.Name = "lblAlineacion";
            this.lblAlineacion.Size = new System.Drawing.Size(81, 18);
            this.lblAlineacion.TabIndex = 11;
            this.lblAlineacion.Text = "Alineación";
            // 
            // cbMontaje
            // 
            this.cbMontaje.BackColor = System.Drawing.Color.LightBlue;
            this.cbMontaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMontaje.Font = new System.Drawing.Font("Arial", 12F);
            this.cbMontaje.FormattingEnabled = true;
            this.cbMontaje.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbMontaje.Location = new System.Drawing.Point(429, 74);
            this.cbMontaje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMontaje.Name = "cbMontaje";
            this.cbMontaje.Size = new System.Drawing.Size(101, 26);
            this.cbMontaje.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(253, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Montaje neumático";
            // 
            // cbAyB
            // 
            this.cbAyB.BackColor = System.Drawing.Color.LightBlue;
            this.cbAyB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAyB.Font = new System.Drawing.Font("Arial", 12F);
            this.cbAyB.FormattingEnabled = true;
            this.cbAyB.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbAyB.Location = new System.Drawing.Point(429, 108);
            this.cbAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAyB.Name = "cbAyB";
            this.cbAyB.Size = new System.Drawing.Size(101, 26);
            this.cbAyB.TabIndex = 6;
            this.cbAyB.SelectedIndexChanged += new System.EventHandler(this.cbAyB_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(253, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alineación y Balanceo";
            // 
            // cbLavado
            // 
            this.cbLavado.BackColor = System.Drawing.Color.LightBlue;
            this.cbLavado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLavado.Font = new System.Drawing.Font("Arial", 12F);
            this.cbLavado.FormattingEnabled = true;
            this.cbLavado.Items.AddRange(new object[] {
            "Moto",
            "Auto",
            "Camioneta",
            "Pequeño utilitario",
            "Pequeño utilitario",
            "Lavado gratis",
            "No"});
            this.cbLavado.Location = new System.Drawing.Point(429, 39);
            this.cbLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLavado.Name = "cbLavado";
            this.cbLavado.Size = new System.Drawing.Size(190, 26);
            this.cbLavado.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(253, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lavado";
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.pDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox txtMatricula;
        private Button btnBuscar;
        private Label lblMatricula;
        private Panel pDatos;
        private Label label3;
        private ComboBox cbAyB;
        private Label label5;
        private ComboBox cbLavado;
        private ComboBox cbMontaje;
        private Label label6;
        private ComboBox cbAlineacion;
        private Label lblAlineacion;
        private ComboBox cbBalanceo;
        private Label lblBalanceo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}