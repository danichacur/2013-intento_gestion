using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            funciones pasajes = new funciones();
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE DEVOLVER LOS PASAJES*/
            pasajes.devolverPasajes(modificacion.f1.TextBox1.Text, MicroFormBaja.f1.tipo_baja, MicroFormBaja.f1.inicio.Value, MicroFormBaja.f1.fin.Value);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
          
        private void button4_Click(object sender, EventArgs e)
        {
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE ALTA DE MICRO.. 
             * TOMA LOS DATOS DEL MICRO QUE SE DIO DE BAJA 
            */

            Abm_Micro.patenteNueva patenteNueva = new Abm_Micro.patenteNueva();
           patenteNueva.Show();
           this.Close();

        }


    }
}
