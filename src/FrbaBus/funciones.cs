using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace FrbaBus
{
    class funciones : conexion
    {

        public bool insertarRecorrido(int ciudOrigen, int ciudDestino, int tipoServ, int basePasaje, int baseEncomienda)
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
                                            ('ajbfkasafbksdf',{0},{1},{2},{3},{4},SYSDATETIME(),SYSDATETIME())", ciudOrigen, ciudDestino, tipoServ, basePasaje, baseEncomienda);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            //SqlDataReader Reg = null;
            //Reg = this.comandosSql.ExecuteReader();
            //MessageBox.Show(Reg.Read().ToString());
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


        public bool noExistePatente(String patente)
        {
            bool Resultado = false;
            int result = 0;
            object otro;
            SqlCommand cmd = new SqlCommand("[transportados].[existe]", this.cnn);
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
            SqlCommand cmd = new SqlCommand("transportados.pasajesVendidos", this.cnn);
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

            SqlCommand cmd = new SqlCommand("transportados.microAlterno", this.cnn);
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

            SqlCommand cmd = new SqlCommand("transportados.cargarMicro", this.cnn);
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
            SqlCommand cmd = new SqlCommand("transportados.idMicro", this.cnn);
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

            SqlCommand cmd = new SqlCommand("transportados.devuelvePasajes", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", microViejo));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INI", fecha));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN ", fechalleg));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();


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
            SqlCommand cmd = new SqlCommand("transportados.devolucionPersonal", this.cnn);
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
        public void ModifyCity(string CiudName, Int32 IsBaja, string CiudNameOrig)
        {
            this.sql = string.Format(@"UPDATE [transportados].[ciudad]
                                        SET
                                        ciud_baja = @Baja ,
                                        ciud_modificado=SYSDATETIME()
                                        where ciud_nombre =@CiudMod");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@CiudMod", CiudName));
            this.comandosSql.Parameters.Add(new SqlParameter("@Baja", IsBaja));
            this.cnn.Open();
            this.comandosSql.ExecuteNonQuery();
            this.cnn.Close();
        }
        public bool CheckCity(string CiudName)
        {
            bool Resultado = false;
            this.sql = string.Format(@"select ciud_id
                                        from transportados.ciudad
                                        WHERE ciud_nombre = '{0}' ", CiudName);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = true;
            }

            this.cnn.Close();
            return Resultado;

        }
        public bool CheckRecorrido(Int32 Ciudorig, Int32 CiudDest, Int32 tipo)
        {
            bool Resultado = false;
            this.sql = string.Format(@"select * from transportados.recorrido
                                        where reco_id_ciudad_destino ={0}
                                        and reco_id_ciudad_origen={1}
                                        and reco_tipo_id={2}", CiudDest, Ciudorig, tipo);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = true;
            }

            this.cnn.Close();
            return Resultado;

        }
        public void ModifyReco(Int32 reco_id, Int32 IsBaja)
        {

            this.sql = string.Format(@"UPDATE [transportados].[recorrido]
                                        SET
                                        reco_baja = @Baja ,
                                        reco_modificado=SYSDATETIME()
                                        where reco_id =@Reco_id");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@Reco_id", reco_id));
            this.comandosSql.Parameters.Add(new SqlParameter("@Baja", IsBaja));
            this.cnn.Open();
            this.comandosSql.ExecuteNonQuery();
            this.cnn.Close();
        }

        public SqlDataReader getFuncID(string user_id)
        {
            this.sql = string.Format(@"select rf.rolf_func_id,fu.func_name from transportados.usuario u
left outer join  transportados.rol_usuario ru on ru.rolu_user_id=u.usua_id
left outer join transportados.Rol_funcionalidad rf on rf.rolf_rol_id=ru.rolu_rol_id
left outer join transportados.funcionalidad fu on fu.func_id=rf.rolf_func_id
where u.usua_username =  '{0}'
order by rf.rolf_func_id desc", user_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            return this.comandosSql.ExecuteReader();
        }
        public bool BajaRol(String Rol)
        {
            /*PROCESO TRANSPARENTE QUE DEVUELVE LOS PASAJES*/
            int result = 0;
            bool Resultado = false;
            SqlCommand cmd = new SqlCommand("transportados.bajaRol", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@rol", Rol));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Resultado = true;
                MessageBox.Show("Baja de rol completa");
            }
            else
            {
                Resultado = false;
                MessageBox.Show("Ocurrió un error al dar de baja al rol");
            }

            this.cnn.Close();
            return Resultado;


        }
    }
}

