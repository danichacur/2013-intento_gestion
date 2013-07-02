using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.func_usuario
{
    public partial class AgregarFunc : Form
    {
        public string nombre;
        public AgregarFunc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AgregarFunc_Load(object sender, EventArgs e)
        {
            Formularios dataFunc = new Formularios();
            DataSet ds_func = dataFunc.llenaComboboxFunc(this.nombre);
            if (ds_func.Tables.Count > 0)
            {
                comboBox1.DataSource = ds_func.Tables[0].DefaultView;
                //se especifica el campo de la tabla
                comboBox1.DisplayMember = "func_nombre";
                comboBox1.ValueMember = "func_id";
            }
            else
            {
                MessageBox.Show("No existen mas funcionalidades", "Error");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
