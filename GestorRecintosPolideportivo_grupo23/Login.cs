﻿using Controladores;
using Modelos;
using System;
using System.Windows.Forms;
using Vistas;

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

        private void iniciar_sesion(object sender, EventArgs e)
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

            Usuario usuario = usuario_controlador.verificar_datos(dni, password);
            
            //Se guarda la sesion en una variable global
            Sesion.UsuarioActual = usuario;

            if (usuario != null)
            {
                MessageBox.Show($"¡Bienvenido {usuario.nombre_usuario}!", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
