using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class BuscarButaca : Form
    {
        public int cantidad;
        public int kg;
        public List<string> pasaje_cli_id = new List<string>();
        public BuscarButaca()
        {
            InitializeComponent();
        }



        private void BuscarButaca_Load(object sender, EventArgs e)
        {

        }
    }
}
