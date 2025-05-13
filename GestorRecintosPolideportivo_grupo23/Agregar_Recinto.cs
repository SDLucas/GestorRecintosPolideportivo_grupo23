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
    public partial class Agregar_Recinto : Form
    {
        Controladores.Recinto_Controlador recinto_controlador;
        Controladores.Tipo_De_Recinto_Controlador tipo_controlador;

        public Agregar_Recinto()
        {
            InitializeComponent();
            recinto_controlador = new Controladores.Recinto_Controlador();
            tipo_controlador = new Controladores.Tipo_De_Recinto_Controlador();
            cbTipoRecinto.DataSource = tipo_controlador.listar_tipo_recinto();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtTarifa.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text) ||
                cbTipoRecinto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el número de cancha sea un número válido
            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("El número de recinto debe ser un número entero válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que la tarifa sea un número decimal válido
            if (!decimal.TryParse(txtTarifa.Text, out decimal tarifa))
            {
                MessageBox.Show("La tarifa debe ser un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String ubicacion = txtUbicacion.Text;
            int id_tipo = ((Tipo_De_Recinto)cbTipoRecinto.SelectedItem).id_tipo_recinto;
            int resultado_validacion = Recinto_Controlador.verificar_recinto(numero);
            if (resultado_validacion == 0)
            {
                recinto_controlador.agregar_recinto(numero, tarifa, ubicacion, id_tipo);
                MessageBox.Show("Recinto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                this.Close();
            }
            else if (resultado_validacion == -1)
            {
                MessageBox.Show("ya existe recinto con ese numero", "Inserción fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("El recinto no pudo ser guardado.", "Inserción fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void LimpiarCampos()
        {
            txtNumero.Clear();  
            txtTarifa.Clear();
            txtUbicacion.Clear();
            cbTipoRecinto.SelectedIndex = -1;
        }
    }
}
