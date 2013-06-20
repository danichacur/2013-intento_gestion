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

        }

        private void Generar_Load(object sender, EventArgs e)
        {
            Llenarcombobox();
        }
        public void Llenarcombobox()
        {
            funciones dataRecorrido = new funciones();
            DataSet ds_Recorrido = dataRecorrido.llenaComboboxRecorrido();
            //da.Fill(ds_origen, "Ciudad");
            comboBox1.DataSource = ds_Recorrido.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "ciud_nombre";
            comboBox1.ValueMember = "ciud_id";
        }
    }
}
