using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.Form1 login = new Login.Form1();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)CiudadListarToolStripMenuItem).Visible = true;
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ciudades.CiudadCrear CiudCreate = new ciudades.CiudadCrear();
            CiudCreate.MdiParent = this;
            CiudCreate.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ciudades.CiudadModificar CiudMod = new ciudades.CiudadModificar();
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
            Abm_Recorrido.RecorridoModificar RecoMod = new Abm_Recorrido.RecorridoModificar();
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
            GenerarViaje.Form1 listViaj = new GenerarViaje.Form1();
            listViaj.MdiParent = this;
            listViaj.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancelar_Viaje.Form1 cancViaj = new Cancelar_Viaje.Form1();
            cancViaj.MdiParent = this;
            cancViaj.Show();
        }

        private void modificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarViaje.modificar modViaj = new GenerarViaje.modificar();
            modViaj.MdiParent = this;
            modViaj.Show();
        }

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
            func_usuario.modUsu ModUsu = new func_usuario.modUsu();
            ModUsu.MdiParent = this;
            ModUsu.Show();
        }

        private void anulacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }   
    }
}
