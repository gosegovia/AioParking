using System.Windows.Forms;

namespace CapaPresentacion.Cajero
{
    partial class ListarFacturas
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
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.cbPaga = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(290, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listar Facturas";
            // 
            // dgvServicios
            // 
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvServicios.Location = new System.Drawing.Point(12, 158);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.RowTemplate.Height = 25;
            this.dgvServicios.Size = new System.Drawing.Size(820, 351);
            this.dgvServicios.TabIndex = 2;
            this.dgvServicios.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DataGridView_Scroll);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(744, 514);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 25);
            this.btnVolver.TabIndex = 24;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnResetear.FlatAppearance.BorderSize = 0;
            this.btnResetear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetear.Font = new System.Drawing.Font("Arial", 12F);
            this.btnResetear.ForeColor = System.Drawing.Color.White;
            this.btnResetear.Location = new System.Drawing.Point(462, 101);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(91, 25);
            this.btnResetear.TabIndex = 32;
            this.btnResetear.Text = "Actualizar";
            this.btnResetear.UseVisualStyleBackColor = false;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(381, 101);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscarCi_Click);
            // 
            // txtCI
            // 
            this.txtCI.BackColor = System.Drawing.Color.LightBlue;
            this.txtCI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCI.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCI.Location = new System.Drawing.Point(239, 101);
            this.txtCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCI.Multiline = true;
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(135, 25);
            this.txtCI.TabIndex = 30;
            this.txtCI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCi_KeyDown);
            this.txtCI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCi_KeyPress);
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCI.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCI.Location = new System.Drawing.Point(213, 105);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(23, 18);
            this.lblCI.TabIndex = 29;
            this.lblCI.Text = "CI";
            // 
            // cbPaga
            // 
            this.cbPaga.AutoSize = true;
            this.cbPaga.Location = new System.Drawing.Point(559, 102);
            this.cbPaga.Name = "cbPaga";
            this.cbPaga.Size = new System.Drawing.Size(130, 22);
            this.cbPaga.TabIndex = 33;
            this.cbPaga.Text = "Mostrar Pagas";
            this.cbPaga.UseVisualStyleBackColor = true;
            this.cbPaga.CheckedChanged += new System.EventHandler(this.cbPaga_CheckedChanged);
            // 
            // ListarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.cbPaga);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCI);
            this.Controls.Add(this.lblCI);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListarFactura";
            this.Text = "ListarCliente";
            this.Load += new System.EventHandler(this.ListarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dgvServicios;
        private Button btnVolver;
        private Button btnResetear;
        private Button btnBuscar;
        private TextBox txtCI;
        private Label lblCI;
        private CheckBox cbPaga;
    }
}