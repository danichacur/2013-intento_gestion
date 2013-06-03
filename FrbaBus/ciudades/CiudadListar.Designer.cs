namespace FrbaBus.Ciudades
{
    partial class Form1
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
            this.ciud_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciud_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciud_creado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciud_modificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciud_baja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ciud_id,
            this.ciud_nombre,
            this.ciud_creado,
            this.ciud_modificado,
            this.ciud_baja});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(544, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // ciud_id
            // 
            this.ciud_id.HeaderText = "ID_Coiudad";
            this.ciud_id.Name = "ciud_id";
            // 
            // ciud_nombre
            // 
            this.ciud_nombre.HeaderText = "Nombre";
            this.ciud_nombre.Name = "ciud_nombre";
            // 
            // ciud_creado
            // 
            this.ciud_creado.HeaderText = "Creado";
            this.ciud_creado.Name = "ciud_creado";
            // 
            // ciud_modificado
            // 
            this.ciud_modificado.HeaderText = "Modificado";
            this.ciud_modificado.Name = "ciud_modificado";
            // 
            // ciud_baja
            // 
            this.ciud_baja.HeaderText = "Baja";
            this.ciud_baja.Name = "ciud_baja";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 266);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciud_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciud_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciud_creado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciud_modificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciud_baja;
    }
}