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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoBD
{
    public partial class F_InicioSesion : Form
    {

        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";
        int contadorIntentos = 0;


        public F_InicioSesion()
        {
            InitializeComponent();
            B_InicioSesion.Enabled = false;
            TB_email.Leave += new EventHandler(TB_email_Leave);
            TB_contraseña.Leave += new EventHandler(TB_contraseña_Leave);

        }

        // Validación cuando el correo pierde el foco
        private void TB_email_Leave(object sender, EventArgs e)
        {
            string email_form = TB_email.Text.Trim();
            // Expresión regular para validar el formato del correo
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email_form, patronCorreo))
            {
                MessageBox.Show("Por favor, ingresa un correo electrónico válido.");
                TB_email.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_InicioSesion.Enabled = false; // Deshabilitar el botón hasta que el correo sea válido
            }
            else
            {
                ValidarCampos();
            }
        }

        // Validación cuando la contraseña pierde el foco
        private void TB_contraseña_Leave(object sender, EventArgs e)
        {
            string contraseña_form = TB_contraseña.Text;

            if (contraseña_form.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                TB_contraseña.Focus(); // Enfocar el campo para que el usuario lo corrija
                B_InicioSesion.Enabled = false; // Deshabilitar el botón hasta que la contraseña sea válida
            }
            else
            {
                ValidarCampos();
            }
        }


        private void F_InicioSesion_Load(object sender, EventArgs e)
        {

        }

        public bool ValidarCampos()
        {
            string email_form = TB_email.Text.Trim();
            string contraseña_form = TB_contraseña.Text;

            // Validación de que no esté vacío
            if (string.IsNullOrWhiteSpace(contraseña_form) || string.IsNullOrWhiteSpace(email_form))
            {
                B_InicioSesion.Enabled = false;
                return false;
            }

            // Si ambos campos son válidos, habilitar el botón
            B_InicioSesion.Enabled = true;
            return true;
        }


        public bool ValidarCredenciales(out string rolUsuario)
        {
            string email_form = TB_email.Text.Trim();
            string contraseña_form = TB_contraseña.Text;
            bool credencialesValidas = false;
            rolUsuario = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                        SELECT R.Descripcion 
                        FROM Persona P
                        JOIN Rol R ON P.IdRol = R.IdRol
                        WHERE P.Email = @Email AND P.Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email_form);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña_form);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        credencialesValidas = true;
                        rolUsuario = reader["Descripcion"].ToString(); // Obtener el rol
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales no son válidas.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al validar credenciales: " + ex.Message);
                }
            }

            return credencialesValidas;
        }



        private void TB_email_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void B_InicioSesion_Click(object sender, EventArgs e)
        {
            string rol = string.Empty;

            if (ValidarCredenciales(out rol))
            {
                // Guardamos el rol en una variable global (lo puedes utilizar en el siguiente formulario)
                Program.RolActual = rol;
                MessageBox.Show("Bienvenido recuerde que usted tiene un rol de: " + Program.RolActual);
                F_PaginaPrincipal menu = new F_PaginaPrincipal(); // Crear instancia del siguiente form
                menu.Show(); // Mostrar el nuevo formulario

                this.Hide(); // Ocultar el formulario actual (opcional)
                // Aquí puedes continuar con el siguiente formulario o lógica
                contadorIntentos = 0; // Reiniciar en caso de éxito
            }
            else
            {
                contadorIntentos++;
                if (contadorIntentos < 3)
                {
                    MessageBox.Show("Credenciales incorrectas. Intente nuevamente.");
                    TB_email.Clear();
                    TB_contraseña.Clear();
                }
                else
                {
                    MessageBox.Show("Ha superado el número de intentos. Espere 30 segundos para intentar nuevamente.");
                    B_InicioSesion.Enabled = false;

                    // Espera de 30 segundos usando un temporizador
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 30000; // 30 segundos
                    timer.Tick += (s, args) =>
                    {
                        B_InicioSesion.Enabled = true;
                        contadorIntentos = 0;
                        timer.Stop();
                        MessageBox.Show("Ya puede volver a intentar.");
                    };
                    timer.Start();
                }
            }
        }

        private void TB_contraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void CB_VerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            TB_contraseña.UseSystemPasswordChar = !CB_VerContraseña.Checked;
        }
    }
}
