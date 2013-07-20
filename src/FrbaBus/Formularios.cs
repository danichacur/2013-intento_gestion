using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FrbaBus
{
    class Formularios : conexion
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

        public DataSet llenaComboboxRecorrido_micro(Int32 recorrido_id)
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
        public DataSet listarRecorrido(string ciudad)
        {
            this.sql = string.Format(@"select 
                                        r.reco_id as 'ID_recorrido'
                                        ,c1.ciud_nombre as 'Ciudad Origen'
                                        ,c2.ciud_nombre as 'Ciudad Destino'
                                        ,t.tipo_nombre as 'Tipo de servicio'
                                        ,r.reco_precio_base as 'Precio Base Pasaje'
                                        ,r.reco_precio_encomienda as 'Precio Base Encomienda'
                                        ,r.reco_baja as 'dado de baja'
                                      from transportados.recorrido r
                                        left outer join transportados.ciudad c1 on r.reco_id_ciudad_destino=c1.ciud_id
                                        left outer join transportados.ciudad c2 on r.reco_id_ciudad_origen=c2.ciud_id
                                        left outer join transportados.tipo_servicio t on r.reco_tipo_id=t.tipo_id
                                        where c1.ciud_nombre like'%{0}%'
                                        or c2.ciud_nombre like '%{0}%';", ciudad);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "ID_recorrido");
            return ds;
        }
        public DataSet MicroLista()
        {
            this.sql = string.Format(@"SELECT DISTINCT
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
                      ,[micr_fecha_modificacion] as 'Fecha de modificación'
                  FROM [GD1C2013].[transportados].[micros] M
                  INNER JOIN transportados.tipo_servicio T ON T.tipo_id = M.micr_tipo_id");
               //     where M.micr_patente = '(0)'", patente);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            da.Fill(ds, "Patente");
            return ds;

        }

        public DataSet ViajesLista()
        {

            this.sql = string.Format(@"SELECT DISTINCT
		                            c2.ciud_nombre as 'Ciudad Origen',
		                            c.ciud_nombre as 'Ciudad Destino',
	                               [viaj_fecha_salida] as 'Fecha de salida'
                                  ,[viaj_fecha_llegada] as 'Fecha de llegada'
                                  ,[viaj_fecha_llegada_estimada] as 'Fecha estimada de llegada'
                                  ,M.micr_patente as 'Patente'
                                  , M.micr_marca as 'Empresa del micro'
                                  , M.micr_modelo as 'Modelo del micro'
                                  ,M.micr_pisos as 'Cantidad de pisos'
  	                              ,T.tipo_nombre as 'Tipo de servicio'
                                  ,[viaj_creado] as 'Fecha de creacion'
                                  ,[viaj_modificado] as 'Fecha de modificacion'
                                  ,[viaj_butacas_libres] as 'Cantidad de butacas libres'
                                  ,[viaj_KG_disponible] as 'Cantidad de KG disponibles'
                              FROM [GD1C2013].[transportados].[viajes] V
                              INNER JOIN transportados.micros M  ON M.micr_id = V.viaj_micro
                              INNER JOIN transportados.recorrido R ON R.reco_id = V.viaj_recorrido
                              INNER JOIN transportados.tipo_servicio T ON M.micr_tipo_id = T.tipo_id
                              inner join transportados.ciudad c on c.ciud_id = r.reco_id_ciudad_destino
                              inner join transportados.ciudad c2 on c2.ciud_id = r.reco_id_ciudad_origen");
                               // where c2.ciud_nombre like '%(0)%'", viaje);
           
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            da.Fill(ds, "Patente");
            return ds;

        }
        public DataSet ViajesListaBusqueda(Int32 ciud_origen,Int32 ciud_destino,string fecha)
        {

            this.sql = string.Format(@"SELECT 
                                    v.viaj_id as Viaje_id,
		                            c2.ciud_nombre as Ciudad_Origen,
		                            c.ciud_nombre as Ciudad_Destino,
	                               [viaj_fecha_salida]
                                  ,[viaj_fecha_llegada_estimada]
  	                              ,T.tipo_nombre
                                    ,viaj_butacas_libres
                                  ,viaj_KG_disponible
                              FROM [GD1C2013].[transportados].[viajes] V
                              INNER JOIN transportados.micros M  ON M.micr_id = V.viaj_micro
                              INNER JOIN transportados.recorrido R ON R.reco_id = V.viaj_recorrido
                              INNER JOIN transportados.tipo_servicio T ON M.micr_tipo_id = T.tipo_id
                              inner join transportados.ciudad c on c.ciud_id = r.reco_id_ciudad_destino
                              inner join transportados.ciudad c2 on c2.ciud_id = r.reco_id_ciudad_origen
                              where c2.ciud_id={0}
                              and c.ciud_id={1}
                              and cast(viaj_fecha_salida As Date) = cast(CONVERT(datetime,'{2}',103)As Date)
                              ", ciud_origen, ciud_destino, fecha);
            
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            da.Fill(ds, "Ciudad_Origen");
            return ds;

        }

        public DataSet ListarDatosMicro()
        {

            this.sql = string.Format(@"SELECT DISTINCT
                                     M.micr_patente as 'Patente del micro',       
	                               [viaj_fecha_salida] as 'Fecha de salida',
		                            c2.ciud_nombre as 'Ciudad Origen',
		                            c.ciud_nombre as 'Ciudad Destino'
  	                              ,T.tipo_nombre as 'Tipo de servicio'
                                  , M.micr_marca as 'Empresa del micro'
                                  , M.micr_modelo as 'Modelo del micro'
                                  ,M.micr_pisos as 'Cantidad de pisos'
                              FROM [GD1C2013].[transportados].[viajes] V
                              INNER JOIN transportados.micros M  ON M.micr_id = V.viaj_micro
                              INNER JOIN transportados.recorrido R ON R.reco_id = V.viaj_recorrido
                              INNER JOIN transportados.tipo_servicio T ON M.micr_tipo_id = T.tipo_id
                              inner join transportados.ciudad c on c.ciud_id = r.reco_id_ciudad_destino
                              inner join transportados.ciudad c2 on c2.ciud_id = r.reco_id_ciudad_origen");
            // where c2.ciud_nombre like '%(0)%'", viaje);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            da.Fill(ds, "Patente");
            return ds;

        }


        public DataSet listarCiudad(string ciudad)
        {
            this.sql = string.Format(@"select ciud_nombre as 'Nombre'
                                            ,ciud_creado as 'Fecha de creacion'
                                            ,ciud_modificado as 'Fecha de Modificacion'
                                            ,case ciud_baja 
                                            	when 0 then 'NO'
	                                            else 'SI' 
                                            end as 'Dada de Baja' 
                                            from transportados.ciudad
                                            where ciud_nombre like '%{0}%'",ciudad);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Nombre");
            return ds;
        }

        public DataSet listarFuncion (string funcion)
        {
            this.sql = string.Format(@"SELECT  [func_name] as 'Nombre'
                                      ,[func_creado] as 'Creado'
                                      ,[func_modificado] as 'Modificado'
                                      FROM [GD1C2013].[transportados].[funcionalidad]
                                      where func_name like '%{0}%'", funcion);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Nombre");
            return ds;
        }
        public DataSet listarRol(string rol)
        {
            this.sql = string.Format(@"SELECT [rol_nombre] as 'Nombre'
                                      ,[rol_creado] as 'Creado'
                                      ,[rol_modificado] as 'Modificado'
                                      ,[rol_borrado] as 'Borrado'
                                      FROM [GD1C2013].[transportados].[Rol]
                                      where rol_nombre like '%{0}%'", rol);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Nombre");
            return ds;
        }
        public DataSet RolxFunc(string rol_func)
        {
            this.sql = string.Format(@"SELECT [rol_nombre] as 'Rol'
                              ,func_name as 'Funcionalidad'
                              FROM [GD1C2013].[transportados].[Rol]
                              left outer join transportados.Rol_funcionalidad on rol_id=rolf_rol_id
                              left outer join transportados.funcionalidad on rolf_func_id=func_id
                              where rol_nombre like '%{0}%'", rol_func);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Nombre");
            return ds;
        }
        public DataSet ListarUser (string user)
        {
            this.sql = string.Format(@"SELECT TOP 1000 [usua_username] as 'Usuario'
                                        ,isnull(rol_nombre,'No Creado') as 'Rol'
                                        ,rolu_creado as 'Creacion'
                                        ,rolu_modificado as 'Modificacion'
                                          FROM [GD1C2013].[transportados].[usuario]
                                          left outer join [GD1C2013].[transportados].rol_usuario on rolu_user_id=usua_id
                                          left outer join [GD1C2013].[transportados].Rol on rol_id =rolu_rol_id
                                          where usua_username like '%{0}%'", user);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Nombre");
            return ds;
        }

        public DataSet llenaComboboxFunc(string rol)
        {
            this.sql = string.Format(@"select func_id,func_nombre
                                        from transportados.funcionalidad
                                        where func_id not in (select rolf_func_id
                                        from transportados.Rol_funcionalidad
                                        left outer join transportados.Rol on rolf_rol_id=rol_id
                                        where rol_nombre ={0})", rol);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            if (da.TableMappings.Count > 0)
            {
                da.Fill(ds, "func_nombre");
            }
          
            return ds;
        }

                public SqlDataReader datos_user(Int32 numero)
        {
            
            this.sql = string.Format(@"SELECT [Cli_id]
                                      ,[Cli_Nombre]
                                      ,[Cli_Apellido]
                                      ,[Cli_Dni]
                                      ,[Cli_Dir]
                                      ,[Cli_Telefono]
                                      ,[Cli_Mail]
                                      ,[Cli_Fecha_Nac]
                                  FROM [GD1C2013].[transportados].[clientes]
                                    where Cli_Dni = {0}", numero);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows )
            {
                return Reg;
            }
            else
            {
                return null;
            }

            
        }
        public DataSet llenarComboButaca(Int32 viaje_id)
        {
            this.sql = string.Format(@"
                select buta_id
                ,'butaca: ' 
                +  CAST(buta_numero AS VARCHAR(10))
                + ' Ubicacion:'
                + case buta_pasillo 
                    when 1 then ' Pasillo' 
                    else ' Ventanilla' 
                    end
                 + ' piso: ' + CAST(buta_piso AS VARCHAR(10)) 
                 as 'Descripcion' 
                from transportados.viajes
                left outer join transportados.butaca on buta_micro_id=viaj_micro
                where viaj_id= {0}
                and buta_id not in (select pasa_butaca_id 
                    from transportados.pasajes 
                    where pasa_viaje_id=viaj_id 
                    and pasa_kg_encomienda <> 0)", viaje_id);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "Descripcion");
            return ds;
        }
        public SqlDataReader getButacaEncomienda(Int32 viaje_id)
        {
            this.sql = string.Format(@"  select buta_id from transportados.viajes
                                      left outer join transportados.butaca on buta_micro_id=viaj_micro
                                      where viaj_id={0}
                                      and buta_piso=0", viaje_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            return Reg;
        }

    }
}

