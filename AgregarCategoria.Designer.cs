namespace ProyectoBD
{
    partial class F_AgregarCategoria
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
            TB_IDCategoria = new TextBox();
            TB_Descripcion = new TextBox();
            B_Cancelar = new Button();
            B_Confirmar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(128, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 29);
            label1.TabIndex = 0;
            label1.Text = "Agregar Categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 107);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 1;
            label2.Text = "IdCategoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 169);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 2;
            label3.Text = "Descripcion";
            // 
            // TB_IDCategoria
            // 
            TB_IDCategoria.Location = new Point(159, 110);
            TB_IDCategoria.Name = "TB_IDCategoria";
            TB_IDCategoria.Size = new Size(285, 31);
            TB_IDCategoria.TabIndex = 3;
            // 
            // TB_Descripcion
            // 
            TB_Descripcion.Location = new Point(159, 169);
            TB_Descripcion.Name = "TB_Descripcion";
            TB_Descripcion.Size = new Size(285, 31);
            TB_Descripcion.TabIndex = 4;
            // 
            // B_Cancelar
            // 
            B_Cancelar.Location = new Point(16, 241);
            B_Cancelar.Name = "B_Cancelar";
            B_Cancelar.Size = new Size(125, 39);
            B_Cancelar.TabIndex = 5;
            B_Cancelar.Text = "Cancelar";
            B_Cancelar.UseVisualStyleBackColor = true;
            B_Cancelar.Click += B_Cancelar_Click;
            // 
            // B_Confirmar
            // 
            B_Confirmar.Location = new Point(364, 241);
            B_Confirmar.Name = "B_Confirmar";
            B_Confirmar.Size = new Size(131, 39);
            B_Confirmar.TabIndex = 6;
            B_Confirmar.Text = "Confirmar";
            B_Confirmar.UseVisualStyleBackColor = true;
            B_Confirmar.Click += B_Confirmar_Click;
            // 
            // F_AgregarCategoria
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 286);
            Controls.Add(B_Confirmar);
            Controls.Add(B_Cancelar);
            Controls.Add(TB_Descripcion);
            Controls.Add(TB_IDCategoria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_AgregarCategoria";
            Text = "AgregarCategoria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TB_IDCategoria;
        private TextBox TB_Descripcion;
        private Button B_Cancelar;
        private Button B_Confirmar;
    }
}