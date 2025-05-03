namespace ProyectoBD
{
    partial class F_InicioSesion
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
            TB_email = new TextBox();
            TB_contraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            B_InicioSesion = new Button();
            SuspendLayout();
            // 
            // TB_email
            // 
            TB_email.Location = new Point(159, 138);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(394, 31);
            TB_email.TabIndex = 0;
            TB_email.TextChanged += TB_email_TextChanged;
            // 
            // TB_contraseña
            // 
            TB_contraseña.Location = new Point(158, 198);
            TB_contraseña.Name = "TB_contraseña";
            TB_contraseña.Size = new Size(395, 31);
            TB_contraseña.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(215, 9);
            label1.Name = "label1";
            label1.Size = new Size(205, 36);
            label1.TabIndex = 2;
            label1.Text = "Iniciar Sesion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 142);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 202);
            label3.Name = "label3";
            label3.Size = new Size(112, 23);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // B_InicioSesion
            // 
            B_InicioSesion.Location = new Point(194, 315);
            B_InicioSesion.Name = "B_InicioSesion";
            B_InicioSesion.Size = new Size(250, 49);
            B_InicioSesion.TabIndex = 5;
            B_InicioSesion.Text = "Continuar";
            B_InicioSesion.UseVisualStyleBackColor = true;
            B_InicioSesion.Click += B_InicioSesion_Click;
            // 
            // F_InicioSesion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 405);
            Controls.Add(B_InicioSesion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TB_contraseña);
            Controls.Add(TB_email);
            Name = "F_InicioSesion";
            Text = "Inicio_Sesion";
            Load += F_InicioSesion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TB_contraseña;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button B_InicioSesion;
        public TextBox TB_email;
    }
}