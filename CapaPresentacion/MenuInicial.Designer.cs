using ADODB;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapaPresentacion
{
    partial class MenuInicial
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
            this.pAuto = new System.Windows.Forms.Panel();
            this.lblCantAutos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCantUtilitarios = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCantMotos = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCantCamionetas = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCantCamiones = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCantTotal = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pAuto
            // 
            this.pAuto.BackColor = System.Drawing.Color.SkyBlue;
            this.pAuto.Controls.Add(this.lblCantAutos);
            this.pAuto.Controls.Add(this.label2);
            this.pAuto.Controls.Add(this.pictureBox1);
            this.pAuto.Location = new System.Drawing.Point(144, 75);
            this.pAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pAuto.Name = "pAuto";
            this.pAuto.Size = new System.Drawing.Size(225, 97);
            this.pAuto.TabIndex = 0;
            // 
            // lblCantAutos
            // 
            this.lblCantAutos.AutoSize = true;
            this.lblCantAutos.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantAutos.Location = new System.Drawing.Point(121, 50);
            this.lblCantAutos.Name = "lblCantAutos";
            this.lblCantAutos.Size = new System.Drawing.Size(36, 25);
            this.lblCantAutos.TabIndex = 2;
            this.lblCantAutos.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label2.Location = new System.Drawing.Point(105, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Autos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.auto;
            this.pictureBox1.Location = new System.Drawing.Point(17, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblCantUtilitarios);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(144, 194);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 97);
            this.panel2.TabIndex = 1;
            // 
            // lblCantUtilitarios
            // 
            this.lblCantUtilitarios.AutoSize = true;
            this.lblCantUtilitarios.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantUtilitarios.Location = new System.Drawing.Point(121, 50);
            this.lblCantUtilitarios.Name = "lblCantUtilitarios";
            this.lblCantUtilitarios.Size = new System.Drawing.Size(36, 25);
            this.lblCantUtilitarios.TabIndex = 5;
            this.lblCantUtilitarios.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label5.Location = new System.Drawing.Point(89, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Utilitarios";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.utilitario;
            this.pictureBox2.Location = new System.Drawing.Point(17, 29);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.lblCantMotos);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(144, 315);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 97);
            this.panel3.TabIndex = 1;
            // 
            // lblCantMotos
            // 
            this.lblCantMotos.AutoSize = true;
            this.lblCantMotos.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantMotos.Location = new System.Drawing.Point(121, 54);
            this.lblCantMotos.Name = "lblCantMotos";
            this.lblCantMotos.Size = new System.Drawing.Size(36, 25);
            this.lblCantMotos.TabIndex = 8;
            this.lblCantMotos.Text = "10";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.moto;
            this.pictureBox3.Location = new System.Drawing.Point(17, 33);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label7.Location = new System.Drawing.Point(103, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Motos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.lblCantCamionetas);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Location = new System.Drawing.Point(453, 75);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 97);
            this.panel4.TabIndex = 1;
            // 
            // lblCantCamionetas
            // 
            this.lblCantCamionetas.AutoSize = true;
            this.lblCantCamionetas.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantCamionetas.Location = new System.Drawing.Point(123, 50);
            this.lblCantCamionetas.Name = "lblCantCamionetas";
            this.lblCantCamionetas.Size = new System.Drawing.Size(36, 25);
            this.lblCantCamionetas.TabIndex = 11;
            this.lblCantCamionetas.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label9.Location = new System.Drawing.Point(86, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Camionetas";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.camioneta;
            this.pictureBox4.Location = new System.Drawing.Point(16, 29);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SkyBlue;
            this.panel5.Controls.Add(this.lblCantCamiones);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(453, 194);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 97);
            this.panel5.TabIndex = 1;
            // 
            // lblCantCamiones
            // 
            this.lblCantCamiones.AutoSize = true;
            this.lblCantCamiones.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantCamiones.Location = new System.Drawing.Point(123, 50);
            this.lblCantCamiones.Name = "lblCantCamiones";
            this.lblCantCamiones.Size = new System.Drawing.Size(36, 25);
            this.lblCantCamiones.TabIndex = 14;
            this.lblCantCamiones.Text = "10";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CapaPresentacion.Properties.Resources.camion;
            this.pictureBox5.Location = new System.Drawing.Point(16, 29);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label11.Location = new System.Drawing.Point(93, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "Camiones";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SkyBlue;
            this.panel6.Controls.Add(this.lblCantTotal);
            this.panel6.Controls.Add(this.pictureBox6);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Location = new System.Drawing.Point(453, 315);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 97);
            this.panel6.TabIndex = 1;
            // 
            // lblCantTotal
            // 
            this.lblCantTotal.AutoSize = true;
            this.lblCantTotal.Font = new System.Drawing.Font("Arial", 16.2F);
            this.lblCantTotal.Location = new System.Drawing.Point(123, 54);
            this.lblCantTotal.Name = "lblCantTotal";
            this.lblCantTotal.Size = new System.Drawing.Size(36, 25);
            this.lblCantTotal.TabIndex = 17;
            this.lblCantTotal.Text = "60";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CapaPresentacion.Properties.Resources.total;
            this.pictureBox6.Location = new System.Drawing.Point(16, 33);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 42);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 15;
            this.pictureBox6.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 16.2F);
            this.label13.Location = new System.Drawing.Point(111, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "Total";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 28.2F);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(254, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vehiculos Actuales";
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(818, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuInicial";
            this.Text = "MenuInicial";
            this.Load += new System.EventHandler(this.MenuInicial_Load);
            this.pAuto.ResumeLayout(false);
            this.pAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pAuto;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label lblCantAutos;
        private Label lblCantUtilitarios;
        private Label label5;
        private PictureBox pictureBox2;
        private Label lblCantMotos;
        private PictureBox pictureBox3;
        private Label label7;
        private Label lblCantCamionetas;
        private Label label9;
        private PictureBox pictureBox4;
        private Label lblCantCamiones;
        private PictureBox pictureBox5;
        private Label label11;
        private Label lblCantTotal;
        private PictureBox pictureBox6;
        private Label label13;
    }
}