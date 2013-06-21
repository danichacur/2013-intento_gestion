using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.ciudades
{
    public partial class CiudadModificar : Form
    {
        public string CiudNombre;
        public string CiudBaja;

        public CiudadModificar()
        {
            InitializeComponent();
        }

        private void CiudadModificar_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = CiudNombre;
            if (CiudBaja == "SI")
            {
                this.checkBox1.Checked = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones ModCiti = new funciones();
            /*if (this.textBox1.Text != CiudNombre)
            {
                citiExist = ModCiti.CheckCity(this.textBox1.Text);
            }*/
            if (this.checkBox1.Checked )
            {
                ModCiti.ModifyCity(this.textBox1.Text, 1, CiudNombre);
                MessageBox.Show("Ciudad dada de baja correctamente", "Modicar ciudad");
                this.Close();
            }
            else 
            {
                ModCiti.ModifyCity(this.textBox1.Text, 0, CiudNombre);
                MessageBox.Show("Ciudad modificada correctamente", "Modicar ciudad");
                this.Close();
            }
                     
        }
    }

}