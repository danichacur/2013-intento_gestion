using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios Usuario0b = new Usuarios();
            Usuario0b.Usuario = this.text1.Text;
            Usuario0b.Contraseña = this.text2.Text;

            if (Usuario0b.Buscar() == true)
            {
                MessageBox.Show(Usuario0b.Mensaje, "Login");
            }
            else
            {
                MessageBox.Show(Usuario0b.Mensaje, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
