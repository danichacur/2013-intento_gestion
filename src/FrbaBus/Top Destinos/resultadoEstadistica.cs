using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Top_Destinos
{
    public partial class resultadoEstadistica : Form
    {
        public DataSet ResultadoLista;

        public resultadoEstadistica()
        {
            InitializeComponent();
        }

        private void resultadoEstadistica_Load(object sender, EventArgs e)
        {

            if (ResultadoLista.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ResultadoLista.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("No existen resultados para el periodo pedido", "Estadisticas");
                this.Close();
            }
        }
    }
}
