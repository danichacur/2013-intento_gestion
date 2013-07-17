using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoCrear : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected Int32 resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public RecorridoCrear()
        {
            InitializeComponent();
        }

        private void RecorridoCrear_Load(object sender, EventArgs e)
        {
            llenacombobox();
        }
        public void llenacombobox()
        {
            Formularios dataCiudad = new Formularios();
            DataSet ds_origen = dataCiudad.llenaComboboxCiudad();
            DataSet ds_destino = dataCiudad.llenaComboboxCiudad();
            DataSet ds_tipo = dataCiudad.llenaComboboxTipo();
            //da.Fill(ds_origen, "Ciudad");
            comboBox1.DataSource = ds_origen.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "ciud_nombre";
            comboBox1.ValueMember = "ciud_id";
            //da.Fill(ds_destino, "Ciudad");
            comboBox2.DataSource = ds_destino.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox2.DisplayMember = "ciud_nombre";
            comboBox2.ValueMember = "ciud_id";
            comboBox3.DataSource = ds_tipo.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox3.DisplayMember = "tipo_nombre";
            comboBox3.ValueMember = "tipo_id";
            //Int32 value = ((KeyValuePair<string, int>)comboBox1.SelectedItem).Value;
            //MessageBox.Show(value.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result;
            funciones dataCiudad = new funciones();
            if (Convert.ToInt32(comboBox1.SelectedValue) != Convert.ToInt32(comboBox2.SelectedValue) && this.textBox1.Text != string.Empty && this.textBox2.Text != string.Empty)
            {
                if (dataCiudad.CheckRecorrido(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue)))
                {
                    MessageBox.Show("El recorrido que trata de crear ya existe", "Error");
                }
                else
                {
                    
                    result = dataCiudad.insertarRecorrido(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(this.textBox1.Text), Convert.ToInt32(this.textBox2.Text));
                    if (result == true)
                    {
                        MessageBox.Show("Recorrido creado correctamente", "Crear Recorrido");
                        this.Close();
                    }
                }
            }
                else if (Convert.ToInt32(comboBox1.SelectedValue) == Convert.ToInt32(comboBox2.SelectedValue))
                {
                    MessageBox.Show("Existe un error en los destinos ","Error");
                    
                }
                else if (this.textBox1.Text == string.Empty)
                {
                    MessageBox.Show("El precio base de encomienda no puede ser 0 ", "Error");
                    
                }
            else if (this.textBox2.Text == string.Empty)
                {
                    MessageBox.Show("El precio base de pasaje no puede ser 0 ", "Error");
                   
                }
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        

    }
}
