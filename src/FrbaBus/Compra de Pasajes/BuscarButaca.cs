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
    public partial class BuscarButaca : Form
    {
        public int cantidad;
        public int cantidad_act=0;
        public int kg;
        public List<string> pasaje_cli_id = new List<string>();
        public List<Int32> butaca_cli_id = new List<Int32>();
        public int viaje_id;
        public bool admin;

        public BuscarButaca()
        {
            InitializeComponent();
        }



        private void BuscarButaca_Load(object sender, EventArgs e)
        {
            Formularios databutaca = new Formularios();

            //LLeno combobox Ciudad Origen
            DataSet ds_origen = databutaca.llenarComboButaca(this.viaje_id);
            comboBox1.DataSource = ds_origen.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "descripcion";
            comboBox1.ValueMember = "buta_numero";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.butaca_cli_id.Count > 0)
            {
                foreach (Int32 butacas in this.butaca_cli_id)
                {
                    if (butacas == Convert.ToInt32(comboBox1.SelectedValue))
                    {
                        MessageBox.Show("Ya has elegido esta butaca", "Error");
                        return;
                    }
                }
                this.butaca_cli_id.Add(Convert.ToInt32(comboBox1.SelectedValue));
                this.cantidad_act = this.cantidad_act + 1;
            }
            else
            {
                this.butaca_cli_id.Add(Convert.ToInt32(comboBox1.SelectedValue));
                this.cantidad_act = this.cantidad_act + 1;
            }
                if (this.cantidad_act == this.cantidad)
                {
                    selectMedioP medioDePago = new selectMedioP();
                    medioDePago.viaje_id = this.viaje_id;
                    medioDePago.pasaje_cli_id = this.pasaje_cli_id;
                    medioDePago.butaca_cli_id = this.butaca_cli_id;
                    medioDePago.kg = this.kg;
                    medioDePago.admin = this.admin;
                    medioDePago.Show();
                    this.Hide();

                }
                
        }
    }
}
