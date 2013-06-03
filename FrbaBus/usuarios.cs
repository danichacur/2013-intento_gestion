using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaBus
{
    class Usuarios:conexion
    {
        private string usuario;
        private string contraseña;

        public Usuarios()
        {
            usuario = string.Empty;
            contraseña = string.Empty;
            this.sql = string.Empty;
        }
        /*public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }*/
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Contraseña
        {
            get {return this.contraseña; }
            set { this.contraseña = value; }
        }
        public bool Buscar()
        {
            bool Resultado = false;
            this.sql = string.Format(@"select usua_id from transportados.usuario where usua_username='{0}' and usua_password = '{1}'", this.usuario, this.contraseña);
            this.comandosSql = new SqlCommand(this.sql,this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            if (Reg.Read())
            {
                Resultado = true;
                this.mensaje = "Bienvenido Datos correctos";
            }
            else
            {
                this.mensaje= "Mmmm Lo siento";
            }
            this.cnn.Close();
            return Resultado;
        }
    }
}
