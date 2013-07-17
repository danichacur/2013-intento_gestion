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
    public partial class Listar : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected Int32 resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public Listar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            cargagrid(); 
        
        }
        void cargagrid()
        {
            Formularios Recorrido = new Formularios();
            DataSet recorridoLista = Recorrido.listarRecorrido(string.Empty);
            dataGridView1.DataSource = recorridoLista.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }    
}
