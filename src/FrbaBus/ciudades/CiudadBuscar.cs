using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.ciudades
{
    public partial class CiudadBuscar : Form
    {
        
        public CiudadBuscar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Formularios Ciudad = new Formularios();
            DataSet ciudadLista = Ciudad.listarCiudad(textBox1.Text);
            dataGridView1.DataSource = ciudadLista.Tables[0].DefaultView;
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ciudades.CiudadModificar CiudMod = new ciudades.CiudadModificar();
            CiudMod.CiudNombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            CiudMod.CiudBaja = dataGridView1.CurrentRow.Cells["Dada de Baja"].Value.ToString();
            CiudMod.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
