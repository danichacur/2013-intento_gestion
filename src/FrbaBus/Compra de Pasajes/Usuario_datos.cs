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
        public SqlDataReader lectura;

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
                this.maskedTextBox3.Text = this.lectura["Cli_Mail"].ToString();
                //this.textBox1.Text = "Perez";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
