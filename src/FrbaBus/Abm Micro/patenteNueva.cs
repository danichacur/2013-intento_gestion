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
    public partial class patenteNueva : Form
    {
        public static patenteNueva nueva;
        public patenteNueva()
        {
            InitializeComponent();
            patenteNueva.nueva = this;
        }
        public TextBox text
        {
            get
            {
                return textBox1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            funciones patente = new funciones();

            if (!patente.noExistePatente(textBox1.Text))
            {
                MessageBox.Show("La patente ingresada ya existe!");
            }
            else
            {
             
                funciones pasajes = new funciones();
                int microAlterno = 0;
                microAlterno = pasajes.cargameMicro(modificacion.f1.TextBox1.Text, textBox1.Text);
                //microAlterno = pasajes.buscarMicro(patenteNueva.nueva.text.Text);
                
                if (microAlterno.Equals(null))
                {
                    MessageBox.Show("Hubo un error, no se pudo dar de alta el micro");
                }
                else
                {
                    MessageBox.Show("Micro dado de alta correctamente");
                    pasajes.reemplazarViajes(microAlterno, modificacion.f1.TextBox1.Text, MicroFormBaja.f1.tipo_baja, Abm_Micro.MicroFormBaja.f1.inicio.Value, Abm_Micro.MicroFormBaja.f1.fin.Value);

                }

                this.Close();
            }
            
        }
    }
}
