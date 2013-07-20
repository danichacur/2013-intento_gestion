using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Canje_de_Ptos
{
    public partial class canje : Form
    {
        public canje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios puntos = new Formularios();
            ListadoPuntos listadopuntos = new ListadoPuntos();
            listadopuntos.puntoslista = puntos.dataPuntosFrecuente(Convert.ToInt32(this.textBox1.Text));
            listadopuntos.premiolista = puntos.datapremiosFrecuente(Convert.ToInt32(this.textBox1.Text));
            listadopuntos.clie_dni = Convert.ToInt32(this.textBox1.Text);
            this.Hide();
            listadopuntos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
