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
            int microAlterno = 0;
            microAlterno = pasajes.buscarMicroAlternativo(MicroFormBaja.f1.inicio.Value, MicroFormBaja.f1.fin.Value, modificacion.f1.TextBox1.Text);
            if (microAlterno == 0)
            {
                Abm_Micro.nuevoMicro MicroNuevo = new Abm_Micro.nuevoMicro();
                 MicroNuevo.Show();
                 this.Close();
              
            }else
            {
                bool result = pasajes.reemplazarViajes(microAlterno, modificacion.f1.TextBox1.Text, MicroFormBaja.f1.tipo_baja, MicroFormBaja.f1.inicio.Value, MicroFormBaja.f1.fin.Value);

                if (result)
                {
                    MessageBox.Show("Proceso completado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al reemplazar los viajes");
                }
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones pasajes = new funciones();
            /*VER BIEN DONDE ENGANCHA EN EL PROCESO DE DEVOLVER LOS PASAJES*/
            bool result = pasajes.devolverPasajes(modificacion.f1.TextBox1.Text, MicroFormBaja.f1.tipo_baja, MicroFormBaja.f1.inicio.Value, MicroFormBaja.f1.fin.Value);

            if (result)
            {
                 MessageBox.Show("Devolución de pasajes completa");
                 this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al devolver los pasajes");
            }

           
        }
    }
}
