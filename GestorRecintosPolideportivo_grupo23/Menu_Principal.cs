using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorRecintosPolideportivo_grupo23
{
    public partial class Menu_Principal : Form
    {
        public Agregar_Recinto formulario_agregar;
        public Listar_Recintos formulario_listar;
        private Usuario usuarioActual;

        public Menu_Principal(Usuario usuarioLogueado)
        {
            InitializeComponent();
            usuarioActual = usuarioLogueado;
            lblUsuarioLogueado.Text = $"Bienvenido, {usuarioActual.Nombre_Usuario} {usuarioActual.Apellido_Usuario}";
            if (usuarioActual.Id_Tipo == 1)
            {
                lblTipoUsuario.Text = "Administrador";
            }
        }

        private void btnAgregarRecinto_Click(object sender, EventArgs e)
        {
            formulario_agregar = new Agregar_Recinto();
            formulario_agregar.Show();
        }

        private void btnListarRecintos_Click(object sender, EventArgs e)
        {
            formulario_listar = new Listar_Recintos();
            formulario_listar.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
