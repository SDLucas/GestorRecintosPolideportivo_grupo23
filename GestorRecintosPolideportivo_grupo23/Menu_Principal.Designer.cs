namespace GestorRecintosPolideportivo_grupo23
{
    partial class Menu_Principal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelRecintos;
        private System.Windows.Forms.Panel panelReservas;
        private System.Windows.Forms.Button btnListarRecintos;
        private System.Windows.Forms.Button btnAgregarRecinto;
        private System.Windows.Forms.Button btnProgramarReserva;
        private System.Windows.Forms.Button btnListarReservas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioLogueado;
        private System.Windows.Forms.Button btnCerrarSesion;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Principal));
            this.panelRecintos = new System.Windows.Forms.Panel();
            this.btnListarRecintos = new System.Windows.Forms.Button();
            this.btnAgregarRecinto = new System.Windows.Forms.Button();
            this.panelReservas = new System.Windows.Forms.Panel();
            this.btnProgramarReserva = new System.Windows.Forms.Button();
            this.btnListarReservas = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioLogueado = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.btnBaja = new System.Windows.Forms.Button();
            this.panelRecintos.SuspendLayout();
            this.panelReservas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRecintos
            // 
            this.panelRecintos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRecintos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecintos.Controls.Add(this.btnListarRecintos);
            this.panelRecintos.Controls.Add(this.btnAgregarRecinto);
            this.panelRecintos.Location = new System.Drawing.Point(160, 107);
            this.panelRecintos.Name = "panelRecintos";
            this.panelRecintos.Size = new System.Drawing.Size(250, 100);
            this.panelRecintos.TabIndex = 0;
            // 
            // btnListarRecintos
            // 
            this.btnListarRecintos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnListarRecintos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarRecintos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnListarRecintos.ForeColor = System.Drawing.Color.White;
            this.btnListarRecintos.Location = new System.Drawing.Point(130, 15);
            this.btnListarRecintos.Name = "btnListarRecintos";
            this.btnListarRecintos.Size = new System.Drawing.Size(100, 70);
            this.btnListarRecintos.TabIndex = 1;
            this.btnListarRecintos.Text = "Listar Recintos";
            this.btnListarRecintos.UseVisualStyleBackColor = false;
            this.btnListarRecintos.Click += new System.EventHandler(this.btnListarRecintos_Click);
            // 
            // btnAgregarRecinto
            // 
            this.btnAgregarRecinto.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAgregarRecinto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRecinto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarRecinto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRecinto.Location = new System.Drawing.Point(15, 15);
            this.btnAgregarRecinto.Name = "btnAgregarRecinto";
            this.btnAgregarRecinto.Size = new System.Drawing.Size(100, 70);
            this.btnAgregarRecinto.TabIndex = 0;
            this.btnAgregarRecinto.Text = "Agregar Recinto";
            this.btnAgregarRecinto.UseVisualStyleBackColor = false;
            this.btnAgregarRecinto.Click += new System.EventHandler(this.btnAgregarRecinto_Click);
            // 
            // panelReservas
            // 
            this.panelReservas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelReservas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReservas.Controls.Add(this.btnProgramarReserva);
            this.panelReservas.Controls.Add(this.btnListarReservas);
            this.panelReservas.Location = new System.Drawing.Point(160, 248);
            this.panelReservas.Name = "panelReservas";
            this.panelReservas.Size = new System.Drawing.Size(250, 100);
            this.panelReservas.TabIndex = 1;
            // 
            // btnProgramarReserva
            // 
            this.btnProgramarReserva.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnProgramarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgramarReserva.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProgramarReserva.ForeColor = System.Drawing.Color.White;
            this.btnProgramarReserva.Location = new System.Drawing.Point(15, 15);
            this.btnProgramarReserva.Name = "btnProgramarReserva";
            this.btnProgramarReserva.Size = new System.Drawing.Size(100, 70);
            this.btnProgramarReserva.TabIndex = 2;
            this.btnProgramarReserva.Text = "Programar Reserva";
            this.btnProgramarReserva.UseVisualStyleBackColor = false;
            this.btnProgramarReserva.Click += new System.EventHandler(this.btnProgramarReserva_Click);
            // 
            // btnListarReservas
            // 
            this.btnListarReservas.BackColor = System.Drawing.Color.SteelBlue;
            this.btnListarReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarReservas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnListarReservas.ForeColor = System.Drawing.Color.White;
            this.btnListarReservas.Location = new System.Drawing.Point(130, 15);
            this.btnListarReservas.Name = "btnListarReservas";
            this.btnListarReservas.Size = new System.Drawing.Size(100, 70);
            this.btnListarReservas.TabIndex = 3;
            this.btnListarReservas.Text = "Listar Reservas";
            this.btnListarReservas.UseVisualStyleBackColor = false;
            this.btnListarReservas.Click += new System.EventHandler(this.btnListarReservas_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitulo.Location = new System.Drawing.Point(0, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(854, 40);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Menú Principal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsuarioLogueado.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(650, 10);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(200, 20);
            this.lblUsuarioLogueado.TabIndex = 3;
            this.lblUsuarioLogueado.Text = "Usuario: ";
            this.lblUsuarioLogueado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 404);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(90, 34);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(455, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 100);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(15, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 70);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar Cliente";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(130, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 70);
            this.button2.TabIndex = 3;
            this.button2.Text = "Listar Clientes";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(455, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 100);
            this.panel2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(15, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 70);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cobrar Reserva";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(130, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 70);
            this.button4.TabIndex = 3;
            this.button4.Text = "Listar Pagos";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipoUsuario.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTipoUsuario.Location = new System.Drawing.Point(8, 10);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblTipoUsuario.TabIndex = 5;
            this.lblTipoUsuario.Text = "Recepcionista";
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.Firebrick;
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaja.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnBaja.ForeColor = System.Drawing.Color.White;
            this.btnBaja.Location = new System.Drawing.Point(118, 404);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(90, 34);
            this.btnBaja.TabIndex = 6;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.lblTipoUsuario);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUsuarioLogueado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelReservas);
            this.Controls.Add(this.panelRecintos);
            this.Controls.Add(this.btnCerrarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_Principal_FormClosing);
            this.panelRecintos.ResumeLayout(false);
            this.panelReservas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Button btnBaja;
    }
}
