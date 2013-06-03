using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaBus
{
    class operaciones:conexion
    {   
      private int tipoServ;
      private int cantButaca;
      private int kgCarga;
      private string marca; 
      private int modelo;
      private string patente;
      private int pisos;
      
      public MicroInsert()
        {
          tipoServ =  -1 ; 
          cantButaca= -1; 
          kgCarga= -1; 
          marca= string.Empty; 
          modelo= -1; 
          patente= string.Empty; 
          pisos = 0;
          this.sql = string.Empty;
        }
        public int TipoServ
        {
            get { return this.tipoServ; }
            set { this.tipoServ = value; }
        }
        public int CantButaca
        {
            get {return this.cantButaca; }
            set { this.cantButaca = value; }
        }
        public int KgCarga
        {
            get { return this.kgCarga; }
            set { this.kgCarga = value; }
        }
        public string Marca
        {
            get {return this.marca; }
            set { this.marca = value; }
        }
        public int Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public string Patente
        {
            get {return this.patente; }
            set { this.patente = value; }
        }
        public int Pisos
        {
            get { return this.pisos; }
            set { this.pisos = value; }
        }
        
      

    }
}
