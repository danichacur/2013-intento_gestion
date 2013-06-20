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
    public partial class buscaMicro : Form
    {
        public buscaMicro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            funciones pasajes = new funciones();
            string microAlterno = null;
            microAlterno = pasajes.buscarMicroAlternativo(MicroFormBaja.f1.inicio.Value, MicroFormBaja.f1.fin.Value, modificacion.f1.TextBox1.Text);
            if (microAlterno == null)
            {
                Abm_Micro.nuevoMicro MicroNuevo = new Abm_Micro.nuevoMicro();
                MicroNuevo.MdiParent = this;
                MicroNuevo.Show();
              
            }else
            {
                pasajes.reemplazarViajes(microAlterno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En proceso...");
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE DEVOLVER LOS PASAJES*/
        }
    }
}
