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
using System.Windows.Forms.VisualStyles;
using Microsoft.Data.SqlClient;

namespace ProyectoBD
{
    public partial class F_Registro : Form
    {

        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";


        public F_Registro()
        {
            InitializeComponent();
            B_GuardarCrear.Enabled = false;
            TB_Telefono.KeyPress += TB_Telefono_KeyPress;
            TB_Cedula.KeyPress += TB_Cedula_KeyPress;
            TB_Nombre.KeyPress += TB_Nombre_KeyPress;
            TB_Email.Leave += TB_Email_Leave;
            TB_Contraseña.Leave += TB_Contraseña_Leave;
            TB_Telefono.Leave += TB_Telefono_Leave;



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
                B_GuardarCrear.Enabled = false; // Deshabilitar el botón hasta que el correo sea válido
            }
            else
            {
                ValidarCampos(); // Verifica que todos los campos sean válidos
            }
        }


        private void TB_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea caracteres no numéricos
            }
        }

        private void TB_Cedula_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TB_Contraseña_Leave(object sender, EventArgs e)
        {
            string contraseña_form = TB_Contraseña.Text;

            // Validar que la contraseña tenga al menos 6 caracteres
            if (contraseña_form.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                TB_Contraseña.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_GuardarCrear.Enabled = false; // Deshabilitar el botón hasta que la contraseña sea válida
            }
            else
            {
                ValidarCampos(); // Verificar que todos los campos sean válidos
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
                B_GuardarCrear.Enabled = false; // Deshabilitar el botón hasta que el teléfono sea válido
            }
            else
            {
                ValidarCampos(); // Verificar que todos los campos sean válidos
            }
        }


        private void F_Registro_Load(object sender, EventArgs e)
        {
            CargarRoles();
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


        public bool CrearPersona()
        {
            long cedula_form;
            long telefono_form;

            // Validar conversiones
            if (!long.TryParse(TB_Cedula.Text.Trim(), out cedula_form) ||
                !long.TryParse(TB_Telefono.Text.Trim(), out telefono_form))
            {
                MessageBox.Show("Cédula o teléfono no son números válidos.");
                return false;
            }

            string nombre_form = TB_Nombre.Text.Trim();
            string contraseña_form = TB_Contraseña.Text.Trim();
            string email_form = TB_Email.Text.Trim();
            int idRol_form = Convert.ToInt32(CB_Rol.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Primero validamos si ya existe ese email
                    string queryVerificar = "SELECT COUNT(*) FROM Persona WHERE IdPersona = @IdPersona OR Email = @Email OR Telefono = @Telefono";
                    SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conn);
                    cmdVerificar.Parameters.AddWithValue("@IdPersona", cedula_form);
                    cmdVerificar.Parameters.AddWithValue("@Email", email_form);
                    cmdVerificar.Parameters.AddWithValue("@Telefono", telefono_form);

                    int count = (int)cmdVerificar.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Esta cedula, telefono o correo ya están registrados.");
                        return false;
                    }

                    // Insertamos la nueva persona
                    string queryInsert = @"INSERT INTO Persona (IdPersona, Nombre, Contraseña, Telefono, Email, IdRol) 
                                   VALUES (@IdPersona, @Nombre, @Contraseña, @Telefono, @Email, @IdRol)";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@IdPersona", cedula_form);
                    cmdInsert.Parameters.AddWithValue("@Nombre", nombre_form);
                    cmdInsert.Parameters.AddWithValue("@Contraseña", contraseña_form);
                    cmdInsert.Parameters.AddWithValue("@Telefono", telefono_form);
                    cmdInsert.Parameters.AddWithValue("@Email", email_form);
                    cmdInsert.Parameters.AddWithValue("@IdRol", idRol_form);

                    int filas = cmdInsert.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Persona creada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la persona.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear persona: " + ex.Message);
                    return false;
                }
            }
        }

        public bool ValidarCampos()
        {
            bool camposValidos =
                !string.IsNullOrWhiteSpace(TB_Cedula.Text) &&
                !string.IsNullOrWhiteSpace(TB_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(TB_Email.Text) &&
                !string.IsNullOrWhiteSpace(TB_Contraseña.Text) &&
                !string.IsNullOrWhiteSpace(TB_Telefono.Text) &&
                CB_Rol.SelectedIndex != -1;

            B_GuardarCrear.Enabled = camposValidos; // Asumiendo que tienes un botón de registro
            return camposValidos;
        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_Cedula.Clear();
            TB_Nombre.Clear();
            TB_Email.Clear();
            TB_Contraseña.Clear();
            TB_Telefono.Clear();
            CB_Rol.SelectedIndex = -1;

            // 2. Redirigir al formulario principal
            F_PaginaPrincipal menu = new F_PaginaPrincipal(); // crea instancia
            menu.Show(); // muestra la nueva ventana
            this.Hide(); // cierra el formulario actual (registro)
        }

        private void B_GuardarCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                bool creado = CrearPersona();

                if (creado)
                {
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ir al formulario principal
                    F_PaginaPrincipal menu = new F_PaginaPrincipal();
                    menu.Show();
                    this.Hide(); // cerrar el actual
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al crear el usuario. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TB_Cedula_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TB_Nombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TB_Contraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TB_Telefono_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TB_Email_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}
