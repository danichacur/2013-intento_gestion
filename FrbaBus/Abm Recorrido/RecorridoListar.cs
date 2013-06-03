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
        protected int resultado;
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
            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(cadenaConexion);
            this.sql = string.Format(@"select r.reco_id,c1.ciud_nombre,c2.ciud_nombre,t.tipo_nombre,r.reco_precio_base,r.reco_precio_encomienda
from transportados.recorrido r
left outer join transportados.ciudad c1 on r.reco_id_ciudad_destino=c1.ciud_id
left outer join transportados.ciudad c2 on r.reco_id_ciudad_origen=c2.ciud_id
left outer join transportados.tipo_servicio t on r.reco_tipo_id=t.tipo_id;");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            cnn.Open();

            SqlDataReader leer = this.comandosSql.ExecuteReader();

            int renglon = 0;

            while (leer.Read())
            {
                renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["reco_id"].Value = leer.GetString(0);
                dataGridView1.Rows[renglon].Cells["Ciudad_destino"].Value = leer.GetString(1);
                dataGridView1.Rows[renglon].Cells["ciudad_origen"].Value = leer.GetString(2);
                dataGridView1.Rows[renglon].Cells["tipo_servicio"].Value = leer.GetString(3);
                dataGridView1.Rows[renglon].Cells["Pasaje_base"].Value = leer.GetInt32(4);
                dataGridView1.Rows[renglon].Cells["encomienda_base"].Value = leer.GetInt32(4);
            }
            this.cnn.Close();
        }


    }    
}
