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
    public partial class listarUsuario : Form
    {
        public listarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios Func = new Formularios();
            DataSet userLista = Func.ListarUser(this.textBox1.Text);
            dataGridView1.DataSource = userLista.Tables[0].DefaultView;
        }
    }
}
