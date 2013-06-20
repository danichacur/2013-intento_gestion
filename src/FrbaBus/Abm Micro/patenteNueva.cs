using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Micro
{
    public partial class patenteNueva : Form
    {
        public static patenteNueva nueva;
        public patenteNueva()
        {
            InitializeComponent();
            patenteNueva.nueva = this;
        }
        public TextBox text
        {
            get
            {
                return textBox1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias!");

            this.Close();
        }
    }
}
