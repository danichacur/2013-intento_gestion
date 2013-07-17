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
        private bool is_client=false;
        public Int32 cant_pasj=0;
        private Int32 add_psj = 0;
        public Int32 cant_kg=0;
        public bool has_kg = false;
        List<string> pasaje_cli_id = new List<string>();
        public Int32 viaje_id;
        private Int32 cant_65=0;
        public bool admin;
        private bool discapacitado = false;

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
                complete_textbox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones func_user = new funciones();
            Formularios datos = new Formularios();
             SqlDataReader lectura_new;
             string cliente;
             

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
                cliente= this.lectura["Cli_id"].ToString();
                
            }
            else
            {
                this.lectura = datos.datos_user(Convert.ToInt32(maskedTextBox1.Text));

                if (this.lectura == null)
                {
                    func_user.newClient(Convert.ToInt32(this.maskedTextBox1.Text), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, Convert.ToInt32(this.maskedTextBox2.Text), this.textBox4.Text, this.dateTimePicker1.Value);
                    lectura_new = datos.datos_user(Convert.ToInt32(maskedTextBox1.Text));
                    lectura_new.Read();
                    cliente=lectura_new["Cli_id"].ToString();

                }
                else
                {
                    complete_textbox();
                    cliente = this.lectura["Cli_id"].ToString();
                }
                

            }
            if (func_user.check_viaje_dup(Convert.ToInt32(cliente), this.viaje_id) && func_user.check_is_traveling(Convert.ToInt32(cliente), this.viaje_id))
            {
                this.pasaje_cli_id.Add(cliente);
                if (checkBox1.Checked) this.discapacitado = true;
                if (has_kg)
                {
                    this.has_kg = false;

                }
                else
                {
                    this.add_psj = this.add_psj + 1;
                    if ((Convert.ToDateTime(this.lectura["Cli_Fecha_Nac"].ToString()) - DateTime.Now).TotalHours > 64) cant_65 = cant_65 + 1;
                }

                if (this.cant_pasj == this.add_psj && this.has_kg == false)
                {
                    BuscarButaca busq = new BuscarButaca();
                    this.Hide();
                    busq.cantidad = add_psj;
                    busq.kg = cant_kg;
                    busq.pasaje_cli_id = this.pasaje_cli_id;
                    busq.viaje_id = this.viaje_id;
                    busq.admin = this.admin;
                    busq.discapacitado = this.discapacitado;
                    busq.cant_65 = this.cant_65;
                    busq.Show();
                }
                else
                {
                    Usuario_datos_Load();
                }

            }
            else
            {
                MessageBox.Show("El usuario ya posee pasajes o esta en viaje en esa fecha", "Error operacion");
                Usuario_datos_Load();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_datos_Load()
        {
            this.maskedTextBox1.Text = string.Empty;
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.maskedTextBox2.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.dateTimePicker1.Value = DateTime.Now;
            if (this.discapacitado || this.has_kg) this.checkBox1.Visible = false;
            this.is_client = false;
        
        }


        private void complete_textbox()
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

        /*private bool check_dup(string cliente)
        {
            bool result;
            Int32 valor;
            if (this.cant_kg > 0) 
            {
                valor=1;
            }
            else
            {
                valor=0;
            }

            for (Int32 i= valor ; i <= pasaje_cli_id.Count; i++)
            {
                if (pasaje_cli_id[i-1] ==pasaje_cli_id[i-1])
                {;
                }
            }*/

 



        
    }
}
