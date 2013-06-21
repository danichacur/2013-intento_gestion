using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.GenerarViaje
{
    public partial class Generar : Form
    {
        public Generar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.GetType() != typeof(System.Data.DataRowView))
            {
                Formularios dataRecorrido_micro = new Formularios();
                DataSet ds_Recorrido_micro = dataRecorrido_micro.llenaComboboxRecorrido_micro(Convert.ToInt32(comboBox1.SelectedValue));
                //da.Fill(ds_origen, "Ciudad");
                comboBox2.DataSource = ds_Recorrido_micro.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                comboBox2.DisplayMember = "micr_patente";
                comboBox2.ValueMember = "micr_id";
            }
        }

        private void Generar_Load(object sender, EventArgs e)
        {
            Llenarcombobox();
        }
        public void Llenarcombobox()
        {
            Formularios dataRecorrido = new Formularios();
            DataSet ds_Recorrido = dataRecorrido.llenaComboboxRecorrido();
            //da.Fill(ds_origen, "Ciudad");
            comboBox1.DataSource = ds_Recorrido.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "reco_nombre";
            comboBox1.ValueMember = "reco_id";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
