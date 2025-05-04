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

        private void B_Personas_Click(object sender, EventArgs e)
        {
            P_DatosPersonal.Show();
            P_DatosPersonal.BringToFront(); // Mostramos el panel
            CargarDatosPersonas();               // Cargamos la tabla
        }

        private void B_ActualizarPersona_Click(object sender, EventArgs e)
        {
            if (DGV_DatosPersonal.SelectedRows.Count > 0)
            {
                var idPersona = DGV_DatosPersonal.SelectedRows[0].Cells["IdPersona"].Value.ToString();
                // Aquí abrirías un formulario de edición pasando el ID
                MessageBox.Show("Actualizar persona con ID: " + idPersona);
                F_ActualizacionDatos menu = new F_ActualizacionDatos();
                menu.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
