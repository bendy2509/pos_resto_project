using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;
using POS_RESTO.Utils;
using POS_RESTO.Forms;

namespace POS_RESTO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            try
            {
                // Test connexion MySQL
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open(); 
                    conn.Close();
                }
                Console.WriteLine("Connexion MySQL réussie !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion MySQL :\n" + ex.Message, 
                    "Échec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            // Boucle principale
            bool keepRunning = true;
    
            while (keepRunning)
            {
                // Afficher login
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() == DialogResult.OK && Session.IsLoggedIn)
                    {
                        // Afficher dashboard
                        using (var dashboard = new DashboardForm())
                        {
                            dashboard.ShowDialog();
                            // A la fermeture du dashboard
                            if (!Session.IsLoggedIn)
                            {
                                // L'utilisateur s'est deconnecte, on recommence
                                continue;
                            }

                            // L'utilisateur a ferme l'application
                            keepRunning = false;
                        }
                    }
                    else
                    {
                        // Login annule ou echoue
                        keepRunning = false;
                    }
                }
            }
        }
    }
}