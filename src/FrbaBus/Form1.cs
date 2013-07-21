using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        public string login_usu;
        public Inicio parentForm;

        public Form1()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
        
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.Login_usu login = new Login.Login_usu();
            login.Show();
        }

        private void CiudadListarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ciudades.Form1 CiudadListar = new Ciudades.Form1();
            CiudadListar.MdiParent = this;
            CiudadListar.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Recorrido.Listar listarRecorrido = new Abm_Recorrido.Listar();
            listarRecorrido.MdiParent = this;
            listarRecorrido.Show();
        }

        private void crearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Abm_Micro.MicroAlta microAlta = new Abm_Micro.MicroAlta();
            microAlta.MdiParent = this;
            microAlta.Show();
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Abm_Micro.modificacion microMod01 = new Abm_Micro.modificacion();
            microMod01.MdiParent = this;
            microMod01.Show();
        }

        private void listar_micro_Click(object sender, EventArgs e)
        {
            // private void CiudadListarToolStripMenuItem_Click(object sender, EventArgs e)

            Abm_Micro.MicroListar MicroListar = new Abm_Micro.MicroListar();
            MicroListar.MdiParent = this;
            MicroListar.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            funciones Func = new funciones();
            SqlDataReader list_func = Func.getFuncID(login_usu);
            while (list_func.Read())
            {
                string menu = list_func.GetString(1);
                var m = menuStrip1.Items.Find(menu, true);
                var ciudad = Ciudad.DropDownItems.Find(menu, true);
                var recorrido = Recorrido.DropDownItems.Find(menu, true);
                var micros = Micros.DropDownItems.Find(menu, true);
                var viaje = Viaje.DropDownItems.Find(menu, true);
                var pasaje = Pasaje.DropDownItems.Find(menu, true);
                var puntos = Puntos.DropDownItems.Find(menu, true);
                var usuarios = Usuarios.DropDownItems.Find(menu, true);

                if (ciudad.Count() > 0)
                {
                    m = ciudad;
                }
                else if (recorrido.Count() > 0)
                {
                    m = recorrido;
                }
                else if (micros.Count() > 0)
                {
                    m = micros;
                }
                else if (viaje.Count() > 0)
                {
                    m = viaje;
                }
                else if (pasaje.Count() > 0)
                {
                    m = pasaje;
                }
                else if (puntos.Count() > 0)
                {
                    m = puntos;
                }
                else if (usuarios.Count() > 0)
                {
                    m = usuarios;
                }

 
                    
                var o = m.ToList();
                foreach (var p in o)
                {
                    p.Visible = true;
                }
            }
        } 

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ciudades.CiudadCrear CiudCreate = new ciudades.CiudadCrear();
            CiudCreate.MdiParent = this;
            CiudCreate.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ciudades.CiudadBuscar CiudMod = new ciudades.CiudadBuscar();
            CiudMod.MdiParent = this;
            CiudMod.Show();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abm_Recorrido.RecorridoCrear RecoCreate = new Abm_Recorrido.RecorridoCrear();
            RecoCreate.MdiParent = this;
            RecoCreate.Show();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abm_Recorrido.Recorrido_buscar RecoMod = new Abm_Recorrido.Recorrido_buscar();
            RecoMod.MdiParent = this;
            RecoMod.Show();
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarViaje.Generar genViaj = new GenerarViaje.Generar();
            genViaj.MdiParent = this;
            genViaj.Show();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GenerarViaje.ListarViajes listViaj = new GenerarViaje.ListarViajes();
            listViaj.MdiParent = this;
            listViaj.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancelar_Viaje.Form1 cancViaj = new Cancelar_Viaje.Form1();
            cancViaj.MdiParent = this;
            cancViaj.Show();
        }

        //private void modificadoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    GenerarViaje.modificar modViaj = new GenerarViaje.modificar();
        //    modViaj.MdiParent = this;
        //    modViaj.Show();
        //}

        private void registrarLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_LLegada_Micro.Form1 RegMic = new Registrar_LLegada_Micro.Form1();
            RegMic.MdiParent = this;
            RegMic.Show();
        }

        private void listarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_usuario.listRol ListRol = new func_usuario.listRol();
            ListRol.MdiParent = this;
            ListRol.Show();
        }

        private void listarFuncionalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_usuario.listFunc ListFunc = new func_usuario.listFunc();
            ListFunc.MdiParent = this;
            ListFunc.Show();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_usuario.listarUsuario ModUsu = new func_usuario.listarUsuario();
            ModUsu.MdiParent = this;
            ModUsu.Show();
        }

        private void anulacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancelar_Viaje.Form1 CancelViaje = new Cancelar_Viaje.Form1();
            CancelViaje.MdiParent = this;
            CancelViaje.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Compra_de_Pasajes.Buscar_viaje Comprar = new Compra_de_Pasajes.Buscar_viaje();
            Comprar.MdiParent = this;
            Comprar.admin = true;
            Comprar.Show();
        }

        private void CiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                parentForm.Close();
                return;
            }

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    parentForm.Close();
                    break;
            }
        }

        private void consulta_puntos_Click(object sender, EventArgs e)
        {
            Canje_de_Ptos.canje puntosCanje = new Canje_de_Ptos.canje();
            puntosCanje.admin = true;
            puntosCanje.MdiParent = this;
            puntosCanje.Show();
        }


    }
}
