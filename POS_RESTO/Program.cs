using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

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
                // On utilise MySqlConnection pour le type de connexion
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open(); 
                    conn.Close();
                }
                // MessageBox.Show("Connexion MySQL reussie !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion MySQL :\n" + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // On arrete l'execution
            }

            // Lance le formulaire principal
            // Application.Run(new Form1());
            
            // Tester le formulaire de login
            Application.Run(new Forms.LoginForm());
            
            // Tester le dashboard
            // Application.Run(new Forms.DashboardForm());
        }
    }
}