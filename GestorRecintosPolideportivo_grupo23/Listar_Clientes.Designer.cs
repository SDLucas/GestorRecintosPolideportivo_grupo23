using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    partial class Listar_Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private DataGridView dataGridViewClientes;
        private Button btnCerrar;

        private void InitializeComponent()
        {
            this.dataGridViewClientes = new DataGridView();
            this.btnCerrar = new Button();

            this.SuspendLayout();

            // dataGridViewClientes
            dataGridViewClientes.Location = new System.Drawing.Point(12, 12);
            dataGridViewClientes.Size = new System.Drawing.Size(560, 300);
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // btnCerrar
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new System.Drawing.Point(240, 320);
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            // Form
            this.Controls.Add(dataGridViewClientes);
            this.Controls.Add(btnCerrar);
            this.Text = "Listado de Clientes";
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }

        #endregion
    }
}