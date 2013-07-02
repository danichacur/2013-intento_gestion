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
    }
}
