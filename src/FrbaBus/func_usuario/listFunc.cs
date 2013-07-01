using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.func_usuario
{
    public partial class listFunc : Form
    {
        public listFunc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios Fumc = new Formularios();
            DataSet fumcLista = Fumc.listarFuncion(this.textBox1.Text);
            dataGridView1.DataSource = fumcLista.Tables[0].DefaultView;
        }


    }
}
