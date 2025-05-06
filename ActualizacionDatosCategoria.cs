using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProyectoBD
{
    public partial class F_ActualizacionDatosCategoria : Form
    {

        private string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        string mostrar_idcategoria;
        string mostrar_descripcion;


        public F_ActualizacionDatosCategoria(string idCategoria, string descripcion)
        {
            InitializeComponent();
            this.mostrar_idcategoria = idCategoria;
            this.mostrar_descripcion = descripcion;
        }

        public void TraerDatos()
        {
            TB_IdCategoria.Text = mostrar_idcategoria;
            TB_IdCategoria.ReadOnly = true;
            TB_Descripcion.Text = mostrar_descripcion;
        }



        private void F_ActualizacionDatosCategoria_Load(object sender, EventArgs e)
        {
            TraerDatos();

        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_IdCategoria.Clear();
            TB_Descripcion.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        private void B_Confirmar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TB_IdCategoria.Text) ||
                string.IsNullOrWhiteSpace(TB_Descripcion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdCategoria;
            string Descripcion = TB_Descripcion.Text.Trim(); ;

            // Validaciones básicas
            if (!int.TryParse(TB_IdCategoria.Text.Trim(), out IdCategoria))
            {
                MessageBox.Show("ID no valido. Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualizar en la base de datos
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Categoria 
                             SET Descripcion = @Descripcion
                             WHERE IdCategoria = @IdCategoria";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Los datos fueron actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); // Puedes cerrar este formulario si quieres
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro a actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
