namespace ProyectoBD
{
    partial class F_AgregarProveedor
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
            B_Confirmar = new Button();
            TB_IDProveedor = new TextBox();
            TB_Nombre = new TextBox();
            TB_Telefono = new TextBox();
            TB_Direccion = new TextBox();
            TB_Email = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(128, 9);
            label1.Name = "label1";
            label1.Size = new Size(229, 29);
            label1.TabIndex = 0;
            label1.Text = "Agregar Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 106);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 1;
            label2.Text = "IdProveedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 159);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 206);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 3;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 257);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 4;
            label5.Text = "Direccion";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 299);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // B_Cancelar
            // 
            B_Cancelar.Location = new Point(27, 385);
            B_Cancelar.Name = "B_Cancelar";
            B_Cancelar.Size = new Size(109, 38);
            B_Cancelar.TabIndex = 6;
            B_Cancelar.Text = "Cancelar";
            B_Cancelar.UseVisualStyleBackColor = true;
            B_Cancelar.Click += B_Cancelar_Click;
            // 
            // B_Confirmar
            // 
            B_Confirmar.Location = new Point(310, 385);
            B_Confirmar.Name = "B_Confirmar";
            B_Confirmar.Size = new Size(155, 38);
            B_Confirmar.TabIndex = 7;
            B_Confirmar.Text = "Guardar y Crear";
            B_Confirmar.UseVisualStyleBackColor = true;
            B_Confirmar.Click += B_Confirmar_Click;
            // 
            // TB_IDProveedor
            // 
            TB_IDProveedor.Location = new Point(155, 106);
            TB_IDProveedor.Name = "TB_IDProveedor";
            TB_IDProveedor.ReadOnly = true;
            TB_IDProveedor.Size = new Size(218, 31);
            TB_IDProveedor.TabIndex = 8;
            // 
            // TB_Nombre
            // 
            TB_Nombre.Location = new Point(123, 159);
            TB_Nombre.Name = "TB_Nombre";
            TB_Nombre.Size = new Size(243, 31);
            TB_Nombre.TabIndex = 9;
            // 
            // TB_Telefono
            // 
            TB_Telefono.Location = new Point(125, 206);
            TB_Telefono.Name = "TB_Telefono";
            TB_Telefono.Size = new Size(242, 31);
            TB_Telefono.TabIndex = 10;
            // 
            // TB_Direccion
            // 
            TB_Direccion.Location = new Point(125, 254);
            TB_Direccion.Name = "TB_Direccion";
            TB_Direccion.Size = new Size(252, 31);
            TB_Direccion.TabIndex = 11;
            // 
            // TB_Email
            // 
            TB_Email.Location = new Point(100, 299);
            TB_Email.Name = "TB_Email";
            TB_Email.Size = new Size(248, 31);
            TB_Email.TabIndex = 12;
            // 
            // F_AgregarProveedor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 450);
            Controls.Add(TB_Email);
            Controls.Add(TB_Direccion);
            Controls.Add(TB_Telefono);
            Controls.Add(TB_Nombre);
            Controls.Add(TB_IDProveedor);
            Controls.Add(B_Confirmar);
            Controls.Add(B_Cancelar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_AgregarProveedor";
            Text = "AgregarProveedor";
            Load += F_AgregarProveedor_Load;
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
        private Button B_Confirmar;
        private TextBox TB_IDProveedor;
        private TextBox TB_Nombre;
        private TextBox TB_Telefono;
        private TextBox TB_Direccion;
        private TextBox TB_Email;
    }
}