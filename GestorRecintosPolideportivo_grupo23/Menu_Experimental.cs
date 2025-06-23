using GestorRecintosPolideportivo_grupo23;
using Modelos;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Vistas
{
    public partial class Menu_Experimental : Form
    {
        Usuario usuarioActual;
        public Menu_Experimental(Usuario usuarioLogueado)
        {
            InitializeComponent();
            FormatoMenu();
            usuarioActual = usuarioLogueado;
            /*lblUsuarioLogueado.Text = $"Bienvenido, {usuarioActual.Nombre_Usuario} {usuarioActual.Apellido_Usuario}";
            if (usuarioActual.Id_Tipo == 1)
            {
                lblTipoUsuario.Text = "Administrador";
            }*/
        }

        private Button CrearBoton(string texto, string iconoKey, EventHandler accion)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.Size = new Size(150, 130);
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Margin = new Padding(15);

            // Puedes cargar un ícono real desde archivo o resources
            try
            {
                btn.Image = Image.FromFile($"Resources\\{iconoKey}.png"); // Asegúrate de tener los íconos
            }
            catch
            {
                // Ícono genérico si no existe
                btn.Image = SystemIcons.Information.ToBitmap();
            }

            btn.Click += accion;
            return btn;
        }


        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            new Agregar_Cliente().ShowDialog();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            new Listar_Clientes().ShowDialog();
        }

        private void btnAgregarRecinto_Click(object sender, EventArgs e)
        {
            new Agregar_Recinto().ShowDialog();
        }

        private void btnListarRecintos_Click(object sender, EventArgs e)
        {
            new Listar_Recintos().ShowDialog();
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            new Agregar_Reserva().ShowDialog();
        }

        private void btnListarReservas_Click(object sender, EventArgs e)
        {
            new Listar_Reservas().ShowDialog();
        }

        private void btnListarPagos_Click(object sender, EventArgs e)
        {
            new Listar_Pagos().ShowDialog();
        }
    }
}
