using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS_RESTO.Configuration;

namespace POS_RESTO.Forms
{
    public partial class ClientForm : Form
    {
        public ClientForm(int? id = null)
        {
            clientId = id;
            InitializeComponent();
           
            
            if (clientId.HasValue)
            {
                this.Text = "MODIFIER CLIENT";
                LoadClientData();
            }
            else
            {
                this.Text = "NOUVEAU CLIENT";
            }
        }
        
        private void LoadClientData()
        {
            try
            {
                string query = "SELECT * FROM Clients WHERE client_id = @id";
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId.Value);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLastName.Text = reader["last_name"].ToString();
                                txtFirstName.Text = reader["first_name"].ToString();
                                cmbGender.Text = reader["gender"].ToString();
                                txtPhone.Text = reader["phone"]?.ToString() ?? "";
                                txtEmail.Text = reader["email"]?.ToString() ?? "";
                                numDebt.Value = Convert.ToDecimal(reader["debt_amount"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement client: {ex.Message}");
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Veuillez saisir le nom");
                txtLastName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Veuillez saisir le prenom");
                txtFirstName.Focus();
                return;
            }
            
            try
            {
                string query;
                
                if (clientId.HasValue)
                {
                    query = @"UPDATE Clients SET 
                             last_name = @lastName,
                             first_name = @firstName,
                             gender = @gender,
                             phone = @phone,
                             email = @email,
                             debt_amount = @debt
                             WHERE client_id = @id";
                }
                else
                {
                    query = @"INSERT INTO Clients (last_name, first_name, gender, phone, email, debt_amount) 
                             VALUES (@lastName, @firstName, @gender, @phone, @email, @debt)";
                }
                
                using (var conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@debt", numDebt.Value);
                        
                        if (clientId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", clientId.Value);
                        }
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show(clientId.HasValue ? "Client modifie avec succes" : "Client ajoute avec succes");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur sauvegarde: {ex.Message}");
            }
        }
    }
}