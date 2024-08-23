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
            pAuto = new Panel();
            lblCantAutos = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            lblCantUtilitarios = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            lblCantMotos = new Label();
            pictureBox3 = new PictureBox();
            label7 = new Label();
            panel4 = new Panel();
            lblCantCamionetas = new Label();
            label9 = new Label();
            pictureBox4 = new PictureBox();
            panel5 = new Panel();
            lblCantCamiones = new Label();
            pictureBox5 = new PictureBox();
            label11 = new Label();
            panel6 = new Panel();
            lblCantTotal = new Label();
            pictureBox6 = new PictureBox();
            label13 = new Label();
            label1 = new Label();
            pAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pAuto
            // 
            pAuto.BackColor = Color.SkyBlue;
            pAuto.Controls.Add(lblCantAutos);
            pAuto.Controls.Add(label2);
            pAuto.Controls.Add(pictureBox1);
            pAuto.Location = new Point(168, 86);
            pAuto.Margin = new Padding(3, 2, 3, 2);
            pAuto.Name = "pAuto";
            pAuto.Size = new Size(262, 112);
            pAuto.TabIndex = 0;
            // 
            // lblCantAutos
            // 
            lblCantAutos.AutoSize = true;
            lblCantAutos.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantAutos.Location = new Point(141, 58);
            lblCantAutos.Name = "lblCantAutos";
            lblCantAutos.Size = new Size(36, 25);
            lblCantAutos.TabIndex = 2;
            lblCantAutos.Text = "20";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(123, 26);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 1;
            label2.Text = "Autos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.auto;
            pictureBox1.Location = new Point(20, 34);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Controls.Add(lblCantUtilitarios);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(168, 224);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 112);
            panel2.TabIndex = 1;
            // 
            // lblCantUtilitarios
            // 
            lblCantUtilitarios.AutoSize = true;
            lblCantUtilitarios.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantUtilitarios.Location = new Point(141, 58);
            lblCantUtilitarios.Name = "lblCantUtilitarios";
            lblCantUtilitarios.Size = new Size(36, 25);
            lblCantUtilitarios.TabIndex = 5;
            lblCantUtilitarios.Text = "10";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(104, 26);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 4;
            label5.Text = "Utilitarios";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.utilitario;
            pictureBox2.Location = new Point(20, 34);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(56, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SkyBlue;
            panel3.Controls.Add(lblCantMotos);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(168, 364);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(262, 112);
            panel3.TabIndex = 1;
            // 
            // lblCantMotos
            // 
            lblCantMotos.AutoSize = true;
            lblCantMotos.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantMotos.Location = new Point(141, 62);
            lblCantMotos.Name = "lblCantMotos";
            lblCantMotos.Size = new Size(36, 25);
            lblCantMotos.TabIndex = 8;
            lblCantMotos.Text = "10";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.moto;
            pictureBox3.Location = new Point(20, 38);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(56, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(120, 31);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 7;
            label7.Text = "Motos";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SkyBlue;
            panel4.Controls.Add(lblCantCamionetas);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(528, 86);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(262, 112);
            panel4.TabIndex = 1;
            // 
            // lblCantCamionetas
            // 
            lblCantCamionetas.AutoSize = true;
            lblCantCamionetas.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantCamionetas.Location = new Point(143, 58);
            lblCantCamionetas.Name = "lblCantCamionetas";
            lblCantCamionetas.Size = new Size(36, 25);
            lblCantCamionetas.TabIndex = 11;
            lblCantCamionetas.Text = "10";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(100, 26);
            label9.Name = "label9";
            label9.Size = new Size(128, 25);
            label9.TabIndex = 10;
            label9.Text = "Camionetas";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.camioneta;
            pictureBox4.Location = new Point(19, 34);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(56, 48);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.SkyBlue;
            panel5.Controls.Add(lblCantCamiones);
            panel5.Controls.Add(pictureBox5);
            panel5.Controls.Add(label11);
            panel5.Location = new Point(528, 224);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(262, 112);
            panel5.TabIndex = 1;
            // 
            // lblCantCamiones
            // 
            lblCantCamiones.AutoSize = true;
            lblCantCamiones.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantCamiones.Location = new Point(143, 58);
            lblCantCamiones.Name = "lblCantCamiones";
            lblCantCamiones.Size = new Size(36, 25);
            lblCantCamiones.TabIndex = 14;
            lblCantCamiones.Text = "10";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.camion;
            pictureBox5.Location = new Point(19, 34);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(56, 48);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 12;
            pictureBox5.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(108, 26);
            label11.Name = "label11";
            label11.Size = new Size(110, 25);
            label11.TabIndex = 13;
            label11.Text = "Camiones";
            // 
            // panel6
            // 
            panel6.BackColor = Color.SkyBlue;
            panel6.Controls.Add(lblCantTotal);
            panel6.Controls.Add(pictureBox6);
            panel6.Controls.Add(label13);
            panel6.Location = new Point(528, 364);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(262, 112);
            panel6.TabIndex = 1;
            // 
            // lblCantTotal
            // 
            lblCantTotal.AutoSize = true;
            lblCantTotal.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantTotal.Location = new Point(143, 62);
            lblCantTotal.Name = "lblCantTotal";
            lblCantTotal.Size = new Size(36, 25);
            lblCantTotal.TabIndex = 17;
            lblCantTotal.Text = "60";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.total;
            pictureBox6.Location = new Point(19, 38);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(56, 48);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(130, 31);
            label13.Name = "label13";
            label13.Size = new Size(59, 25);
            label13.TabIndex = 16;
            label13.Text = "Total";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(296, 26);
            label1.Name = "label1";
            label1.Size = new Size(335, 43);
            label1.TabIndex = 2;
            label1.Text = "Vehiculos Actuales";
            // 
            // MenuInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(954, 518);
            Controls.Add(label1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pAuto);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MenuInicial";
            Text = "MenuInicial";
            pAuto.ResumeLayout(false);
            pAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
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