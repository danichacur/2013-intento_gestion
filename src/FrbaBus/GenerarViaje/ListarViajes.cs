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
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public ListarViajes()
        {
            InitializeComponent();
        }

        private void ListarViajes_Load(object sender, EventArgs e)
        {
            DataSet ViajesLista = new DataSet();

            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(cadenaConexion);

            this.sql = string.Format(@"SELECT 
		                            c2.ciud_nombre as Ciudad_Origen,
		                            c.ciud_nombre as Ciudad_Destino,
	                               [viaj_fecha_salida]
                                  ,[viaj_fecha_llegada]
                                  ,[viaj_fecha_llegada_estimada]
                                  ,M.micr_patente
                                  , M.micr_marca
                                  , M.micr_modelo
                                  ,M.micr_pisos
  	                              ,T.tipo_nombre
                                  ,[viaj_creado]
                                  ,[viaj_modificado]
                                  ,[viaj_butacas_libres]
                                  ,[viaj_KG_disponible]
                              FROM [GD1C2013].[transportados].[viajes] V
                              INNER JOIN transportados.micros M  ON M.micr_id = V.viaj_micro
                              INNER JOIN transportados.recorrido R ON R.reco_id = V.viaj_recorrido
                              INNER JOIN transportados.tipo_servicio T ON M.micr_tipo_id = T.tipo_id
                              inner join transportados.ciudad c on c.ciud_id = r.reco_id_ciudad_destino
                              inner join transportados.ciudad c2 on c2.ciud_id = r.reco_id_ciudad_origen");
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);

            da.Fill(ViajesLista, "Patente");

            dataGridView1.DataSource = ViajesLista.Tables[0].DefaultView;

        }

    }
}
