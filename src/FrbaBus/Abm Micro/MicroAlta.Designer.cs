namespace FrbaBus.Abm_Micro
{
    partial class MicroAlta
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
            this.label1 = new System.Windows.Forms.Label();
            this.patenteBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modeloBox = new System.Windows.Forms.TextBox();
            this.marcaCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.servicioCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butacaCombo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.kgText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.butacaCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente";
            // 
            // patenteBox
            // 
            this.patenteBox.Location = new System.Drawing.Point(128, 24);
            this.patenteBox.Name = "patenteBox";
            this.patenteBox.Size = new System.Drawing.Size(121, 20);
            this.patenteBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo";
            // 
            // modeloBox
            // 
            this.modeloBox.Location = new System.Drawing.Point(128, 51);
            this.modeloBox.Name = "modeloBox";
            this.modeloBox.Size = new System.Drawing.Size(121, 20);
            this.modeloBox.TabIndex = 3;
            // 
            // marcaCombo
            // 
            this.marcaCombo.FormattingEnabled = true;
            this.marcaCombo.Location = new System.Drawing.Point(128, 80);
            this.marcaCombo.Name = "marcaCombo";
            this.marcaCombo.Size = new System.Drawing.Size(121, 21);
            this.marcaCombo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca";
            // 
            // servicioCombo
            // 
            this.servicioCombo.FormattingEnabled = true;
            this.servicioCombo.Location = new System.Drawing.Point(128, 111);
            this.servicioCombo.Name = "servicioCombo";
            this.servicioCombo.Size = new System.Drawing.Size(121, 21);
            this.servicioCombo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo De servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cantidad de Butacas";
            // 
            // butacaCombo
            // 
            this.butacaCombo.Location = new System.Drawing.Point(128, 142);
            this.butacaCombo.Name = "butacaCombo";
            this.butacaCombo.Size = new System.Drawing.Size(120, 20);
            this.butacaCombo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kg disponibles";
            // 
            // kgText
            // 
            this.kgText.Location = new System.Drawing.Point(128, 168);
            this.kgText.Name = "kgText";
            this.kgText.Size = new System.Drawing.Size(121, 20);
            this.kgText.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MicroAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kgText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butacaCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.servicioCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.marcaCombo);
            this.Controls.Add(this.modeloBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patenteBox);
            this.Controls.Add(this.label1);
            this.Name = "MicroAlta";
            this.Text = "Alta de micros";
            ((System.ComponentModel.ISupportInitialize)(this.butacaCombo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox patenteBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modeloBox;
        private System.Windows.Forms.ComboBox marcaCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox servicioCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown butacaCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox kgText;
        private System.Windows.Forms.Button button1;

    }
}