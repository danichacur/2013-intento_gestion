using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Ciudades
{
    public partial class Form1 : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Formularios Ciudad = new Formularios();
            DataSet ciudadLista = Ciudad.listarCiudad();
            dataGridView1.DataSource = ciudadLista.Tables[0].DefaultView;
        }
            void cargagrid()
        {
            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection (cadenaConexion);
            this.sql = string.Format(@"select * from transportados.ciudad;");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            cnn.Open();

            SqlDataReader leer = this.comandosSql.ExecuteReader();

            int renglon = 0;

            while(leer.Read())
            {
                renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["ciud_id"].Value=leer.GetInt32(0);
                dataGridView1.Rows[renglon].Cells["ciud_nombre"].Value=leer.GetString(1);
                dataGridView1.Rows[renglon].Cells["ciud_creado"].Value=leer.GetDateTime(2);
                dataGridView1.Rows[renglon].Cells["ciud_modificado"].Value=leer.GetDateTime(3);
                dataGridView1.Rows[renglon].Cells["ciud_baja"].Value=leer.GetBoolean(4);

            }
            this.cnn.Close();
        }
    }
}
