using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class PaymentDao
    {
        // Méthode pour créer un paiement (utilisée dans BtnSave_Click)
        public static void CreatePayment(int orderId, decimal amount, string paymentMode)
        {
            try
            {
                // Vérifier si la commande existe
                string checkOrderQuery = "SELECT COUNT(*) FROM Orders WHERE order_id = @orderId";

                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    // Vérifier l'existence de la commande
                    var orderExists = false;
                    using (var cmd = new MySqlCommand(checkOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        orderExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                    
                    if (!orderExists)
                    {
                        throw new Exception($"La commande #{orderId} n'existe pas.");
                    }
                    
                    // Calculer le total de la commande et le montant déjà payé
                    decimal orderTotal = GetOrderTotal(orderId);
                    decimal amountPaid = GetAmountPaidForOrder(orderId);
                    decimal remainingAmount = orderTotal - amountPaid;
                    
                    // Si la commande est déjà entièrement payée
                    if (remainingAmount <= 0)
                    {
                        throw new Exception($"La commande #{orderId} est déjà entièrement payée.");
                    }
                    
                    // Si le montant à payer dépasse le montant restant
                    if (amount > remainingAmount)
                    {
                        var result = MessageBox.Show(
                            $"Le montant ({amount:N0} HTG) dépasse le montant restant à payer ({remainingAmount:N0} HTG).\n" +
                            $"Voulez-vous payer exactement le montant restant ({remainingAmount:N0} HTG)?",
                            "Montant trop élevé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.Yes)
                        {
                            amount = remainingAmount;
                        }
                        else
                        {
                            return;
                        }
                    }
                    
                    // Insérer le paiement (le trigger trg_update_client_debt gère automatiquement la dette)
                    string insertQuery = @"INSERT INTO Payments (order_id, amount, payment_mode) 
                                          VALUES (@orderId, @amount, @mode)";
                    
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@mode", paymentMode);
                        
                        cmd.ExecuteNonQuery();
                    }
                    
                    // Vérifier si la commande est maintenant entièrement payée
                    decimal newAmountPaid = GetAmountPaidForOrder(orderId);
                    if (newAmountPaid >= orderTotal)
                    {
                        // Marquer la commande comme terminée
                        OrderDao.UpdateOrderStatus(orderId, "terminee");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur création paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le total d'une commande
        public static decimal GetOrderTotal(int orderId)
        {
            try
            {
                string query = @"
                    SELECT m.unit_price * o.quantity as total
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    WHERE o.order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total commande: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir les détails d'une commande (pour affichage)
        public static Order GetOrderDetails(int orderId)
        {
            try
            {
                string query = @"
                    SELECT o.*, m.name as menu_name, m.unit_price, 
                           CONCAT(c.last_name, ' ', c.first_name) as client_name,
                           c.client_id
                    FROM Orders o
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    WHERE o.order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Order
                                {
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    MenuId = Convert.ToInt32(reader["menu_id"]),
                                    MenuName = reader["menu_name"].ToString(),
                                    ClientId = Convert.ToInt32(reader["client_id"]),
                                    ClientName = reader["client_name"].ToString(),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                                    OrderDate = Convert.ToDateTime(reader["order_date"]),
                                    Status = reader["status"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement détails commande: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode pour obtenir les détails d'un paiement
        public static Payment GetPaymentById(int paymentId)
        {
            try
            {
                string query = @"
                    SELECT p.*, o.*, m.name as menu_name, m.unit_price,
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Payments p
                    JOIN Orders o ON p.order_id = o.order_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    WHERE p.payment_id = @paymentId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@paymentId", paymentId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Payment
                                {
                                    PaymentId = Convert.ToInt32(reader["payment_id"]),
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    Amount = Convert.ToDecimal(reader["amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                    PaymentMode = reader["payment_mode"].ToString(),
                                    OrderDetails = new Order
                                    {
                                        MenuName = reader["menu_name"].ToString(),
                                        ClientName = reader["client_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiement: {ex.Message}", ex);
            }
            
            return null;
        }
        
        // Méthode pour obtenir tous les paiements d'une commande
        public static List<Payment> GetPaymentsByOrderId(int orderId)
        {
            var payments = new List<Payment>();
            
            try
            {
                string query = @"
                    SELECT p.*, o.*, m.name as menu_name, m.unit_price,
                           CONCAT(c.last_name, ' ', c.first_name) as client_name
                    FROM Payments p
                    JOIN Orders o ON p.order_id = o.order_id
                    JOIN Menus m ON o.menu_id = m.menu_id
                    JOIN Clients c ON o.client_id = c.client_id
                    WHERE p.order_id = @orderId
                    ORDER BY p.payment_date";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payments.Add(new Payment
                                {
                                    PaymentId = Convert.ToInt32(reader["payment_id"]),
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    Amount = Convert.ToDecimal(reader["amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                                    PaymentMode = reader["payment_mode"].ToString(),
                                    OrderDetails = new Order
                                    {
                                        MenuName = reader["menu_name"].ToString(),
                                        ClientName = reader["client_name"].ToString(),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["unit_price"])
                                    }
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement paiements commande: {ex.Message}", ex);
            }
            
            return payments;
        }
        
        // Méthode pour obtenir le total des paiements par jour
        public static decimal GetDailyPaymentsTotal(DateTime date)
        {
            try
            {
                string query = "SELECT COALESCE(SUM(amount), 0) FROM Payments WHERE DATE(payment_date) = @date";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total paiements: {ex.Message}", ex);
            }
        }
        
        // Méthode pour vérifier si une commande est déjà payée (entièrement)
        public static bool IsOrderFullyPaid(int orderId)
        {
            try
            {
                decimal orderTotal = GetOrderTotal(orderId);
                decimal amountPaid = GetAmountPaidForOrder(orderId);
                
                return amountPaid >= orderTotal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur vérification paiement commande: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le montant déjà payé pour une commande
        public static decimal GetAmountPaidForOrder(int orderId)
        {
            try
            {
                string query = "SELECT COALESCE(SUM(amount), 0) FROM Payments WHERE order_id = @orderId";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul montant payé: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le montant restant à payer pour une commande
        public static decimal GetRemainingAmountForOrder(int orderId)
        {
            try
            {
                decimal orderTotal = GetOrderTotal(orderId);
                decimal amountPaid = GetAmountPaidForOrder(orderId);
                
                decimal remaining = orderTotal - amountPaid;
                return remaining > 0 ? remaining : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul montant restant: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir un DataTable formaté pour l'affichage
        public static DataTable GetPaymentsDataTable(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            
            try
            {
                string query = @"
                    SELECT 
                        p.payment_id as 'ID',
                        p.order_id as 'Commande',
                        FORMAT(p.amount, 2) as 'Montant (HTG)',
                        DATE_FORMAT(p.payment_date, '%d/%m/%Y %H:%i') as 'Date',
                        p.payment_mode as 'Mode paiement'
                    FROM Payments p
                    WHERE DATE(p.payment_date) BETWEEN @fromDate AND @toDate
                    ORDER BY p.payment_date DESC";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur chargement DataTable paiements: {ex.Message}", ex);
            }
            
            return dt;
        }
        
        // Méthode pour obtenir le total des paiements sur une période
        public static decimal GetTotalPaymentsByPeriod(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) 
                    FROM Payments 
                    WHERE DATE(payment_date) BETWEEN @fromDate AND @toDate";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total paiements période: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir le total par mode de paiement
        public static decimal GetPaymentsByModeTotal(string paymentMode, DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount), 0) 
                    FROM Payments 
                    WHERE payment_mode = @mode 
                      AND DATE(payment_date) BETWEEN @fromDate AND @toDate";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mode", paymentMode);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        cmd.Parameters.AddWithValue("@toDate", toDate.Date);
                        
                        var result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur calcul total par mode paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour supprimer un paiement
        public static int DeletePayment(int paymentId)
        {
            try
            {
                string query = "DELETE FROM Payments WHERE payment_id = @id";
                
                using (var conn = Configuration.DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", paymentId);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur suppression paiement: {ex.Message}", ex);
            }
        }
        
        // Méthode pour obtenir un résumé de paiement pour une commande
        public static PaymentSummary GetPaymentSummary(int orderId)
        {
            try
            {
                decimal orderTotal = GetOrderTotal(orderId);
                decimal amountPaid = GetAmountPaidForOrder(orderId);
                decimal remaining = orderTotal - amountPaid;
                bool isFullyPaid = amountPaid >= orderTotal;
                var payments = GetPaymentsByOrderId(orderId);
                
                return new PaymentSummary
                {
                    OrderId = orderId,
                    OrderTotal = orderTotal,
                    AmountPaid = amountPaid,
                    RemainingAmount = remaining > 0 ? remaining : 0,
                    IsFullyPaid = isFullyPaid,
                    PaymentCount = payments.Count,
                    Payments = payments
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur génération résumé paiement: {ex.Message}", ex);
            }
        }
    }
}