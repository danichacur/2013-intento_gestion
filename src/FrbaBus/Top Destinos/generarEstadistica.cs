using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Top_Destinos
{
    public partial class generarEstadistica : Form
    {
        public string vista;

        public generarEstadistica()
        {
            InitializeComponent();
        }

        private void generarEstadistica_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add(1);
            this.comboBox1.Items.Add(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultadoEstadistica Resultado = new resultadoEstadistica();
            func_estadisticas funciones = new func_estadisticas();
            
            if (this.vista == "Mas Pasajes Comprados")
            {
                Resultado.ResultadoLista = funciones.dataEstadisticaDestinos(Convert.ToInt32(this.maskedTextBox1.Text), Convert.ToInt32(this.comboBox1.Text));
                Resultado.Show();
            }
            else if (this.vista == "Micros mas vacios")
            {
                Resultado.ResultadoLista = funciones.dataEstadisticaMicroVacio(Convert.ToInt32(this.maskedTextBox1.Text), Convert.ToInt32(this.comboBox1.Text));
                Resultado.Show();
            }
            else if (this.vista == "Pasajes cancelados")
            {
                Resultado.ResultadoLista = funciones.dataEstadisticaPasajeCancelado(Convert.ToInt32(this.maskedTextBox1.Text), Convert.ToInt32(this.comboBox1.Text));
                Resultado.Show();
            }
            else if (this.vista == "Puntos Clientes")
            {
                Resultado.ResultadoLista = funciones.dataEstadisticaClientes(Convert.ToInt32(this.maskedTextBox1.Text), Convert.ToInt32(this.comboBox1.Text));
                Resultado.Show();
            }
            else 
            {
                Resultado.ResultadoLista = funciones.dataEstadisticaMicrosBaja(Convert.ToInt32(this.maskedTextBox1.Text), Convert.ToInt32(this.comboBox1.Text));
                Resultado.Show();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
