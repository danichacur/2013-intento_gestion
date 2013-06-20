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
    public partial class Login_usu : Form
    {
        public Login_usu()
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
                Inicio parentForm = (Inicio)this.MdiParent;
                parentForm.Hide();
                Form1 IniAdmin = new Form1();
                IniAdmin.Show();
            }
            else
            {
                MessageBox.Show(Usuario0b.Mensaje, "Error");
                text2.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
