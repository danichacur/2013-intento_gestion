using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Micro
{
    public partial class modificacion : Form
    {
        public static modificacion f1;
        public modificacion()
        {
            InitializeComponent();
       
            modificacion.f1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error, debe ingresar una patente");
            }
            else
            {
                funciones existe = new funciones();
                if (existe.noExistePatente(textBox1.Text))
                {
                    MessageBox.Show("Error, no existen micros con esa patente");
                }
                else
                {
                    Abm_Micro.MicroFormModificacion microMod = new Abm_Micro.MicroFormModificacion();
                    microMod.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error, debe ingresar una patente");
            }
            else
            {
                funciones existe = new funciones();
                if (existe.noExistePatente(textBox1.Text))
                {
                    MessageBox.Show("Error, no existen micros con esa patente");
                }
                else
                {
                    Abm_Micro.MicroFormBaja microBaja = new Abm_Micro.MicroFormBaja();
                    microBaja.Show();
                    this.Hide();
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public TextBox TextBox1
        {
            get
            {
                return textBox1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }    
}
