using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Listar_Pagos
    {
        DataGridView dataGridViewPagos;
        Button btnCerrar;
        private void formatoMenu()
        {
            this.dataGridViewPagos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).BeginInit();
            this.SuspendLayout();

            // dataGridViewPagos
            this.dataGridViewPagos.AllowUserToAddRows = false;
            this.dataGridViewPagos.AllowUserToDeleteRows = false;
            this.dataGridViewPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPagos.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPagos.Name = "dataGridViewPagos";
            this.dataGridViewPagos.ReadOnly = true;
            this.dataGridViewPagos.Size = new System.Drawing.Size(760, 350);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(340, 375);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // Listar_Pagos
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.dataGridViewPagos);
            this.Controls.Add(this.btnCerrar);
            this.Text = "Pagos Realizados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPagos)).EndInit();
            this.ResumeLayout(false);
        }
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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Listar_Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Listar_Pagos";
            this.Text = "Listar_Pagos";
            this.ResumeLayout(false);

        }

        #endregion
    }
}