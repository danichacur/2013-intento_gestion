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
    public partial class listRol : Form
    {
        public listRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios Rol = new Formularios();
            DataSet rolLista = Rol.listarRol(this.textBox1.Text);
            dataGridView1.DataSource = rolLista.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RolMod Modificar = new RolMod();
            Modificar.nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(); ;
            Modificar.Show();
        }


    }
}
