namespace FrbaBus.Abm_Recorrido
{
    partial class Listar
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
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reco_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasaje_base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encomienda_base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad_origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reco_id,
            this.tipo_servicio,
            this.Pasaje_base,
            this.encomienda_base,
            this.ciudad_origen,
            this.Ciudad_destino});
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(673, 228);
            this.dataGridView1.TabIndex = 1;
            // 
            // reco_id
            // 
            this.reco_id.HeaderText = "ID_Recorrido";
            this.reco_id.Name = "reco_id";
            this.reco_id.ReadOnly = true;
            // 
            // tipo_servicio
            // 
            this.tipo_servicio.HeaderText = "Tipo de servicio";
            this.tipo_servicio.Name = "tipo_servicio";
            this.tipo_servicio.ReadOnly = true;
            // 
            // Pasaje_base
            // 
            this.Pasaje_base.HeaderText = "Precio Base Pasaje";
            this.Pasaje_base.Name = "Pasaje_base";
            this.Pasaje_base.ReadOnly = true;
            // 
            // encomienda_base
            // 
            this.encomienda_base.HeaderText = "Precio Base encomienda";
            this.encomienda_base.Name = "encomienda_base";
            this.encomienda_base.ReadOnly = true;
            // 
            // ciudad_origen
            // 
            this.ciudad_origen.HeaderText = "Ciudad de origen";
            this.ciudad_origen.Name = "ciudad_origen";
            this.ciudad_origen.ReadOnly = true;
            // 
            // Ciudad_destino
            // 
            this.Ciudad_destino.HeaderText = "Ciudad de Destino";
            this.Ciudad_destino.Name = "Ciudad_destino";
            this.Ciudad_destino.ReadOnly = true;
            // 
            // Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 297);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Listar";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Listar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reco_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasaje_base;
        private System.Windows.Forms.DataGridViewTextBoxColumn encomienda_base;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad_origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad_destino;
    }
}