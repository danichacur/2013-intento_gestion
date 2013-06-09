using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace FrbaBus
{
    class funciones:conexion
    {
        public DataSet llenaComboboxCiudad()
        {
            this.sql = string.Format(@"select ciud_id,ciud_nombre from transportados.ciudad");
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Ciudad");
            return ds;
        }
        public DataSet llenaComboboxTipo()
        {
            this.sql = string.Format(@"select tipo_id,tipo_nombre from transportados.tipo_servicio");
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "tipo_servicio");
            return ds;
        }
        public bool insertarRecorrido(int ciudOrigen, int ciudDestino,int tipoServ,int basePasaje,int baseEncomienda)
        {
            bool Resultado = false;
            int result = 0;
            //this.sql = string.Format(@"select tipo_id,tipo_nombre from transportados.tipo_servicio");
            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[recorrido](
                                            [reco_id],
                                            [reco_id_ciudad_origen],
                                            [reco_id_ciudad_destino],
                                            [reco_tipo_id],
                                            [reco_precio_base],
                                            [reco_precio_encomienda],
                                            [reco_creado],
                                            [reco_modificado])
                                            values
                                            ('ajbfkasafbksdf',{0},{1},{2},{3},{4},SYSDATETIME(),SYSDATETIME())", ciudOrigen,ciudDestino,tipoServ,basePasaje,baseEncomienda);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            //SqlDataReader Reg = null;
            //Reg = this.comandosSql.ExecuteReader();
            //MessageBox.Show(Reg.Read().ToString());
            result=this.comandosSql.ExecuteNonQuery();
            if (result>0)
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }
            this.cnn.Close();
            return Resultado;
        }
        public bool insertarCiudad(string ciudad)
        {
            bool Resultado = false;
            int result = 0;
            //this.sql = string.Format(@"select tipo_id,tipo_nombre from transportados.tipo_servicio");
            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[ciudad](
                                            [ciud_nombre]
                                            ,[ciud_creado]
                                            ,[ciud_modificado]
                                            ,[ciud_baja])
                                            values
                                            ('{0}',SYSDATETIME(),SYSDATETIME(),0)", ciudad);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            result = this.comandosSql.ExecuteNonQuery();
            if (result > 0)
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }
            this.cnn.Close();
            return Resultado;
        }
        public DataSet listarRecorrido()
        {
            this.sql = string.Format(@"select 
                                        r.reco_id as 'ID_recorrido'
                                        ,c1.ciud_nombre as 'Ciudad Origen'
                                        ,c2.ciud_nombre as 'Ciudad Destino'
                                        ,t.tipo_nombre as 'Tipo de recorrido'
                                        ,r.reco_precio_base as 'Precio Base Pasaje'
                                        ,r.reco_precio_encomienda as 'Precio Base Encomienda'
                                      from transportados.recorrido r
                                        left outer join transportados.ciudad c1 on r.reco_id_ciudad_destino=c1.ciud_id
                                        left outer join transportados.ciudad c2 on r.reco_id_ciudad_origen=c2.ciud_id
                                        left outer join transportados.tipo_servicio t on r.reco_tipo_id=t.tipo_id;");
            /*this.comandosSql = new SqlCommand(this.sql, this.cnn);
            cnn.Open();
            SqlDataReader resultado = this.comandosSql.ExecuteReader();
            this.cnn.Close();
            return resultado;*/
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "tipo_servicio");
            return ds;
        }
    }
}
