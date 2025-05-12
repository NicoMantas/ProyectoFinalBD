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
    public partial class F_ActualizacionDatosProveedor : Form
    {
        private string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";

        string mostrar_idProveedor;
        string mostrar_nombre;
        string mostrar_telefono;
        string mostrar_direccion;
        string mostrar_email;

        public F_ActualizacionDatosProveedor(string IdProveedor, string nombre, string telefono, string direccion, string email)
        {
            InitializeComponent();
            this.mostrar_idProveedor = IdProveedor;
            this.mostrar_nombre = nombre;
            this.mostrar_telefono = telefono;
            this.mostrar_direccion = direccion;
            this.mostrar_email = email;
            TB_Telefono.Leave += TB_Telefono_Leave;
            TB_Nombre.KeyPress += TB_Nombre_KeyPress;
            TB_Email.Leave += TB_Email_Leave;
            TB_Telefono.KeyPress += TB_Telefono_KeyPress;
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
                B_Confirmar.Enabled = false; // Deshabilitar el botón hasta que el correo sea válido
            }
        }


        private void TB_Telefono_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TB_Telefono_Leave(object sender, EventArgs e)
        {
            string telefono_form = TB_Telefono.Text.Trim();

            // Validar que el teléfono tenga al menos 9 caracteres
            if (telefono_form.Length < 9)
            {
                MessageBox.Show("El teléfono debe tener al menos 9 caracteres.");
                TB_Telefono.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_Confirmar.Enabled = false; // Deshabilitar el botón hasta que el teléfono sea válido
            }
        }

        public void TraerDatos()
        {
            TB_IDProveedor.Text = mostrar_idProveedor;
            TB_IDProveedor.ReadOnly = true;
            TB_Nombre.Text = mostrar_nombre;
            TB_Telefono.Text = mostrar_telefono;
            TB_Direccion.Text = mostrar_direccion;
            TB_Email.Text = mostrar_email;

        }

        private void F_ActualizacionDatosProveedor_Load(object sender, EventArgs e)
        {
            TraerDatos();
        }

        private void B_Cancelar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar todos los campos del formulario
            TB_IDProveedor.Clear();
            TB_Nombre.Clear();
            TB_Telefono.Clear();
            TB_Direccion.Clear();
            TB_Email.Clear();

            // 2. Redirigir al formulario principal
            this.Hide(); // cierra el formulario actual (registro)
        }

        private void B_Confirmar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(TB_IDProveedor.Text) ||
                string.IsNullOrWhiteSpace(TB_Nombre.Text) || 
                string.IsNullOrWhiteSpace(TB_Telefono.Text) ||
                string.IsNullOrWhiteSpace(TB_Direccion.Text) || 
                string.IsNullOrWhiteSpace(TB_Email.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdProveedor;
            string nombre = TB_Nombre.Text.Trim();
            string telefono = TB_Telefono.Text.Trim();
            string direccion = TB_Direccion.Text.Trim();
            string email = TB_Email.Text.Trim();

            // Validaciones básicas
            if (!int.TryParse(TB_IDProveedor.Text.Trim(), out IdProveedor))
            {
                MessageBox.Show("ID no valido. Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Por favor ingrese un correo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar en la base de datos
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Proveedor 
                             SET Nombre = @Nombre,
                                Telefono = @Telefono,
                                Direccion = @Direccion,
                                Email = @Email
                             WHERE IdProveedor = @IdProveedor";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@IdProveedor", IdProveedor);

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
