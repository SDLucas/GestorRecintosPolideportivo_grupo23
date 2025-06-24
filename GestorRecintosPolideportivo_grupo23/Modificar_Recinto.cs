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
    public partial class Modificar_Recinto : Form
    {
        private readonly int numeroRecinto;
        private Recinto_Controlador recinto_controlador;
        private Tipo_De_Recinto_Controlador tipo_controlador;

        public Modificar_Recinto(int numeroRecinto)
        {
            InitializeComponent();
            this.numeroRecinto = numeroRecinto;
            recinto_controlador = new Recinto_Controlador();
            tipo_controlador = new Tipo_De_Recinto_Controlador();

            cbTipoRecinto.DataSource = tipo_controlador.listar_tipo_recinto();

            CargarDatosRecinto();
        }

        private void CargarDatosRecinto()
        {
            Recinto recinto = Recinto_Controlador.obtener_recinto_por_numero(numeroRecinto);

            if (recinto != null)
            {
                txtNumero.Text = recinto.nro_recinto.ToString();
                txtNumero.Enabled = false; // No se puede modificar la PK

                txtTarifa.Text = recinto.tarifa_recinto.ToString();
                txtUbicacion.Text = recinto.ubicacion_recinto;

                // Seleccionar el tipo correspondiente en el ComboBox
                foreach (Tipo_De_Recinto tipo in cbTipoRecinto.Items)
                {
                    if (tipo.id_tipo_recinto == recinto.tipo_recinto.id_tipo_recinto)
                    {
                        cbTipoRecinto.SelectedItem = tipo;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el recinto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(txtTarifa.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text) ||
                cbTipoRecinto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la tarifa sea un número válido
            if (!decimal.TryParse(txtTarifa.Text, out decimal tarifa))
            {
                MessageBox.Show("La tarifa debe ser un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ubicacion = txtUbicacion.Text;
            int id_tipo = ((Tipo_De_Recinto)cbTipoRecinto.SelectedItem).id_tipo_recinto;

            int resultado = recinto_controlador.actualizar_recinto(numeroRecinto, tarifa, ubicacion, id_tipo);

            if (resultado == 0)
            {
                MessageBox.Show("Recinto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el recinto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
