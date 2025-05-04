namespace ProyectoBD
{
    partial class F_Registro
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
            label7 = new Label();
            TB_Cedula = new TextBox();
            TB_Nombre = new TextBox();
            TB_Contraseña = new TextBox();
            TB_Telefono = new TextBox();
            TB_Email = new TextBox();
            CB_Rol = new ComboBox();
            B_Cancelar = new Button();
            B_GuardarCrear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(162, 22);
            label1.Name = "label1";
            label1.Size = new Size(265, 33);
            label1.TabIndex = 0;
            label1.Text = "Registrar Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 107);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 1;
            label2.Text = "Cedula";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 171);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 221);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 3;
            label4.Text = "Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 274);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 4;
            label5.Text = "Telefono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 323);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(96, 374);
            label7.Name = "label7";
            label7.Size = new Size(37, 25);
            label7.TabIndex = 6;
            label7.Text = "Rol";
            // 
            // TB_Cedula
            // 
            TB_Cedula.Location = new Point(139, 101);
            TB_Cedula.Name = "TB_Cedula";
            TB_Cedula.Size = new Size(351, 31);
            TB_Cedula.TabIndex = 7;
            // 
            // TB_Nombre
            // 
            TB_Nombre.Location = new Point(139, 165);
            TB_Nombre.Name = "TB_Nombre";
            TB_Nombre.Size = new Size(350, 31);
            TB_Nombre.TabIndex = 8;
            // 
            // TB_Contraseña
            // 
            TB_Contraseña.Location = new Point(139, 215);
            TB_Contraseña.Name = "TB_Contraseña";
            TB_Contraseña.Size = new Size(351, 31);
            TB_Contraseña.TabIndex = 9;
            // 
            // TB_Telefono
            // 
            TB_Telefono.Location = new Point(139, 274);
            TB_Telefono.Name = "TB_Telefono";
            TB_Telefono.Size = new Size(350, 31);
            TB_Telefono.TabIndex = 10;
            // 
            // TB_Email
            // 
            TB_Email.Location = new Point(139, 323);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(383, 31);
            TB_Email.TabIndex = 11;
            // 
            // CB_Rol
            // 
            CB_Rol.FormattingEnabled = true;
            CB_Rol.Location = new Point(139, 371);
            CB_Rol.Name = "CB_Rol";
            CB_Rol.Size = new Size(193, 33);
            CB_Rol.TabIndex = 12;
            // 
            // B_Cancelar
            // 
            B_Cancelar.Location = new Point(31, 436);
            B_Cancelar.Name = "B_Cancelar";
            B_Cancelar.Size = new Size(149, 46);
            B_Cancelar.TabIndex = 13;
            B_Cancelar.Text = "Cancelar";
            B_Cancelar.UseVisualStyleBackColor = true;
            B_Cancelar.Click += B_Cancelar_Click;
            // 
            // B_GuardarCrear
            // 
            B_GuardarCrear.Location = new Point(439, 436);
            B_GuardarCrear.Name = "B_GuardarCrear";
            B_GuardarCrear.Size = new Size(149, 46);
            B_GuardarCrear.TabIndex = 14;
            B_GuardarCrear.Text = "Guardar y Crear";
            B_GuardarCrear.UseVisualStyleBackColor = true;
            B_GuardarCrear.Click += B_GuardarCrear_Click;
            // 
            // F_Registro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 517);
            Controls.Add(B_GuardarCrear);
            Controls.Add(B_Cancelar);
            Controls.Add(CB_Rol);
            Controls.Add(TB_Email);
            Controls.Add(TB_Telefono);
            Controls.Add(TB_Contraseña);
            Controls.Add(TB_Nombre);
            Controls.Add(TB_Cedula);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "F_Registro";
            Text = "Registro";
            Load += F_Registro_Load;
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
        private Label label7;
        private TextBox TB_Cedula;
        private TextBox TB_Nombre;
        private TextBox TB_Contraseña;
        private TextBox TB_Telefono;
        private TextBox TB_Email;
        private ComboBox CB_Rol;
        private Button B_Cancelar;
        private Button B_GuardarCrear;
    }
}