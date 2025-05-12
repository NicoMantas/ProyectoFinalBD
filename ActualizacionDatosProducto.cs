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

namespace ProyectoBD
{
    public partial class F_ActualizacionDatosProducto : Form
    {
        private string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        string mostrar_IdProducto;
        string mostrar_Nombre;
        string mostrar_Stock;
        string mostrar_Proveedor;
        string mostrar_Categoria;
        string mostrar_Precio;

        public F_ActualizacionDatosProducto(string IdProducto, string Nombre, string Stock, string Proveedor, string Categoria, string Precio)
        {
            InitializeComponent();

            this.mostrar_IdProducto = IdProducto;
            this.mostrar_Nombre = Nombre;
            this.mostrar_Stock = Stock;
            this.mostrar_Proveedor = Proveedor;
            this.mostrar_Categoria = Categoria;
            this.mostrar_Precio = Precio;
            TB_Nombre.KeyPress += TB_Nombre_KeyPress;
            TB_Stock.KeyPress += TB_Numero_KeyPress;
            TB_Precio.KeyPress += TB_Numero_KeyPress;
            TB_Stock.Leave += TB_Numero_stock_Leave;
            TB_Precio.Leave += TB_Numero_precio_Leave;


        }
        private void TB_Numero_stock_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(TB_Stock.Text.Trim(), out int numero))
            {
                if (numero <= 0)
                {
                    MessageBox.Show("El número debe ser mayor que cero.");
                    TB_Stock.Focus(); // Vuelve a enfocar para corregir
                    B_confirmar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
                TB_Stock.Focus();
                B_confirmar.Enabled = false;
            }
        }
        private void TB_Numero_precio_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(TB_Precio.Text.Trim(), out int numero))
            {
                if (numero <= 0)
                {
                    MessageBox.Show("El número debe ser mayor que cero.");
                    TB_Precio.Focus(); // Vuelve a enfocar para corregir
                    B_confirmar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
                TB_Precio.Focus();
                B_confirmar.Enabled = false;
            }
        }


        private void TB_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea caracteres no numéricos
            }
        }

        private void TB_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacio y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea todo lo que no sea letra, espacio o control
            }
        }

        public void TraerDatos()
        {
            TB_IdProducto.Text = mostrar_IdProducto;
            TB_IdProducto.ReadOnly = true;
            TB_Nombre.Text = mostrar_Nombre;
            TB_Stock.Text = mostrar_Stock;
            CB_IdProveedor.Text = mostrar_Proveedor;
            CB_IdCategoria.Text = mostrar_Categoria;
            TB_Precio.Text = mostrar_Precio;

        }

        private void F_ActualizacionDatosProducto_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarCategorias();
            TraerDatos();
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

                    // Establece el valor actual si está en la lista
                    if (CB_IdProveedor.Items.Contains(mostrar_Proveedor))
                    {
                        CB_IdProveedor.SelectedItem = mostrar_Proveedor;
                    }
                    else
                    {
                        CB_IdProveedor.Text = mostrar_Proveedor;
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

                    // Establece el valor actual si está en la lista
                    if (CB_IdCategoria.Items.Contains(mostrar_Categoria))
                    {
                        CB_IdCategoria.SelectedItem = mostrar_Categoria;
                    }
                    else
                    {
                        CB_IdCategoria.Text = mostrar_Categoria;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías: " + ex.Message);
                }
            }
        }

        private void B_cancelar_Click_1(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_IdProducto.Clear();
            TB_Nombre.Clear();
            TB_Stock.Clear();
            TB_Precio.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        private void B_confirmar_Click(object sender, EventArgs e)
        {
            ActualizarProducto();
        }

        private void ActualizarProducto()
        {
            string nombre = TB_Nombre.Text.Trim();
            string idProducto = TB_IdProducto.Text.Trim();
            string stockText = TB_Stock.Text.Trim();
            string precioText = TB_Precio.Text.Trim();
            string nombreProveedor = CB_IdProveedor.Text.Trim();
            string nombreCategoria = CB_IdCategoria.Text.Trim();

            if (!int.TryParse(stockText, out int stock) || !int.TryParse(precioText, out int precio))
            {
                MessageBox.Show("Stock o precio no son válidos.");
                return;
            }

            int idProveedor = -1;
            int idCategoria = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Obtener IdProveedor por nombre
                    string queryProveedor = "SELECT IdProveedor FROM Proveedor WHERE Nombre = @NombreProveedor";
                    SqlCommand cmdProveedor = new SqlCommand(queryProveedor, conn);
                    cmdProveedor.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                    object resultProveedor = cmdProveedor.ExecuteScalar();
                    if (resultProveedor != null)
                        idProveedor = Convert.ToInt32(resultProveedor);
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                        return;
                    }

                    // Obtener IdCategoria por nombre
                    string queryCategoria = "SELECT IdCategoria FROM Categoria WHERE Descripcion = @NombreCategoria";
                    SqlCommand cmdCategoria = new SqlCommand(queryCategoria, conn);
                    cmdCategoria.Parameters.AddWithValue("@NombreCategoria", nombreCategoria);
                    object resultCategoria = cmdCategoria.ExecuteScalar();
                    if (resultCategoria != null)
                        idCategoria = Convert.ToInt32(resultCategoria);
                    else
                    {
                        MessageBox.Show("Categoría no encontrada.");
                        return;
                    }

                    // Actualizar el producto
                    string queryUpdate = @"
                UPDATE InventarioProducto
                SET Nombre = @Nombre, Stock = @Stock, IdProveedor = @IdProveedor, IdCategoria = @IdCategoria, Precio = @Precio
                WHERE IdProducto = @IdProducto";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@Nombre", nombre);
                    cmdUpdate.Parameters.AddWithValue("@Stock", stock);
                    cmdUpdate.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmdUpdate.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    cmdUpdate.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmdUpdate.Parameters.AddWithValue("@Precio", precio);

                    int filas = cmdUpdate.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Producto actualizado correctamente.");
                        this.Hide(); // o this.Hide() si prefieres
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar producto: " + ex.Message);
                }
            }
        }

    }
}
