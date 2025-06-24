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
    public partial class Listar_Recintos : Form
    {
        Recinto_Controlador recinto_controlador;
        private List<Recinto> listaRecintos = new List<Recinto>();

        public Listar_Recintos()
        {
            recinto_controlador = new Recinto_Controlador();
            InitializeComponent();
            this.dataGridViewRecintos.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridViewRecintos_CellFormatting);
            CargarRecintos();
        }

        private void CargarRecintos()
        {
            listaRecintos = recinto_controlador.listar_recintos();
            dataGridViewRecintos.AutoGenerateColumns = false;
            dataGridViewRecintos.Columns.Clear();

            // Crear columnas manualmente
            DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
            colNumero.Name = "NumeroRecinto";
            colNumero.DataPropertyName = "NumeroRecinto";
            colNumero.HeaderText = "N° Recinto";
            dataGridViewRecintos.Columns.Add(colNumero);

            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.Name = "TipoRecinto";
            colTipo.DataPropertyName = "TipoRecinto.NombreTipoRecinto";
            colTipo.HeaderText = "Tipo";
            dataGridViewRecintos.Columns.Add(colTipo);

            DataGridViewTextBoxColumn colTarifa = new DataGridViewTextBoxColumn();
            colTarifa.Name = "Tarifa";
            colTarifa.DataPropertyName = "Tarifa";
            colTarifa.HeaderText = "Tarifa";
            dataGridViewRecintos.Columns.Add(colTarifa);

            DataGridViewTextBoxColumn colUbicacion = new DataGridViewTextBoxColumn();
            colUbicacion.Name = "Ubicacion";
            colUbicacion.DataPropertyName = "Ubicacion";
            colUbicacion.HeaderText = "Ubicación";
            dataGridViewRecintos.Columns.Add(colUbicacion);

            // Botón Estado
            DataGridViewButtonColumn btnEstado = new DataGridViewButtonColumn();
            btnEstado.Name = "AccionEstado";
            btnEstado.HeaderText = "Estado";
            btnEstado.UseColumnTextForButtonValue = false;
            dataGridViewRecintos.Columns.Add(btnEstado);

            // Botón Modificar
            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.Name = "Modificar";
            btnModificar.HeaderText = "Modificar";
            btnModificar.Text = "Modificar";
            btnModificar.UseColumnTextForButtonValue = true;
            dataGridViewRecintos.Columns.Add(btnModificar);

            dataGridViewRecintos.DataSource = listaRecintos;

            AjustarAnchoColumnas();
            OrdenarColumnasCorrectamente();
        }

        private void AjustarAnchoColumnas()
        {
            foreach (DataGridViewColumn columna in dataGridViewRecintos.Columns)
            {
                if (columna.Name == "Ubicacion")
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void OrdenarColumnasCorrectamente()
        {
            if (dataGridViewRecintos.Columns["NumeroRecinto"] != null)
                dataGridViewRecintos.Columns["NumeroRecinto"].DisplayIndex = 0;

            if (dataGridViewRecintos.Columns["TipoRecinto"] != null)
                dataGridViewRecintos.Columns["TipoRecinto"].DisplayIndex = 1;

            if (dataGridViewRecintos.Columns["Tarifa"] != null)
                dataGridViewRecintos.Columns["Tarifa"].DisplayIndex = 2;

            if (dataGridViewRecintos.Columns["Ubicacion"] != null)
                dataGridViewRecintos.Columns["Ubicacion"].DisplayIndex = 3;

            if (dataGridViewRecintos.Columns["AccionEstado"] != null)
                dataGridViewRecintos.Columns["AccionEstado"].DisplayIndex = 4;

            if (dataGridViewRecintos.Columns["Modificar"] != null)
                dataGridViewRecintos.Columns["Modificar"].DisplayIndex = 5;
        }

        private void dataGridViewRecintos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columna = dataGridViewRecintos.Columns[e.ColumnIndex].Name;
            int numeroRecinto = Convert.ToInt32(dataGridViewRecintos.Rows[e.RowIndex].Cells["NumeroRecinto"].Value);

            var recinto = listaRecintos.FirstOrDefault(r => r.nro_recinto == numeroRecinto);

            if (recinto == null)
                return;

            if (columna == "Modificar")
            {
                Modificar_Recinto formModificar = new Modificar_Recinto(numeroRecinto);
                formModificar.ShowDialog();
                CargarRecintos();
            }
            else if (columna == "AccionEstado")
            {
                if (recinto.habilitado)
                {
                    recinto_controlador.DeshabilitarRecintoPorNumero(numeroRecinto);
                }
                else
                {
                    recinto_controlador.HabilitarRecintoPorNumero(numeroRecinto);
                }

                MessageBox.Show("Estado actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRecintos();
            }
        }

        private void dataGridViewRecintos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreColumna = dataGridViewRecintos.Columns[e.ColumnIndex].Name;
                int numeroRecinto = Convert.ToInt32(dataGridViewRecintos.Rows[e.RowIndex].Cells["NumeroRecinto"].Value);
                var recinto = listaRecintos.FirstOrDefault(r => r.nro_recinto == numeroRecinto);

                if (recinto != null)
                {
                    if (nombreColumna == "TipoRecinto")
                    {
                        e.Value = recinto.tipo_recinto?.nombre_tipo_recinto;
                    }
                    else if (nombreColumna == "AccionEstado")
                    {
                        if (recinto.habilitado)
                        {
                            e.Value = "Deshabilitar";
                        }
                        else
                        {
                            e.Value = "Habilitar";
                        }
                    }
                }
            }
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarRecintos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
