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

namespace ProyectoBD
{
    public partial class F_AgregarCategoria : Form
    {
        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        public F_AgregarCategoria()
        {
            InitializeComponent();
            GenerarSiguienteIDCategoria();
            TB_IDCategoria.ReadOnly = true;
            TB_Descripcion.KeyPress += TB_Descripcion_KeyPress;
        }

        private void TB_Descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacio y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea todo lo que no sea letra, espacio o control
            }
        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_Descripcion.Clear();
            TB_IDCategoria.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        public bool ValidarCampos()
        {
            bool camposValidos =
                !string.IsNullOrWhiteSpace(TB_IDCategoria.Text) &&
                !string.IsNullOrWhiteSpace(TB_Descripcion.Text);

            B_Confirmar.Enabled = camposValidos; // Asumiendo que tienes un botón de registro
            return camposValidos;
        }

        private void GenerarSiguienteIDCategoria()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(IdCategoria), 0) + 1 FROM Categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int siguienteID = (int)cmd.ExecuteScalar();
                    TB_IDCategoria.Text = siguienteID.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el próximo ID: " + ex.Message);
                }
            }
        }

        public bool CrearCategoria()
        {
            int idCategoria_form;

            // Validar conversiones
            if (!int.TryParse(TB_IDCategoria.Text.Trim(), out idCategoria_form))
            {
                MessageBox.Show("Error en el ID.");
                return false;
            }

            string descripcion_form = TB_Descripcion.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Primero validamos si ya existe ese email
                    string queryVerificar = "SELECT COUNT(*) FROM Categoria WHERE Descripcion = @Descripcion";
                    SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conn);
                    cmdVerificar.Parameters.AddWithValue("@Descripcion", descripcion_form);

                    int count = (int)cmdVerificar.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Esta categoria ya esta creada.");
                        return false;
                    }

                    // Insertamos la nueva persona
                    string queryInsert = @"INSERT INTO Categoria (IdCategoria, Descripcion) 
                                   VALUES (@IdCategoria, @Descripcion)";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@IdCategoria", idCategoria_form);
                    cmdInsert.Parameters.AddWithValue("@Descripcion", descripcion_form);

                    int filas = cmdInsert.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Categoria creada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la categoria.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear categoria: " + ex.Message);
                    return false;
                }
            }
        }

        private void B_Confirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                bool creado = CrearCategoria();

                if (creado)
                {
                    MessageBox.Show("Categoria creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ir al formulario principal
                    this.Hide(); // cerrar el actual
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el Categoria. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void F_AgregarCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
