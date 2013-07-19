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

        // Declare the DateTimePicker.
        //public System.Windows.Forms.DateTimePicker DateTimePicker2;

        private void button1_Click_1(object sender, EventArgs e)
        {
            funciones analisis = new funciones();
            //int id_viaje = 0;
            id_viaje = analisis.validar_terminal_arribo(textBox1.Text, comboBox2.Text, comboBox1.Text, dateTimePicker2.Value);
            if (id_viaje != 0)
            {
                //mostrar datos del micro
                Registrar_LLegada_Micro.Datos_Micro datos = new Registrar_LLegada_Micro.Datos_Micro();
                datos.Show();

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

        /*public void SetMyCustomFormat()
            {
               // Set the Format type and the CustomFormat string.
               dateTimePicker1.Format = DateTimePickerFormat.Custom;
               dateTimePicker1.CustomFormat = "MM'/“hh yyyy”: 'mm tt";

               dateTimePicker2.Format = DateTimePickerFormat.Custom;
               dateTimePicker2.CustomFormat = "MM'/“hh yyyy”: 'mm tt";
            }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
          //  InitializeDateTimePicker();
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
      /*  private void InitializeDateTimePicker()
        {
            // Construct the DateTimePicker.
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();

            //Set size and location.
            this.DateTimePicker2.Location = new System.Drawing.Point(270, 210);
            this.DateTimePicker2.Size = new System.Drawing.Size(200, 20);

            // Set the alignment of the drop-down MonthCalendar to right.
            this.DateTimePicker2.DropDownAlign = LeftRightAlignment.Right;

            // Set the Value property to 50 years before today.
            DateTimePicker2.Value = System.DateTime.Now.AddYears(-50);

            //Set a custom format containing the string "of the year"
            DateTimePicker2.Format = DateTimePickerFormat.Custom;
            DateTimePicker2.CustomFormat = "DD'/'MM'/'YYYY ': 'mm tt";

            // Add the DateTimePicker to the form.
            this.Controls.Add(this.DateTimePicker2);
        }
       */

