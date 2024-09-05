using ADODB;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapaPresentacion
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pArriba = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMinimizar = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.pIzquierda = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pBotones = new System.Windows.Forms.Panel();
            this.btnVehiculo = new System.Windows.Forms.Button();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnParking = new System.Windows.Forms.Button();
            this.btnNeumaticos = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pInfoCargo = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblPersona = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pArriba.SuspendLayout();
            this.pIzquierda.SuspendLayout();
            this.pBotones.SuspendLayout();
            this.pInfoCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pArriba
            // 
            this.pArriba.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pArriba.Controls.Add(this.lblTitulo);
            this.pArriba.Controls.Add(this.lblMinimizar);
            this.pArriba.Controls.Add(this.lblCerrar);
            this.pArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pArriba.Location = new System.Drawing.Point(0, 0);
            this.pArriba.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pArriba.Name = "pArriba";
            this.pArriba.Size = new System.Drawing.Size(1024, 25);
            this.pArriba.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(48, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(88, 18);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "AIOParking";
            // 
            // lblMinimizar
            // 
            this.lblMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimizar.AutoSize = true;
            this.lblMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimizar.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold);
            this.lblMinimizar.ForeColor = System.Drawing.Color.White;
            this.lblMinimizar.Location = new System.Drawing.Point(978, -5);
            this.lblMinimizar.Name = "lblMinimizar";
            this.lblMinimizar.Size = new System.Drawing.Size(23, 32);
            this.lblMinimizar.TabIndex = 1;
            this.lblMinimizar.Text = "-";
            this.lblMinimizar.Click += new System.EventHandler(this.lblMinimizar_Click);
            // 
            // lblCerrar
            // 
            this.lblCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblCerrar.ForeColor = System.Drawing.Color.White;
            this.lblCerrar.Location = new System.Drawing.Point(1002, 3);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(20, 19);
            this.lblCerrar.TabIndex = 0;
            this.lblCerrar.Text = "X";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // pIzquierda
            // 
            this.pIzquierda.BackColor = System.Drawing.SystemColors.Highlight;
            this.pIzquierda.Controls.Add(this.btnLogout);
            this.pIzquierda.Controls.Add(this.pBotones);
            this.pIzquierda.Controls.Add(this.pInfoCargo);
            this.pIzquierda.Controls.Add(this.pictureBox1);
            this.pIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pIzquierda.Location = new System.Drawing.Point(0, 25);
            this.pIzquierda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pIzquierda.Name = "pIzquierda";
            this.pIzquierda.Size = new System.Drawing.Size(180, 575);
            this.pIzquierda.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCyan;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnLogout.Location = new System.Drawing.Point(35, 538);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(109, 25);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pBotones
            // 
            this.pBotones.Controls.Add(this.btnVehiculo);
            this.pBotones.Controls.Add(this.btnPrecio);
            this.pBotones.Controls.Add(this.btnEmpleados);
            this.pBotones.Controls.Add(this.btnParking);
            this.pBotones.Controls.Add(this.btnNeumaticos);
            this.pBotones.Controls.Add(this.btnServicios);
            this.pBotones.Controls.Add(this.btnInicio);
            this.pBotones.Controls.Add(this.btnClientes);
            this.pBotones.Location = new System.Drawing.Point(3, 209);
            this.pBotones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBotones.Name = "pBotones";
            this.pBotones.Size = new System.Drawing.Size(174, 252);
            this.pBotones.TabIndex = 2;
            // 
            // btnVehiculo
            // 
            this.btnVehiculo.BackColor = System.Drawing.Color.LightCyan;
            this.btnVehiculo.FlatAppearance.BorderSize = 0;
            this.btnVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehiculo.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnVehiculo.Location = new System.Drawing.Point(33, 66);
            this.btnVehiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVehiculo.Name = "btnVehiculo";
            this.btnVehiculo.Size = new System.Drawing.Size(110, 25);
            this.btnVehiculo.TabIndex = 7;
            this.btnVehiculo.Text = "Vehículo";
            this.btnVehiculo.UseVisualStyleBackColor = false;
            this.btnVehiculo.Click += new System.EventHandler(this.btnVehiculo_Click);
            // 
            // btnPrecio
            // 
            this.btnPrecio.BackColor = System.Drawing.Color.LightCyan;
            this.btnPrecio.FlatAppearance.BorderSize = 0;
            this.btnPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecio.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnPrecio.Location = new System.Drawing.Point(33, 217);
            this.btnPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(110, 25);
            this.btnPrecio.TabIndex = 6;
            this.btnPrecio.Text = "Precio";
            this.btnPrecio.UseVisualStyleBackColor = false;
            this.btnPrecio.Click += new System.EventHandler(this.btnPrecio_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.Color.LightCyan;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnEmpleados.Location = new System.Drawing.Point(33, 187);
            this.btnEmpleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(110, 25);
            this.btnEmpleados.TabIndex = 5;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnParking
            // 
            this.btnParking.BackColor = System.Drawing.Color.LightCyan;
            this.btnParking.FlatAppearance.BorderSize = 0;
            this.btnParking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParking.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnParking.Location = new System.Drawing.Point(33, 157);
            this.btnParking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnParking.Name = "btnParking";
            this.btnParking.Size = new System.Drawing.Size(110, 25);
            this.btnParking.TabIndex = 4;
            this.btnParking.Text = "Parking";
            this.btnParking.UseVisualStyleBackColor = false;
            this.btnParking.Click += new System.EventHandler(this.btnParking_Click);
            // 
            // btnNeumaticos
            // 
            this.btnNeumaticos.BackColor = System.Drawing.Color.LightCyan;
            this.btnNeumaticos.FlatAppearance.BorderSize = 0;
            this.btnNeumaticos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeumaticos.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnNeumaticos.Location = new System.Drawing.Point(33, 128);
            this.btnNeumaticos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNeumaticos.Name = "btnNeumaticos";
            this.btnNeumaticos.Size = new System.Drawing.Size(110, 25);
            this.btnNeumaticos.TabIndex = 3;
            this.btnNeumaticos.Text = "Neumático";
            this.btnNeumaticos.UseVisualStyleBackColor = false;
            this.btnNeumaticos.Click += new System.EventHandler(this.btnNeumaticos_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.LightCyan;
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnServicios.Location = new System.Drawing.Point(33, 97);
            this.btnServicios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(110, 25);
            this.btnServicios.TabIndex = 2;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.LightCyan;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnInicio.Location = new System.Drawing.Point(33, 6);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(110, 25);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.LightCyan;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnClientes.Location = new System.Drawing.Point(33, 36);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(110, 25);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Cliente";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pInfoCargo
            // 
            this.pInfoCargo.Controls.Add(this.lblRol);
            this.pInfoCargo.Controls.Add(this.lblPersona);
            this.pInfoCargo.Location = new System.Drawing.Point(3, 142);
            this.pInfoCargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pInfoCargo.Name = "pInfoCargo";
            this.pInfoCargo.Size = new System.Drawing.Size(174, 49);
            this.pInfoCargo.TabIndex = 1;
            // 
            // lblRol
            // 
            this.lblRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Arial", 12F);
            this.lblRol.ForeColor = System.Drawing.Color.White;
            this.lblRol.Location = new System.Drawing.Point(2, 26);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(84, 24);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Operador\r\n";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRol.UseCompatibleTextRendering = true;
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPersona.ForeColor = System.Drawing.Color.White;
            this.lblPersona.Location = new System.Drawing.Point(3, 5);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(67, 18);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Persona";
            this.lblPersona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.AioParkingLogo_150px;
            this.pictureBox1.Location = new System.Drawing.Point(36, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pIzquierda);
            this.Controls.Add(this.pArriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.pArriba.ResumeLayout(false);
            this.pArriba.PerformLayout();
            this.pIzquierda.ResumeLayout(false);
            this.pBotones.ResumeLayout(false);
            this.pInfoCargo.ResumeLayout(false);
            this.pInfoCargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pArriba;
        private Panel pIzquierda;
        private Label lblCerrar;
        private Label lblMinimizar;
        private PictureBox pictureBox1;
        private Label lblTitulo;
        private Panel pInfoCargo;
        private Label lblPersona;
        private Label lblRol;
        private Panel pBotones;
        private Button btnClientes;
        private Button btnInicio;
        private Button btnServicios;
        private Button btnParking;
        private Button btnNeumaticos;
        private Button btnEmpleados;
        private Button btnPrecio;
        private Button btnVehiculo;
        private Button btnLogout;
    }
}
