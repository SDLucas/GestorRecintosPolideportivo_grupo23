using Controladores;
using Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vistas;

namespace WindowsFormsApp1
{
    public partial class Listar_Clientes : Form
    {
        Cliente_Controlador clienteControlador = new Cliente_Controlador();
        private List<Cliente> listaClientes;

        public Listar_Clientes()
        {
            InitializeComponent();
            CargarClientes();

            this.dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
        }

        private void CargarClientes()
        {
            listaClientes = clienteControlador.listar_clientes(); // incluir activos e inactivos
            dataGridViewClientes.Columns.Clear();
            dataGridViewClientes.AutoGenerateColumns = false;

            dataGridViewClientes.DataSource = listaClientes;

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id_cliente",
                HeaderText = "ID",
                Name = "id_cliente"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "dni_cliente",
                HeaderText = "DNI",
                Name = "dni_cliente"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre_cliente",
                HeaderText = "Nombre",
                Name = "nombre_cliente"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "apellido_cliente",
                HeaderText = "Apellido",
                Name = "apellido_cliente"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "telefono_cliente",
                HeaderText = "Teléfono",
                Name = "telefono_cliente"
            });

            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstadoTexto",
                HeaderText = "Estado"
            });

            // Botón Modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn
            {
                Name = "Modificar",
                HeaderText = "",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            };
            dataGridViewClientes.Columns.Add(btnModificar);

            // Botón Alta/Baja lógica
            DataGridViewButtonColumn btnEstado = new DataGridViewButtonColumn
            {
                Name = "Estado",
                HeaderText = "",
                Text = "Cambiar Estado",
                UseColumnTextForButtonValue = false
            };
            dataGridViewClientes.Columns.Add(btnEstado);

            dataGridViewClientes.CellFormatting += DataGridViewClientes_CellFormatting;
        }

        private void DataGridViewClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewClientes.Columns[e.ColumnIndex].Name == "EstadoTexto")
            {
                var cliente = (Cliente)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem;
                e.Value = cliente.estado_cliente ? "Activo" : "Inactivo";
                e.FormattingApplied = true;
            }
            else if (dataGridViewClientes.Columns[e.ColumnIndex].Name == "Estado")
            {
                var cliente = (Cliente)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem;
                e.Value = cliente.estado_cliente ? "Dar de baja" : "Dar de alta";
                e.FormattingApplied = true;
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dataGridViewClientes.Columns[e.ColumnIndex].Name;
            var cliente = (Cliente)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem;

            if (columna == "Modificar")
            {
                Modificar_Cliente form = new Modificar_Cliente(cliente);
                form.ShowDialog();
                CargarClientes(); // refresca la grilla
            }
            else if (columna == "Estado")
            {
                string accion = cliente.estado_cliente ? "dar de baja" : "dar de alta";
                DialogResult r = MessageBox.Show($"¿Está seguro que desea {accion} al cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    if (cliente.estado_cliente)
                    {
                        clienteControlador.DarBajaCliente(cliente.id_cliente);
                    }
                    else
                    {
                        clienteControlador.DarAltaCliente(cliente.id_cliente);
                    }

                    MessageBox.Show("Estado actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                }
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
