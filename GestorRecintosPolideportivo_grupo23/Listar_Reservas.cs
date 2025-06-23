using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controladores;
using Modelos;

namespace WindowsFormsApp1
{
    public partial class Listar_Reservas : Form
    {
        Reserva_Controlador reservaControlador = new Reserva_Controlador();

        public Listar_Reservas()
        {
            InitializeComponent();
            CargarReservas();
            this.dataGridViewReservas.CellContentClick += dataGridViewReservas_CellContentClick;
            dataGridViewReservas.DataError += dataGridViewReservas_DataError;

        }
        private void dataGridViewReservas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Cancelamos la excepción para evitar el cuadro de error
            e.Cancel = true;
        }
    


        private void CargarReservas()
        {
            dataGridViewReservas.Columns.Clear();

            List<Reserva> reservas = reservaControlador.listar_reservas();
            dataGridViewReservas.DataSource = reservas;

            // Encabezados de columnas
            dataGridViewReservas.Columns["id_reserva"].HeaderText = "ID";
            dataGridViewReservas.Columns["fecha_reserva"].HeaderText = "Fecha";
            dataGridViewReservas.Columns["hora_reserva"].HeaderText = "Hora";
            dataGridViewReservas.Columns["nombre_cliente"].HeaderText = "Nombre Cliente";
            dataGridViewReservas.Columns["apellido_cliente"].HeaderText = "Apellido Cliente";
            dataGridViewReservas.Columns["nombre_usuario"].HeaderText = "Nombre Usuario";
            dataGridViewReservas.Columns["apellido_usuario"].HeaderText = "Apellido Usuario";
            dataGridViewReservas.Columns["nro_recinto"].HeaderText = "Nro Recinto";
            dataGridViewReservas.Columns["PagadoTexto"].HeaderText = "¿Pagado?";
            dataGridViewReservas.Columns["monto_reserva"].HeaderText = "Monto";
            dataGridViewReservas.Columns["EstadoTexto"].HeaderText = "Estado";
            // Ocultar las columnas bool ya que utilizamos las propiedades tipo String del modelo
            dataGridViewReservas.Columns["pagado"].Visible = false;
            dataGridViewReservas.Columns["estado"].Visible = false;



            // Eliminar columnas si ya existen
            if (dataGridViewReservas.Columns.Contains("Modificar"))
                dataGridViewReservas.Columns.Remove("Modificar");
            if (dataGridViewReservas.Columns.Contains("Cancelar"))
                dataGridViewReservas.Columns.Remove("Cancelar");


            // Botón Modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "Modificar";
            btnModificar.HeaderText = "";
            btnModificar.Text = "Modificar";
            btnModificar.UseColumnTextForButtonValue = true;
            dataGridViewReservas.Columns.Add(btnModificar);

            // Botón Cancelar
            DataGridViewButtonColumn btnCancelar = new DataGridViewButtonColumn();
            btnCancelar.Name = "Cancelar";
            btnCancelar.HeaderText = "";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseColumnTextForButtonValue = true;
            dataGridViewReservas.Columns.Add(btnCancelar);

            //boton de cobrar
            if (!dataGridViewReservas.Columns.Contains("Cobrar"))
            {
                DataGridViewButtonColumn btnCobrar = new DataGridViewButtonColumn();
                btnCobrar.Name = "Cobrar";
                btnCobrar.HeaderText = "";
                btnCobrar.Text = "Cobrar";
                btnCobrar.UseColumnTextForButtonValue = true;
                dataGridViewReservas.Columns.Add(btnCobrar);
            }

            // Autoajustar columnas
            foreach (DataGridViewColumn col in dataGridViewReservas.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


        }

        private void dataGridViewReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dataGridViewReservas.Columns[e.ColumnIndex].Name;
            int id_reserva = Convert.ToInt32(dataGridViewReservas.Rows[e.RowIndex].Cells["id_reserva"].Value);

            if (columna == "Modificar")
            {
                Modificar_Reserva form = new Modificar_Reserva(id_reserva);
                form.ShowDialog();
                CargarReservas();
            }
            else if (columna == "Cancelar")
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea cancelar esta reserva?", "Confirmar", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    Reserva_Controlador rc = new Reserva_Controlador();
                    rc.cancelar_reserva(id_reserva);
                    MessageBox.Show("Reserva cancelada.");
                    CargarReservas();
                }
            }else if (columna == "Cobrar")
            {
                var reserva = (Reserva)dataGridViewReservas.Rows[e.RowIndex].DataBoundItem;

                if (reserva.pagado)
                {
                    MessageBox.Show("Esta reserva ya fue pagada.", "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new Registrar_Pago(reserva).ShowDialog();
                CargarReservas(); // refrescar la grilla después del pago
            }

        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
