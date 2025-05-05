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
    public partial class F_AgregarProveedor : Form
    {
        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        public F_AgregarProveedor()
        {
            InitializeComponent(); 
            GenerarSiguienteIDProveedor();
            TB_IDProveedor.ReadOnly = true;
        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_Direccion.Clear();
            TB_IDProveedor.Clear();
            TB_Nombre.Clear();
            TB_Telefono.Clear();
            TB_Email.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        public bool ValidarCampos()
        {
            bool camposValidos =
                !string.IsNullOrWhiteSpace(TB_IDProveedor.Text) &&
                !string.IsNullOrWhiteSpace(TB_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(TB_Email.Text) &&
                !string.IsNullOrWhiteSpace(TB_Direccion.Text) &&
                !string.IsNullOrWhiteSpace(TB_Telefono.Text);

            B_Confirmar.Enabled = camposValidos; // Asumiendo que tienes un botón de registro
            return camposValidos;
        }

        private void GenerarSiguienteIDProveedor()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(IdProveedor), 0) + 1 FROM Proveedor";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int siguienteID = (int)cmd.ExecuteScalar();
                    TB_IDProveedor.Text = siguienteID.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el próximo ID: " + ex.Message);
                }
            }
        }

        public bool CrearProveedor()
        {
            int idProveedor_form;
            long telefono_form;

            // Validar conversiones
            if (!int.TryParse(TB_IDProveedor.Text.Trim(), out idProveedor_form) ||
                !long.TryParse(TB_Telefono.Text.Trim(), out telefono_form))
            {
                MessageBox.Show("Teléfono no valido.");
                return false;
            }

            string nombre_form = TB_Nombre.Text.Trim();
            string email_form = TB_Email.Text.Trim();
            string direccion_form = TB_Direccion.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Primero validamos si ya existe ese email
                    string queryVerificar = "SELECT COUNT(*) FROM Proveedor WHERE Email = @Email OR Telefono = @Telefono";
                    SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conn);
                    cmdVerificar.Parameters.AddWithValue("@Email", email_form);
                    cmdVerificar.Parameters.AddWithValue("@Telefono", telefono_form);

                    int count = (int)cmdVerificar.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Este telefono o correo ya están registrados.");
                        return false;
                    }

                    // Insertamos la nueva persona
                    string queryInsert = @"INSERT INTO Proveedor (IdProveedor, Nombre, Telefono, Direccion, Email) 
                                   VALUES (@IdProveedor, @Nombre, @Telefono, @Direccion, @Email)";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@IdProveedor", idProveedor_form);
                    cmdInsert.Parameters.AddWithValue("@Nombre", nombre_form);
                    cmdInsert.Parameters.AddWithValue("@Telefono", telefono_form);
                    cmdInsert.Parameters.AddWithValue("@Direccion", direccion_form);
                    cmdInsert.Parameters.AddWithValue("@Email", email_form);

                    int filas = cmdInsert.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Proveedor creada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la proveedor.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear proveedor: " + ex.Message);
                    return false;
                }
            }
        }


        private void B_Confirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                bool creado = CrearProveedor();

                if (creado)
                {
                    MessageBox.Show("Proveedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ir al formulario principal
                    this.Hide(); // cerrar el actual
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el Proveedor. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
