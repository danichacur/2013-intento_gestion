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

            DataSet MicroLista = new DataSet();

            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(cadenaConexion);

            this.sql = string.Format(@"SELECT 
	                  [micr_patente] AS Patente
                      ,[micr_marca] AS Marca
                      ,[micr_modelo] As Modelo
                      ,T.tipo_nombre As 'Tipo de servicio'
                      ,[micr_pisos] as 'Cantidad de pisos'
                      ,[micr_cant_butacas] as 'Cantidad de butacas'
                      ,[micr_kg_encomienda] as 'KG para encomienda'
                      ,case [micr_baja] 
                           when 0 then 'NO'
	                        else 'SI' 
                            end as 'Dado de Baja Permanente' 
                    ,[micr_fecha_baja] as 'Fecha de baja'
                      ,case [micr_baja_tecnica]
                      when 0 then 'NO'
	                        else 'SI' 
                            end as 'Baja Tecnica' 
                      ,[micr_fecha_baja_tecnica] as 'Fecha de baja tecnica'
                      ,[micr_fecha_regreso] as 'Fecha de retorno'
                      ,[micro_creado] as 'Fecha de creacion'
                  FROM [GD1C2013].[transportados].[micros] M
                  INNER JOIN transportados.tipo_servicio T ON T.tipo_id = M.micr_tipo_id ");
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);

            da.Fill(MicroLista, "Patente");

            dataGridView1.DataSource = MicroLista.Tables[0].DefaultView;


        }

    }
}
