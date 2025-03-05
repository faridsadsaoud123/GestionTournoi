using GestionTournoi.Backend;

namespace GestionTournoi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();

            // Chargement de données par défaut
            Seed.SeedData();
            // Lancement du frontend
            Application.Run(new Form1());
        }
    }
}