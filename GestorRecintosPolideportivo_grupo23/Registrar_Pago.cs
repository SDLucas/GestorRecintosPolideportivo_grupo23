using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controladores;
using Modelos;

namespace WindowsFormsApp1
{
    public partial class Registrar_Pago : Form
    {
        private readonly int id_reserva;
        private readonly float monto;
        private readonly Pago_Controlador pagoControlador = new Pago_Controlador();
        private readonly Reserva reserva;

        public Registrar_Pago(Reserva reserva)
        {
            InitializeComponent();
            this.Text = "Cobrar Reserva";
            this.id_reserva = reserva.id_reserva;
            this.monto = reserva.monto_reserva;
            this.reserva = reserva;

            lblReserva.Text = $"ID Reserva: {id_reserva}";
            lblMonto.Text = $"Monto: ${monto}";
            CargarMediosPago();
        }

        private void CargarMediosPago()
        {
            var medios = new Medio_Pago_Controlador().listar_medios_pago();
            cbMedioPago.DataSource = medios;
            cbMedioPago.DisplayMember = "nombre_medio";
            cbMedioPago.ValueMember = "id_medio";
            cbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (cbMedioPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un medio de pago.");
                return;
            }

            int id_usuario = Sesion.UsuarioActual.id_Usuario;
            int id_medio = (int)cbMedioPago.SelectedValue;

            int resultado = pagoControlador.registrar_pago(id_reserva, id_usuario, id_medio, monto);

            if (resultado > 0)
            {
                MessageBox.Show("Pago registrado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el pago.");
            }
        }

        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            pagoControlador.registrar_pago(id_reserva,Sesion.UsuarioActual.id_Usuario,((Medio_Pago)(cbMedioPago.SelectedItem)).id_medio,monto);
            this.Hide();
        }
    }
}
