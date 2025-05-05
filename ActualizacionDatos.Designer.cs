namespace ProyectoBD
{
    partial class F_ActualizacionDatos
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            B_Cancelar = new Button();
            B_GuardarActualizacionPersona = new Button();
            TB_Cedula = new TextBox();
            TB_Nombre = new TextBox();
            TB_Telefono = new TextBox();
            TB_Email = new TextBox();
            CB_Rol = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(176, 9);
            label1.Name = "label1";
            label1.Size = new Size(256, 31);
            label1.TabIndex = 0;
            label1.Text = "Actualizacion Datos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 101);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 1;
            label2.Text = "Cedula";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 154);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 207);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 3;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 265);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 4;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 327);
            label6.Name = "label6";
            label6.Size = new Size(37, 25);
            label6.TabIndex = 5;
            label6.Text = "Rol";
            label6.Click += label6_Click;
            // 
            // B_Cancelar
            // 
            B_Cancelar.Location = new Point(28, 405);
            B_Cancelar.Name = "B_Cancelar";
            B_Cancelar.Size = new Size(112, 34);
            B_Cancelar.TabIndex = 6;
            B_Cancelar.Text = "Cancelar";
            B_Cancelar.UseVisualStyleBackColor = true;
            B_Cancelar.Click += B_Cancelar_Click;
            // 
            // B_GuardarActualizacionPersona
            // 
            B_GuardarActualizacionPersona.Location = new Point(455, 405);
            B_GuardarActualizacionPersona.Name = "B_GuardarActualizacionPersona";
            B_GuardarActualizacionPersona.Size = new Size(112, 34);
            B_GuardarActualizacionPersona.TabIndex = 7;
            B_GuardarActualizacionPersona.Text = "Actualizar";
            B_GuardarActualizacionPersona.UseVisualStyleBackColor = true;
            B_GuardarActualizacionPersona.Click += B_GuardarActualizacionPersona_Click;
            // 
            // TB_Cedula
            // 
            TB_Cedula.Location = new Point(133, 103);
            TB_Cedula.Name = "TB_Cedula";
            TB_Cedula.Size = new Size(370, 31);
            TB_Cedula.TabIndex = 8;
            // 
            // TB_Nombre
            // 
            TB_Nombre.Location = new Point(124, 161);
            TB_Nombre.Name = "TB_Nombre";
            TB_Nombre.Size = new Size(384, 31);
            TB_Nombre.TabIndex = 9;
            // 
            // TB_Telefono
            // 
            TB_Telefono.Location = new Point(130, 213);
            TB_Telefono.Name = "TB_Telefono";
            TB_Telefono.Size = new Size(376, 31);
            TB_Telefono.TabIndex = 10;
            // 
            // TB_Email
            // 
            TB_Email.Location = new Point(120, 265);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(390, 31);
            TB_Email.TabIndex = 11;
            // 
            // CB_Rol
            // 
            CB_Rol.FormattingEnabled = true;
            CB_Rol.Location = new Point(98, 324);
            CB_Rol.Name = "CB_Rol";
            CB_Rol.Size = new Size(250, 33);
            CB_Rol.TabIndex = 12;
            // 
            // F_ActualizacionDatos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 497);
            Controls.Add(CB_Rol);
            Controls.Add(TB_Email);
            Controls.Add(TB_Telefono);
            Controls.Add(TB_Nombre);
            Controls.Add(TB_Cedula);
            Controls.Add(B_GuardarActualizacionPersona);
            Controls.Add(B_Cancelar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_ActualizacionDatos";
            Text = "ActualizacionDatos";
            Load += F_ActualizacionDatos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button B_Cancelar;
        private Button B_GuardarActualizacionPersona;
        private TextBox TB_Cedula;
        private TextBox TB_Nombre;
        private TextBox TB_Telefono;
        private TextBox TB_Email;
        private ComboBox CB_Rol;
    }
}