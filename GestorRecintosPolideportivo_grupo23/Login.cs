using Controladores;
using Modelos;
using System;
using System.Windows.Forms;

namespace GestorRecintosPolideportivo_grupo23
{
    public partial class Login : Form
    {
        private Usuario_Controlador usuario_controlador;

        public Login()
        {
            InitializeComponent();
            usuario_controlador = new Usuario_Controlador();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDNI.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = txtPassword.Text;

            Usuario usuario = usuario_controlador.ValidarLogin(dni, password);

            if (usuario != null)
            {
                MessageBox.Show($"¡Bienvenido {usuario.Nombre_Usuario}!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                // Abrís tu menú principal o pantalla inicial
                Menu_Principal menuPrincipal = new Menu_Principal(usuario);
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("DNI o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
