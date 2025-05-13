namespace ProyectoBD
{
    partial class F_PaginaPrincipal
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
            label1 = new Label();
            P_DatosPersonal = new Panel();
            TB_Consulta = new TextBox();
            B_Consulta = new Button();
            B_Despachar = new Button();
            B_AgregarDatos = new Button();
            B_EliminarDatos = new Button();
            B_ActualizarPersona = new Button();
            DGV_DatosPersonal = new DataGridView();
            B_Personas = new Button();
            B_CerrarSesion = new Button();
            B_CrearPersona = new Button();
            B_Inventario = new Button();
            B_Ventas = new Button();
            B_Proveedores = new Button();
            button1 = new Button();
            B_InventarioBajo = new Button();
            P_DatosPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_DatosPersonal).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(461, 9);
            label1.Name = "label1";
            label1.Size = new Size(328, 43);
            label1.TabIndex = 0;
            label1.Text = "Gestion Inventario";
            // 
            // P_DatosPersonal
            // 
            P_DatosPersonal.Controls.Add(B_InventarioBajo);
            P_DatosPersonal.Controls.Add(TB_Consulta);
            P_DatosPersonal.Controls.Add(B_Consulta);
            P_DatosPersonal.Controls.Add(B_Despachar);
            P_DatosPersonal.Controls.Add(B_AgregarDatos);
            P_DatosPersonal.Controls.Add(B_EliminarDatos);
            P_DatosPersonal.Controls.Add(B_ActualizarPersona);
            P_DatosPersonal.Controls.Add(DGV_DatosPersonal);
            P_DatosPersonal.Location = new Point(9, 126);
            P_DatosPersonal.Name = "P_DatosPersonal";
            P_DatosPersonal.Size = new Size(1178, 477);
            P_DatosPersonal.TabIndex = 1;
            P_DatosPersonal.Paint += P_DatosPersonal_Paint;
            // 
            // TB_Consulta
            // 
            TB_Consulta.Location = new Point(896, 105);
            TB_Consulta.Name = "TB_Consulta";
            TB_Consulta.Size = new Size(254, 31);
            TB_Consulta.TabIndex = 6;
            // 
            // B_Consulta
            // 
            B_Consulta.Location = new Point(919, 142);
            B_Consulta.Name = "B_Consulta";
            B_Consulta.Size = new Size(202, 46);
            B_Consulta.TabIndex = 5;
            B_Consulta.Text = "Consultar";
            B_Consulta.UseVisualStyleBackColor = true;
            B_Consulta.Click += B_ConsultaPersona_Click;
            // 
            // B_Despachar
            // 
            B_Despachar.Location = new Point(920, 406);
            B_Despachar.Name = "B_Despachar";
            B_Despachar.Size = new Size(207, 42);
            B_Despachar.TabIndex = 4;
            B_Despachar.Text = "Despachar Venta";
            B_Despachar.UseVisualStyleBackColor = true;
            B_Despachar.Click += B_Despachar_Click;
            // 
            // B_AgregarDatos
            // 
            B_AgregarDatos.Location = new Point(919, 194);
            B_AgregarDatos.Name = "B_AgregarDatos";
            B_AgregarDatos.Size = new Size(208, 48);
            B_AgregarDatos.TabIndex = 3;
            B_AgregarDatos.Text = "Agregar Datos";
            B_AgregarDatos.UseVisualStyleBackColor = true;
            B_AgregarDatos.Click += B_AgregarDatos_Click;
            // 
            // B_EliminarDatos
            // 
            B_EliminarDatos.Location = new Point(920, 346);
            B_EliminarDatos.Name = "B_EliminarDatos";
            B_EliminarDatos.Size = new Size(207, 42);
            B_EliminarDatos.TabIndex = 2;
            B_EliminarDatos.Text = "Eliminar Datos";
            B_EliminarDatos.UseVisualStyleBackColor = true;
            B_EliminarDatos.Click += button3_Click;
            // 
            // B_ActualizarPersona
            // 
            B_ActualizarPersona.Location = new Point(919, 266);
            B_ActualizarPersona.Name = "B_ActualizarPersona";
            B_ActualizarPersona.Size = new Size(208, 48);
            B_ActualizarPersona.TabIndex = 1;
            B_ActualizarPersona.Text = "Actualizar Datos";
            B_ActualizarPersona.UseVisualStyleBackColor = true;
            B_ActualizarPersona.Click += B_ActualizarPersona_Click;
            // 
            // DGV_DatosPersonal
            // 
            DGV_DatosPersonal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_DatosPersonal.Location = new Point(3, 5);
            DGV_DatosPersonal.Name = "DGV_DatosPersonal";
            DGV_DatosPersonal.RowHeadersWidth = 62;
            DGV_DatosPersonal.Size = new Size(847, 471);
            DGV_DatosPersonal.TabIndex = 0;
            // 
            // B_Personas
            // 
            B_Personas.Location = new Point(116, 81);
            B_Personas.Name = "B_Personas";
            B_Personas.Size = new Size(191, 39);
            B_Personas.TabIndex = 2;
            B_Personas.Text = "Ver Datos Personal";
            B_Personas.UseVisualStyleBackColor = true;
            B_Personas.Click += B_Personas_Click;
            // 
            // B_CerrarSesion
            // 
            B_CerrarSesion.Location = new Point(23, 17);
            B_CerrarSesion.Name = "B_CerrarSesion";
            B_CerrarSesion.Size = new Size(155, 40);
            B_CerrarSesion.TabIndex = 3;
            B_CerrarSesion.Text = "Salir Sesion";
            B_CerrarSesion.UseVisualStyleBackColor = true;
            B_CerrarSesion.Click += B_CerrarSesion_Click;
            // 
            // B_CrearPersona
            // 
            B_CrearPersona.Location = new Point(1006, 14);
            B_CrearPersona.Name = "B_CrearPersona";
            B_CrearPersona.Size = new Size(184, 39);
            B_CrearPersona.TabIndex = 4;
            B_CrearPersona.Text = "Crear User Personal";
            B_CrearPersona.UseVisualStyleBackColor = true;
            B_CrearPersona.Click += B_CrearPersona_Click;
            // 
            // B_Inventario
            // 
            B_Inventario.Location = new Point(336, 81);
            B_Inventario.Name = "B_Inventario";
            B_Inventario.Size = new Size(160, 39);
            B_Inventario.TabIndex = 5;
            B_Inventario.Text = "Inventario";
            B_Inventario.UseVisualStyleBackColor = true;
            B_Inventario.Click += B_Inventario_Click;
            // 
            // B_Ventas
            // 
            B_Ventas.Location = new Point(526, 81);
            B_Ventas.Name = "B_Ventas";
            B_Ventas.Size = new Size(136, 39);
            B_Ventas.TabIndex = 6;
            B_Ventas.Text = "Ventas";
            B_Ventas.UseVisualStyleBackColor = true;
            B_Ventas.Click += B_Ventas_Click;
            // 
            // B_Proveedores
            // 
            B_Proveedores.Location = new Point(707, 80);
            B_Proveedores.Name = "B_Proveedores";
            B_Proveedores.Size = new Size(152, 40);
            B_Proveedores.TabIndex = 7;
            B_Proveedores.Text = "Proveedores";
            B_Proveedores.UseVisualStyleBackColor = true;
            B_Proveedores.Click += B_Proveedores_Click;
            // 
            // button1
            // 
            button1.Location = new Point(905, 82);
            button1.Name = "button1";
            button1.Size = new Size(155, 37);
            button1.TabIndex = 8;
            button1.Text = "Categorias";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // B_InventarioBajo
            // 
            B_InventarioBajo.Location = new Point(919, 51);
            B_InventarioBajo.Name = "B_InventarioBajo";
            B_InventarioBajo.Size = new Size(195, 38);
            B_InventarioBajo.TabIndex = 7;
            B_InventarioBajo.Text = "Ver Inventario Bajo";
            B_InventarioBajo.UseVisualStyleBackColor = true;
            B_InventarioBajo.Click += B_InventarioBajo_Click;
            // 
            // F_PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 614);
            Controls.Add(button1);
            Controls.Add(B_Proveedores);
            Controls.Add(B_Ventas);
            Controls.Add(B_Inventario);
            Controls.Add(B_CrearPersona);
            Controls.Add(B_CerrarSesion);
            Controls.Add(B_Personas);
            Controls.Add(P_DatosPersonal);
            Controls.Add(label1);
            Name = "F_PaginaPrincipal";
            Text = "PaginaPrincipal";
            Load += F_PaginaPrincipal_Load;
            P_DatosPersonal.ResumeLayout(false);
            P_DatosPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_DatosPersonal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel P_DatosPersonal;
        private Button B_Personas;
        private Button B_CerrarSesion;
        private Button B_CrearPersona;
        private Button B_Inventario;
        private Button B_Ventas;
        private Button B_Proveedores;
        private Button button1;
        private DataGridView DGV_DatosPersonal;
        private Button B_EliminarDatos;
        private Button B_ActualizarPersona;
        private Button B_AgregarDatos;
        private Button B_Despachar;
        private Button B_Consulta;
        private TextBox TB_Consulta;
        private Button B_InventarioBajo;
    }
}