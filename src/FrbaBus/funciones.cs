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

        public DataSet llenaComboboxMarca()
        {
            this.sql = string.Format(@"select distinct micr_marca from transportados.micros");
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "marca");
            return ds;
        }

        public DataSet llenaComboboxRecorrido()
        {
            this.sql = string.Format(@"select reco_id,cd.ciud_nombre+'-'+ci.ciud_nombre as reco_nombre
            from transportados.recorrido
            left outer join transportados.ciudad ci on ci.ciud_id=reco_id_ciudad_origen
            left outer join transportados.ciudad cd on cd.ciud_id=reco_id_ciudad_destino");
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "reco_nombre");
            return ds;
        }

        public DataSet llenaComboboxRecorrido_micro(int recorrido_id)
        {
            this.sql = string.Format(@"select micr_id,micr_patente
            from transportados.recorrido
            left outer join transportados.micros on micr_tipo_id=reco_tipo_id
            where reco_id = {0}", recorrido_id);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "micr_patente");
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
                                        ,t.tipo_nombre as 'Tipo de servicio'
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

        public bool noExistePatente( String patente)
        {
            bool Resultado = false;
            int result = 0;
            object otro;
            SqlCommand cmd = new SqlCommand("existe", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", patente));
            this.cnn.Open();
            otro = cmd.ExecuteScalar();
            result = Convert.ToInt32(otro);
            if (result > 0)
            {
                Resultado = false;
            }
            else
            {
                Resultado = true;
            }
            this.cnn.Close();
            return Resultado;

        }
        
        public int contarPasajesVendidos(DateTime inicio, DateTime fin, String patente)
        {
            int result = 0;
            object otro;
            SqlCommand cmd = new SqlCommand("pasajesVendidos", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", patente));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INI", inicio));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN ", fin));
            this.cnn.Open();
            otro = cmd.ExecuteScalar();
            if (string.IsNullOrEmpty(Convert.ToString(otro)))
            {
                result = 0;
            }
            else
            {
                result = Convert.ToInt32(otro);
            }
            this.cnn.Close();
            return result;

        }

        public bool bajaServicioMicro(DateTime inicio, String patente)
        {
            bool Resultado = false;
            int result = 0;
            this.sql = string.Format(@"UPDATE transportados.micros
                                        SET
                                        micr_baja = 1,
                                        micr_fecha_baja = (0) ,

                                        micr_baja_tecnica
                                        micr_fecha_baja_tecnica
                                        micr_fecha_regreso

                                        WHERE micr_patente = (1) ", inicio, patente);
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


        public bool bajaTecnicaMicro(DateTime inicio, DateTime fin, String patente)
        {
            bool Resultado = false;
            int result = 0;
            this.sql = string.Format(@"UPDATE transportados.micros
                                        SET
                                        micr_baja_tecnica = 1,
                                        micr_fecha_baja_tecnica = (0) ,
                                        micr_fecha_regreso = (1)
                                        WHERE micr_patente = '(2)' ", inicio, fin, patente); 
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

        public int buscarMicroAlternativo(DateTime inicio, DateTime fin, String patente)
        {

            int result = 0;
            Object otro;
  
            SqlCommand cmd = new SqlCommand("microAlterno", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", patente));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INI", inicio));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN ", fin));
            this.cnn.Open();          
            // execute the command
            otro = cmd.ExecuteScalar();
            result = Convert.ToInt32(otro);
            //System.Console.WriteLine(otro);
           this.cnn.Close();
            return result;
        }

        public void cargameMicro(String patenteVieja, string patenteNueva)
        {
            int result = 0;

            SqlCommand cmd = new SqlCommand("cargarMicro", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@patenteNueva", patenteNueva));
            cmd.Parameters.Add(new SqlParameter("@patenteVieja", patenteVieja));
    
            this.cnn.Open();          
            result = cmd.ExecuteNonQuery();

            this.cnn.Close();
            //return result;
        }

        public int buscarMicro(String patente)
        {
            int result = 0;
            Object otro;
            SqlCommand cmd = new SqlCommand("idMicro", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", patente));
            this.cnn.Open();
            // execute the command
            otro = cmd.ExecuteScalar();
            result = Convert.ToInt32(otro);
            //System.Console.WriteLine(otro);
            this.cnn.Close();
            return result;
        }



        public void reemplazarViajes(int microAlterno, string microViejo, DateTime fecha, DateTime fechalleg)
        {
            /*PROCESO TRANSPARENTE QUE CAMBIA EL MICRO ASIGNADO POR OTRO*/
 
            int result = 0;
            this.sql = string.Format(@"UPDATE TRANSPORTADOS.VIAJES
                SET VIAJ_MICRO = @id_micro
                WHERE VIAJ_MICRO = (SELECT MICR_ID FROM TRANSPORTADOS.MICROS
				                WHERE MICR_PATENTE = @patente)
                AND VIAJ_FECHA_SALIDA BETWEEN @inicio AND @fin");
            
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@id_micro", microAlterno));
            this.comandosSql.Parameters.Add(new SqlParameter("@patente", microViejo));
            this.comandosSql.Parameters.Add(new SqlParameter("@inicio", fecha));
            this.comandosSql.Parameters.Add(new SqlParameter("@fin", fechalleg));


            this.cnn.Open();
            result = this.comandosSql.ExecuteNonQuery();

            this.cnn.Close();

        }

        public void devolverPasajes(string microViejo, DateTime fecha, DateTime fechalleg)
        {
            /*PROCESO TRANSPARENTE QUE DEVUELVE LOS PASAJES*/
            int result = 0;

            SqlCommand cmd = new SqlCommand("devuelvePasajes", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", microViejo));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INI", fecha));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN ", fechalleg));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();
            this.cnn.Close();

            if (result > 0)
            {
                MessageBox.Show("Devolución de pasajes completa");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al devolver los pasajes");
            }
        }

        public bool devolucionPersonal(string voucher, int codPasaje, string motivo)
        {
            /*PROCESO TRANSPARENTE QUE DEVUELVE LOS PASAJES*/
            int result = 0;
            bool Resultado = false;
            SqlCommand cmd = new SqlCommand("devolucionPersonal", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@VOUCHER", voucher));
            cmd.Parameters.Add(new SqlParameter("@PASAJE", codPasaje));
            cmd.Parameters.Add(new SqlParameter("@MOTIVO ", motivo));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Resultado = true;
                MessageBox.Show("Devolución de pasajes completa");
            }
            else
            {
                Resultado = false;
                MessageBox.Show("Ocurrió un error al devolver los pasajes");
            }
            
            this.cnn.Close();
            return Resultado;
        }
    }
}
