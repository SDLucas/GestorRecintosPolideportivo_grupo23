namespace GestorRecintosPolideportivo_grupo23
{
    partial class Modificar_Recinto
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.ComboBox cbTipoRecinto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblTipo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.cbTipoRecinto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(12, 25);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(256, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // txtTarifa
            // 
            this.txtTarifa.Location = new System.Drawing.Point(12, 68);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(256, 20);
            this.txtTarifa.TabIndex = 1;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(12, 111);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(256, 20);
            this.txtUbicacion.TabIndex = 2;
            // 
            // cbTipoRecinto
            // 
            this.cbTipoRecinto.FormattingEnabled = true;
            this.cbTipoRecinto.Location = new System.Drawing.Point(12, 154);
            this.cbTipoRecinto.Name = "cbTipoRecinto";
            this.cbTipoRecinto.Size = new System.Drawing.Size(256, 21);
            this.cbTipoRecinto.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(99, 198);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 38);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 9);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(94, 13);
            this.lblNumero.TabIndex = 5;
            this.lblNumero.Text = "Número de recinto";
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(12, 52);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(76, 13);
            this.lblTarifa.TabIndex = 6;
            this.lblTarifa.Text = "Tarifa por hora";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(12, 95);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(55, 13);
            this.lblUbicacion.TabIndex = 7;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 138);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(78, 13);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "Tipo de recinto";
            // 
            // Modificar_Recinto
            // 
            this.ClientSize = new System.Drawing.Size(282, 257);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbTipoRecinto);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.txtNumero);
            this.Name = "Modificar_Recinto";
            this.Text = "Modificar Recinto";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
