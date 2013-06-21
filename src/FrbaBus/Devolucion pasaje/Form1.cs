using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Cancelar_Viaje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones pasajes = new funciones();
            bool ok;
            ok = pasajes.devolucionPersonal(textBox2.Text, Convert.ToInt32(textBox1.Text), richTextBox1.Text);
            if (ok)
            {
                MessageBox.Show("Devolucion completada correctamente");
                this.Close();
            }else
            {
                MessageBox.Show("Ocurrió un error, revise los datos ingresados");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
