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
    public partial class Datos_Micro : Form
    {
        public Datos_Micro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones analisis = new funciones();
            
            if (analisis.registrar_micro( Form1.f1.viaje, Form1.f1.llegada ))
            {
                actualizarPuntos();
                Registrar_LLegada_Micro.Nueva_carga nueva = new Registrar_LLegada_Micro.Nueva_carga();
                nueva.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el micro, intente mas tarde");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Datos_Micro_Load(object sender, EventArgs e)
        {

            Formularios Viajes = new Formularios();
            DataSet ListarDatosMicro = Viajes.ListarDatosMicro(Form1.f1.viaje);
            dataGridView1.DataSource = ListarDatosMicro.Tables[0].DefaultView;

        }

        private void actualizarPuntos()
        {
           //aca deberia actualizar los puntos de la gente !!!! y validar los que se vencieron
            funciones actualiza_y_valida = new funciones();
             actualiza_y_valida.actualizar_y_validar_puntos(Form1.f1.viaje);
            
        }
        
    }
}
