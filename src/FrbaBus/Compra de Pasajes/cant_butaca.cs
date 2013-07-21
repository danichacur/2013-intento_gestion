using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class cant_butaca : Form
    {
        public Int32 viaje_id;
        public string fecha;
        public string ciud_orig_nombre;
        public Int32 ciud_orig_id;
        public string ciud_dest_nombre;
        public Int32 ciud_dest_id;
        public string tipo_nombre;
        public Int32 buta_libre;
        public Int32 kg_libre;
        public bool admin;
        public static cant_butaca c_butaca;

        public cant_butaca()
        {
            InitializeComponent();
            cant_butaca.c_butaca = this;
        }

        private void cant_butaca_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(viaje_id);
            textBox2.Text = ciud_orig_nombre;
            textBox3.Text = ciud_dest_nombre;
            textBox4.Text = tipo_nombre;
            textBox5.Text = fecha;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                maskedTextBox1.Text = "0";
            }
            if (maskedTextBox2.Text == "")
            {
                maskedTextBox2.Text = "0";
            }

            if (Convert.ToInt32(maskedTextBox1.Text) > this.buta_libre)
            {
                MessageBox.Show("No hay las suficientes butacas", "Error");
            }
            else if (Convert.ToInt32(maskedTextBox2.Text) > this.kg_libre)
            {
                MessageBox.Show("No hay suficiente tamaño en la bodega", "Error");
            }
            else
            {
                Usuario_datos data = new Usuario_datos();
                data.cant_kg = Convert.ToInt32(maskedTextBox2.Text);
                data.cant_pasj = Convert.ToInt32(maskedTextBox1.Text);
                data.viaje_id = this.viaje_id;
                data.admin = this.admin;
                if (data.cant_kg > 0)
                { 
                    data.has_kg = true;
                }
                data.Show();
                this.Hide();
            }

        }

        public string kg
        {
            get
            {
                return maskedTextBox2.Text;
            }
        }

    }
}
