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

        private void B_Personas_Click(object sender, EventArgs e)
        {
            seccionActual = "Persona";
            P_DatosPersonal.Show();
            P_DatosPersonal.BringToFront(); // Mostramos el panel
            B_AgregarDatos.Hide();
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

            }
            else if (seccionActual == "Categoria")
            {

            }
            else if (seccionActual == "Inventario")
            {

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

            }
        }

        private void B_Proveedores_Click(object sender, EventArgs e)
        {
            seccionActual = "Proveedor";
            P_DatosPersonal.Show();
            B_AgregarDatos.Show();
            CargarDatosProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seccionActual = "Categoria";
            P_DatosPersonal.Show();
            B_AgregarDatos.Show();
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
            //CargarDatosInventario();

        }

        private void F_PaginaPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
