using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;
using POS_RESTO.Utils;

namespace POS_RESTO.Data
{
    public static class ClientDao
    {
        // Méthode pour charger un client par ID (utilisée dans LoadClientData)
        public static Client GetClientById(int clientId)
        {
            try
            {
                string query = "SELECT * FROM Clients WHERE client_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Client
                                {
                                    ClientId = Convert.ToInt32(reader["client_id"]),
                                    LastName = reader["last_name"].ToString(),
                                    FirstName = reader["first_name"].ToString(),
                                    Gender = reader["gender"]?.ToString(),
                                    Phone = reader["phone"]?.ToString(),
                                    Email = reader["email"]?.ToString(),
                                    DebtAmount = Convert.ToDecimal(reader["debt_amount"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement client: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode pour sauvegarder un client (utilisée dans BtnSave_Click)
        public static void SaveClient(Client client)
        {
            if (!string.IsNullOrWhiteSpace(client.Email) && 
                !ValidationHelper.IsValidEmail(client.Email))
            {
                throw new Exception("Format email invalide");
            }
            
            try
            {
                string query;
                
                if (client.ClientId > 0)
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
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lastName", client.LastName);
                        cmd.Parameters.AddWithValue("@firstName", client.FirstName);
                        cmd.Parameters.AddWithValue("@gender", client.Gender ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", client.Phone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", client.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@debt", client.DebtAmount);
                        
                        if (client.ClientId > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", client.ClientId);
                        }
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur sauvegarde client: {ex.Message}", ex);
            }
        }
        
        // Méthodes supplémentaires utiles
        public static List<Client> GetAllClients()
        {
            var clients = new List<Client>();
            
            try
            {
                string query = "SELECT * FROM Clients ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clients.Add(new Client
                                {
                                    ClientId = Convert.ToInt32(reader["client_id"]),
                                    LastName = reader["last_name"].ToString(),
                                    FirstName = reader["first_name"].ToString(),
                                    Gender = reader["gender"]?.ToString(),
                                    Phone = reader["phone"]?.ToString(),
                                    Email = reader["email"]?.ToString(),
                                    DebtAmount = Convert.ToDecimal(reader["debt_amount"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement clients: {ex.Message}", ex);
            }
            
            return clients;
        }
        
        public static DataTable GetClientsDataTable()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = "SELECT * FROM Clients ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable clients: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static int DeleteClient(int clientId)
        {
            try
            {
                string query = "DELETE FROM Clients WHERE client_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", clientId);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur suppression client: {ex.Message}", ex);
            }
        }
        
        public static List<Client> SearchClients(string searchText)
        {
            var clients = new List<Client>();
            
            try
            {
                string query = @"
                    SELECT * FROM Clients 
                    WHERE last_name LIKE @search 
                       OR first_name LIKE @search 
                       OR phone LIKE @search 
                       OR email LIKE @search
                    ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clients.Add(new Client
                                {
                                    ClientId = Convert.ToInt32(reader["client_id"]),
                                    LastName = reader["last_name"].ToString(),
                                    FirstName = reader["first_name"].ToString(),
                                    Gender = reader["gender"]?.ToString(),
                                    Phone = reader["phone"]?.ToString(),
                                    Email = reader["email"]?.ToString(),
                                    DebtAmount = Convert.ToDecimal(reader["debt_amount"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur recherche clients: {ex.Message}", ex);
            }
            
            return clients;
        }
        
        public static void UpdateClientDebt(int clientId, decimal amount)
        {
            try
            {
                string query = "UPDATE Clients SET debt_amount = @debt WHERE client_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@debt", amount);
                        cmd.Parameters.AddWithValue("@id", clientId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur mise à jour dette: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir un DataTable formaté pour le UserControl
        public static DataTable GetAllClientsDataTable()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        client_id as 'ID',
                        last_name as 'Nom',
                        first_name as 'Prénom',
                        gender as 'Genre',
                        phone as 'Téléphone',
                        email as 'Email',
                        FORMAT(debt_amount, 2) as 'Dette (HTG)'
                    FROM Clients 
                    ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable clients: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        public static DataTable SearchClientsDataTable(string searchTerm)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        client_id as 'ID',
                        last_name as 'Nom',
                        first_name as 'Prénom',
                        gender as 'Genre',
                        phone as 'Téléphone',
                        email as 'Email',
                        FORMAT(debt_amount, 2) as 'Dette (HTG)'
                    FROM Clients 
                    WHERE last_name LIKE @search 
                       OR first_name LIKE @search 
                       OR phone LIKE @search 
                       OR email LIKE @search
                    ORDER BY last_name, first_name";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur recherche DataTable clients: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir le total de la dette de tous les clients
        public static decimal GetTotalDebt()
        {
            try
            {
                string query = "SELECT COALESCE(SUM(debt_amount), 0) FROM Clients";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        return Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total dette: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir les clients avec une dette
        public static DataTable GetClientsWithDebtDataTable()
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        client_id as 'ID',
                        last_name as 'Nom',
                        first_name as 'Prénom',
                        phone as 'Téléphone',
                        email as 'Email',
                        FORMAT(debt_amount, 2) as 'Dette (HTG)'
                    FROM Clients 
                    WHERE debt_amount > 0 
                    ORDER BY debt_amount DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement clients avec dette: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir le nombre total de clients
        public static int GetTotalClientsCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Clients";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur comptage clients: {ex.Message}", ex);
            }
        }
    }
}