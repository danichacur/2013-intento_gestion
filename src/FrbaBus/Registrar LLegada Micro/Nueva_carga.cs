using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Registrar_LLegada_Micro
{
    public partial class Nueva_carga : Form
    {
        public Nueva_carga()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrar_LLegada_Micro.Form1 nueva = new Registrar_LLegada_Micro.Form1();
            nueva.Show();
            this.Close();
        }
    }
}
