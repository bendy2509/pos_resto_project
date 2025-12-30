using POS_RESTO.Configuration;
using POS_RESTO.Utils;

namespace POS_RESTO.Forms;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        AuthentifierUtilisateur();
    }
    
    private void AuthentifierUtilisateur()
    {
        string username = textUsername.Text.Trim();
        string password = textPassword.Text;

        // Validation basique
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Veuillez entrer le nom d'utilisateur et le mot de passe", 
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textUsername.Focus();
            return;
        }

        try
        {
            // Verifier dans la base de données
            if (VerifierIdentifiantsMySql(username, password))
            {
                // Succes - fermer le LoginForm avec DialogResult.OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", 
                    "Echec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.SelectAll();
                textPassword.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur de connexion : {ex.Message}", 
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private bool VerifierIdentifiantsMySql(string username, string password)
    {
        using (var conn = DatabaseConfig.GetConnection())
        {
            conn.Open();
        
            string query = "SELECT user_id, username, role FROM Users WHERE username = @username AND password = @password";
        
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // Note: Dans la réalité, hash le mot de passe
            
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Stocker l'utilisateur
                        Session.UserId = Convert.ToInt32(reader["user_id"]);
                        Session.Username = reader["username"].ToString();
                        Session.Role = reader["role"].ToString();
                    
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
    private void CheckShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        textPassword.UseSystemPasswordChar = !checkShowPassword.Checked;
    }
    
    private void BtnCancel_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(@"Voulez-vous quitter l application ?", 
                @"Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            this.Close();
        }
    }
}