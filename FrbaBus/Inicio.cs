using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Compra_de_Pasajes.Form1 Comprar = new Compra_de_Pasajes.Form1();
            Comprar.MdiParent = this;
            Comprar.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
              Login.Login_usu login = new Login.Login_usu();
              login.MdiParent = this;
            login.Show();
        }
    }
}
