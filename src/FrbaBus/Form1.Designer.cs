namespace FrbaBus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Ciudad = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_ciudad = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar_ciudad = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_ciudad = new System.Windows.Forms.ToolStripMenuItem();
            this.Recorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_recorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar_recorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_recorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.Micros = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_micro = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar_micro = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_micro = new System.Windows.Forms.ToolStripMenuItem();
            this.registrar_llegada = new System.Windows.Forms.ToolStripMenuItem();
            this.Viaje = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_viaje = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_viaje = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar_viaje = new System.Windows.Forms.ToolStripMenuItem();
            this.Pasaje = new System.Windows.Forms.ToolStripMenuItem();
            this.pasaje_generar = new System.Windows.Forms.ToolStripMenuItem();
            this.pasaje_anular = new System.Windows.Forms.ToolStripMenuItem();
            this.Puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta_puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_roles = new System.Windows.Forms.ToolStripMenuItem();
            this.listar_funcionalidades = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar_usuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ciudad,
            this.Recorrido,
            this.Micros,
            this.Viaje,
            this.Pasaje,
            this.Puntos,
            this.Usuarios});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Ciudad
            // 
            this.Ciudad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_ciudad,
            this.modificar_ciudad,
            this.listar_ciudad});
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Size = new System.Drawing.Size(63, 20);
            this.Ciudad.Text = "Ciudades";
            this.Ciudad.Visible = false;
            this.Ciudad.Click += new System.EventHandler(this.CiudadToolStripMenuItem_Click);
            // 
            // crear_ciudad
            // 
            this.crear_ciudad.Name = "crear_ciudad";
            this.crear_ciudad.Size = new System.Drawing.Size(128, 22);
            this.crear_ciudad.Text = "Crear";
            this.crear_ciudad.Visible = false;
            this.crear_ciudad.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // modificar_ciudad
            // 
            this.modificar_ciudad.Name = "modificar_ciudad";
            this.modificar_ciudad.Size = new System.Drawing.Size(128, 22);
            this.modificar_ciudad.Text = "Modificar";
            this.modificar_ciudad.Visible = false;
            this.modificar_ciudad.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // listar_ciudad
            // 
            this.listar_ciudad.Name = "listar_ciudad";
            this.listar_ciudad.Size = new System.Drawing.Size(128, 22);
            this.listar_ciudad.Text = "Listar";
            this.listar_ciudad.Visible = false;
            this.listar_ciudad.Click += new System.EventHandler(this.CiudadListarToolStripMenuItem_Click);
            // 
            // Recorrido
            // 
            this.Recorrido.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_recorrido,
            this.modificar_recorrido,
            this.listar_recorrido});
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(65, 20);
            this.Recorrido.Text = "Recorrido";
            this.Recorrido.Visible = false;
            // 
            // crear_recorrido
            // 
            this.crear_recorrido.Name = "crear_recorrido";
            this.crear_recorrido.Size = new System.Drawing.Size(128, 22);
            this.crear_recorrido.Text = "Crear";
            this.crear_recorrido.Visible = false;
            this.crear_recorrido.Click += new System.EventHandler(this.crearToolStripMenuItem1_Click);
            // 
            // modificar_recorrido
            // 
            this.modificar_recorrido.Name = "modificar_recorrido";
            this.modificar_recorrido.Size = new System.Drawing.Size(128, 22);
            this.modificar_recorrido.Text = "Modificar";
            this.modificar_recorrido.Visible = false;
            this.modificar_recorrido.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // listar_recorrido
            // 
            this.listar_recorrido.Name = "listar_recorrido";
            this.listar_recorrido.Size = new System.Drawing.Size(128, 22);
            this.listar_recorrido.Text = "Listar";
            this.listar_recorrido.Visible = false;
            this.listar_recorrido.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // Micros
            // 
            this.Micros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_micro,
            this.modificar_micro,
            this.listar_micro,
            this.registrar_llegada});
            this.Micros.Name = "Micros";
            this.Micros.Size = new System.Drawing.Size(49, 20);
            this.Micros.Text = "Micros";
            this.Micros.Visible = false;
            // 
            // crear_micro
            // 
            this.crear_micro.Name = "crear_micro";
            this.crear_micro.Size = new System.Drawing.Size(166, 22);
            this.crear_micro.Text = "Crear";
            this.crear_micro.Visible = false;
            this.crear_micro.Click += new System.EventHandler(this.crearToolStripMenuItem2_Click);
            // 
            // modificar_micro
            // 
            this.modificar_micro.Name = "modificar_micro";
            this.modificar_micro.Size = new System.Drawing.Size(166, 22);
            this.modificar_micro.Text = "Modificar";
            this.modificar_micro.Visible = false;
            this.modificar_micro.Click += new System.EventHandler(this.modificarToolStripMenuItem2_Click);
            // 
            // listar_micro
            // 
            this.listar_micro.Name = "listar_micro";
            this.listar_micro.Size = new System.Drawing.Size(166, 22);
            this.listar_micro.Text = "Listar";
            this.listar_micro.Visible = false;
            this.listar_micro.Click += new System.EventHandler(this.listar_micro_Click);
            // 
            // registrar_llegada
            // 
            this.registrar_llegada.Name = "registrar_llegada";
            this.registrar_llegada.Size = new System.Drawing.Size(166, 22);
            this.registrar_llegada.Text = "Registrar llegada";
            this.registrar_llegada.Visible = false;
            this.registrar_llegada.Click += new System.EventHandler(this.registrarLlegadaToolStripMenuItem_Click);
            // 
            // Viaje
            // 
            this.Viaje.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_viaje,
            this.listar_viaje,
            this.modificar_viaje});
            this.Viaje.Name = "Viaje";
            this.Viaje.Size = new System.Drawing.Size(42, 20);
            this.Viaje.Text = "Viaje";
            this.Viaje.Visible = false;
            // 
            // crear_viaje
            // 
            this.crear_viaje.Name = "crear_viaje";
            this.crear_viaje.Size = new System.Drawing.Size(124, 22);
            this.crear_viaje.Text = "Generar";
            this.crear_viaje.Visible = false;
            this.crear_viaje.Click += new System.EventHandler(this.generarToolStripMenuItem_Click);
            // 
            // listar_viaje
            // 
            this.listar_viaje.Name = "listar_viaje";
            this.listar_viaje.Size = new System.Drawing.Size(124, 22);
            this.listar_viaje.Text = "Listar";
            this.listar_viaje.Visible = false;
            this.listar_viaje.Click += new System.EventHandler(this.listarToolStripMenuItem2_Click);
            // 
            // modificar_viaje
            // 
            this.modificar_viaje.Name = "modificar_viaje";
            this.modificar_viaje.Size = new System.Drawing.Size(124, 22);
            // 
            // Pasaje
            // 
            this.Pasaje.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasaje_generar,
            this.pasaje_anular});
            this.Pasaje.Name = "Pasaje";
            this.Pasaje.Size = new System.Drawing.Size(51, 20);
            this.Pasaje.Text = "Pasaje";
            this.Pasaje.Visible = false;
            // 
            // pasaje_generar
            // 
            this.pasaje_generar.Name = "pasaje_generar";
            this.pasaje_generar.Size = new System.Drawing.Size(131, 22);
            this.pasaje_generar.Text = "Compra";
            this.pasaje_generar.Visible = false;
            this.pasaje_generar.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // pasaje_anular
            // 
            this.pasaje_anular.Name = "pasaje_anular";
            this.pasaje_anular.Size = new System.Drawing.Size(131, 22);
            this.pasaje_anular.Text = "Anulacion";
            this.pasaje_anular.Visible = false;
            this.pasaje_anular.Click += new System.EventHandler(this.anulacionToolStripMenuItem_Click);
            // 
            // Puntos
            // 
            this.Puntos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consulta_puntos});
            this.Puntos.Name = "Puntos";
            this.Puntos.Size = new System.Drawing.Size(52, 20);
            this.Puntos.Text = "Puntos";
            this.Puntos.Visible = false;
            // 
            // consulta_puntos
            // 
            this.consulta_puntos.Name = "consulta_puntos";
            this.consulta_puntos.Size = new System.Drawing.Size(152, 22);
            this.consulta_puntos.Text = "Canjear";
            this.consulta_puntos.Visible = false;
            this.consulta_puntos.Click += new System.EventHandler(this.consulta_puntos_Click);
            // 
            // Usuarios
            // 
            this.Usuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listar_roles,
            this.listar_funcionalidades,
            this.modificar_usuario});
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(60, 20);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.Visible = false;
            // 
            // listar_roles
            // 
            this.listar_roles.Name = "listar_roles";
            this.listar_roles.Size = new System.Drawing.Size(188, 22);
            this.listar_roles.Text = "Listar Roles";
            this.listar_roles.Visible = false;
            this.listar_roles.Click += new System.EventHandler(this.listarRolesToolStripMenuItem_Click);
            // 
            // listar_funcionalidades
            // 
            this.listar_funcionalidades.Name = "listar_funcionalidades";
            this.listar_funcionalidades.Size = new System.Drawing.Size(188, 22);
            this.listar_funcionalidades.Text = "Listar funcionalidades";
            this.listar_funcionalidades.Visible = false;
            this.listar_funcionalidades.Click += new System.EventHandler(this.listarFuncionalidadesToolStripMenuItem_Click);
            // 
            // modificar_usuario
            // 
            this.modificar_usuario.Name = "modificar_usuario";
            this.modificar_usuario.Size = new System.Drawing.Size(188, 22);
            this.modificar_usuario.Text = "Modificar usuario";
            this.modificar_usuario.Visible = false;
            this.modificar_usuario.Click += new System.EventHandler(this.modificarUsuarioToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaBus.Properties.Resources.images__2_;
            this.ClientSize = new System.Drawing.Size(666, 274);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Ciudad;
        private System.Windows.Forms.ToolStripMenuItem listar_ciudad;
        private System.Windows.Forms.ToolStripMenuItem crear_ciudad;
        private System.Windows.Forms.ToolStripMenuItem modificar_ciudad;
        private System.Windows.Forms.ToolStripMenuItem Recorrido;
        private System.Windows.Forms.ToolStripMenuItem crear_recorrido;
        private System.Windows.Forms.ToolStripMenuItem modificar_recorrido;
        private System.Windows.Forms.ToolStripMenuItem listar_recorrido;
        private System.Windows.Forms.ToolStripMenuItem Micros;
        private System.Windows.Forms.ToolStripMenuItem crear_micro;
        private System.Windows.Forms.ToolStripMenuItem modificar_micro;
        private System.Windows.Forms.ToolStripMenuItem listar_micro;
        private System.Windows.Forms.ToolStripMenuItem Viaje;
        private System.Windows.Forms.ToolStripMenuItem crear_viaje;
        private System.Windows.Forms.ToolStripMenuItem listar_viaje;
        private System.Windows.Forms.ToolStripMenuItem Pasaje;
        private System.Windows.Forms.ToolStripMenuItem pasaje_generar;
        private System.Windows.Forms.ToolStripMenuItem pasaje_anular;
        private System.Windows.Forms.ToolStripMenuItem Puntos;
        private System.Windows.Forms.ToolStripMenuItem consulta_puntos;
        private System.Windows.Forms.ToolStripMenuItem Usuarios;
        private System.Windows.Forms.ToolStripMenuItem listar_roles;
        private System.Windows.Forms.ToolStripMenuItem listar_funcionalidades;
        private System.Windows.Forms.ToolStripMenuItem modificar_usuario;
        private System.Windows.Forms.ToolStripMenuItem modificar_viaje;
        private System.Windows.Forms.ToolStripMenuItem registrar_llegada;



    }
}