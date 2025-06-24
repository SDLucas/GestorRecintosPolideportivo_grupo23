using System;
using System.Windows.Forms;
using Controladores;
using Modelos;

namespace WindowsFormsApp1
{
    public partial class Modificar_Reserva : Form
    {
        private readonly Reserva_Controlador reservaControlador = new Reserva_Controlador();
        private readonly Cliente_Controlador clienteControlador = new Cliente_Controlador();
        private readonly Recinto_Controlador recintoControlador = new Recinto_Controlador();

        private readonly int idReserva;
        private Reserva reservaActual;

        DateTimePicker dtpFecha;
        NumericUpDown nudHora;
        ComboBox cbCliente;
        ComboBox cbRecinto;
        Button btnGuardar;
        Button btnCancelar;

        public Modificar_Reserva(int idReserva)
        {
            InitializeComponent();
            Inicializacion();
            this.idReserva = idReserva;
            CargarDatosIniciales();
        }

        private void Inicializacion()
        {
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.nudHora = new System.Windows.Forms.NumericUpDown();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbRecinto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // dtpFecha
            this.dtpFecha.Location = new System.Drawing.Point(30, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            //dtpFecha.MinDate = DateTime.Now;

            // nudHora
            this.nudHora.Location = new System.Drawing.Point(30, 70);
            this.nudHora.Minimum = 1;
            this.nudHora.Maximum = 24;
            this.nudHora.Name = "nudHora";
            this.nudHora.Size = new System.Drawing.Size(200, 20);

            // cbCliente
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.Location = new System.Drawing.Point(30, 110);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(200, 21);

            // cbRecinto
            this.cbRecinto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecinto.Location = new System.Drawing.Point(30, 150);
            this.cbRecinto.Name = "cbRecinto";
            this.cbRecinto.Size = new System.Drawing.Size(200, 21);

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(30, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(140, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Modificar_Reserva Form
            this.ClientSize = new System.Drawing.Size(260, 260);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.nudHora);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.cbRecinto);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "Modificar_Reserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Reserva";
            this.ResumeLayout(false);
        }


        private void CargarDatosIniciales()
        {
            reservaActual = reservaControlador.obtener_reserva_por_id(idReserva);

            if (reservaActual == null)
            {
                MessageBox.Show("La reserva no fue encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Inicializar controles con datos de la reserva
            dtpFecha.Value = reservaActual.fecha_reserva;
            nudHora.Value = reservaActual.hora_reserva;

            cbCliente.DataSource = clienteControlador.listar_clientes();
            cbCliente.DisplayMember = "nombre_completo";
            cbCliente.ValueMember = "id_cliente";
            cbCliente.SelectedValue = reservaActual.id_cliente;

            cbRecinto.DataSource = recintoControlador.listar_recintos();
            cbRecinto.DisplayMember = "NumeroRecinto";
            cbRecinto.ValueMember = "nro_recinto";
            cbRecinto.SelectedValue = reservaActual.nro_recinto;

            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRecinto.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime nuevaFecha = dtpFecha.Value.Date;
            int nuevaHora = (int)nudHora.Value;
            int nuevoCliente = (int)cbCliente.SelectedValue;
            int nuevoRecinto = (int)cbRecinto.SelectedValue;

            // Validar conflicto horario
            bool existeConflicto = reservaControlador.existe_reserva_en_horario(nuevaFecha, nuevaHora, nuevoRecinto, idReserva);

            if (existeConflicto)
            {
                MessageBox.Show("Ya existe una reserva activa en esa fecha y hora para ese recinto.", "Conflicto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resultado = reservaControlador.actualizar_reserva(idReserva, nuevaFecha, nuevaHora, nuevoCliente, nuevoRecinto);

            if (resultado > 0)
            {
                MessageBox.Show("Reserva modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
