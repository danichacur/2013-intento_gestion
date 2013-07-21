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
    public partial class Premios : Form
    {
        public int clie_dni;
        public double total;
        public bool admin;

        public Premios()
        {
            InitializeComponent();
        }

        private void Premios_Load(object sender, EventArgs e)
        {
            Formularios puntos = new Formularios();
            dataGridView1.DataSource = puntos.datapremios(this.total).Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.admin)
            { funciones user_func = new funciones();
            user_func.canjearProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells["prem_id"].Value.ToString()), this.clie_dni);

            }
            this.Close();
        }
    }
}
