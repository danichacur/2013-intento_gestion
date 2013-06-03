using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoCrear : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;

        public RecorridoCrear()
        {
            InitializeComponent();
        }

        private void RecorridoCrear_Load(object sender, EventArgs e)
        {
            llenacombobox();
        }
        public void llenacombobox()
        {
            
            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(cadenaConexion);
            this.sql = string.Format(@"select * from ciudades");
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("select ciud_nombre from transportados.ciudad", this.cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "Ciudad");
            da.Fill(ds1, "Ciudad");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.ValueMember = "ciud_nombre";
            comboBox2.DataSource = ds1.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox2.ValueMember = "ciud_nombre";
        }

    }
}
