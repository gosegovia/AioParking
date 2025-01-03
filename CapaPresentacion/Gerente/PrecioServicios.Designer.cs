﻿using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Gerente
{
    partial class PrecioServicios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNeumatico = new System.Windows.Forms.TabPage();
            this.dgvNeumatico = new System.Windows.Forms.DataGridView();
            this.pDatosNeumatico = new System.Windows.Forms.Panel();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cbModelo = new System.Windows.Forms.ComboBox();
            this.btnCancelarNeumatico = new System.Windows.Forms.Button();
            this.btnGuardarNeumatico = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecioNeumatico = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.btnBuscarNeumatico = new System.Windows.Forms.Button();
            this.txtNeumatico = new System.Windows.Forms.TextBox();
            this.lblNeumatico = new System.Windows.Forms.Label();
            this.tabLavadero = new System.Windows.Forms.TabPage();
            this.dgvLavado = new System.Windows.Forms.DataGridView();
            this.pDatosLavado = new System.Windows.Forms.Panel();
            this.lblNombreLavado = new System.Windows.Forms.Label();
            this.btnCancelarLavado = new System.Windows.Forms.Button();
            this.btnGuardarLavado = new System.Windows.Forms.Button();
            this.txtPrecioLavado = new System.Windows.Forms.TextBox();
            this.lblPracioLavado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnBuscarLavado = new System.Windows.Forms.Button();
            this.txtLavado = new System.Windows.Forms.TextBox();
            this.lblLavado = new System.Windows.Forms.Label();
            this.tabAyB = new System.Windows.Forms.TabPage();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            this.btnBuscarAyB = new System.Windows.Forms.Button();
            this.txtAyB = new System.Windows.Forms.TextBox();
            this.lblAyB = new System.Windows.Forms.Label();
            this.pDatosAyB = new System.Windows.Forms.Panel();
            this.lblNombreAyB = new System.Windows.Forms.Label();
            this.btnCancelarAyB = new System.Windows.Forms.Button();
            this.btnGuardarAyB = new System.Windows.Forms.Button();
            this.txtPrecioAyB = new System.Windows.Forms.TextBox();
            this.lblPrecioAyB = new System.Windows.Forms.Label();
            this.lblNombreAyBText = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabNeumatico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeumatico)).BeginInit();
            this.pDatosNeumatico.SuspendLayout();
            this.tabLavadero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavado)).BeginInit();
            this.pDatosLavado.SuspendLayout();
            this.tabAyB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.pDatosAyB.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(257, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualización Precios";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNeumatico);
            this.tabControl1.Controls.Add(this.tabLavadero);
            this.tabControl1.Controls.Add(this.tabAyB);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.tabControl1.Location = new System.Drawing.Point(12, 80);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabNeumatico
            // 
            this.tabNeumatico.Controls.Add(this.dgvNeumatico);
            this.tabNeumatico.Controls.Add(this.pDatosNeumatico);
            this.tabNeumatico.Controls.Add(this.btnBuscarNeumatico);
            this.tabNeumatico.Controls.Add(this.txtNeumatico);
            this.tabNeumatico.Controls.Add(this.lblNeumatico);
            this.tabNeumatico.Location = new System.Drawing.Point(4, 27);
            this.tabNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabNeumatico.Name = "tabNeumatico";
            this.tabNeumatico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabNeumatico.Size = new System.Drawing.Size(818, 419);
            this.tabNeumatico.TabIndex = 0;
            this.tabNeumatico.Text = "Neumático";
            this.tabNeumatico.UseVisualStyleBackColor = true;
            // 
            // dgvNeumatico
            // 
            this.dgvNeumatico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNeumatico.Location = new System.Drawing.Point(332, 110);
            this.dgvNeumatico.Name = "dgvNeumatico";
            this.dgvNeumatico.RowTemplate.Height = 25;
            this.dgvNeumatico.Size = new System.Drawing.Size(459, 221);
            this.dgvNeumatico.TabIndex = 19;
            this.dgvNeumatico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNeumatico_CellClick);
            // 
            // pDatosNeumatico
            // 
            this.pDatosNeumatico.Controls.Add(this.txtStock);
            this.pDatosNeumatico.Controls.Add(this.label3);
            this.pDatosNeumatico.Controls.Add(this.txtNombre);
            this.pDatosNeumatico.Controls.Add(this.label2);
            this.pDatosNeumatico.Controls.Add(this.btnEliminar);
            this.pDatosNeumatico.Controls.Add(this.cbModelo);
            this.pDatosNeumatico.Controls.Add(this.btnCancelarNeumatico);
            this.pDatosNeumatico.Controls.Add(this.btnGuardarNeumatico);
            this.pDatosNeumatico.Controls.Add(this.txtPrecio);
            this.pDatosNeumatico.Controls.Add(this.lblPrecioNeumatico);
            this.pDatosNeumatico.Controls.Add(this.lblModelo);
            this.pDatosNeumatico.Location = new System.Drawing.Point(22, 85);
            this.pDatosNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatosNeumatico.Name = "pDatosNeumatico";
            this.pDatosNeumatico.Size = new System.Drawing.Size(293, 308);
            this.pDatosNeumatico.TabIndex = 3;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.LightBlue;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Location = new System.Drawing.Point(109, 118);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Multiline = true;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(135, 25);
            this.txtStock.TabIndex = 14;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(38, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Stock";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.LightBlue;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Location = new System.Drawing.Point(109, 19);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(135, 25);
            this.txtNombre.TabIndex = 12;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(38, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(106, 164);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cbModelo
            // 
            this.cbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelo.FormattingEnabled = true;
            this.cbModelo.Items.AddRange(new object[] {
            "Michelin",
            "Bridgestone",
            "Pirelli"});
            this.cbModelo.Location = new System.Drawing.Point(109, 52);
            this.cbModelo.Name = "cbModelo";
            this.cbModelo.Size = new System.Drawing.Size(136, 26);
            this.cbModelo.TabIndex = 9;
            // 
            // btnCancelarNeumatico
            // 
            this.btnCancelarNeumatico.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelarNeumatico.FlatAppearance.BorderSize = 0;
            this.btnCancelarNeumatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarNeumatico.ForeColor = System.Drawing.Color.White;
            this.btnCancelarNeumatico.Location = new System.Drawing.Point(188, 164);
            this.btnCancelarNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarNeumatico.Name = "btnCancelarNeumatico";
            this.btnCancelarNeumatico.Size = new System.Drawing.Size(85, 25);
            this.btnCancelarNeumatico.TabIndex = 8;
            this.btnCancelarNeumatico.Text = "Cancelar";
            this.btnCancelarNeumatico.UseVisualStyleBackColor = false;
            this.btnCancelarNeumatico.Click += new System.EventHandler(this.btnCancelarNeumatico_Click);
            // 
            // btnGuardarNeumatico
            // 
            this.btnGuardarNeumatico.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarNeumatico.FlatAppearance.BorderSize = 0;
            this.btnGuardarNeumatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNeumatico.ForeColor = System.Drawing.Color.White;
            this.btnGuardarNeumatico.Location = new System.Drawing.Point(25, 164);
            this.btnGuardarNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarNeumatico.Name = "btnGuardarNeumatico";
            this.btnGuardarNeumatico.Size = new System.Drawing.Size(75, 25);
            this.btnGuardarNeumatico.TabIndex = 4;
            this.btnGuardarNeumatico.Text = "Guardar";
            this.btnGuardarNeumatico.UseVisualStyleBackColor = false;
            this.btnGuardarNeumatico.Click += new System.EventHandler(this.btnGuardarNeumatico_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.LightBlue;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Location = new System.Drawing.Point(109, 86);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(135, 25);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblPrecioNeumatico
            // 
            this.lblPrecioNeumatico.AutoSize = true;
            this.lblPrecioNeumatico.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecioNeumatico.Location = new System.Drawing.Point(39, 88);
            this.lblPrecioNeumatico.Name = "lblPrecioNeumatico";
            this.lblPrecioNeumatico.Size = new System.Drawing.Size(54, 18);
            this.lblPrecioNeumatico.TabIndex = 6;
            this.lblPrecioNeumatico.Text = "Precio";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblModelo.Location = new System.Drawing.Point(38, 55);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(52, 18);
            this.lblModelo.TabIndex = 4;
            this.lblModelo.Text = "Marca";
            // 
            // btnBuscarNeumatico
            // 
            this.btnBuscarNeumatico.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarNeumatico.FlatAppearance.BorderSize = 0;
            this.btnBuscarNeumatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNeumatico.ForeColor = System.Drawing.Color.White;
            this.btnBuscarNeumatico.Location = new System.Drawing.Point(512, 30);
            this.btnBuscarNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarNeumatico.Name = "btnBuscarNeumatico";
            this.btnBuscarNeumatico.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarNeumatico.TabIndex = 2;
            this.btnBuscarNeumatico.Text = "Buscar";
            this.btnBuscarNeumatico.UseVisualStyleBackColor = false;
            this.btnBuscarNeumatico.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNeumatico
            // 
            this.txtNeumatico.BackColor = System.Drawing.Color.LightBlue;
            this.txtNeumatico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNeumatico.Location = new System.Drawing.Point(371, 30);
            this.txtNeumatico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNeumatico.Multiline = true;
            this.txtNeumatico.Name = "txtNeumatico";
            this.txtNeumatico.Size = new System.Drawing.Size(135, 25);
            this.txtNeumatico.TabIndex = 1;
            this.txtNeumatico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNeumatico_KeyDown);
            this.txtNeumatico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNeumatico_KeyPress);
            // 
            // lblNeumatico
            // 
            this.lblNeumatico.AutoSize = true;
            this.lblNeumatico.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNeumatico.Location = new System.Drawing.Point(282, 33);
            this.lblNeumatico.Name = "lblNeumatico";
            this.lblNeumatico.Size = new System.Drawing.Size(83, 18);
            this.lblNeumatico.TabIndex = 0;
            this.lblNeumatico.Text = "Neumático";
            // 
            // tabLavadero
            // 
            this.tabLavadero.Controls.Add(this.dgvLavado);
            this.tabLavadero.Controls.Add(this.pDatosLavado);
            this.tabLavadero.Controls.Add(this.btnBuscarLavado);
            this.tabLavadero.Controls.Add(this.txtLavado);
            this.tabLavadero.Controls.Add(this.lblLavado);
            this.tabLavadero.Location = new System.Drawing.Point(4, 27);
            this.tabLavadero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLavadero.Name = "tabLavadero";
            this.tabLavadero.Size = new System.Drawing.Size(818, 419);
            this.tabLavadero.TabIndex = 2;
            this.tabLavadero.Text = "Lavadero";
            this.tabLavadero.UseVisualStyleBackColor = true;
            // 
            // dgvLavado
            // 
            this.dgvLavado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLavado.Location = new System.Drawing.Point(358, 105);
            this.dgvLavado.Name = "dgvLavado";
            this.dgvLavado.RowTemplate.Height = 25;
            this.dgvLavado.Size = new System.Drawing.Size(396, 201);
            this.dgvLavado.TabIndex = 29;
            this.dgvLavado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLavado_CellClick);
            // 
            // pDatosLavado
            // 
            this.pDatosLavado.Controls.Add(this.lblNombreLavado);
            this.pDatosLavado.Controls.Add(this.btnCancelarLavado);
            this.pDatosLavado.Controls.Add(this.btnGuardarLavado);
            this.pDatosLavado.Controls.Add(this.txtPrecioLavado);
            this.pDatosLavado.Controls.Add(this.lblPracioLavado);
            this.pDatosLavado.Controls.Add(this.lblNombre);
            this.pDatosLavado.Location = new System.Drawing.Point(106, 84);
            this.pDatosLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatosLavado.Name = "pDatosLavado";
            this.pDatosLavado.Size = new System.Drawing.Size(237, 252);
            this.pDatosLavado.TabIndex = 6;
            // 
            // lblNombreLavado
            // 
            this.lblNombreLavado.AutoSize = true;
            this.lblNombreLavado.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombreLavado.Location = new System.Drawing.Point(86, 21);
            this.lblNombreLavado.Name = "lblNombreLavado";
            this.lblNombreLavado.Size = new System.Drawing.Size(28, 18);
            this.lblNombreLavado.TabIndex = 9;
            this.lblNombreLavado.Text = ".....";
            // 
            // btnCancelarLavado
            // 
            this.btnCancelarLavado.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelarLavado.FlatAppearance.BorderSize = 0;
            this.btnCancelarLavado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarLavado.ForeColor = System.Drawing.Color.White;
            this.btnCancelarLavado.Location = new System.Drawing.Point(124, 100);
            this.btnCancelarLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarLavado.Name = "btnCancelarLavado";
            this.btnCancelarLavado.Size = new System.Drawing.Size(90, 25);
            this.btnCancelarLavado.TabIndex = 8;
            this.btnCancelarLavado.Text = "Cancelar";
            this.btnCancelarLavado.UseVisualStyleBackColor = false;
            this.btnCancelarLavado.Click += new System.EventHandler(this.btnCancelarLavado_Click);
            // 
            // btnGuardarLavado
            // 
            this.btnGuardarLavado.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarLavado.FlatAppearance.BorderSize = 0;
            this.btnGuardarLavado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarLavado.ForeColor = System.Drawing.Color.White;
            this.btnGuardarLavado.Location = new System.Drawing.Point(43, 100);
            this.btnGuardarLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarLavado.Name = "btnGuardarLavado";
            this.btnGuardarLavado.Size = new System.Drawing.Size(75, 25);
            this.btnGuardarLavado.TabIndex = 4;
            this.btnGuardarLavado.Text = "Guardar";
            this.btnGuardarLavado.UseVisualStyleBackColor = false;
            this.btnGuardarLavado.Click += new System.EventHandler(this.btnGuardarLavado_Click);
            // 
            // txtPrecioLavado
            // 
            this.txtPrecioLavado.BackColor = System.Drawing.Color.LightBlue;
            this.txtPrecioLavado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecioLavado.Location = new System.Drawing.Point(86, 51);
            this.txtPrecioLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioLavado.Multiline = true;
            this.txtPrecioLavado.Name = "txtPrecioLavado";
            this.txtPrecioLavado.Size = new System.Drawing.Size(135, 25);
            this.txtPrecioLavado.TabIndex = 7;
            this.txtPrecioLavado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioLavado_KeyPress);
            // 
            // lblPracioLavado
            // 
            this.lblPracioLavado.AutoSize = true;
            this.lblPracioLavado.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPracioLavado.Location = new System.Drawing.Point(13, 54);
            this.lblPracioLavado.Name = "lblPracioLavado";
            this.lblPracioLavado.Size = new System.Drawing.Size(54, 18);
            this.lblPracioLavado.TabIndex = 6;
            this.lblPracioLavado.Text = "Precio";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Location = new System.Drawing.Point(13, 21);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 18);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnBuscarLavado
            // 
            this.btnBuscarLavado.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarLavado.FlatAppearance.BorderSize = 0;
            this.btnBuscarLavado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarLavado.ForeColor = System.Drawing.Color.White;
            this.btnBuscarLavado.Location = new System.Drawing.Point(458, 30);
            this.btnBuscarLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarLavado.Name = "btnBuscarLavado";
            this.btnBuscarLavado.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarLavado.TabIndex = 5;
            this.btnBuscarLavado.Text = "Buscar";
            this.btnBuscarLavado.UseVisualStyleBackColor = false;
            this.btnBuscarLavado.Click += new System.EventHandler(this.btnBuscarLavado_Click);
            // 
            // txtLavado
            // 
            this.txtLavado.BackColor = System.Drawing.Color.LightBlue;
            this.txtLavado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLavado.Location = new System.Drawing.Point(315, 30);
            this.txtLavado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLavado.Multiline = true;
            this.txtLavado.Name = "txtLavado";
            this.txtLavado.Size = new System.Drawing.Size(135, 25);
            this.txtLavado.TabIndex = 4;
            this.txtLavado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLavado_KeyDown);
            this.txtLavado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLavado_KeyPress);
            // 
            // lblLavado
            // 
            this.lblLavado.AutoSize = true;
            this.lblLavado.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblLavado.Location = new System.Drawing.Point(250, 32);
            this.lblLavado.Name = "lblLavado";
            this.lblLavado.Size = new System.Drawing.Size(60, 18);
            this.lblLavado.TabIndex = 3;
            this.lblLavado.Text = "Lavado";
            // 
            // tabAyB
            // 
            this.tabAyB.Controls.Add(this.dgvServicio);
            this.tabAyB.Controls.Add(this.btnBuscarAyB);
            this.tabAyB.Controls.Add(this.txtAyB);
            this.tabAyB.Controls.Add(this.lblAyB);
            this.tabAyB.Controls.Add(this.pDatosAyB);
            this.tabAyB.Location = new System.Drawing.Point(4, 27);
            this.tabAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAyB.Name = "tabAyB";
            this.tabAyB.Size = new System.Drawing.Size(818, 419);
            this.tabAyB.TabIndex = 3;
            this.tabAyB.Text = "Alineación y Balanceo";
            this.tabAyB.UseVisualStyleBackColor = true;
            // 
            // dgvServicio
            // 
            this.dgvServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvServicio.Location = new System.Drawing.Point(419, 105);
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.RowTemplate.Height = 25;
            this.dgvServicio.Size = new System.Drawing.Size(396, 201);
            this.dgvServicio.TabIndex = 29;
            this.dgvServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicio_CellClick);
            // 
            // btnBuscarAyB
            // 
            this.btnBuscarAyB.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarAyB.FlatAppearance.BorderSize = 0;
            this.btnBuscarAyB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAyB.ForeColor = System.Drawing.Color.White;
            this.btnBuscarAyB.Location = new System.Drawing.Point(547, 30);
            this.btnBuscarAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarAyB.Name = "btnBuscarAyB";
            this.btnBuscarAyB.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarAyB.TabIndex = 6;
            this.btnBuscarAyB.Text = "Buscar";
            this.btnBuscarAyB.UseVisualStyleBackColor = false;
            this.btnBuscarAyB.Click += new System.EventHandler(this.btnBuscarAyB_Click);
            // 
            // txtAyB
            // 
            this.txtAyB.BackColor = System.Drawing.Color.LightBlue;
            this.txtAyB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAyB.Location = new System.Drawing.Point(404, 30);
            this.txtAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAyB.Multiline = true;
            this.txtAyB.Name = "txtAyB";
            this.txtAyB.Size = new System.Drawing.Size(135, 25);
            this.txtAyB.TabIndex = 5;
            this.txtAyB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAyB_KeyDown);
            this.txtAyB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAyB_KeyPress);
            // 
            // lblAyB
            // 
            this.lblAyB.AutoSize = true;
            this.lblAyB.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAyB.Location = new System.Drawing.Point(229, 33);
            this.lblAyB.Name = "lblAyB";
            this.lblAyB.Size = new System.Drawing.Size(162, 18);
            this.lblAyB.TabIndex = 4;
            this.lblAyB.Text = "Alineación y Balanceo";
            // 
            // pDatosAyB
            // 
            this.pDatosAyB.Controls.Add(this.lblNombreAyB);
            this.pDatosAyB.Controls.Add(this.btnCancelarAyB);
            this.pDatosAyB.Controls.Add(this.btnGuardarAyB);
            this.pDatosAyB.Controls.Add(this.txtPrecioAyB);
            this.pDatosAyB.Controls.Add(this.lblPrecioAyB);
            this.pDatosAyB.Controls.Add(this.lblNombreAyBText);
            this.pDatosAyB.Location = new System.Drawing.Point(17, 122);
            this.pDatosAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDatosAyB.Name = "pDatosAyB";
            this.pDatosAyB.Size = new System.Drawing.Size(384, 159);
            this.pDatosAyB.TabIndex = 7;
            // 
            // lblNombreAyB
            // 
            this.lblNombreAyB.AutoSize = true;
            this.lblNombreAyB.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombreAyB.Location = new System.Drawing.Point(82, 14);
            this.lblNombreAyB.Name = "lblNombreAyB";
            this.lblNombreAyB.Size = new System.Drawing.Size(28, 18);
            this.lblNombreAyB.TabIndex = 9;
            this.lblNombreAyB.Text = ".....";
            // 
            // btnCancelarAyB
            // 
            this.btnCancelarAyB.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancelarAyB.FlatAppearance.BorderSize = 0;
            this.btnCancelarAyB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarAyB.ForeColor = System.Drawing.Color.White;
            this.btnCancelarAyB.Location = new System.Drawing.Point(131, 103);
            this.btnCancelarAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarAyB.Name = "btnCancelarAyB";
            this.btnCancelarAyB.Size = new System.Drawing.Size(85, 25);
            this.btnCancelarAyB.TabIndex = 8;
            this.btnCancelarAyB.Text = "Cancelar";
            this.btnCancelarAyB.UseVisualStyleBackColor = false;
            this.btnCancelarAyB.Click += new System.EventHandler(this.btnCancelarAyB_Click);
            // 
            // btnGuardarAyB
            // 
            this.btnGuardarAyB.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarAyB.FlatAppearance.BorderSize = 0;
            this.btnGuardarAyB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAyB.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAyB.Location = new System.Drawing.Point(42, 103);
            this.btnGuardarAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarAyB.Name = "btnGuardarAyB";
            this.btnGuardarAyB.Size = new System.Drawing.Size(75, 25);
            this.btnGuardarAyB.TabIndex = 4;
            this.btnGuardarAyB.Text = "Guardar";
            this.btnGuardarAyB.UseVisualStyleBackColor = false;
            this.btnGuardarAyB.Click += new System.EventHandler(this.btnGuardarAyB_Click);
            // 
            // txtPrecioAyB
            // 
            this.txtPrecioAyB.BackColor = System.Drawing.Color.LightBlue;
            this.txtPrecioAyB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecioAyB.Location = new System.Drawing.Point(82, 44);
            this.txtPrecioAyB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioAyB.Multiline = true;
            this.txtPrecioAyB.Name = "txtPrecioAyB";
            this.txtPrecioAyB.Size = new System.Drawing.Size(135, 25);
            this.txtPrecioAyB.TabIndex = 7;
            this.txtPrecioAyB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioAyB_KeyPress);
            // 
            // lblPrecioAyB
            // 
            this.lblPrecioAyB.AutoSize = true;
            this.lblPrecioAyB.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrecioAyB.Location = new System.Drawing.Point(15, 46);
            this.lblPrecioAyB.Name = "lblPrecioAyB";
            this.lblPrecioAyB.Size = new System.Drawing.Size(54, 18);
            this.lblPrecioAyB.TabIndex = 6;
            this.lblPrecioAyB.Text = "Precio";
            // 
            // lblNombreAyBText
            // 
            this.lblNombreAyBText.AutoSize = true;
            this.lblNombreAyBText.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNombreAyBText.Location = new System.Drawing.Point(14, 14);
            this.lblNombreAyBText.Name = "lblNombreAyBText";
            this.lblNombreAyBText.Size = new System.Drawing.Size(64, 18);
            this.lblNombreAyBText.TabIndex = 4;
            this.lblNombreAyBText.Text = "Nombre";
            // 
            // PrecioServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PrecioServicios";
            this.Text = "PrecioServicios";
            this.Load += new System.EventHandler(this.PrecioServicios_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNeumatico.ResumeLayout(false);
            this.tabNeumatico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeumatico)).EndInit();
            this.pDatosNeumatico.ResumeLayout(false);
            this.pDatosNeumatico.PerformLayout();
            this.tabLavadero.ResumeLayout(false);
            this.tabLavadero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavado)).EndInit();
            this.pDatosLavado.ResumeLayout(false);
            this.pDatosLavado.PerformLayout();
            this.tabAyB.ResumeLayout(false);
            this.tabAyB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.pDatosAyB.ResumeLayout(false);
            this.pDatosAyB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabNeumatico;
        private TabPage tabLavadero;
        private TabPage tabAyB;
        private Panel pDatosLavado;
        private Button btnCancelarLavado;
        private Button btnGuardarLavado;
        private TextBox txtPrecioLavado;
        private Label lblPracioLavado;
        private Label lblNombre;
        private Button btnBuscarLavado;
        private TextBox txtLavado;
        private Label lblLavado;
        private Button btnBuscarAyB;
        private TextBox txtAyB;
        private Label lblAyB;
        private Panel pDatosAyB;
        private Button btnCancelarAyB;
        private Button btnGuardarAyB;
        private TextBox txtPrecioAyB;
        private Label lblPrecioAyB;
        private Label lblNombreAyBText;
        private Panel pDatosNeumatico;
        private Button btnCancelarNeumatico;
        private Button btnGuardarNeumatico;
        private TextBox txtPrecio;
        private Label lblPrecioNeumatico;
        private Label lblModelo;
        private Button btnBuscarNeumatico;
        private TextBox txtNeumatico;
        private Label lblNeumatico;
        private ComboBox cbModelo;
        private Button btnEliminar;
        private Label lblNombreLavado;
        private Label lblNombreAyB;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtStock;
        private Label label3;
        private DataGridView dgvNeumatico;
        private DataGridView dgvLavado;
        private DataGridView dgvServicio;
    }
}