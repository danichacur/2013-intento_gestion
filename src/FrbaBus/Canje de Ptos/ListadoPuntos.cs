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
    public partial class ListadoPuntos : Form
    {
        public DataSet puntoslista;
        public DataSet premiolista;
        public int clie_dni;
        double total;
        public bool admin;

        public ListadoPuntos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = puntoslista.Tables[0].DefaultView;
            this.textBox1.Text = (Convert.ToDouble(puntoslista.Tables[0].Compute("Sum(Puntos)", "Vencido=false").ToString())
                                        - Convert.ToDouble(puntoslista.Tables[0].Compute("Sum(Puntos_Usados)", "Vencido=false").ToString())).ToString();
            this.total = Convert.ToDouble(this.textBox1.Text);
            dataGridView2.DataSource = premiolista.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Premios premioForm = new Premios();
            premioForm.total = this.total;
            premioForm.clie_dni = this.clie_dni;
            premioForm.admin = this.admin;
            this.Hide();
            premioForm.Show();
        }
    }
}
