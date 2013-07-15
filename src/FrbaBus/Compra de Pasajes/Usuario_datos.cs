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
    public partial class Usuario_datos : Form
    {
        private SqlDataReader lectura;
        private bool is_client;
        public int cant_pasj=0;
        private int add_psj = 0;
        public int cant_kg=0;
        public bool has_kg = false;
        List<string> pasaje_cli_id = new List<string>();

        public Usuario_datos()
        {
            InitializeComponent();
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
            funciones func_user = new funciones();
            Formularios datos = new Formularios();
             SqlDataReader lectura_new;
            if (is_client)
            {
                if (this.textBox1.Text != this.lectura["Cli_Nombre"].ToString() ||
                    this.textBox2.Text != this.lectura["Cli_Apellido"].ToString() ||
                    this.textBox3.Text != this.lectura["Cli_Dir"].ToString() ||
                    this.maskedTextBox2.Text != this.lectura["Cli_Telefono"].ToString() ||
                    this.textBox4.Text != this.lectura["Cli_Mail"].ToString() ||
                    this.dateTimePicker1.Value != Convert.ToDateTime(this.lectura["Cli_Fecha_Nac"].ToString()))
                {
                    func_user.modClient(Convert.ToInt32(this.lectura["Cli_id"].ToString()),Convert.ToInt32( this.maskedTextBox1.Text), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, Convert.ToInt32(this.maskedTextBox2.Text), this.textBox4.Text, this.dateTimePicker1.Value);
                }
                this.pasaje_cli_id.Add(this.lectura["Cli_id"].ToString());
                
            }
            else
            {
                func_user.newClient(Convert.ToInt32(this.maskedTextBox1.Text), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, Convert.ToInt32(this.maskedTextBox2.Text), this.textBox4.Text, this.dateTimePicker1.Value);
                lectura_new = datos.datos_user(Convert.ToInt32(maskedTextBox1.Text));
                lectura_new.Read();
                this.pasaje_cli_id.Add(lectura_new["Cli_id"].ToString());

            }
            if (has_kg)
            {
                this.has_kg = false;

            }
            else
            {
                this.add_psj = this.add_psj + 1;
            }

            if (this.cant_pasj == this.add_psj && this.has_kg == false)
            {
                BuscarButaca busq = new BuscarButaca();
                busq.cantidad = add_psj;
                busq.kg = cant_kg;
                busq.pasaje_cli_id = this.pasaje_cli_id;
                busq.Show();
                this.Hide();
            }
            else
            {
                Usuario_datos_Load();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_datos_Load()
        {
        
        }

        
    }
}
