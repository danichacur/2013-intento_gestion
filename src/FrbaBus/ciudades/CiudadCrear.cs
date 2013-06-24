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
    public partial class CiudadCrear : Form
    {
        public CiudadCrear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result;
            bool citiExist = true;
            funciones dataCiudad = new funciones();
            citiExist = dataCiudad.CheckCity(this.textBox1.Text);
            if (citiExist)
            {
                MessageBox.Show("Ciudad Duplicada", "Error");  
            }
            else
            {
                
                result = dataCiudad.insertarCiudad(this.textBox1.Text);
                if (result == true)
                {
                    MessageBox.Show("Ciudad Creada correctamente");
                    this.Close();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
