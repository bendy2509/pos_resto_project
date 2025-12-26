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
        
            // Afficher d'abord le LoginForm
            var loginForm = new Forms.LoginForm();
            
            if (loginForm.ShowDialog() == DialogResult.OK) 
            {
                // Puis ouvrir le DashboardForm
                Application.Run(new Forms.DashboardForm());
            }
            else
            {
                // Login annule ou echoue
                Application.Exit();
            }
        }
    }
}