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
    public partial class F_InicioSesion : Form
    {

        string connectionString = "Data Source=(localdb)\\MyLocalDB;Initial Catalog=BD_Inventario;Integrated Security=True";
        int contadorIntentos = 0;


        public F_InicioSesion()
        {
            InitializeComponent();
            B_InicioSesion.Enabled = false;

        }

        private void F_InicioSesion_Load(object sender, EventArgs e)
        {

        }

        public bool ValidarCampos()
        {
            if (!string.IsNullOrWhiteSpace(TB_contraseña.Text) && !string.IsNullOrWhiteSpace(TB_email.Text))
            {
                B_InicioSesion.Enabled = true;
                return true;
            }
            else
            {
                B_InicioSesion.Enabled = false;
                return false;
            }
        }

        public bool ValidarCredenciales()
        {
            string email_form = TB_email.Text.Trim();
            string contraseña_form = TB_contraseña.Text;
            bool credencialesValidas = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Persona WHERE Email = @Email AND Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email_form);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña_form);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    credencialesValidas = count > 0;
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
            if (ValidarCredenciales())
            {
                MessageBox.Show("Bienvenido");
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
