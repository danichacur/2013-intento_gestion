using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaBus
{
    class conexion
    {
        public string cadenaConexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;
        protected string mensaje;


        public conexion()
        {
            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(this.cadenaConexion);

        }
        public string Mensaje
        { 
            get
            {
                return this.mensaje;
            }

        }
    }
}
