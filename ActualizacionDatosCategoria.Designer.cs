namespace ProyectoBD
{
    partial class F_ActualizacionDatosCategoria
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
            TB_IdCategoria = new TextBox();
            TB_Descripcion = new TextBox();
            B_Cancelar = new Button();
            B_Confirmar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(100, 9);
            label1.Name = "label1";
            label1.Size = new Size(257, 29);
            label1.TabIndex = 0;
            label1.Text = "Actualizar Categorias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 101);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 1;
            label2.Text = "IdCategoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 163);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 2;
            label3.Text = "Descripcion";
            // 
            // TB_IdCategoria
            // 
            TB_IdCategoria.Location = new Point(137, 98);
            TB_IdCategoria.Name = "TB_IdCategoria";
            TB_IdCategoria.Size = new Size(220, 31);
            TB_IdCategoria.TabIndex = 3;
            // 
            // TB_Descripcion
            // 
            TB_Descripcion.Location = new Point(137, 163);
            TB_Descripcion.Name = "TB_Descripcion";
            TB_Descripcion.Size = new Size(220, 31);
            TB_Descripcion.TabIndex = 4;
            // 
            // B_Cancelar
            // 
            B_Cancelar.Location = new Point(8, 246);
            B_Cancelar.Name = "B_Cancelar";
            B_Cancelar.Size = new Size(113, 34);
            B_Cancelar.TabIndex = 5;
            B_Cancelar.Text = "Cancelar";
            B_Cancelar.UseVisualStyleBackColor = true;
            B_Cancelar.Click += B_Cancelar_Click;
            // 
            // B_Confirmar
            // 
            B_Confirmar.Location = new Point(292, 246);
            B_Confirmar.Name = "B_Confirmar";
            B_Confirmar.Size = new Size(144, 34);
            B_Confirmar.TabIndex = 6;
            B_Confirmar.Text = "Actualizar";
            B_Confirmar.TextAlign = ContentAlignment.BottomCenter;
            B_Confirmar.UseVisualStyleBackColor = true;
            B_Confirmar.Click += B_Confirmar_Click;
            // 
            // F_ActualizacionDatosCategoria
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 304);
            Controls.Add(B_Confirmar);
            Controls.Add(B_Cancelar);
            Controls.Add(TB_Descripcion);
            Controls.Add(TB_IdCategoria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "F_ActualizacionDatosCategoria";
            Text = "ActualizacionDatosCategoria";
            Load += F_ActualizacionDatosCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TB_IdCategoria;
        private TextBox TB_Descripcion;
        private Button B_Cancelar;
        private Button B_Confirmar;
    }
}