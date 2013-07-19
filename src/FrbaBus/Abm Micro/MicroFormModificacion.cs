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
    public partial class MicroFormModificacion : Form
    {
        public MicroFormModificacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones modificacion = new funciones();
            if (modificacion.modificar_micro(this.textBox1.Text, comboBox1.Text))
            {
                MessageBox.Show("Micro modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el micro, intente mas tarde");
            }


        }

        private void MicroFormModificacion_Load(object sender, EventArgs e)
        {
            llenacombobox();
            funciones empresa = new funciones();
           
            this.textBox1.Text = modificacion.f1.TextBox1.Text;
            this.textBox2.Text = empresa.buscaEmpresaActual(this.textBox1.Text);
        }

        public void llenacombobox()
        {
            Formularios combos = new Formularios();
            DataSet marca = combos.llenaComboboxMarca();
            comboBox1.DataSource = marca.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "micr_marca";
            comboBox1.ValueMember = "micr_marca";
        }
    }
}
