using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.GenerarViaje
{
    public partial class ListarViajes : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected Int32 resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public ListarViajes()
        {
            InitializeComponent();
        }

        private void ListarViajes_Load(object sender, EventArgs e)
        {
            cargagrid(); 
        }

        void cargagrid()
        {
            Formularios Viajes = new Formularios();
            DataSet ViajesLista = Viajes.ViajesLista();
            dataGridView1.DataSource = ViajesLista.Tables[0].DefaultView;
        }

    }
}
