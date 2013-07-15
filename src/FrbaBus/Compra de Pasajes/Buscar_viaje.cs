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
    public partial class Buscar_viaje : Form
    {
        public bool admin;

        public Buscar_viaje()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_viaje_Load(object sender, EventArgs e)
        {
            Formularios dataCiudad = new Formularios();
            
            //LLeno combobox Ciudad Origen
            DataSet ds_origen = dataCiudad.llenaComboboxCiudad();
            comboBox1.DataSource = ds_origen.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "ciud_nombre";
            comboBox1.ValueMember = "ciud_id";

            // LLeno combobox de ciudad destino
            DataSet ds_destino = dataCiudad.llenaComboboxCiudad();
            comboBox2.DataSource = ds_destino.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox2.DisplayMember = "ciud_nombre";
            comboBox2.ValueMember = "ciud_id";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) != Convert.ToInt32(comboBox2.SelectedValue))
            {

                Select_viaje form_viaje = new Select_viaje();
                form_viaje.ciud_origen = Convert.ToInt32(comboBox1.SelectedValue);
                form_viaje.ciud_destino = Convert.ToInt32(comboBox2.SelectedValue);
                form_viaje.fecha = Convert.ToString(dateTimePicker1.Value);
                form_viaje.admin = this.admin;
                form_viaje.Show();
            }
        }
    }
}
