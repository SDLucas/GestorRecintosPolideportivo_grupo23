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

namespace GestorRecintosPolideportivo_grupo23
{
    public partial class Agregar_Reserva : Form
    {
        private Cliente_Controlador clienteControlador = new Cliente_Controlador();
        private Recinto_Controlador recintoControlador = new Recinto_Controlador();
        private Usuario_Controlador usuarioControlador = new Usuario_Controlador();
        private Reserva_Controlador reservaControlador = new Reserva_Controlador();

        private List<Cliente> listaClientes;
        private List<Recinto> listaRecintos;

        public static int horaApertura=8;
        public static int horaCierre =24;

        public Agregar_Reserva()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            // Recintos
            listaRecintos = recintoControlador.listar_recintos_habilitados();
            cbRecinto.DataSource = listaRecintos;
            //No hace falta establecer un campo especifico ya que los modelos sobreescribren ToString()
            //cbRecinto.DisplayMember = "NumeroRecinto";
            //cbRecinto.ValueMember = "NumeroRecinto";

            // Clientes
            listaClientes = clienteControlador.listar_clientes();
            cbCliente.DataSource = listaClientes;
            //cbCliente.DisplayMember = "dni_cliente";
            //cbCliente.ValueMember = "id_cliente";

            dtpFecha.MinDate = DateTime.Today;
            ActualizarHorasDisponibles();

        }

        private void ActualizarHorasDisponibles()
        {
            cbHora.Items.Clear();
            btnAgregar.Enabled = false;

            if (cbRecinto.SelectedItem == null) return;

            Recinto recintoSeleccionado = (Recinto)cbRecinto.SelectedItem;
            int nroRecinto = recintoSeleccionado.NumeroRecinto;
            DateTime fecha = dtpFecha.Value.Date;

            List<int> horasReservadas = reservaControlador.ObtenerHorasReservadas(nroRecinto, fecha);

            for (int hora = horaApertura; hora <= horaCierre; hora++)
            {
                if (!horasReservadas.Contains(hora))
                {
                    cbHora.Items.Add(hora);
                }
            }

            if (cbHora.Items.Count > 0)
            {
                cbHora.SelectedIndex = 0;
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled=false;
                MessageBox.Show("Este recinto no tiene horas disponibles para esta fecha.", "Sin disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static bool validarCamposReserva(DateTime fecha,Cliente cliente,
           Recinto recinto,int hora)
        {
            if((fecha.Date < DateTime.Today))
            {
                MessageBox.Show("Por favor, seleccione una fecha futura o actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return (cliente!=null && recinto!=null && fecha !=null);
        }

        private void reservar(object sender, EventArgs e)
        {
            if (validarCamposReserva(dtpFecha.Value.Date, (Cliente)cbCliente.SelectedItem,
                (Recinto)cbRecinto.SelectedItem, (int)cbHora.SelectedItem))
            {

                DateTime fecha = dtpFecha.Value.Date;
                int id_cliente = ((Cliente)cbCliente.SelectedValue).id_cliente;
                int nro_recinto = ((Recinto)cbRecinto.SelectedValue).NumeroRecinto;
                int id_usuario = Sesion.UsuarioActual.id_Usuario;
                int hora = (int)cbHora.SelectedItem;

                int resultado = reservaControlador.agregar_reserva(fecha, id_cliente, nro_recinto, id_usuario, hora);

                if (resultado > 0)
                {
                    MessageBox.Show("Reserva creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbRecinto_SelectedValueChanged(object sender, EventArgs e)
        {
            ActualizarHorasDisponibles();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ActualizarHorasDisponibles();
        }
    }
}