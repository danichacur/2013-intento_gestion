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

    public partial class selectMedioP : Form
    {
        public bool admin ;
        public List<string> pasaje_cli_id = new List<string>();
        public List<Int32> butaca_cli_id = new List<Int32>();
        public Int32 kg;
        public Int32 viaje_id;
        public bool discapacitado;
        public List<Int32> pasaje_65 = new List<Int32>();
        public int has_discapacitado = 0;
        public int cant_psj;

        public selectMedioP()
        {
            InitializeComponent();
        }

        private void selectMedioP_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Tarjeta De Credito");
            
            if (this.admin)
            {
                comboBox1.Items.Add("Efectivo");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != string.Empty)
            {
                User_Compra compra = new User_Compra();
                compra.opcion = comboBox1.SelectedText;
                compra.pasaje_cli_id = this.pasaje_cli_id;
                compra.butaca_cli_id = this.butaca_cli_id;
                compra.viaje_id = this.viaje_id;
                compra.kg = this.kg;
                compra.discapacitado = this.discapacitado;
                compra.pasaje_65 = this.pasaje_65;
                compra.has_discapacitado = this.has_discapacitado;
                compra.cant_psj = this.cant_psj;
                compra.Show();
                this.Hide();

            }
           
        }
    }
}
