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
    public partial class F_PaginaPrincipal : Form
    {
        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";
        private string seccionActual = "";


        public F_PaginaPrincipal()
        {
            InitializeComponent();
            P_DatosPersonal.Hide();
        }

        private void B_CerrarSesion_Click(object sender, EventArgs e)
        {
            F_InicioSesion login = new F_InicioSesion(); // o F_Registro si vuelves allí
            login.Show();
            this.Hide(); // o this.Hide();
        }

        private void B_CrearPersona_Click(object sender, EventArgs e)
        {
            F_Registro login = new F_Registro(); // o F_Registro si vuelves allí
            login.Show();
            this.Hide(); // o this.Hide();
        }

        private void P_DatosPersonal_Paint(object sender, PaintEventArgs e)
        {
            P_DatosPersonal.Controls.Add(DGV_DatosPersonal);
            DGV_DatosPersonal.Dock = DockStyle.Fill;

        }

        private void CargarDatosPersonas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
               SELECT p.IdPersona, p.Nombre, p.Email, p.Telefono, r.Descripcion AS Rol
                FROM Persona p
                INNER JOIN Rol r ON p.IdRol = r.IdRol";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DGV_DatosPersonal.DataSource = tabla;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void CargarDatosProveedores()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
               SELECT IdProveedor, Nombre, Telefono, Direccion, Email
                FROM Proveedor";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DGV_DatosPersonal.DataSource = tabla;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void CargarDatosCategorias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
               SELECT IdCategoria, Descripcion
                FROM Categoria";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DGV_DatosPersonal.DataSource = tabla;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void CargarDatosVentas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    V.IdVenta,
                    V.FechaVenta,
                    V.Cliente,
                    V.IdPersona,
                    DV.IdDetalleVenta,
                    DV.IdProducto,
                    DV.Cantidad
                FROM Venta V
                INNER JOIN DetalleVenta DV ON V.IdVenta = DV.IdVenta";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DGV_DatosPersonal.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void CargarDatosInventario()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                                    SELECT 
                                        p.IdProducto, 
                                        p.Nombre, 
                                        p.Stock, 
                                        pr.Nombre AS Proveedor, 
                                        c.Descripcion AS Categoria, 
                                        p.Precio
                                    FROM InventarioProducto p
                                    INNER JOIN Proveedor pr ON p.IdProveedor = pr.IdProveedor
                                    INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DGV_DatosPersonal.DataSource = tabla;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void B_Personas_Click(object sender, EventArgs e)
        {
            seccionActual = "Persona";
            P_DatosPersonal.Show();
            P_DatosPersonal.BringToFront(); // Mostramos el panel
            B_AgregarDatos.Hide();
            B_Despachar.Hide();
            CargarDatosPersonas();               // Cargamos la tabla
        }

        private void B_ActualizarPersona_Click(object sender, EventArgs e)
        {
            if (seccionActual == "Persona")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idPersona = DGV_DatosPersonal.SelectedRows[0].Cells["IdPersona"].Value.ToString();
                    // Aquí abrirías un formulario de edición pasando el ID
                    MessageBox.Show("Actualizar persona con ID: " + idPersona);

                    string cedula = DGV_DatosPersonal.SelectedRows[0].Cells["IdPersona"].Value.ToString();
                    string nombre = DGV_DatosPersonal.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    string email = DGV_DatosPersonal.SelectedRows[0].Cells["Email"].Value.ToString();
                    string telefono = DGV_DatosPersonal.SelectedRows[0].Cells["Telefono"].Value.ToString();
                    string idRol = DGV_DatosPersonal.SelectedRows[0].Cells["Rol"].Value.ToString();


                    F_ActualizacionDatos menu = new F_ActualizacionDatos(cedula, nombre, email, telefono, idRol);
                    menu.Show();
                }
            }
            else if (seccionActual == "Proveedor")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idProveedor = DGV_DatosPersonal.SelectedRows[0].Cells["IdProveedor"].Value.ToString();
                    // Aquí abrirías un formulario de edición pasando el ID
                    MessageBox.Show("Actualizar persona con ID: " + idProveedor);

                    string IdProveedor = DGV_DatosPersonal.SelectedRows[0].Cells["IdProveedor"].Value.ToString();
                    string nombre = DGV_DatosPersonal.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    string telefono = DGV_DatosPersonal.SelectedRows[0].Cells["Telefono"].Value.ToString();
                    string direccion = DGV_DatosPersonal.SelectedRows[0].Cells["Direccion"].Value.ToString();
                    string email = DGV_DatosPersonal.SelectedRows[0].Cells["Email"].Value.ToString();


                    F_ActualizacionDatosProveedor menu = new F_ActualizacionDatosProveedor(IdProveedor, nombre, telefono, direccion, email);
                    menu.Show();
                }
            }
            else if (seccionActual == "Categoria")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idCategoria = DGV_DatosPersonal.SelectedRows[0].Cells["IdCategoria"].Value.ToString();
                    // Aquí abrirías un formulario de edición pasando el ID
                    MessageBox.Show("Actualizar persona con ID: " + idCategoria);

                    string IdCategoria = DGV_DatosPersonal.SelectedRows[0].Cells["IdCategoria"].Value.ToString();
                    string Descripcion = DGV_DatosPersonal.SelectedRows[0].Cells["Descripcion"].Value.ToString();


                    F_ActualizacionDatosCategoria menu = new F_ActualizacionDatosCategoria(IdCategoria, Descripcion);
                    menu.Show();
                }
            }
            else if (seccionActual == "Inventario")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                    // Aquí abrirías un formulario de edición pasando el ID
                    MessageBox.Show("Actualizar persona con ID: " + idProducto);

                    string IdProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                    string Nombre = DGV_DatosPersonal.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    string Stock = DGV_DatosPersonal.SelectedRows[0].Cells["Stock"].Value.ToString();
                    string Proveedor = DGV_DatosPersonal.SelectedRows[0].Cells["Proveedor"].Value.ToString();
                    string Categoria = DGV_DatosPersonal.SelectedRows[0].Cells["Categoria"].Value.ToString();
                    string Precio = DGV_DatosPersonal.SelectedRows[0].Cells["Precio"].Value.ToString();


                    F_ActualizacionDatosProducto menu = new F_ActualizacionDatosProducto(IdProducto, Nombre, Stock, Proveedor, Categoria, Precio);
                    menu.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (seccionActual == "Persona")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idPersona = DGV_DatosPersonal.SelectedRows[0].Cells["IdPersona"].Value.ToString();

                    // Confirmación
                    var confirm = MessageBox.Show("¿Estás seguro de eliminar esta persona?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string deleteQuery = "DELETE FROM Persona WHERE IdPersona = @Id";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@Id", idPersona);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Persona eliminada.");
                            CargarDatosPersonas(); // refrescar tabla
                        }
                    }
                }
            }
            else if (seccionActual == "Proveedor")
            {

                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idProveedor = DGV_DatosPersonal.SelectedRows[0].Cells["IdProveedor"].Value.ToString();

                    // Confirmación
                    var confirm = MessageBox.Show("¿Estás seguro de eliminar este Proveedor?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string deleteQuery = "DELETE FROM Proveedor WHERE IdProveedor = @IdProveedor";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Proveedor eliminado.");
                            CargarDatosProveedores(); // refrescar tabla
                        }
                    }
                }

            }
            else if (seccionActual == "Categoria")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idCategoria = DGV_DatosPersonal.SelectedRows[0].Cells["IdCategoria"].Value.ToString();

                    // Confirmación
                    var confirm = MessageBox.Show("¿Estás seguro de eliminar esta Categoria?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string deleteQuery = "DELETE FROM Categoria WHERE IdCategoria = @IdCategoria";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Categoria eliminada.");
                            CargarDatosCategorias(); // refrescar tabla
                        }
                    }
                }

            }
            else if (seccionActual == "Inventario")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    var idProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();

                    // Confirmación
                    var confirm = MessageBox.Show("¿Estás seguro de eliminar este Producto?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string deleteQuery = "DELETE FROM InventarioProducto WHERE IdProducto = @IdProducto";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Producto eliminado.");
                            CargarDatosInventario(); // refrescar tabla
                        }
                    }
                }
            }
        }

        private void B_Proveedores_Click(object sender, EventArgs e)
        {
            seccionActual = "Proveedor";
            P_DatosPersonal.Show();
            B_AgregarDatos.Show();
            B_ActualizarPersona.Show();
            B_EliminarDatos.Show();
            B_Despachar.Hide();
            CargarDatosProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seccionActual = "Categoria";
            P_DatosPersonal.Show();
            B_AgregarDatos.Show();
            B_ActualizarPersona.Show();
            B_EliminarDatos.Show();
            B_Despachar.Hide();
            CargarDatosCategorias();
        }

        private void B_AgregarDatos_Click(object sender, EventArgs e)
        {
            if (seccionActual == "Proveedor")
            {
                F_AgregarProveedor menu = new F_AgregarProveedor();
                menu.Show();

            }
            else if (seccionActual == "Categoria")
            {
                F_AgregarCategoria menu = new F_AgregarCategoria();
                menu.Show();
            }
            else if (seccionActual == "Inventario")
            {
                F_AgregarInventario menu = new F_AgregarInventario();
                menu.Show();
            }
        }

        private void B_Inventario_Click(object sender, EventArgs e)
        {
            seccionActual = "Inventario";
            P_DatosPersonal.Show();
            B_AgregarDatos.Show();
            B_ActualizarPersona.Show();
            B_EliminarDatos.Show();
            B_Despachar.Hide();
            CargarDatosInventario();

        }

        private void F_PaginaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void B_Ventas_Click(object sender, EventArgs e)
        {
            seccionActual = "Ventas";
            P_DatosPersonal.Show();
            B_AgregarDatos.Hide();
            B_ActualizarPersona.Hide();
            B_EliminarDatos.Hide();
            B_Despachar.Show();
            CargarDatosVentas();
        }

        private void B_Despachar_Click(object sender, EventArgs e)
        {
            /*
            if (seccionActual == "Ventas")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    string idProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                    int cantidadVenta = Convert.ToInt32(DGV_DatosPersonal.SelectedRows[0].Cells["Cantidad"].Value); // Cantidad vendida (a despachar)

                    // Consulta para obtener el stock actual desde InventarioProducto
                    int stockActual = 0;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string stockQuery = "SELECT Stock FROM InventarioProducto WHERE IdProducto = @IdProducto";
                        SqlCommand cmd = new SqlCommand(stockQuery, conn);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            stockActual = Convert.ToInt32(result);
                        }
                        conn.Close();
                    }

                    if (stockActual < cantidadVenta)
                    {
                        MessageBox.Show("No hay suficiente stock para despachar esa cantidad.");
                        return;
                    }

                    // Si hay suficiente stock, actualizamos el inventario
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE InventarioProducto SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidadVenta);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Producto despachado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para despachar.");
                }
            }
            */
            if (seccionActual == "Ventas")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    string idProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                    int cantidadVenta = Convert.ToInt32(DGV_DatosPersonal.SelectedRows[0].Cells["Cantidad"].Value);

                    // Este es el ID del registro a eliminar (de la tabla DetalleVenta, por ejemplo)
                    string idDetalleVenta = DGV_DatosPersonal.SelectedRows[0].Cells["IdDetalleVenta"].Value.ToString();

                    int stockActual = 0;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string stockQuery = "SELECT Stock FROM InventarioProducto WHERE IdProducto = @IdProducto";
                        SqlCommand cmd = new SqlCommand(stockQuery, conn);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            stockActual = Convert.ToInt32(result);
                        }
                        conn.Close();
                    }

                    if (stockActual < cantidadVenta)
                    {
                        MessageBox.Show("No hay suficiente stock para despachar esa cantidad.");
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // Actualizar el stock
                            string updateQuery = "UPDATE InventarioProducto SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";
                            SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@Cantidad", cantidadVenta);
                            cmdUpdate.Parameters.AddWithValue("@IdProducto", idProducto);
                            cmdUpdate.ExecuteNonQuery();

                            // Eliminar el registro de detalle de venta
                            string deleteQuery = "DELETE FROM DetalleVenta WHERE IdDetalleVenta = @IdDetalleVenta";
                            SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn, transaction);
                            cmdDelete.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);
                            cmdDelete.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Producto despachado y registro eliminado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al despachar producto: " + ex.Message);
                        }

                        conn.Close();
                    }

                    CargarDatosVentas(); // Refresca la tabla con los registros restantes
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para despachar.");
                }
            }
        }

    }
}

