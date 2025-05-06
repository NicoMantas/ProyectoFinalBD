using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace ProyectoBD
{
    internal static class Program
    {
        public static string RolActual = ""; // Variable global para el rol del usuario
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new F_PaginaPrincipal());
            //Application.Run(new F_InicioSesion());
            */

            // Mostrar formulario de inicio de sesi�n
            F_InicioSesion inicioSesion = new F_InicioSesion();
            inicioSesion.ShowDialog(); // Espera que el usuario inicie sesi�n

            // Verificar si el rol ha sido asignado correctamente
            if (!string.IsNullOrEmpty(Program.RolActual)) // Si el rol es v�lido
            {
                // Dependiendo del rol, mostrar el formulario correspondiente
                ApplicationConfiguration.Initialize();
                Application.Run(new F_PaginaPrincipal());
            }
            else
            {
                MessageBox.Show("No se ha iniciado sesi�n correctamente.", "Error de inicio de sesi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}