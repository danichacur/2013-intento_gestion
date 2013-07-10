using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroListar : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public MicroListar()
        {
            InitializeComponent();
        }

        private void MicroListar_Load(object sender, EventArgs e)
        {
            cargagrid(); 
        }
         void cargagrid()
        {
            Formularios Micro = new Formularios();
            DataSet MicroLista = Micro.MicroLista();
            dataGridView1.DataSource = MicroLista.Tables[0].DefaultView;
        }

    }
}
