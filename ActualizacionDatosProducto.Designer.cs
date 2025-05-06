namespace ProyectoBD
{
    partial class F_ActualizacionDatosProducto
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
            B_cancelar = new Button();
            B_confirmar = new Button();
            TB_IdProducto = new TextBox();
            TB_Nombre = new TextBox();
            TB_Stock = new TextBox();
            TB_Precio = new TextBox();
            CB_IdProveedor = new ComboBox();
            CB_IdCategoria = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(145, 9);
            label1.Name = "label1";
            label1.Size = new Size(240, 29);
            label1.TabIndex = 0;
            label1.Text = "Actualizar Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 76);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 1;
            label2.Text = "IdProducto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 135);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 189);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 3;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 255);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 4;
            label5.Text = "IdProveedor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 318);
            label6.Name = "label6";
            label6.Size = new Size(104, 25);
            label6.TabIndex = 5;
            label6.Text = "IdCategoria";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 377);
            label7.Name = "label7";
            label7.Size = new Size(60, 25);
            label7.TabIndex = 6;
            label7.Text = "Precio";
            // 
            // B_cancelar
            // 
            B_cancelar.Location = new Point(21, 441);
            B_cancelar.Name = "B_cancelar";
            B_cancelar.Size = new Size(118, 42);
            B_cancelar.TabIndex = 7;
            B_cancelar.Text = "Cancelar";
            B_cancelar.UseVisualStyleBackColor = true;
            B_cancelar.Click += B_cancelar_Click_1;
            // 
            // B_confirmar
            // 
            B_confirmar.Location = new Point(354, 441);
            B_confirmar.Name = "B_confirmar";
            B_confirmar.Size = new Size(135, 42);
            B_confirmar.TabIndex = 8;
            B_confirmar.Text = "Confirmar";
            B_confirmar.UseVisualStyleBackColor = true;
            B_confirmar.Click += B_confirmar_Click;
            // 
            // TB_IdProducto
            // 
            TB_IdProducto.Location = new Point(145, 76);
            TB_IdProducto.Name = "TB_IdProducto";
            TB_IdProducto.Size = new Size(294, 31);
            TB_IdProducto.TabIndex = 9;
            // 
            // TB_Nombre
            // 
            TB_Nombre.Location = new Point(145, 135);
            TB_Nombre.Name = "TB_Nombre";
            TB_Nombre.Size = new Size(292, 31);
            TB_Nombre.TabIndex = 10;
            // 
            // TB_Stock
            // 
            TB_Stock.Location = new Point(107, 189);
            TB_Stock.Name = "TB_Stock";
            TB_Stock.Size = new Size(248, 31);
            TB_Stock.TabIndex = 11;
            // 
            // TB_Precio
            // 
            TB_Precio.Location = new Point(114, 377);
            TB_Precio.Name = "TB_Precio";
            TB_Precio.Size = new Size(258, 31);
            TB_Precio.TabIndex = 14;
            // 
            // CB_IdProveedor
            // 
            CB_IdProveedor.FormattingEnabled = true;
            CB_IdProveedor.Location = new Point(161, 256);
            CB_IdProveedor.Name = "CB_IdProveedor";
            CB_IdProveedor.Size = new Size(231, 33);
            CB_IdProveedor.TabIndex = 15;
            // 
            // CB_IdCategoria
            // 
            CB_IdCategoria.FormattingEnabled = true;
            CB_IdCategoria.Location = new Point(161, 310);
            CB_IdCategoria.Name = "CB_IdCategoria";
            CB_IdCategoria.Size = new Size(231, 33);
            CB_IdCategoria.TabIndex = 16;
            // 
            // F_ActualizacionDatosProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 497);
            Controls.Add(CB_IdCategoria);
            Controls.Add(CB_IdProveedor);
            Controls.Add(TB_Precio);
            Controls.Add(TB_Stock);
            Controls.Add(TB_Nombre);
            Controls.Add(TB_IdProducto);
            Controls.Add(B_confirmar);
            Controls.Add(B_cancelar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_ActualizacionDatosProducto";
            Text = "ActualizacionDatosProducto";
            Load += F_ActualizacionDatosProducto_Load;
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
        private Button B_cancelar;
        private Button B_confirmar;
        private TextBox TB_IdProducto;
        private TextBox TB_Nombre;
        private TextBox TB_Stock;
        private TextBox TB_IdProveedor;
        private TextBox TB_IdCategoria;
        private TextBox TB_Precio;
        private ComboBox CB_IdProveedor;
        private ComboBox CB_IdCategoria;
    }
}