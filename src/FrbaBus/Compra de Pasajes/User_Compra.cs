using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class User_Compra : Form
    {
        public List<string> pasaje_cli_id = new List<string>();
        public List<Int32> butaca_cli_id = new List<Int32>();
        public Int32 kg;
        public Int32 viaje_id;
        public string opcion;
        private SqlDataReader lectura;
        private bool is_client=false;
        public bool discapacitado;
        public Int32 cant_65;
        private decimal discount=0m;
        public int cant_psj;

        public User_Compra()
        {
            InitializeComponent();
        }

        private void User_Compra_Load(object sender, EventArgs e)
        {
            if (opcion == "Efectivo")
            {
                this.label12.Visible = false;
                this.label8.Visible = false;
                this.label13.Visible = false;
                this.label11.Visible = false;
                this.label9.Visible = false;
                this.label10.Visible = false;
                this.comboBox1.Visible = false;
                this.comboBox2.Visible = false;
                this.maskedTextBox3.Visible = false;
                this.maskedTextBox4.Visible = false;
                this.maskedTextBox5.Visible = false;
                this.maskedTextBox6.Visible = false;
            }
            else
            {
                comboBox1.Items.Add("Visa");
                comboBox1.Items.Add("Master");
                comboBox1.Items.Add("Naranja");
                comboBox1.Items.Add("Amex");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Visa")
            {
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("3");
                comboBox2.Items.Add("6");
                comboBox2.Items.Add("12");
            }
            else
            {
                comboBox2.Items.Add("1");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formularios datos = new Formularios();

            this.lectura = datos.datos_user(Convert.ToInt32(maskedTextBox1.Text));

            if (this.lectura == null)
            {
                MessageBox.Show("No hay ningun cliente cargado");

            }
            else
            {
                this.lectura.Read();
                this.textBox1.Text = this.lectura["Cli_Nombre"].ToString();
                this.textBox2.Text = this.lectura["Cli_Apellido"].ToString();
                this.textBox3.Text = this.lectura["Cli_Dir"].ToString();
                this.maskedTextBox2.Text = this.lectura["Cli_Telefono"].ToString();
                this.textBox4.Text = this.lectura["Cli_Mail"].ToString();
                this.dateTimePicker1.Value = Convert.ToDateTime(this.lectura["Cli_Fecha_Nac"].ToString());
                this.is_client = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones func = new funciones();
            Int32 voucher_id;

            if (this.discapacitado)
            {
                if (this.cant_psj > 2)
                {
                    if ((this.cant_65 - 2) > 0)
                    {
                        this.discount = 2m + 0.5m * Convert.ToDecimal(this.cant_65 - 2);
                    }
                }
                else { this.discount = 2m; }

            }
            else
            {
                this.discount = 0.5m * Convert.ToDecimal(this.cant_65 - 2);
            }

            voucher_id= func.realizar_compra(Convert.ToInt32(this.lectura["Cli_id"]), this.kg, this.viaje_id, this.cant_psj, this.discount);

            if (this.kg > 0)
            {
                func.insertar_butaca(this.viaje_id, voucher_id, butaca_cli_id[0], Convert.ToInt32(pasaje_cli_id[0]), this.kg, 0);

                for (Int32 i = 1; i < butaca_cli_id.Count; i++)
                {
                    func.insertar_butaca(this.viaje_id, voucher_id, butaca_cli_id[i], Convert.ToInt32(pasaje_cli_id[i]), this.kg, 0);
                }
            }
            else
            {
                for (Int32 i = 0; i < butaca_cli_id.Count; i++)
                {
                    func.insertar_butaca(this.viaje_id, voucher_id, butaca_cli_id[i], Convert.ToInt32(pasaje_cli_id[i]), this.kg, 0);
                }
            }


        }
    }
}
