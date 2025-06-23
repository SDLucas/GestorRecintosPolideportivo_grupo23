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

        public Listar_Clientes()
        {
            InitializeComponent();
            CargarClientes();

            this.dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = clienteControlador.listar_clientes();
            dataGridViewClientes.DataSource = clientes;

            dataGridViewClientes.Columns["id_cliente"].Visible = false;
            dataGridViewClientes.Columns["dni_cliente"].HeaderText = "DNI";
            dataGridViewClientes.Columns["nombre_cliente"].HeaderText = "Nombre";
            dataGridViewClientes.Columns["apellido_cliente"].HeaderText = "Apellido";
            dataGridViewClientes.Columns["telefono_cliente"].HeaderText = "Teléfono";

            if (!dataGridViewClientes.Columns.Contains("Modificar"))
            {
                var btnModificar = new DataGridViewButtonColumn
                {
                    Name = "Modificar",
                    HeaderText = "",
                    Text = "Modificar",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewClientes.Columns.Add(btnModificar);
            }


        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dataGridViewClientes.Columns[e.ColumnIndex].Name;
            if (columna == "Modificar")
            {
                var cliente = (Cliente)dataGridViewClientes.Rows[e.RowIndex].DataBoundItem;
                Modificar_Cliente form = new Modificar_Cliente(cliente);
                form.ShowDialog();
                CargarClientes(); // refresca la grilla
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
