using System;
using System.Windows.Forms;
using Controladores;
using Modelos;

namespace Vistas
{
    public partial class Modificar_Cliente : Form
    {
        private Cliente clienteOriginal;
        private Cliente_Controlador controlador = new Cliente_Controlador();

        public Modificar_Cliente(Cliente cliente)
        {
            InitializeComponent();
            clienteOriginal = cliente;
            CargarDatosEnFormulario();
        }

        private void CargarDatosEnFormulario()
        {
            txtDNI.Text = clienteOriginal.dni_cliente.ToString();
            txtNombre.Text = clienteOriginal.nombre_cliente;
            txtApellido.Text = clienteOriginal.apellido_cliente;
            txtTelefono.Text = clienteOriginal.telefono_cliente;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDNI.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente clienteModificado = new Cliente
            {
                id_cliente = clienteOriginal.id_cliente,
                dni_cliente = dni,
                nombre_cliente = txtNombre.Text.Trim(),
                apellido_cliente = txtApellido.Text.Trim(),
                telefono_cliente = txtTelefono.Text.Trim()
            };

            int resultado = controlador.modificar_cliente(clienteModificado);

            if (resultado > 0)
            {
                MessageBox.Show("Cliente modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}