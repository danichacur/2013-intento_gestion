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
        public ListadoPuntos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = puntoslista.Tables[0].DefaultView;
            this.textBox1.Text = (Convert.ToDouble(puntoslista.Tables[0].Compute("Sum(Puntos)", "Vencido=false").ToString())
                                        - Convert.ToDouble(puntoslista.Tables[0].Compute("Sum(Puntos_Usados)", "Vencido=false").ToString())).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
