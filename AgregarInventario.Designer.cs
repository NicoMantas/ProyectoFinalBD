namespace ProyectoBD
{
    partial class F_AgregarInventario
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
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            TB_IDProducto = new TextBox();
            TB_Nombre = new TextBox();
            TB_Stock = new TextBox();
            TB_IDProveedor = new TextBox();
            TB_IDCategoria = new TextBox();
            TB_Precio = new TextBox();
            B_cancelar = new Button();
            B_Actualizar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(135, 8);
            label1.Name = "label1";
            label1.Size = new Size(234, 27);
            label1.TabIndex = 0;
            label1.Text = "Agregar al Inventario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(23, 95);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 1;
            label2.Text = "IdProducto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(23, 133);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(23, 174);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 25);
            label5.TabIndex = 4;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(23, 216);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 5;
            label6.Text = "IdProveedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(23, 260);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(104, 25);
            label7.TabIndex = 6;
            label7.Text = "IdCategoria";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(23, 294);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(60, 25);
            label8.TabIndex = 7;
            label8.Text = "Precio";
            // 
            // TB_IDProducto
            // 
            TB_IDProducto.Font = new Font("Segoe UI", 9F);
            TB_IDProducto.Location = new Point(128, 92);
            TB_IDProducto.Margin = new Padding(2, 3, 2, 3);
            TB_IDProducto.Name = "TB_IDProducto";
            TB_IDProducto.Size = new Size(250, 31);
            TB_IDProducto.TabIndex = 8;
            // 
            // TB_Nombre
            // 
            TB_Nombre.Font = new Font("Segoe UI", 9F);
            TB_Nombre.Location = new Point(128, 132);
            TB_Nombre.Margin = new Padding(2, 3, 2, 3);
            TB_Nombre.Name = "TB_Nombre";
            TB_Nombre.Size = new Size(250, 31);
            TB_Nombre.TabIndex = 9;
            TB_Nombre.TextChanged += textBox2_TextChanged;
            // 
            // TB_Stock
            // 
            TB_Stock.Font = new Font("Segoe UI", 9F);
            TB_Stock.Location = new Point(128, 174);
            TB_Stock.Margin = new Padding(2, 3, 2, 3);
            TB_Stock.Name = "TB_Stock";
            TB_Stock.Size = new Size(250, 31);
            TB_Stock.TabIndex = 10;
            // 
            // TB_IDProveedor
            // 
            TB_IDProveedor.Location = new Point(133, 219);
            TB_IDProveedor.Name = "TB_IDProveedor";
            TB_IDProveedor.Size = new Size(245, 31);
            TB_IDProveedor.TabIndex = 11;
            // 
            // TB_IDCategoria
            // 
            TB_IDCategoria.Location = new Point(132, 260);
            TB_IDCategoria.Name = "TB_IDCategoria";
            TB_IDCategoria.Size = new Size(244, 31);
            TB_IDCategoria.TabIndex = 12;
            // 
            // TB_Precio
            // 
            TB_Precio.Location = new Point(95, 302);
            TB_Precio.Name = "TB_Precio";
            TB_Precio.Size = new Size(248, 31);
            TB_Precio.TabIndex = 13;
            // 
            // B_cancelar
            // 
            B_cancelar.Location = new Point(19, 400);
            B_cancelar.Name = "B_cancelar";
            B_cancelar.Size = new Size(145, 40);
            B_cancelar.TabIndex = 14;
            B_cancelar.Text = "Cancelar";
            B_cancelar.UseVisualStyleBackColor = true;
            B_cancelar.Click += B_cancelar_Click;
            // 
            // B_Actualizar
            // 
            B_Actualizar.Location = new Point(350, 398);
            B_Actualizar.Name = "B_Actualizar";
            B_Actualizar.Size = new Size(129, 40);
            B_Actualizar.TabIndex = 15;
            B_Actualizar.Text = "Confirmar";
            B_Actualizar.UseVisualStyleBackColor = true;
            B_Actualizar.Click += B_Actualizar_Click;
            // 
            // F_AgregarInventario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 450);
            Controls.Add(B_Actualizar);
            Controls.Add(B_cancelar);
            Controls.Add(TB_Precio);
            Controls.Add(TB_IDCategoria);
            Controls.Add(TB_IDProveedor);
            Controls.Add(TB_Stock);
            Controls.Add(TB_Nombre);
            Controls.Add(TB_IDProducto);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F);
            Name = "F_AgregarInventario";
            Text = "AgregarInventario";
            Load += F_AgregarInventario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox TB_IDProducto;
        private TextBox TB_Nombre;
        private TextBox TB_Stock;
        private TextBox TB_IDProveedor;
        private TextBox TB_IDCategoria;
        private TextBox TB_Precio;
        private Button B_cancelar;
        private Button B_Actualizar;
    }
}