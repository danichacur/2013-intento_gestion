﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Registrar_LLegada_Micro
{
    public partial class Form1 : Form
    {
        public static Form1 f1;

        public Form1()
        {
            InitializeComponent();
            Form1.f1 = this;
        }
        int id_viaje = 0;

        public int viaje
        {
            get
            {
                return id_viaje;
            }

        }

        public string patente
        {
            get
            {
                return textBox1.Text;
            }

        }

        public DateTime llegada
        {
            get
            {
                return dateTimePicker1.Value;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            funciones analisis = new funciones();
            //int id_viaje = 0;
            id_viaje = analisis.validar_terminal_arribo(textBox1.Text, comboBox2.Text, comboBox1.Text, dateTimePicker1.Value);
            if (id_viaje != 0)
            {
                //mostrar datos del micro
                if (analisis.validar_fecha_salida(id_viaje))
                {
                    Registrar_LLegada_Micro.Datos_Micro datos = new Registrar_LLegada_Micro.Datos_Micro();
                    datos.Show();
                }
                else {
                    MessageBox.Show("Error. El micro indicado aún no comenzo el viaje");
                }
            }
            else
            {
                MessageBox.Show("Error. El micro arribó a una ciudad incorrecta");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
        private void Form1_Load(object sender, EventArgs e)
        {
            Formularios dataCiudad = new Formularios();
            DataSet ds_origen = dataCiudad.llenaComboboxCiudad();
            DataSet ds_destino = dataCiudad.llenaComboboxCiudad();

            comboBox1.DataSource = ds_origen.Tables[0].DefaultView;
            comboBox1.DisplayMember = "ciud_nombre";
            comboBox1.ValueMember = "ciud_id";

            comboBox2.DataSource = ds_destino.Tables[0].DefaultView;
            comboBox2.DisplayMember = "ciud_nombre";
            comboBox2.ValueMember = "ciud_id";
        }
            }
}
     
