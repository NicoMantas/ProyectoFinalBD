using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProyectoBD
{
    public partial class F_ActualizacionDatos : Form
    {

        private string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        string mostrar_cedula;
        string mostrar_nombre;
        string mostrar_email;
        string mostrar_telefono;
        string mostrar_idRol;

        public F_ActualizacionDatos(string cedula, string nombre, string email, string telefono, string idRol)
        {
            InitializeComponent();
            this.mostrar_cedula = cedula;
            this.mostrar_nombre = nombre;
            this.mostrar_email = email;
            this.mostrar_telefono = telefono;
            this.mostrar_idRol = idRol;
            TB_Nombre.KeyPress += TB_Nombre_KeyPress;
            TB_Telefono.KeyPress += TB_Telefono_KeyPress;
            TB_Telefono.Leave += TB_Telefono_Leave;
            TB_Email.Leave += TB_Email_Leave;
        }

        private void TB_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacio y teclas de control (como backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea todo lo que no sea letra, espacio o control
            }
        }
        private void TB_Telefono_Leave(object sender, EventArgs e)
        {
            string telefono_form = TB_Telefono.Text.Trim();

            // Validar que el teléfono tenga al menos 9 caracteres
            if (telefono_form.Length < 9)
            {
                MessageBox.Show("El teléfono debe tener al menos 9 caracteres.");
                TB_Telefono.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_GuardarActualizacionPersona.Enabled = false; // Deshabilitar el botón hasta que el teléfono sea válido
            }
        }

        private void TB_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea caracteres no numéricos
            }
        }
        private void TB_Email_Leave(object sender, EventArgs e)
        {
            string email_form = TB_Email.Text.Trim();
            // Expresión regular para validar el formato del correo
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email_form, patronCorreo))
            {
                MessageBox.Show("Por favor, ingresa un correo electrónico válido.");
                TB_Email.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_GuardarActualizacionPersona.Enabled = false; // Deshabilitar el botón hasta que el correo sea válido
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_Cedula.Clear();
            TB_Nombre.Clear();
            TB_Email.Clear();
            TB_Telefono.Clear();
            CB_Rol.SelectedIndex = -1;

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        public void TraerDatos()
        {
            TB_Cedula.Text = mostrar_cedula;
            TB_Cedula.ReadOnly = true;
            TB_Nombre.Text = mostrar_nombre;
            TB_Email.Text = mostrar_email;
            TB_Telefono.Text = mostrar_telefono;
            CB_Rol.SelectedIndex = CB_Rol.FindStringExact(mostrar_idRol);


        }

        private void CargarRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdRol, Descripcion FROM Rol";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable roles = new DataTable();
                    roles.Load(reader);

                    CB_Rol.DataSource = roles;
                    CB_Rol.DisplayMember = "Descripcion"; // Lo que el usuario ve
                    CB_Rol.ValueMember = "IdRol";       // El valor real que se guarda

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar roles: " + ex.Message);
                }
            }
        }

        private void F_ActualizacionDatos_Load(object sender, EventArgs e)
        {
            CargarRoles();  // Asegúrate de tener esta función como en el formulario de registro
            TraerDatos();
        }

        private void B_GuardarActualizacionPersona_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TB_Cedula.Text) ||
                string.IsNullOrWhiteSpace(TB_Nombre.Text) ||
                string.IsNullOrWhiteSpace(TB_Email.Text) ||
                string.IsNullOrWhiteSpace(TB_Telefono.Text) ||
                CB_Rol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long cedula, telefono;
            int idRol;

            // Validaciones básicas
            if (!long.TryParse(TB_Cedula.Text.Trim(), out cedula) ||
                !long.TryParse(TB_Telefono.Text.Trim(), out telefono))
            {
                MessageBox.Show("Cédula o Teléfono inválidos. Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idRol = Convert.ToInt32(CB_Rol.SelectedValue);
            string nombre = TB_Nombre.Text.Trim();
            string email = TB_Email.Text.Trim();

            // Actualizar en la base de datos
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Persona 
                             SET Nombre = @Nombre, 
                                 Telefono = @Telefono, 
                                 Email = @Email, 
                                 IdRol = @IdRol
                             WHERE IdPersona = @Cedula";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@IdRol", idRol);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

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
