using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class Recorrido_buscar : Form
    {
        public Recorrido_buscar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios Recorrido = new Formularios();
            DataSet RecorridoLista = Recorrido.listarRecorrido(textBox1.Text);
            dataGridView1.DataSource = RecorridoLista.Tables[0].DefaultView;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Recorrido.RecorridoModificar RecoMod = new Abm_Recorrido.RecorridoModificar();
            RecoMod.RecoBaja = dataGridView1.CurrentRow.Cells["dado de baja"].Value.ToString();
            RecoMod.CiudOrig = dataGridView1.CurrentRow.Cells["Ciudad Origen"].Value.ToString();
            RecoMod.CiudDest = dataGridView1.CurrentRow.Cells["Ciudad Destino"].Value.ToString();
            RecoMod.Reco_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_recorrido"].Value.ToString());
            RecoMod.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Recorrido.RecorridoModificar RecoMod = new Abm_Recorrido.RecorridoModificar();
            RecoMod.RecoBaja = dataGridView1.CurrentRow.Cells["dado de baja"].Value.ToString();
            RecoMod.CiudOrig = dataGridView1.CurrentRow.Cells["Ciudad Origen"].Value.ToString();
            RecoMod.CiudDest = dataGridView1.CurrentRow.Cells["Ciudad Destino"].Value.ToString();
            RecoMod.Reco_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_recorrido"].Value.ToString());
            RecoMod.Show();
        }
    }
}
