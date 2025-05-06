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
    public partial class F_AgregarInventario : Form
    {

        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        public F_AgregarInventario()
        {
            InitializeComponent();
            GenerarSiguienteIdProducto();
            TB_IDProducto.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void F_AgregarInventario_Load(object sender, EventArgs e)
        {

        }

        public bool ValidarCampos()
        {
            bool camposValidos =
                !string.IsNullOrWhiteSpace(TB_IDCategoria.Text) &&
                !string.IsNullOrWhiteSpace(TB_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(TB_Stock.Text) &&
                !string.IsNullOrWhiteSpace(TB_IDProveedor.Text) &&
                !string.IsNullOrWhiteSpace(TB_IDCategoria.Text) &&
                !string.IsNullOrWhiteSpace(TB_Precio.Text);

            B_Actualizar.Enabled = camposValidos; // Asumiendo que tienes un botón de registro
            return camposValidos;
        }

        private void GenerarSiguienteIdProducto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(IdProducto), 0) + 1 FROM InventarioProducto";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int siguienteID = (int)cmd.ExecuteScalar();
                    TB_IDProducto.Text = siguienteID.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el próximo ID: " + ex.Message);
                }
            }
        }

        public bool CrearProductoInventario()
        {
            int idProducto_form;
            int idProveedor_form;
            int idCategoria_form;
            int stock_form;
            int precio_form;

            // Validar conversiones
            if (!int.TryParse(TB_IDProducto.Text.Trim(), out idProducto_form) ||
                !int.TryParse(TB_IDProveedor.Text.Trim(), out idProveedor_form) ||
                !int.TryParse(TB_IDCategoria.Text.Trim(), out idCategoria_form) ||
                !int.TryParse(TB_Stock.Text.Trim(), out stock_form) ||
                !int.TryParse(TB_Precio.Text.Trim(), out precio_form))
            {
                MessageBox.Show("ID de Producto, Proveedor, Categoría, Stock o Precio no válido.");
                return false;
            }

            string nombre_form = TB_Nombre.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string queryInsert = @"
                INSERT INTO InventarioProducto 
                    (IdProducto, Nombre, Stock, IdProveedor, IdCategoria, Precio) 
                VALUES 
                    (@IdProducto, @Nombre, @Stock, @IdProveedor, @IdCategoria, @Precio)";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@IdProducto", idProducto_form);
                    cmdInsert.Parameters.AddWithValue("@Nombre", nombre_form);
                    cmdInsert.Parameters.AddWithValue("@Stock", stock_form);
                    cmdInsert.Parameters.AddWithValue("@IdProveedor", idProveedor_form);
                    cmdInsert.Parameters.AddWithValue("@IdCategoria", idCategoria_form);
                    cmdInsert.Parameters.AddWithValue("@Precio", precio_form);

                    int filas = cmdInsert.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Producto creado correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el producto.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear producto: " + ex.Message);
                    return false;
                }
            }
        }

        private void B_cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_IDCategoria.Clear();
            TB_Nombre.Clear();
            TB_Stock.Clear();
            TB_IDProveedor.Clear();
            TB_IDCategoria.Clear();
            TB_Precio.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        private void B_Actualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                bool creado = CrearProductoInventario();

                if (creado)
                {
                    MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ir al formulario principal
                    this.Hide(); // cerrar el actual
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el Producto. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
