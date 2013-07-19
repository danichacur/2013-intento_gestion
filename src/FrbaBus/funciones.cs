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

        public bool insertarRecorrido(Int32 ciudOrigen, Int32 ciudDestino, Int32 tipoServ, Int32 basePasaje, Int32 baseEncomienda)
        {
            bool Resultado = false;
            Int32 result = 0;
            //this.sql = string.Format(@"select tipo_id,tipo_nombre from transportados.tipo_servicio");
            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[recorrido](
                                            [reco_id_ciudad_origen],
                                            [reco_id_ciudad_destino],
                                            [reco_tipo_id],
                                            [reco_precio_base],
                                            [reco_precio_encomienda],
                                            [reco_creado],
                                            [reco_modificado])
                                            values
                                            ({0},{1},{2},{3},{4},SYSDATETIME(),SYSDATETIME())", ciudOrigen, ciudDestino, tipoServ, basePasaje, baseEncomienda);
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
            Int32 result = 0;
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
            Int32 result = 0;
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

        public int validar_terminal_arribo(string patente, string destino, string origen, DateTime salida)
        {
            //bool Resultado = false;
            Object otro;
            int result;

            this.sql = string.Format(@"SELECT viaj_id
                                    FROM transportados.ciudad C,
                                    transportados.ciudad C2,
                                    transportados.recorrido R,
                                    transportados.viajes V,
                                    transportados.micros M
                                    WHERE 
                                    C.ciud_id = R.reco_id_ciudad_destino
                                    and C2.ciud_id = R.reco_id_ciudad_origen
                                    AND V.viaj_recorrido = R.reco_id
                                    AND V.viaj_micro = M.micr_id
                                    AND M.micr_patente = @PATENTE
                                    and c2.ciud_nombre = @ORIGEN
                                    and c.ciud_nombre = @DESTINO
                                    AND V.viaj_fecha_salida = @FECHA");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@PATENTE", patente));
            this.comandosSql.Parameters.Add(new SqlParameter("@ORIGEN", origen));
            this.comandosSql.Parameters.Add(new SqlParameter("@DESTINO", destino));
            this.comandosSql.Parameters.Add(new SqlParameter("@FECHA", salida));
            this.cnn.Open();
            otro = this.comandosSql.ExecuteScalar();
            result = Convert.ToInt32(otro);
            this.cnn.Close();

            return result;
        }

        public bool registrar_micro(int id_viaje, DateTime fecha_arribo)
        {
            bool Resultado = false;
            int result;

            this.sql = string.Format(@"UPDATE transportados.viajes 
                                    SET viaj_fecha_llegada = @FECHA,
                                    viaj_modificado = SYSDATETIME()
                                    WHERE viaj_id = @VIAJE");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@VIAJE", id_viaje));
            this.comandosSql.Parameters.Add(new SqlParameter("@FECHA", fecha_arribo));
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

        public bool insertar_micro(string tipoServ, Int32 cantButaca, Int32 kgCarga, string marca, string modelo, string patente, Int32 pisos)
        {
            bool Resultado = false;
            Int32 result = 0;

            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[micros](
    [micr_tipo_id],[micr_cant_butacas],[micr_kg_encomienda],[micr_marca],[micr_modelo],[micr_baja],[micr_baja_tecnica],[micro_creado],[micr_patente],[micr_pisos] )
    (select tipo_id,{0},{1},'{2}','{3}',0,0,SYSDATETIME(),'{4}',{5}
        from transportados.tipo_servicio where tipo_nombre = '{6}')"
                , cantButaca, kgCarga, marca, modelo, patente, pisos, tipoServ);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            cnn.Open();

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


        public Int32 contarPasajesVendidos(DateTime inicio, DateTime fin, String patente)
        {
            Int32 result = 0;
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
            Int32 result = 0;
            this.sql = string.Format(@"UPDATE transportados.micros
                                        SET
                                        micr_baja = 1,
                                        micr_fecha_baja = '(0)',
                                        micr_fecha_modificacion = SYSDATETIME()
                                        WHERE micr_patente = '(1)' ", inicio, patente);
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
            Int32 result = 0;
            this.sql = string.Format(@"UPDATE transportados.micros
                                        SET
                                        micr_baja_tecnica = 1,
                                        micr_fecha_baja_tecnica = (0) ,
                                        micr_fecha_regreso = (1),
                                        micr_fecha_modificacion = SYSDATETIME()
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

        public Int32 buscarMicroAlternativo(DateTime inicio, DateTime fin, String patente)
        {

            Int32 result = 0;
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

        public Int32 cargameMicro(String patenteVieja, string patenteNueva)
        {
            Int32 result = 0;
            Object otro;
            SqlCommand cmd = new SqlCommand("transportados.cargarMicro", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@patenteNueva", patenteNueva));
            cmd.Parameters.Add(new SqlParameter("@patenteVieja", patenteVieja));

            this.cnn.Open();
            otro = cmd.ExecuteScalar();
            result = Convert.ToInt32(otro);
            this.cnn.Close();
            return result;
        }

        public Int32 buscarMicro(String patente)
        {
            Int32 result = 0;
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


        public string buscaEmpresaActual(string patente)
        {
            Object otro;
            string result;

            this.sql = string.Format(@"SELECT micr_marca
                                        from transportados.micros
                                        where micr_patente =@PATENTE");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@PATENTE", patente));
            this.cnn.Open();
            otro = this.comandosSql.ExecuteScalar();
            result = Convert.ToString(otro);
            this.cnn.Close();
            return result;
        }

        public bool modificar_micro(string patente, string marca)
        {
            bool Resultado = false;
            Int32 result = 0;
            this.sql = string.Format(@"UPDATE transportados.micros
                                        SET
                                        micr_marca = @MARCA,
                                        micr_fecha_modificacion = SYSDATETIME()
                                        WHERE micr_patente = @PATENTE");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@PATENTE", patente));
            this.comandosSql.Parameters.Add(new SqlParameter("@MARCA", marca));
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

        public bool reemplazarViajes(Int32 microAlterno, string microViejo, string tipo_baja,DateTime fecha, DateTime fechalleg)
        {
            /*PROCESO TRANSPARENTE QUE CAMBIA EL MICRO ASIGNADO POR OTRO*/

            Int32 result = 0;
            bool Resultado = false;
            SqlCommand cmd = new SqlCommand("transportados.reemplaza_micro", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_micro", microAlterno));
            cmd.Parameters.Add(new SqlParameter("@patente", microViejo));
            cmd.Parameters.Add(new SqlParameter("@inicio", fecha));
            cmd.Parameters.Add(new SqlParameter("@fin", fechalleg));
            cmd.Parameters.Add(new SqlParameter("@BAJA", tipo_baja));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();

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

        public bool devolverPasajes(string microViejo, string tipo_baja, DateTime fecha, DateTime fechalleg)
        {
            /*PROCESO TRANSPARENTE QUE DEVUELVE LOS PASAJES*/
            Int32 result = 0;
            bool Resultado = false;
            SqlCommand cmd = new SqlCommand("transportados.devuelvePasajes", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PATENTE", microViejo));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INI", fecha));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN ", fechalleg));
            cmd.Parameters.Add(new SqlParameter("@BAJA", tipo_baja));

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();

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

        public bool devolucionPersonal(Int32 voucher, Int32 codPasaje, string motivo)
        {
            /*PROCESO TRANSPARENTE QUE DEVUELVE LOS PASAJES*/
            Int32 result = 0;
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
            }
            else
            {
                Resultado = false;
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
            
            Int32 result = 0;
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

                public bool modClient(Int32 id, Int32 dni, string nombre, string apellido, string direccion, Int32 telefono, string mail, DateTime fecha_nac)
        {
            bool Resultado = false;
            Int32 result = 0;

            this.sql = string.Format(@"update [GD1C2013].[transportados].[clientes]
                                        set [Cli_Nombre]={1}
                                      ,[Cli_Apellido]={2}
                                      ,[Cli_Dni]={3}
                                      ,[Cli_Dir]={4}
                                      ,[Cli_Telefono]={5}
                                      ,[Cli_Mail]={6}
                                      ,[Cli_Fecha_Nac]=CONVERT(datetime,'{7}',103)
                                      ,[cli_modificado]=SYSDATETIME()
                                        where [Cli_id]={0}", id, dni, nombre, apellido, direccion, telefono, mail, fecha_nac.ToString());
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
        public bool newClient(Int32 dni, string nombre, string apellido, string direccion, Int32 telefono, string mail, DateTime fecha_nac)
        {
            bool Resultado = false;
            Int32 result = 0;

            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[clientes]
                                       ([Cli_Nombre]
                                      ,[Cli_Apellido]
                                      ,[Cli_Dni]
                                      ,[Cli_Dir]
                                      ,[Cli_Telefono]
                                      ,[Cli_Mail]
                                      ,[Cli_Fecha_Nac]
                                      ,[cli_creado]
                                      ,[cli_modificado])
                                       VALUES
                                        ('{0}','{1}',{2},'{3}',{4},'{5}','{6}',SYSDATETIME(),SYSDATETIME())", nombre, apellido, dni, direccion, telefono, mail, fecha_nac.ToString());
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


        public Int32 realizar_compra (Int32 cli_id, Int32 kg, Int32 viaje_id, Int32 cant_butaca,Int32 discount)
        {
            Int32 result = 0;
            Int32 salida=0;
            float total = 0;
            SqlCommand cmd = new SqlCommand("transportados.compra", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@CLI_ID",cli_id));
            cmd.Parameters.Add(new SqlParameter("@VIAJE_ID",viaje_id));
            cmd.Parameters.Add(new SqlParameter("@CANT_BUTACA",cant_butaca));
            cmd.Parameters.Add(new SqlParameter("@CANT_KG",kg));
            cmd.Parameters.Add(new SqlParameter("@CANT_DISCOUNT", discount));
            cmd.Parameters.Add("@compra", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TOTAL", SqlDbType.Real).Direction = ParameterDirection.Output;

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();
            salida = int.Parse(cmd.Parameters["@compra"].Value.ToString());
            total = float.Parse(cmd.Parameters["@TOTAL"].Value.ToString());
            if (result > 0)
            {
                MessageBox.Show("El total de su compra es " + Convert.ToString(total), "Resultado operacion");
                MessageBox.Show("Compra realizada con id " + Convert.ToString(salida), "Resultado operacion");
            }
            else
            {
                
                MessageBox.Show("Ocurrió un error al realizar la compra", "Error");
            }

            this.cnn.Close();
            return salida;


        }

        public void crear_pasaje(Int32 viaje_id, Int32 voucher_id, Int32 butaca_id, Int32 cli_id,Int32 kg, Int32 bonificado,double precio)
        {
            Int32 result = 0;
            Int32 salida=0;
            
            SqlCommand cmd = new SqlCommand("transportados.Compra_pasaje", this.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@VOUCHER_ID", voucher_id));
            cmd.Parameters.Add(new SqlParameter("@VIAJE_ID",viaje_id));
            cmd.Parameters.Add(new SqlParameter("@BUTACA_ID", butaca_id));
            cmd.Parameters.Add(new SqlParameter("@CANT_KG",kg));
            cmd.Parameters.Add(new SqlParameter("@BONIFICADO", bonificado));
            cmd.Parameters.Add(new SqlParameter("@CLIENTE_ID", cli_id));
            cmd.Parameters.Add(new SqlParameter("@PRECIO", precio));
            cmd.Parameters.Add("@PASAJE", SqlDbType.Int).Direction = ParameterDirection.Output;
            

            this.cnn.Open();
            result = cmd.ExecuteNonQuery();
            salida = int.Parse(cmd.Parameters["@PASAJE"].Value.ToString());
           
            if (result > 0)
            {
                
                MessageBox.Show("Se genero el pasaje  " + Convert.ToString(salida), "Resultado operacion");
            }
            else
            {

                MessageBox.Show("Ocurrió un error al generar el pasaje", "Error");
            }

            this.cnn.Close();
  
        }

        public bool check_is_traveling (Int32 clie_id, Int32 viaj_id)
        {
            bool Resultado = true;
            this.sql = string.Format(@"select * from transportados.pasajes
                inner join transportados.viajes v1 on v1.viaj_id=pasa_viaje_id,
                transportados.viajes v2
                where pasa_clie_id={0}
                and v2.viaj_id = {1}
                and (((v2.viaj_fecha_salida < v1.viaj_fecha_llegada or    v2.viaj_fecha_salida < v1.viaj_fecha_llegada_estimada) 
		                and v2.viaj_fecha_salida > v1.viaj_fecha_salida) or
                      ((v2.viaj_fecha_llegada > v1.viaj_fecha_salida or  v2.viaj_fecha_llegada_estimada > v1.viaj_fecha_salida) 
                      and  v2.viaj_fecha_salida < v1.viaj_fecha_salida))", clie_id, viaj_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = false;
            }

            this.cnn.Close();
            return Resultado;
        }

        public bool check_viaje_dup (Int32 clie_id, Int32 viaj_id)
        {
            bool Resultado = true;
            this.sql = string.Format(@"select * from transportados.pasajes
                where pasa_clie_id={0}
                and pasa_viaje_id = {1}
                ", clie_id, viaj_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = false;
            }

            this.cnn.Close();
            return Resultado;
        }

        public bool actualizar_y_validar_puntos(int id_viaje)
        {
            bool Resultado = false;
            int result;

            this.comandosSql = new SqlCommand("transportados.actualiza_puntos", this.cnn);
            this.comandosSql.CommandType = CommandType.StoredProcedure;
            this.comandosSql.Parameters.Add(new SqlParameter("@VIAJE", id_viaje));
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

        public double getPasjasjePrecio (Int32 viaje_id)
        {
            double Resultado = 0;
            this.sql = string.Format(@"
                select reco_precio_base*tipo_porcentaje as 'Precio'
                from transportados.viajes 
                inner join transportados.recorrido on viaj_recorrido=reco_id
                inner join transportados.tipo_servicio on reco_tipo_id=tipo_id
                where viaj_id={0};
                ", viaje_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Reg.Read();
                Resultado = Convert.ToDouble(Reg["Precio"].ToString());
            }

            this.cnn.Close();
            return Resultado;
        }
        public double getEncomiendaPrecio(Int32 viaje_id)
        {
            double Resultado = 0;
            this.sql = string.Format(@"
                select reco_precio_encomienda*tipo_porcentaje as 'Precio'
                from transportados.viajes 
                inner join transportados.recorrido on viaj_recorrido=reco_id
                inner join transportados.tipo_servicio on reco_tipo_id=tipo_id
                where viaj_id={0};
                ", viaje_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Reg.Read();
                Resultado = Convert.ToDouble(Reg["Precio"].ToString());
            }

            this.cnn.Close();
            return Resultado;
        }

    }
}

