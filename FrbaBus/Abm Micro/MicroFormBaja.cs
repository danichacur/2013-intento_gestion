using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroFormBaja : Form
    {
        public MicroFormBaja()
        {
            InitializeComponent();
        }
        private void MicroFormBaja_Load(object sender, EventArgs e)
        {
            llenacombobox();
            this.textBox1.Text = modificacion.f1.TextBox1.Text;
        }
        public void llenacombobox()
        {
             var tipoBaja = new[] { "Fuera de servicio", "Fin vida útil"};
            comboBox1.DataSource = tipoBaja;
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





    }
}
