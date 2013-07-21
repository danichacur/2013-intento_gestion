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
        public bool admin = false;
        public canje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != string.Empty)
            {
                Formularios puntos = new Formularios();
                funciones func = new funciones();
                func.vencerPuntos();
                ListadoPuntos listadopuntos = new ListadoPuntos();
                listadopuntos.puntoslista = puntos.dataPuntosFrecuente(Convert.ToInt32(this.textBox1.Text));
                if (listadopuntos.puntoslista.Tables[0].Rows.Count > 0)
                {
                    listadopuntos.premiolista = puntos.datapremiosFrecuente(Convert.ToInt32(this.textBox1.Text));
                    listadopuntos.clie_dni = Convert.ToInt32(this.textBox1.Text);
                    listadopuntos.admin = this.admin;
                    this.Hide();
                    listadopuntos.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos para el DNI ingresado", "Puntos");
                }
            }
            else
            {
                MessageBox.Show("El DNI no puede estar vacio", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
