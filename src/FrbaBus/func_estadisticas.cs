using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FrbaBus
{
    class func_estadisticas:conexion
    {
        public DataSet dataEstadisticaDestinos(int year, int sem)
        {
            this.sql = string.Format(@"
              select top 5 ciud_nombre,Año,Semestre,Cantidad from transportados.destino_view
              inner join transportados.ciudad on ciud_id = ciudad
              where Semestre={0}
              and Año={1}
              order by cantidad desc
               ", sem,year);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "ciud_nombre");
            return ds;
        }

        public DataSet dataEstadisticaMicroVacio(int year, int sem)
        {
            this.sql = string.Format(@"
              select top 5 ciud_nombre,Año,Semestre,Cantidad from transportados.destinoMicroVacio_view
              inner join transportados.ciudad on ciud_id = ciudad
              where Semestre={0}
              and Año={1}
              order by cantidad desc
               ", sem,year);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "ciud_nombre");
            return ds;
        }

        public DataSet dataEstadisticaPasajeCancelado(int year, int sem)
        {
            this.sql = string.Format(@"
              select top 5 ciud_nombre,Año,Semestre,Cantidad from transportados.destinoPasajeCancelado_view
              inner join transportados.ciudad on ciud_id = ciudad
              where Semestre={0}
              and Año={1}
              order by cantidad desc
               ", sem, year);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "ciud_nombre");
            return ds;
        }

        public DataSet dataEstadisticaClientes(int year, int sem)
        {
            this.sql = string.Format(@"
              select top 5 Año,Semestre,Cli_Nombre as 'Nombre',Cli_Apellido as 'Apellido',Cli_Dni as 'DNI',Puntos_Acumulados,Puntos_usados from transportados.puntosClientes_view
              inner join transportados.clientes  on Cli_id=punt_clie_id
              where Semestre={0}
              and Año={1}
              order by Puntos_Acumulados desc
               ", sem, year);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "punt_clie_id");
            return ds;
        }
        public DataSet dataEstadisticaMicrosBaja(int year, int sem)
        {
            this.sql = string.Format(@"
              select top 5 micr_patente,Cantidad_dias,Año,Semestre from transportados.MicrosView
              where Semestre={0}
              and Año={1}
              order by Cantidad_Dias desc
               ", sem, year);

            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "micr_patente");
            return ds;
        }
    }
}
