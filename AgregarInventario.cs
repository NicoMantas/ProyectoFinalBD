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
            CargarProveedores();
            CargarCategorias();
        }

        private void CargarProveedores()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nombre FROM Proveedor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    CB_IdProveedor.Items.Clear();
                    while (reader.Read())
                    {
                        CB_IdProveedor.Items.Add(reader["Nombre"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar proveedores: " + ex.Message);
                }
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Descripcion FROM Categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    CB_IdCategoria.Items.Clear();
                    while (reader.Read())
                    {
                        CB_IdCategoria.Items.Add(reader["Descripcion"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías: " + ex.Message);
                }
            }
        }

        public bool ValidarCampos()
        {
            bool camposValidos =
                !string.IsNullOrWhiteSpace(TB_IDProducto.Text) &&
                !string.IsNullOrWhiteSpace(TB_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(TB_Stock.Text) &&
                !string.IsNullOrWhiteSpace(CB_IdProveedor.Text) &&
                !string.IsNullOrWhiteSpace(CB_IdCategoria.Text) &&
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
            int stock_form;
            int precio_form;

            string nombreProveedor = CB_IdProveedor.Text.Trim();
            string nombreCategoria = CB_IdCategoria.Text.Trim();
            int idProveedor_form = -1;
            int idCategoria_form = -1;

            // Validar conversiones
            if (!int.TryParse(TB_IDProducto.Text.Trim(), out idProducto_form) ||
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

                    // Obtener IdProveedor
                    string queryProveedor = "SELECT IdProveedor FROM Proveedor WHERE Nombre = @Nombre";
                    SqlCommand cmdProv = new SqlCommand(queryProveedor, conn);
                    cmdProv.Parameters.AddWithValue("@Nombre", nombreProveedor);
                    object resultProv = cmdProv.ExecuteScalar();
                    if (resultProv != null)
                        idProveedor_form = Convert.ToInt32(resultProv);
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                        return false;
                    }

                    // Obtener IdCategoria
                    string queryCategoria = "SELECT IdCategoria FROM Categoria WHERE Descripcion = @Nombre";
                    SqlCommand cmdCat = new SqlCommand(queryCategoria, conn);
                    cmdCat.Parameters.AddWithValue("@Nombre", nombreCategoria);
                    object resultCat = cmdCat.ExecuteScalar();
                    if (resultCat != null)
                        idCategoria_form = Convert.ToInt32(resultCat);
                    else
                    {
                        MessageBox.Show("Categoría no encontrada.");
                        return false;
                    }

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
            TB_IDProducto.Clear();
            TB_Nombre.Clear();
            TB_Stock.Clear();
            TB_Precio.Clear();
            CB_IdProveedor.SelectedIndex = -1;
            CB_IdCategoria.SelectedIndex = -1;

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

        private void TB_IDProveedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
