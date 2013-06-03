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
    public partial class modificacion : Form
    {
        public modificacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Micro.MicroFormModificacion microMod = new Abm_Micro.MicroFormModificacion();
            microMod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Micro.MicroFormBaja microBaja = new Abm_Micro.MicroFormBaja();
            //microBaja.MdiParent = this;
            microBaja.Show();
            this.Hide();
        }
    }
}
