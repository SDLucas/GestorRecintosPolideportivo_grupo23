using System.Windows.Forms;

namespace Vistas
{
    partial class Menu_Experimental
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private void FormatoMenu()
        {
            this.Text = "Menú Principal";
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(20);
            panel.WrapContents = true;
            panel.AutoScroll = true;

            Button[] botones = {
        CrearBoton("Agregar Cliente", "Agregar_Cliente", btnAgregarCliente_Click),
        CrearBoton("Listar Clientes", "Listar_Clientes", btnListarClientes_Click),
        CrearBoton("Agregar Recinto", "Agregar_Recinto", btnAgregarRecinto_Click),
        CrearBoton("Listar Recintos", "Listar_Recintos", btnListarRecintos_Click),
        CrearBoton("Agregar Reserva", "Agregar_Reserva", btnAgregarReserva_Click),
        CrearBoton("Listar Reservas", "Listar_Reservas", btnListarReservas_Click),
        CrearBoton("Listar Pagos", "Listar_Pagos", btnListarPagos_Click),
    };

            foreach (var b in botones)
                panel.Controls.Add(b);

            this.Controls.Add(panel);
        }
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Menu_Principal";
        }

        #endregion
    }
}