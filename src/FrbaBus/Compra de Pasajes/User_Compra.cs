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
        public List<Int32> pasaje_65 = new List<Int32>();
        public int has_discapacitado = 0;
        private Int32 discount=0;
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
                comboBox2.Items.Clear();
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("3");
                comboBox2.Items.Add("6");
                comboBox2.Items.Add("12");
            }
            else
            {
                comboBox2.Items.Clear();
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
                complete_textbox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones func_user = new funciones();
            Formularios datos = new Formularios();
            Formularios datos_new = new Formularios();
            SqlDataReader lectura_new;
            string cliente;
            Int32 voucher_id;
            double precio_butaca = func_user.getPasjasjePrecio(this.viaje_id);
            double precio_encomienda = func_user.getEncomiendaPrecio(this.viaje_id);

            if (this.textBox1.Text != string.Empty &&
                 this.textBox2.Text != string.Empty &&
                 this.textBox3.Text != string.Empty &&
                 this.textBox4.Text != string.Empty &&
                 this.maskedTextBox1.Text != string.Empty &&
                 this.maskedTextBox2.Text != string.Empty
                 )
            {
                if (this.maskedTextBox3.Text != string.Empty
                    && this.maskedTextBox4.Text != string.Empty
                    && this.maskedTextBox5.Text != string.Empty
                    && this.maskedTextBox6.Text != string.Empty
                    || this.opcion == "Efectivo")
                {
                    if (this.is_client)
                    {
                        if (this.textBox1.Text != this.lectura["Cli_Nombre"].ToString() ||
                            this.textBox2.Text != this.lectura["Cli_Apellido"].ToString() ||
                            this.textBox3.Text != this.lectura["Cli_Dir"].ToString() ||
                            this.maskedTextBox2.Text != this.lectura["Cli_Telefono"].ToString() ||
                            this.textBox4.Text != this.lectura["Cli_Mail"].ToString() ||
                            this.dateTimePicker1.Value != Convert.ToDateTime(this.lectura["Cli_Fecha_Nac"].ToString()))
                        {
                            func_user.modClient(Convert.ToInt32(this.lectura["Cli_id"].ToString()), Convert.ToInt32(this.maskedTextBox1.Text), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, Convert.ToInt32(this.maskedTextBox2.Text), this.textBox4.Text, this.dateTimePicker1.Value);
                        }
                        cliente = this.lectura["Cli_id"].ToString();

                    }
                    else
                    {
                        this.lectura = datos.datos_user(Convert.ToInt32(maskedTextBox1.Text));

                        if (this.lectura == null)
                        {
                            func_user.newClient(Convert.ToInt32(this.maskedTextBox1.Text), this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, Convert.ToInt32(this.maskedTextBox2.Text), this.textBox4.Text, this.dateTimePicker1.Value);
                            lectura_new = datos_new.datos_user(Convert.ToInt32(maskedTextBox1.Text));
                            lectura_new.Read();
                            cliente = lectura_new["Cli_id"].ToString();

                        }
                        else
                        {
                            complete_textbox();
                            cliente = this.lectura["Cli_id"].ToString();
                        }


                    }




                    if (this.discapacitado)
                    {
                        if (this.cant_psj > 2)
                        {
                            if ((this.pasaje_65.Count - 2) > 0)
                            {
                                this.discount = 4 + (this.pasaje_65.Count - 2);
                            }
                        }
                        else { this.discount = 4; }

                    }
                    else
                    {
                        this.discount = this.pasaje_65.Count;
                    }

                    voucher_id = func_user.realizar_compra(Convert.ToInt32(cliente), this.kg, this.viaje_id, this.cant_psj, this.discount);

                    if (this.kg > 0)
                    {
                        func_user.crear_pasaje(this.viaje_id, voucher_id, this.butaca_cli_id[0], Convert.ToInt32(this.pasaje_cli_id[0]), this.kg, 0, precio_encomienda);
                        this.butaca_cli_id.Remove(butaca_cli_id[0]);
                        this.pasaje_cli_id.Remove(pasaje_cli_id[0]);

                        foreach (string cliente_id in this.pasaje_cli_id)
                        {
                            if (Convert.ToInt32(cliente_id) == has_discapacitado)
                            {
                                func_user.crear_pasaje(this.viaje_id, voucher_id, this.butaca_cli_id[this.pasaje_cli_id.IndexOf(cliente_id)], Convert.ToInt32(cliente), 0, 1, 0);
                                this.butaca_cli_id.Remove(butaca_cli_id[this.pasaje_cli_id.IndexOf(cliente_id)]);
                                this.pasaje_cli_id.Remove(cliente_id);
                                if (this.butaca_cli_id.Count > 0)
                                {
                                    func_user.crear_pasaje(this.viaje_id, voucher_id, butaca_cli_id[0], Convert.ToInt32(this.pasaje_cli_id[0]), 0, 1, 0);
                                    this.butaca_cli_id.Remove(butaca_cli_id[0]);
                                    this.pasaje_cli_id.Remove(pasaje_cli_id[0]);
                                    break;
                                }
                                else
                                { break; }
                            }
                        }
                        ingresar_pasaje(voucher_id);
                        this.Close();
                    }
                    else
                    {
                        ingresar_pasaje(voucher_id);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No estan todos los campos de tarjeta  completos", "Error operacion");

                }
            }
            else
            {
                MessageBox.Show("No estan todos los campos completos", "Error operacion");

            }
        }

        

        private void ingresar_pasaje(Int32 voucher_id)
        {
            funciones func = new funciones();

            double precio_butaca = func.getPasjasjePrecio(this.viaje_id);
            double precio_encomienda = func.getEncomiendaPrecio(this.viaje_id);

            for (Int32 i = 0; i < butaca_cli_id.Count; i++)
            {
                if (this.pasaje_65.Contains(Convert.ToInt32(this.pasaje_cli_id[i])))
                {
                    func.crear_pasaje(this.viaje_id, voucher_id, this.butaca_cli_id[i], Convert.ToInt32(this.pasaje_cli_id[i]), 0, 1, precio_butaca / 2);
                }
                else
                {
                    func.crear_pasaje(this.viaje_id, voucher_id, this.butaca_cli_id[i], Convert.ToInt32(this.pasaje_cli_id[i]), 0, 0, precio_butaca);
                }
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}