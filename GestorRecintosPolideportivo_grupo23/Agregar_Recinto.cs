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

        private bool validarCamposRecinto(String numero, String tarifa, String ubicacion, Tipo_De_Recinto tipo)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(numero) ||
                string.IsNullOrWhiteSpace(tarifa) ||
                string.IsNullOrWhiteSpace(ubicacion) ||
                tipo == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el número de cancha sea un número válido
            if (!int.TryParse(txtNumero.Text, out int num))
            {
                MessageBox.Show("Revise el formato de los campos ingresados", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que la tarifa sea un número decimal válido
            if (!decimal.TryParse(txtTarifa.Text, out decimal tar))
            {
                MessageBox.Show("Revise el formato de los campos ingresados", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void botonAgregarRecintoClick(object sender, EventArgs e)
        {
            if (validarCamposRecinto(txtNumero.Text,txtTarifa.Text,txtUbicacion.Text, (Tipo_De_Recinto)cbTipoRecinto.SelectedItem) != true)
            {
                return;
            }
            decimal.TryParse(txtTarifa.Text, out decimal tarifa);
            int.TryParse(txtNumero.Text, out int numero);

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
