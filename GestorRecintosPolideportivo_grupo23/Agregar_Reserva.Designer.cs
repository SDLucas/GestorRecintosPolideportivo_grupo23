using System.Windows.Forms;
using System;

namespace GestorRecintosPolideportivo_grupo23
{
    partial class Agregar_Reserva
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
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbRecinto = new System.Windows.Forms.ComboBox();
            this.cbHora = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblRecinto = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(12, 25);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(260, 21);
            this.cbCliente.TabIndex = 0;
            // 
            // cbRecinto
            // 
            this.cbRecinto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecinto.FormattingEnabled = true;
            this.cbRecinto.Location = new System.Drawing.Point(12, 69);
            this.cbRecinto.Name = "cbRecinto";
            this.cbRecinto.Size = new System.Drawing.Size(260, 21);
            this.cbRecinto.TabIndex = 1;
            this.cbRecinto.SelectedValueChanged += new System.EventHandler(this.cbRecinto_SelectedValueChanged);
            // 
            // cbHora
            // 
            this.cbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHora.FormattingEnabled = true;
            this.cbHora.Location = new System.Drawing.Point(12, 160);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(73, 21);
            this.cbHora.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(197, 226);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.reservar);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(12, 113);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblRecinto
            // 
            this.lblRecinto.AutoSize = true;
            this.lblRecinto.Location = new System.Drawing.Point(12, 53);
            this.lblRecinto.Name = "lblRecinto";
            this.lblRecinto.Size = new System.Drawing.Size(47, 13);
            this.lblRecinto.TabIndex = 6;
            this.lblRecinto.Text = "Recinto:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 97);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(12, 144);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(44, 13);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "Horario:";
            // 
            // Agregar_Reserva
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblRecinto);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cbHora);
            this.Controls.Add(this.cbRecinto);
            this.Controls.Add(this.cbCliente);
            this.Name = "Agregar_Reserva";
            this.Text = "Agregar Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private ComboBox cbCliente;
        private ComboBox cbRecinto;
        private ComboBox cbHora;
        private Button btnAgregar;
        private DateTimePicker dtpFecha;
        private Label lblCliente;
        private Label lblRecinto;
        private Label lblFecha;
        private Label lblHora;
    }
}