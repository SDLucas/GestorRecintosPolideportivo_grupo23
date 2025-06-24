using Controladores;
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
using WindowsFormsApp1;

namespace GestorRecintosPolideportivo_grupo23
{
    public partial class Menu_Principal : Form
    {
        public Agregar_Recinto agregar_recintos;
        public Listar_Recintos listar_recintos;
        public Agregar_Cliente agregar_cliente;
        public Listar_Clientes listar_clientes;
        public Agregar_Reserva agregar_reserva;
        public Listar_Pagos listar_pagos;
        public Listar_Reservas listar_reservas;

        public Usuario_Controlador usuario_Controlador;
        
        private Usuario usuarioActual;

        public Menu_Principal(Usuario usuarioLogueado)
        {
            InitializeComponent();
            usuarioActual = usuarioLogueado;
            usuario_Controlador = new Usuario_Controlador();
            lblUsuarioLogueado.Text = $"Bienvenido, {usuarioActual.nombre_usuario} {usuarioActual.apellido_usuario}";
            if (usuarioActual.id_tipo == 1)
            {
                lblTipoUsuario.Text = "Administrador";
            }
        }

        private void btnAgregarRecinto_Click(object sender, EventArgs e)
        {
            agregar_recintos = new Agregar_Recinto();
            agregar_recintos.Show();
        }

        private void btnListarRecintos_Click(object sender, EventArgs e)
        {
            listar_recintos = new Listar_Recintos();
            listar_recintos.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            cerrarSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar_cliente = new Agregar_Cliente();
            agregar_cliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listar_clientes = new Listar_Clientes();
            listar_clientes.Show();
        }

        private void btnProgramarReserva_Click(object sender, EventArgs e)
        {
            agregar_reserva = new Agregar_Reserva();
            agregar_reserva.Show();
        }

        private void btnListarReservas_Click(object sender, EventArgs e)
        {
            listar_reservas = new Listar_Reservas();
            listar_reservas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listar_pagos = new Listar_Pagos();
            listar_pagos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
        "Ingrese el ID de la reserva que desea cobrar:", "Cobrar Reserva");

            if (int.TryParse(input, out int idReserva))
            {
                Reserva_Controlador controlador = new Reserva_Controlador();
                var reserva = controlador.obtener_reserva_por_id(idReserva);

                if (reserva == null)
                {
                    MessageBox.Show("No se encontró la reserva indicada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (reserva.pagado)
                {
                    MessageBox.Show("La reserva ya se encuentra pagada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                new Registrar_Pago(reserva).ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe ingresar un número de reserva válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cerrarSesion()
        {
            this.Hide();
            //Se instancia y se muestra el formulario de login
            Login loginForm = new Login();
            loginForm.Show();
            //Se elimina el usuario almacenado en la variable global
            Sesion.UsuarioActual = null;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            string inputPass = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su contraseña para confirmar la baja:", "Confirmar baja");
            var usuarioVerificado = usuario_Controlador.verificar_datos(Sesion.UsuarioActual.dni_usuario, inputPass);
            if (string.IsNullOrEmpty(inputPass) || usuarioVerificado==null)
            {
                MessageBox.Show("Contraseña incorrecta.");
                return;
            }else
            {
                usuario_Controlador.dar_baja_usuario(Sesion.UsuarioActual.id_usuario);
                cerrarSesion();
            }
        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
