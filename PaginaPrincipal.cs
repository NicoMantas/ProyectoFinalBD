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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            AplicarPermisosPorSeccion(seccionActual);

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
            AplicarPermisosBoton(seccionActual);
            CargarDatosPersonas();

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
                            try
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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error tratando violar algun argumento: " + ex.Message);
                            }
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
                            try
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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error tratando violar algun argumento: " + ex.Message);
                            }
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
                            try
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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error tratando violar algun argumento: " + ex.Message);
                            }
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
                            try
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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error tratando violar algun argumento: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void B_Proveedores_Click(object sender, EventArgs e)
        {
            seccionActual = "Proveedor";
            P_DatosPersonal.Show();
            AplicarPermisosBoton(seccionActual);
            CargarDatosProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seccionActual = "Categoria";
            P_DatosPersonal.Show();
            AplicarPermisosBoton(seccionActual);
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
            AplicarPermisosBoton(seccionActual);
            CargarDatosInventario();

        }

        private void F_PaginaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void B_Ventas_Click(object sender, EventArgs e)
        {
            seccionActual = "Ventas";
            P_DatosPersonal.Show();
            AplicarPermisosBoton(seccionActual);
            CargarDatosVentas();
        }

        public void AplicarPermisosPorSeccion(string seccion)
        {
            if (Program.RolActual == "Administrador")
            {
                // El administrador siempre tiene acceso total
                B_AgregarDatos.Enabled = true;
                B_ActualizarPersona.Enabled = true;
                B_EliminarDatos.Enabled = true;
                B_Despachar.Enabled = true;
            }
            else if (Program.RolActual == "Usuario")
            {
                B_Personas.Visible = false;
                B_CrearPersona.Visible = false;
            }
        }

        public void AplicarPermisosBoton(string seccion)
        {
            if (Program.RolActual == "Usuario")
            {
                // Aplica permisos según la sección
                switch (seccion)
                {
                    case "Inventario":
                        B_AgregarDatos.Visible = true;
                        B_ActualizarPersona.Visible = true;
                        B_EliminarDatos.Visible = false;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = true;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;

                    case "Ventas":
                        B_Despachar.Visible = true;
                        B_AgregarDatos.Visible = false;
                        B_ActualizarPersona.Visible = false;
                        B_EliminarDatos.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = true;
                        TB_Consulta.Visible = true;
                        break;

                    case "Proveedor":
                        B_AgregarDatos.Visible = false;
                        B_ActualizarPersona.Visible = false;
                        B_EliminarDatos.Visible = false;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;
                    case "Categoria":
                        B_AgregarDatos.Visible = false;
                        B_ActualizarPersona.Visible = false;
                        B_EliminarDatos.Visible = false;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (seccion)
                {
                    case "Persona":
                        B_AgregarDatos.Visible = false;
                        B_ActualizarPersona.Visible = true;
                        B_EliminarDatos.Visible = true;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = true;
                        TB_Consulta.Visible = true;
                        break;

                    case "Inventario":
                        B_AgregarDatos.Visible = true;
                        B_ActualizarPersona.Visible = true;
                        B_EliminarDatos.Visible = true;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = true;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;

                    case "Ventas":
                        B_Despachar.Visible = true;
                        B_AgregarDatos.Visible = false;
                        B_ActualizarPersona.Visible = false;
                        B_EliminarDatos.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = true;
                        TB_Consulta.Visible = true;
                        break;

                    case "Proveedor":
                        B_AgregarDatos.Visible = true;
                        B_ActualizarPersona.Visible = true;
                        B_EliminarDatos.Visible = true;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;
                    case "Categoria":
                        B_AgregarDatos.Visible = true;
                        B_ActualizarPersona.Visible = true;
                        B_EliminarDatos.Visible = true;
                        B_Despachar.Visible = false;
                        B_InventarioBajo.Visible = false;
                        B_Consulta.Visible = false;
                        TB_Consulta.Visible = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void B_Despachar_Click(object sender, EventArgs e)
        {
            //Codigo Bueno
            /*
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
            */

            if (seccionActual == "Ventas")
            {
                if (DGV_DatosPersonal.SelectedRows.Count > 0)
                {
                    string idProducto = DGV_DatosPersonal.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                    int cantidadVenta = Convert.ToInt32(DGV_DatosPersonal.SelectedRows[0].Cells["Cantidad"].Value);
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
                            // ✅ Usar procedimiento almacenado para actualizar stock
                            SqlCommand cmdSP = new SqlCommand("SP_ActualizarStockProducto", conn, transaction);
                            cmdSP.CommandType = CommandType.StoredProcedure;
                            cmdSP.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(idProducto));
                            cmdSP.Parameters.AddWithValue("@cantidadVendida", cantidadVenta);
                            cmdSP.ExecuteNonQuery();

                            // ❌ Ya no usamos el updateQuery aquí
                            // ✅ Eliminar el registro de detalle de venta
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

                    CargarDatosVentas(); // Refresca la tabla
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para despachar.");
                }
            }

        }

        private void B_ConsultaPersona_Click(object sender, EventArgs e)
        {
            if (seccionActual == "Persona")
            {
                string email = TB_Consulta.Text;  // Suponiendo que TB_Email es el TextBox donde el usuario ingresa el email
                CargarDatosPersonaPorEmail(email);
            }
            else if (seccionActual == "Ventas")
            {
                // Obtener el texto del TextBox y dividirlo por el delimitador
                string[] fechas = TB_Consulta.Text.Split('-');  // Utilizamos el guion como delimitador entre las fechas

                if (fechas.Length == 2)
                {
                    try
                    {
                        DateTime fechaInicio = Convert.ToDateTime(fechas[0].Trim());  // Convertir la primera fecha (FechaInicio)
                        DateTime fechaFin = Convert.ToDateTime(fechas[1].Trim());     // Convertir la segunda fecha (FechaFin)

                        // Limpiar el TextBox
                        TB_Consulta.Clear();

                        // Llamar al método para cargar los datos
                        CargarDatosVentasPorFecha(fechaInicio, fechaFin);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Por favor, ingrese las fechas en el formato correcto: 'yyyy-MM-dd - yyyy-MM-dd'.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese las fechas separadas por un guion: 'FechaInicio - FechaFin'.");
                }
            }
        }

        private void CargarDatosPersonaPorEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // La consulta SQL ahora filtra por el campo Email
                    string query = @"
                SELECT p.IdPersona, p.Nombre, p.Email, r.Descripcion AS Rol
                FROM Persona p
                INNER JOIN Rol r ON p.IdRol = r.IdRol
                WHERE p.Email = @Email";  // Filtramos por Email

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email); // Parámetro para la consulta

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        // Si hay resultados, asignamos los datos al DataGridView
                        DGV_DatosPersonal.DataSource = tabla;
                        TB_Consulta.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para el email proporcionado.");
                        TB_Consulta.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void CargarDatosVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // La consulta SQL ahora filtra por el rango de fechas
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
                INNER JOIN DetalleVenta DV ON V.IdVenta = DV.IdVenta
                WHERE V.FechaVenta BETWEEN @FechaInicio AND @FechaFin";  // Filtramos por fecha

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        // Si hay resultados, asignamos los datos al DataGridView
                        DGV_DatosPersonal.DataSource = tabla;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para las fechas proporcionadas.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void B_InventarioBajo_Click(object sender, EventArgs e)
        {
            int stockMinimo = 10; // Puedes obtener este valor desde un control NumericUpDown si lo deseas

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_VerInventarioBajoStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    conn.Close();

                    DGV_DatosPersonal.DataSource = dt; // Asignar al DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar el inventario bajo stock: " + ex.Message);
                }
            }
        }
    }
}

