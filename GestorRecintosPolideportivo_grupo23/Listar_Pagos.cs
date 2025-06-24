using Controladores;
using Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Listar_Pagos : Form
    {
        Pago_Controlador pagoControlador = new Pago_Controlador();

        public Listar_Pagos()
        {
            InitializeComponent();
            formatoMenu();
            CargarPagos();
            dataGridViewPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void CargarPagos()
        {
            var lista = pagoControlador.listar_pagos();
            dataGridViewPagos.DataSource = lista;

            dataGridViewPagos.Columns["id_pago"].HeaderText = "ID Pago";
            dataGridViewPagos.Columns["id_reserva"].HeaderText = "Reserva";
            dataGridViewPagos.Columns["nombre_medio"].HeaderText = "Medio de pago";
            dataGridViewPagos.Columns["UsuarioCompleto"].HeaderText = "Usuario";
            dataGridViewPagos.Columns["ClienteCompleto"].HeaderText = "Cliente";
            dataGridViewPagos.Columns["monto_pago"].HeaderText = "Monto";
            dataGridViewPagos.Columns["fecha_pago"].HeaderText = "Fecha";

            dataGridViewPagos.Columns["apellido_usuario"].Visible = false;
            dataGridViewPagos.Columns["nombre_usuario"].Visible = false;
            dataGridViewPagos.Columns["nombre_cliente"].Visible = false;
            dataGridViewPagos.Columns["apellido_cliente"].Visible = false;

            /*foreach (DataGridViewColumn col in dataGridViewPagos.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }*/ // Ajustar el ancho de las columnas automáticamente, funciona defectuosamente al utilizar
            //la propiedad fill, por eso lo dejo comentado
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
