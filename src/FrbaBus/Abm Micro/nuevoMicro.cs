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
    public partial class nuevoMicro : Form
    {
        public nuevoMicro()
        {
            InitializeComponent();
        }

        private void nuevoMicro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En proceso...");
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE DEVOLVER LOS PASAJES*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En proceso...");
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE ALTA DE MICRO.. 
             * TENDRIA QUE TOMAR LOS DATOS DEL MICRO QUE SE DIO DE BAJA O
             * QUE EL PROCESO DE ALTA SEA NORMAL COMO SI NADA?
             DSP HAY QUE ASIGNAR A LOS PASAJES VENDIDOS ESTE NUEVO MICRO!! OJO*/
            funciones pasajes = new funciones();
            int microAlterno = 0;
            pasajes.reemplazarViajes(microAlterno, modificacion.f1.TextBox1.Text, MicroFormBaja.f1.inicio.Value);
        }


    }
}
