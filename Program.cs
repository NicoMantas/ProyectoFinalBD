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
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new F_PaginaPrincipal());
            Application.Run(new F_InicioSesion());
            
        }
    }
}