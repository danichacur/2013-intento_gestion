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
        public int viaje_id;
        public string fecha;
        public string ciud_orig_nombre;
        public int ciud_orig_id;
        public string ciud_dest_nombre;
        public int ciud_dest_id;
        public string tipo_nombre;
        public int buta_libre;
        public int kg_libre;
        public bool admin;


        public cant_butaca()
        {
            InitializeComponent();
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
            if (Convert.ToInt32(maskedTextBox1.Text) > this.buta_libre)
            {
                MessageBox.Show("No hay las suficientes butacas", "Error");
            }
            else if (Convert.ToInt32(maskedTextBox1.Text) > this.kg_libre)
            {
                MessageBox.Show("No hay las suficientes Tamaño en la bodega", "Error");
            }
            else
            {
                Usuario_datos data = new Usuario_datos();
                data.cant_kg = Convert.ToInt32(maskedTextBox1.Text);
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
    }
}
