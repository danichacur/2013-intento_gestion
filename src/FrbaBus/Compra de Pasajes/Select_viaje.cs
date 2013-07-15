using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class Select_viaje : Form
    {
        public int ciud_origen;
        public int ciud_destino;
        public string fecha;
        public bool admin;
        

        public Select_viaje()
        {
            InitializeComponent();
        }

        private void Select_viaje_Load(object sender, EventArgs e)
        {
            Formularios Viaje = new Formularios();
            DataSet Viajelista = Viaje.ViajesListaBusqueda(ciud_origen, ciud_destino, fecha);
            dataGridView1.DataSource = Viajelista.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            cant_butaca butaca = new cant_butaca();

            butaca.viaje_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Viaje_id"].Value.ToString());
            butaca.fecha=this.fecha;
            butaca.ciud_orig_nombre=dataGridView1.CurrentRow.Cells["Ciudad_Origen"].Value.ToString();
            butaca.ciud_orig_id=this.ciud_origen;
            butaca.ciud_dest_nombre=dataGridView1.CurrentRow.Cells["Ciudad_Destino"].Value.ToString();
            butaca.ciud_dest_id=this.ciud_destino;
            butaca.tipo_nombre=dataGridView1.CurrentRow.Cells["tipo_nombre"].Value.ToString();
            butaca.buta_libre = Convert.ToInt32(dataGridView1.CurrentRow.Cells["viaj_butacas_libres"].Value.ToString());
            butaca.kg_libre = Convert.ToInt32(dataGridView1.CurrentRow.Cells["viaj_KG_disponible"].Value.ToString());
            butaca.admin = this.admin;
            butaca.Show();
            this.Hide();
            
        }
    }
}
