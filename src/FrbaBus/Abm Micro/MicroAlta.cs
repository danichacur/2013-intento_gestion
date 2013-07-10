using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroAlta : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;
        protected string mensaje;

        public static MicroAlta Malta;
        public MicroAlta()
        {
            InitializeComponent();
            MicroAlta.Malta = this;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            funciones patente = new funciones();
            if (!patente.noExistePatente(patenteBox.Text))
            {
                MessageBox.Show("La patente ingresada ya existe!");
            }
            else
            {
                insertar_micro(servicioCombo.Text, Convert.ToInt32(butacaCombo.Value), Convert.ToInt32(kgText.Text), marcaCombo.Text, modeloBox.Text, patenteBox.Text, Convert.ToInt32(textBox1.Text));
                MessageBox.Show(mensaje);
            }

        }

        public void insertar_micro(string tipoServ,int cantButaca,int kgCarga, string marca, string modelo, string patente, int pisos )
        {
            //bool Resultado = false;
            int result = 0;
            this.cadenaConexion = (@"Data Source=PC_PRUEBA\SQLSERVER2008;Initial Catalog =GD1C2013; integrated security =true;User Id=gd;Password=gd2013;");
            this.cnn = new SqlConnection(cadenaConexion);
            this.sql = string.Format(@"INSERT INTO [GD1C2013].[transportados].[micros](
    [micr_tipo_id],[micr_cant_butacas],[micr_kg_encomienda],[micr_marca],[micr_modelo],[micr_baja],[micr_baja_tecnica],[micro_creado],[micr_patente],[micr_pisos] )
    (select tipo_id,{0},{1},'{2}','{3}',0,0,SYSDATETIME(),'{4}',{5}
        from transportados.tipo_servicio where tipo_nombre = '(6)')"
                ,cantButaca,kgCarga,marca,modelo,patente,pisos,tipoServ);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            cnn.Open();

            result = this.comandosSql.ExecuteNonQuery();
            if (result > 0)
            {
                //Resultado = true;
                this.mensaje = "Datos correctos";
            }
            else
            {
                //Resultado = false;
                this.mensaje = "Mmmm Lo siento, no se pudo crear el micro";
            }

            this.cnn.Close();
        }

        private void MicroAlta_Load(object sender, EventArgs e)
        {
            llenacombobox();
        }

         public void llenacombobox()
        {
            Formularios combos = new Formularios();
            DataSet servicio = combos.llenaComboboxTipo();
            //DataSet modelo = combos.llenaComboboxModelo();
            DataSet marca = combos.llenaComboboxMarca();
            //da.Fill(ds_origen, "Ciudad");
            marcaCombo.DataSource = marca.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            marcaCombo.DisplayMember = "micr_marca";
            marcaCombo.ValueMember = "micr_marca";
            
            servicioCombo.DataSource = servicio.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            servicioCombo.DisplayMember = "tipo_nombre";
            servicioCombo.ValueMember = "tipo_id";
            //int value = ((KeyValuePair<string, int>)comboBox1.SelectedItem).Value;
            //MessageBox.Show(value.ToString());

        }

    }
}
