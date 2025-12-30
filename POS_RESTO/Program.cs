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
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open(); 
                    conn.Close();
                }
                Console.WriteLine("Connexion MySQL reussie !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion MySQL :\n" + ex.Message, 
                    "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Afficher d abord le LoginForm
            var loginForm = new LoginForm();
    
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si login reussi, ouvrir le MainForm
                Application.Run(new MainForm());
            }
        }
    }
}